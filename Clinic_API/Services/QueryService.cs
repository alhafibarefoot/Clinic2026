using Clinic2026_API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Clinic2026_API.Services;

/// <summary>
/// Service for applying search, filter, and sort operations to IQueryable
/// </summary>
public static class QueryService
{
    /// <summary>
    /// Apply dynamic column filtering based on query parameters
    /// </summary>
    public static IQueryable<T> ApplyFilters<T>(IQueryable<T> query, IQueryCollection queryParams)
    {
        var type = typeof(T);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var param in queryParams)
        {
            // Skip reserved keywords
            if (param.Key.Equals("search", StringComparison.OrdinalIgnoreCase) ||
                param.Key.Equals("sort", StringComparison.OrdinalIgnoreCase) ||
                param.Key.Equals("order", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var property = properties.FirstOrDefault(p => p.Name.Equals(param.Key, StringComparison.OrdinalIgnoreCase));
            if (property == null) continue;

            string? value = param.Value;
            if (string.IsNullOrWhiteSpace(value)) continue;

            var parameter = Expression.Parameter(type, "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // Convert value to property type
            object? convertedValue = null;
            try
            {
                // Handle Nullable types
                var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                convertedValue = Convert.ChangeType(value, targetType);
            }
            catch
            {
                continue; // Skip if conversion fails
            }

            var constant = Expression.Constant(convertedValue);

            // Handle Nullable comparison
            Expression left = propertyAccess;
            Expression right = Expression.Convert(constant, property.PropertyType);

            // Create equality expression: x.Property == value
            var equal = Expression.Equal(left, right);
            var lambda = Expression.Lambda<Func<T, bool>>(equal, parameter);

            query = query.Where(lambda);
        }

        return query;
    }

    /// <summary>
    /// Apply global search across all string properties
    /// </summary>
    public static IQueryable<T> ApplySearch<T>(IQueryable<T> query, string search)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.PropertyType == typeof(string));

        if (!properties.Any()) return query;

        var parameter = Expression.Parameter(typeof(T), "x");
        var searchExpression = Expression.Constant(search);
        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        Expression? predicate = null;

        foreach (var prop in properties)
        {
            var propExpression = Expression.Property(parameter, prop);

            // Handle nulls: (x.Prop != null && x.Prop.Contains(search))
            var notNull = Expression.NotEqual(propExpression, Expression.Constant(null));
            var contains = Expression.Call(propExpression, containsMethod!, searchExpression);
            var condition = Expression.AndAlso(notNull, contains);

            if (predicate == null) predicate = condition;
            else predicate = Expression.OrElse(predicate, condition);
        }

        if (predicate == null) return query;

        var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameter);
        return query.Where(lambda);
    }

    /// <summary>
    /// Apply sorting to query
    /// </summary>
    public static IQueryable<T> ApplySort<T>(IQueryable<T> query, string? sort, string? order)
    {
        var type = typeof(T);
        var propertyName = sort;

        // Default sort: First property (usually ID) if sort is null
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            var firstProp = type.GetProperties().FirstOrDefault();
            if (firstProp == null) return query;
            propertyName = firstProp.Name;
        }

        var property = type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (property == null) return query;

        var parameter = Expression.Parameter(type, "x");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter);

        string methodName = (order?.ToLower() == "desc") ? "OrderByDescending" : "OrderBy";

        var resultExpression = Expression.Call(
            typeof(Queryable),
            methodName,
            new Type[] { type, property.PropertyType },
            query.Expression,
            Expression.Quote(orderByExp));

        return query.Provider.CreateQuery<T>(resultExpression);
    }
}
