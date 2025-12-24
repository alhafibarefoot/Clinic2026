# 📚 Clinic2026 API - Wiki Documentation

Welcome to the comprehensive documentation for the **Clinic2026 API** project. This wiki provides complete guides for developers, students, and administrators.

---

## 📖 Documentation Structure

### For Arabic Speakers (للناطقين بالعربية)

#### 🎓 [Complete Tutorial (الدليل التعليمي الشامل)](./Clinic_API_Complete_Tutorial_AR.md)
**Best for:** Students and beginners learning Minimal API from scratch

**Content:**
- 15 comprehensive chapters
- Step-by-step instructions from environment setup to deployment
- Complete code examples with detailed explanations
- Covers: GitHub, .NET CLI, Entity Framework, JWT, Swagger, and more

**Start here if you are:**
- New to Minimal API
- Learning .NET development
- Want detailed explanations

---

#### ⚡ [Quick Reference (المرجع السريع)](./Quick_Reference_AR.md)
**Best for:** Developers who need quick code snippets

**Content:**
- Git commands
- .NET CLI commands
- Entity Framework commands
- Connection strings
- Ready-to-use CRUD code
- JWT authentication setup
- Common SQL queries
- VS Code shortcuts

**Use this when:**
- You need a specific command quickly
- You want to copy-paste code
- You're looking for a quick example

---

#### 🔧 [Troubleshooting Guide (دليل حل المشاكل)](./Common_Errors_Solutions_AR.md)
**Best for:** Anyone encountering errors

**Content:**
- 21 common problems with solutions
- Database connection issues
- Entity Framework errors
- JWT authentication problems
- Performance optimization tips

**Use this when:**
- You encounter an error
- API is not working correctly
- You want to optimize performance

---

#### 📋 [Arabic Index (الفهرس العربي)](./README_AR.md)
**Best for:** Navigation and overview

**Content:**
- Overview of all documentation
- How to use the wiki
- Project structure
- Learning path (8 weeks)
- Quick start guide

---

### For English Speakers

#### 📘 [Complete Project Documentation](./Complete_Project_Documentation.md)
**Best for:** Understanding the entire project

**Content:**
- Project overview and architecture
- Technology stack
- Complete project structure
- API features (pagination, filtering, sorting, searching)
- Authentication & authorization
- Endpoints documentation
- Caching strategy
- Error handling
- Performance optimizations
- Development journey

**Use this for:**
- Comprehensive project understanding
- Architecture reference
- Production deployment
- Team onboarding

---

#### 🚀 [Quick Start Guide](./Quick_Start_Guide.md)
**Best for:** Getting started quickly

**Content:**
- Prerequisites
- Installation steps
- First-time setup
- Basic usage examples

**Use this when:**
- You want to run the project quickly
- You're new to the project
- You need minimal setup instructions

---

#### 🔍 [Technical Reference](./Technical_Reference.md)
**Best for:** Advanced developers

**Content:**
- Detailed technical specifications
- API endpoint reference
- Database schema
- Code architecture patterns
- Advanced features

---

## 🎯 Quick Navigation

### By Role

**👨‍🎓 Students:**
1. Start with [Complete Tutorial (AR)](./Clinic_API_Complete_Tutorial_AR.md)
2. Follow chapters in order
3. Use [Quick Reference (AR)](./Quick_Reference_AR.md) as needed
4. Refer to [Troubleshooting (AR)](./Common_Errors_Solutions_AR.md) when stuck

**👨‍💻 Developers:**
1. Read [Complete Project Documentation](./Complete_Project_Documentation.md)
2. Use [Quick Start Guide](./Quick_Start_Guide.md) to set up
3. Refer to [Technical Reference](./Technical_Reference.md) for details
4. Use [Quick Reference (AR)](./Quick_Reference_AR.md) for code snippets

**👨‍🏫 Teachers:**
1. Use [Complete Tutorial (AR)](./Clinic_API_Complete_Tutorial_AR.md) as curriculum
2. Each chapter = one lecture
3. Provide [Quick Reference (AR)](./Quick_Reference_AR.md) as handout
4. Share [Troubleshooting (AR)](./Common_Errors_Solutions_AR.md) with students

---

## 📁 Project Structure

```
Clinic_API/
├── Data/                    # DbContext
├── Models/                  # Entity Models (135+ entities)
├── Extensions/              # Extension Methods & Endpoints
├── Services/                # Business Logic
├── Middleware/              # Global Error Handling
├── wwwroot/                 # Static Files (Swagger customization)
├── wiki/                    # This documentation
├── Program.cs               # Application entry point
└── appsettings.json         # Configuration
```

---

## 🚀 Quick Start

```bash
# 1. Clone the repository
git clone <your-repo-url>
cd Clinic2026/Clinic_API

# 2. Restore packages
dotnet restore

# 3. Update connection string in appsettings.json

# 4. Run the project
dotnet run

# 5. Open Swagger
# https://localhost:7099/swagger
```

---

## 🛠️ Prerequisites

- ✅ [.NET 9 SDK](https://dotnet.microsoft.com/download)
- ✅ [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads)
- ✅ [Visual Studio Code](https://code.visualstudio.com) or Visual Studio 2022
- ✅ [Git](https://git-scm.com)

---

## 📦 Key Features

- ✅ **100+ API Endpoints** with full CRUD operations
- ✅ **JWT Authentication** with role-based authorization
- ✅ **Output Caching** for optimal performance
- ✅ **Pagination, Filtering, Sorting, Searching** on all GET endpoints
- ✅ **Bilingual Support** (English/Arabic)
- ✅ **Comprehensive Swagger Documentation**
- ✅ **Production-Ready** with enterprise best practices

---

## 🔗 Useful Links

### Official Documentation
- [.NET Documentation](https://learn.microsoft.com/dotnet/)
- [ASP.NET Core Minimal APIs](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)

### Tools
- [JWT.io](https://jwt.io/) - Decode JWT tokens
- [Swagger Editor](https://editor.swagger.io/) - Edit OpenAPI specs
- [Postman](https://www.postman.com/) - Test APIs

---

## 📞 Support

For questions or issues:
1. Check the [Troubleshooting Guide (AR)](./Common_Errors_Solutions_AR.md)
2. Review the appropriate documentation above
3. Check Swagger documentation at `/swagger`
4. Contact the development team

---

## 📄 Documentation Files

| File | Language | Purpose | Best For |
|------|----------|---------|----------|
| [Clinic_API_Complete_Tutorial_AR.md](./Clinic_API_Complete_Tutorial_AR.md) | 🇸🇦 Arabic | Complete tutorial (15 chapters) | Students & Beginners |
| [Quick_Reference_AR.md](./Quick_Reference_AR.md) | 🇸🇦 Arabic | Quick command reference | Developers |
| [Common_Errors_Solutions_AR.md](./Common_Errors_Solutions_AR.md) | 🇸🇦 Arabic | Troubleshooting guide | Problem solving |
| [README_AR.md](./README_AR.md) | 🇸🇦 Arabic | Arabic index & overview | Navigation |
| [Complete_Project_Documentation.md](./Complete_Project_Documentation.md) | 🇬🇧 English | Full project documentation | Comprehensive reference |
| [Quick_Start_Guide.md](./Quick_Start_Guide.md) | 🇬🇧 English | Quick setup guide | Fast start |
| [Technical_Reference.md](./Technical_Reference.md) | 🇬🇧 English | Technical details | Advanced developers |

---

**Last Updated:** December 24, 2025
**Version:** 2.0
**Status:** ✅ Production Ready

---

**Happy Coding! 🚀**
