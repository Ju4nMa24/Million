# 📦 Million API

**Million API** is a .NET 8 Web API project that uses **Entity Framework Core**, **Clean Architecture**, and **JWT-based OAuth2 authentication**. It supports model-first development with full migration support, monitoring via Watchdog, and secure access through Swagger UI.

---

## 📋 Table of Contents

- [Prerequisites](#prerequisites)
- [1. Creating a Migration](#1-creating-a-migration)
- [2. Applying the Migration](#2-applying-the-migration)
- [3. Rolling Back the Last Migration](#3-rolling-back-the-last-migration)
- [4. Checking the Migration Status](#4-checking-the-migration-status)
- [5. Updating the Database After Model Changes](#5-updating-the-database-after-model-changes)
- [6. Ensuring the DbContext is Registered](#6-ensuring-the-dbcontext-is-registered)
- [7. Accessing Watchdog](#7-accessing-watchdog)
- [8. Using OAuth2 Authentication in Swagger](#8-using-oauth2-authentication-in-swagger)

---

## Prerequisites

Ensure you have installed the required packages:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

## 1. Creating a Migration

Run the following command to create a migration:

```powershell
Add-Migration InitialCreate -Context DataBaseService
```

> Replace `InitialCreate` with your desired migration name.

---

## 2. Applying the Migration

Apply the migration using:

```powershell
Update-Database -Context DataBaseService
```

---

## 3. Rolling Back the Last Migration

To revert the last migration (only if not yet applied):

```powershell
Remove-Migration -Context DataBaseService
```

---

## 4. Checking the Migration Status

To check the migrations that have been applied:

```powershell
Get-Migrations -Context DataBaseService
```

---

## 5. Updating the Database After Model Changes

If you make changes to your models, generate a new migration and apply it:

```powershell
Add-Migration UpdateModels -Context DataBaseService
Update-Database -Context DataBaseService
```

---

## 6. Ensuring the DbContext is Registered

Make sure your `Program.cs` includes the DbContext registration:

```csharp
builder.Services.AddDbContext<DataBaseService>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));
```

---

## 7. Accessing Watchdog

To monitor your API with Watchdog:

1. Open your browser and navigate to:
   ```
   http://localhost:5000/watchdog
   ```
   > Replace `5000` with the actual port your app is running on.

2. If prompted, log in with the credentials:
   ```
   Username: admin
   Password: 123456
   ```

3. Use Watchdog to monitor:
   - Logs
   - Exceptions
   - Performance metrics

4. You can also filter and search logs to find specific issues.

---

## 8. Using OAuth2 Authentication in Swagger

Million.Api uses OAuth2 token-based authentication. Follow these steps to authenticate and use the protected endpoints via Swagger:

### Step-by-step:

1. **Register a User**

   Call the following endpoint:
   ```
   POST /register
   ```

   With a JSON body like:

   ```json
   {
     "email": "test@example.com",
     "password": "YourSecurePassword123!",
     "confirmPassword": "YourSecurePassword123!"
   }
   ```

2. **Log In to Get a Token**

   Call the login endpoint:
   ```
   POST /login
   ```

   With the body:

   ```json
   {
     "email": "test@example.com",
     "password": "YourSecurePassword123!"
   }
   ```

   This will return a JWT access token.

3. **Authorize in Swagger UI**

   - Click the `Authorize` button at the top of Swagger UI.
   - In the input field, type:
     ```
     Bearer YOUR_TOKEN_HERE
     ```
     (Replace `YOUR_TOKEN_HERE` with the token you got in step 2.)

   - Click `Authorize` and then `Close`.

4. **Use the API**

   Now all protected endpoints will be accessible through Swagger UI using your authenticated session.

---

## ✅ Done!

You're now ready to work with **Million API** using EF Core migrations, Watchdog monitoring, and secure Swagger access! 🚀
