# 🏋️‍♂️ Gym Management System (GymSystem)

A comprehensive desktop application built with **C#** and **Windows Forms**, utilizing a **3-Tier Architecture** to ensure clean separation of concerns, high maintainability, and scalable software design.

---

## 📌 Features

### 🔑 Users & Authentication
- **Login Interface:** Secure authentication and role/permissions validation.
- **Remember Me Functionality:** Persists user credentials locally in the Windows Registry using Base64 encoding for seamless re-login.
- **User Management (CRUD):** Complete operations to view, create, edit, and delete system users, linked to person profiles (`PersonID`).

### 👨‍🏫 Trainers Management
- **Trainer Profiles:** View, search, and filter trainers using responsive `DataGridView` components with automatic list updates.
- **Context Menu Interaction:** Right-click context menus for quick actions like updating, deleting, or viewing detailed trainer information.
- **Custom UI Controls:** Reusable `UserControls` (such as `ctrlPersonCard` and `ctrlPersonCardWithFilter`) for modular UI presentation.

### 📝 Attendance Tracking (Trainers Attendance - *Work in Progress*)
- **Check-In / Check-Out:** Logging system for trainer attendance tracking, assigned to the active user (`CreatedByUserID`).

### 🛡️ Error Logging System
- A dedicated logger (`LoggerHelperData` / `clsLogger`) that catches and logs database exceptions locally into text files for debugging and monitoring.

---

## 🏗️ Architecture & Tech Stack

The solution is structured into **3 distinct projects**:

```text
GymSystem (Solution)
│
├── 📂 GymSystem (UI Layer - WinForms)
│   ├── Forms (FrmLogin, FrmManageTrainers, FrmManageUsers, etc.)
│   ├── Controls (ctrlPersonCard, CustomTextBox, etc.)
│   └── Global Classes (clsGlobal for Registry & Session Management)
│
├── ⚙️ GymSystem_Business (Business Logic Layer - BLL)
│   ├── clsUser.cs
│   ├── clsTrainers.cs
│   ├── clsPerson.cs
│   └── ...
│
└── 🗄️ GymSystem_DataAccess (Data Access Layer - DAL)
    ├── clsUsersData.cs
    ├── clsTrainersData.cs
    ├── clsPersonData.cs
    ├── clsDataAccessSettings.cs
    └── LoggerHelperData.cs

```

## 🏗️ Tech Stack & Prerequisites

| Category | Technology / Tool |
| :--- | :--- |
| **Language & Framework** | C# (.NET Framework / .NET Core) |
| **User Interface** | Windows Forms, Guna.UI2 Controls |
| **Database & ORM** | Microsoft SQL Server (`ADO.NET`, `SqlConnection`, `SqlCommand`, `SqlDataReader`) |
| **Local Storage** | Windows Registry (`Microsoft.Win32`) |
| **IDE / Environment** | Visual Studio 2022 (or newer) with **.NET Desktop Development** workload |

---

## 🚀 Getting Started

### 📋 Prerequisites
Before running the application, ensure you have the following installed:
- **Visual Studio 2022** (or newer) with **.NET Desktop Development** workload.
- **Microsoft SQL Server** & **SQL Server Management Studio (SSMS)**.

---

### 🛠️ Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/your-username/GymSystem.git](https://github.com/your-username/GymSystem.git)
    ```
2. **Database Setup:**
   - Open SSMS and create a new database named `GymSystemDB`.
   - Run the provided database SQL script to generate the required tables (`Users`, `People`, `Trainers`, etc.).

3. **Configure Connection String:**
   - Navigate to the `GymSystem_DataAccess` project.
   - Open `clsDataAccessSettings.cs` and update the connection string with your SQL Server details:
     ```csharp
     public static string ConnectionString = "Server=.;Database=GymSystemDB;Trusted_Connection=True;";
     ```

4. **Run the Application:**
   - Open `GymSystem.sln` in Visual Studio.
   - Press **`F5`** or click **Start** to build and run the project.
