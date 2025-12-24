# Clinic2026 API - Quick Start Guide

## 🚀 5-Minute Quick Start

### Step 1: Run the Application
```bash
cd d:\VisualCode\Clinic2026\clinic_api
dotnet watch run
```

### Step 2: Open Swagger
Navigate to: `https://localhost:7099/swagger`

### Step 3: Login
1. Find `/api/auth/login` endpoint
2. Click "Try it out"
3. Enter credentials:
```json
{
  "userName": "your-username",
  "password": "your-password"
}
```
4. Click "Execute"
5. Copy the `token` from the response

### Step 4: Authorize
1. Click the **Authorize** button (🔒) at the top
2. Paste the token
3. Click "Authorize"
4. Click "Close"

### Step 5: Test an Endpoint
1. Find `/api/lookup/ltabbreviations` GET endpoint
2. Click "Try it out"
3. Click "Execute"
4. See your data!

---

## 📝 Common API Operations

### Get All Records (Paginated)
```http
GET /api/lookup/ltabbreviations
```

**Response:**
```json
{
  "items": [
    {
      "id": 1,
      "abbreviationCode": "ABB-0001",
      "nameEn": "Doctor",
      "nameAr": "دكتور",
      "isActive": true
    }
  ],
  "totalCount": 50,
  "page": 1,
  "pageSize": 50,
  "totalPages": 1
}
```

### Get Specific Page
```http
GET /api/lookup/ltabbreviations?page=2&pageSize=20
```

### Search
```http
GET /api/lookup/ltabbreviations?search=doctor
```

### Filter
```http
GET /api/lookup/ltabbreviations?isActive=true
```

### Sort
```http
GET /api/lookup/ltabbreviations?sort=NameEn&order=desc
```

### Combined
```http
GET /api/lookup/ltabbreviations?search=doc&isActive=true&sort=NameEn&page=1&pageSize=10
```

### Create New Record
```http
POST /api/lookup/ltabbreviations
Content-Type: application/json

{
  "nameEn": "Professor",
  "nameAr": "أستاذ",
  "isActive": true
}
```

### Update Record
```http
PUT /api/lookup/ltabbreviations/ABB-0001
Content-Type: application/json

{
  "nameEn": "Professor Updated",
  "nameAr": "أستاذ محدث",
  "isActive": true
}
```

### Delete Record
```http
DELETE /api/lookup/ltabbreviations/ABB-0001
```

---

## 🔑 Available Endpoints

### Authentication
- `POST /api/auth/login` - Login and get JWT token

### System Management
- `GET /api/system/tblroles` - List all roles
- `POST /api/system/tblroles` - Create role
- `PUT /api/system/tblroles/{code}` - Update role
- `DELETE /api/system/tblroles/{code}` - Delete role

- `GET /api/system/tblusers` - List all users
- `POST /api/system/tblusers` - Create user
- `PUT /api/system/tblusers/{userName}` - Update user
- `DELETE /api/system/tblusers/{userName}` - Delete user

- `GET /api/system/tbluserroles` - List user-role assignments
- `POST /api/system/tbluserroles` - Assign role to user
- `DELETE /api/system/tbluserroles/{code}` - Remove role assignment

### Lookup Tables (All follow same pattern)

**Address-related:**
- `/api/lookup/ltaddress1countries` - Countries
- `/api/lookup/ltaddress2governorates` - Governorates
- `/api/lookup/ltaddress3cities` - Cities
- `/api/lookup/ltaddress4areas` - Areas
- `/api/lookup/ltaddress5roads` - Roads

**Financial:**
- `/api/lookup/ltfiscalyears` - Fiscal years
- `/api/lookup/ltcurrencies` - Currencies
- `/api/lookup/ltpaymentmethods` - Payment methods
- `/api/lookup/ltaccountingdocumenttypes` - Document types

**General:**
- `/api/lookup/ltabbreviations` - Abbreviations
- `/api/lookup/ltfilescreenactions` - File screen actions

**Task Management:**
- `/api/lookup/lttask1impacts` - Task impacts
- `/api/lookup/lttask2urgencies` - Task urgencies
- `/api/lookup/lttask3priorities` - Task priorities
- `/api/lookup/lttask5rates` - Task rates

**And 90+ more lookup endpoints...**

---

## 💡 Tips & Tricks

### 1. Use Pagination for Large Datasets
```http
GET /api/lookup/ltaddress5roads?pageSize=100
```

### 2. Combine Search with Filters
```http
GET /api/lookup/ltcurrencies?search=dollar&isActive=true
```

### 3. Sort for Better UX
```http
GET /api/lookup/ltabbreviations?sort=NameEn&order=asc
```

### 4. Check Total Count
Look at `totalCount` and `totalPages` in response to know how much data exists.

### 5. Use Swagger for Testing
Swagger UI provides a great interface for testing all endpoints without writing code.

---

## ⚠️ Common Issues & Solutions

### Issue: 401 Unauthorized
**Solution:** Make sure you've clicked the Authorize button and entered your JWT token.

### Issue: Token Expired
**Solution:** Login again to get a new token. Tokens expire after 24 hours (1440 minutes).

### Issue: 404 Not Found
**Solution:** Check the endpoint URL. Make sure the entity code exists.

### Issue: 400 Bad Request
**Solution:** Check your request body. Make sure all required fields are provided.

### Issue: 500 Internal Server Error
**Solution:** Check the error message in the response. It will tell you what went wrong.

---

## 🎯 Next Steps

1. **Explore Swagger** - Try different endpoints
2. **Read Full Documentation** - See `Complete_Project_Documentation.md`
3. **Test CRUD Operations** - Create, Read, Update, Delete
4. **Try Advanced Queries** - Combine search, filter, sort, pagination
5. **Build Your Client** - Use the API in your application

---

**Happy Coding! 🚀**
