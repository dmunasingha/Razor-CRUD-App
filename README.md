# RazorCrudApp

A simple CRUD web application built with ASP.NET Core Razor Pages, featuring:

* User Authentication (Login / Logout)
* SQLite Database Integration
* Toast Notifications using Bootstrap
* Entity Framework Core (EF Core) with Code-First Migrations

---

## 🚀 Features

* 🧑‍💼 User Authentication with Cookie-based login/logout
* 📦 SQLite database
* 📝 CRUD operations on User Model (or any other data model)
* 💬 Bootstrap Toast Notifications
* 📄 Razor Pages + Layout + Partial Integration

---

## 🛠️ Setup Instructions

### Prerequisites

* [.NET 6 or later SDK](https://dotnet.microsoft.com/en-us/download)
* (Optional) Visual Studio 2022+ / VS Code
* SQLite Explorer (like DB Browser for SQLite)

---

### ⚙️ Getting Started

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/RazorCrudApp.git
   cd RazorCrudApp
   ```

2. **Restore Dependencies**

   ```bash
   dotnet restore
   ```

3. **Add EF Core Tools (if not already installed)**

   ```bash
   dotnet tool install --global dotnet-ef
   ```

4. **Apply Migrations and Create the Database**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run the Application**

   ```bash
   dotnet run
   ```

---

## 🥪 Usage

* Visit: `https://localhost:5001`
* Use the Login form to authenticate.
* Use navigation bar to perform CRUD actions.
* Use Toasts for visual feedback on actions.

---

## 🧹 Folder Structure

```
/Pages
  /Auth          # Login, Logout pages
  /Users         # CRUD pages for users
/Models
  User.cs        # User model
/Data
  AppDbContext.cs
```

---

## 📦 Dependencies

* ASP.NET Core Razor Pages
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.AspNetCore.Authentication.Cookies
* Bootstrap 5
* jQuery

---

## 🫯 Troubleshooting

### Issue: `no such table: Users`

Run migrations and update database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Issue: `The file is being used by another process`

Close the app or watcher, then run:

```bash
taskkill /f /im RazorCrudApp.exe
dotnet clean
dotnet build
```

---

## 📖 License

MIT License. Feel free to use and contribute!

---

## 🤝 Contributing

Pull requests are welcome. For major changes, open an issue first to discuss what you'd like to change.

---

## ✍️ Author

**Dunith Munasingha**
Sri Lanka
Software Engineer

---
