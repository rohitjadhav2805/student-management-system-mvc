# 🎓 Student Management System (ASP.NET MVC)

A web-based **Student Management System** built using **ASP.NET MVC (Database First Approach)**.
This application allows users to manage student records with full CRUD functionality and image upload support.

---

## 🚀 Features

* ✅ Add New Student
* ✅ View All Students
* ✅ View Student Details
* ✅ Update Student Information
* ✅ Soft Delete (No permanent deletion)
* ✅ Upload Student Photo
* ✅ Form Validation using ModelState
* ✅ LINQ-based Data Filtering
* ✅ Clean MVC Architecture (Controller + DAL)

---

## 🛡️ Data Handling Strategy (Soft Delete)

This project uses a **Soft Delete approach**:

* Data is **not permanently deleted from the database**
* Records are marked inactive using `Status = false`
* Only active records (`Status = true`) are visible to users
* Deleted records can be restored in future if required

### 💼 Why This is Important

* Prevents accidental data loss
* Maintains historical records
* Helps in auditing and tracking
* Commonly used in real-world enterprise applications

---

## 🛠️ Tech Stack

* **Frontend:** HTML, CSS, Bootstrap
* **Backend:** ASP.NET MVC (C#)
* **Database:** SQL Server
* **ORM:** LINQ to SQL (DB First Approach)
* **IDE:** Visual Studio

---

## 🧠 Concepts Used

* MVC Architecture
* Database First Approach
* LINQ Queries
* File Upload Handling
* Model Binding
* TempData & ViewData
* Soft Delete Implementation

---

## 📂 Project Structure

MVCWithLinq1/
│
├── Controllers/
│   └── StudentController.cs
│
├── Models/
│   ├── Student.cs
│   ├── StudentDAL.cs
│   └── StudentDataContext.dbml
│
├── Views/
│   └── Student/
│
├── Uploads/
│
└── Web.config

---

## ⚙️ How to Run the Project (Local Setup)

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/your-username/your-repo-name.git
```

---

### 2️⃣ Open in Visual Studio

* Open the `.sln` file
* Restore NuGet packages (if prompted)

---

### 3️⃣ Configure Database

* Open SQL Server
* Create a database (example: `StudentDB`)
* Import your `.mdf` file OR run SQL script

---

### 4️⃣ Update Connection String

Open `Web.config` and update:

```xml
<connectionStrings>
  <add name="DataSourceConnectionString" 
       connectionString="your_sql_connection_string_here" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

### 5️⃣ Run the Application

* Press **F5** or click **Run**
* Open browser and navigate to:

```
https://localhost:xxxx/Student/DisplayStudents
```

---

## 🌐 Deployment (IIS)

### Steps to Deploy on IIS:

1. Right-click project → Publish
2. Choose Folder → Publish
3. Open IIS Manager
4. Create a new website
5. Set physical path to published folder
6. Configure Application Pool (.NET Framework version)
7. Update connection string in `Web.config`
8. Browse your application


---

## 🔮 Future Enhancements

* 🔐 Authentication (Login/Register)
* 🔍 Search & Pagination
* 📊 Dashboard
* 🌐 Web API Integration
* 📱 Responsive UI Improvements

---

## 🙋‍♂️ Author

**Rohit Jadhav**

* ASP.NET MVC Developer
* C# | SQL Server | LINQ

---

## ⭐ Support

If you like this project, give it a ⭐ on GitHub!
