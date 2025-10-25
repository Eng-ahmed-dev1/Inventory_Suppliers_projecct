# 📦 Inventory & Suppliers Management System

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-512BD4?style=for-the-badge&logo=windows&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=xaml&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)

A comprehensive **WPF Desktop Application** for managing inventory, products, and suppliers with role-based access control. Built with modern .NET technologies and Entity Framework Core for efficient data management.

---

## 🌟 Key Features

### 🔐 Authentication & Authorization
- ✅ Secure login system with role-based access
- ✅ Two user roles: **Administrator** and **Stock Clerk**
- ✅ Password-protected user accounts
- ✅ Session management with logout functionality

### 👨‍💼 Administrator Dashboard
- ✅ Full CRUD operations on products (Create, Read, Update, Delete)
- ✅ Product management with detailed information
- ✅ Real-time DataGrid with product listing
- ✅ Supplier assignment for products
- ✅ Input validation and error handling
- ✅ Interactive selection and auto-fill forms

### 📊 Stock Clerk Interface
- ✅ View complete stock inventory
- ✅ Low stock alerts and monitoring (≤10 items)
- ✅ Product shipping functionality
- ✅ Automatic stock quantity updates
- ✅ Separate views for regular and low stock items
- ✅ Real-time inventory tracking

### 🏢 Supplier Management
- ✅ Supplier database integration
- ✅ Product-supplier relationships
- ✅ Contact information management
- ✅ Foreign key associations

### 📈 Real-time Updates
- ✅ Instant DataGrid refresh after operations
- ✅ Dynamic quantity calculations
- ✅ Live stock level monitoring
- ✅ Automatic low stock detection

---

## 🛠️ Technologies & Tools

| Technology | Purpose | Version |
|-----------|---------|---------|
| **C#** | Primary programming language | Latest |
| **.NET Framework/Core** | Application framework | 6.0+ |
| **WPF (Windows Presentation Foundation)** | Desktop UI framework | - |
| **XAML** | UI markup language | - |
| **Entity Framework Core** | ORM for database operations | Latest |
| **SQL Server** | Database management system | 2019+ |
| **LINQ** | Data querying | - |
| **Visual Studio** | IDE | 2022 |

---

## 📋 System Requirements

### Prerequisites
- **Operating System:** Windows 10/11 (64-bit)
- **.NET SDK:** Version 6.0 or higher
- **SQL Server:** 2019 or higher (Express edition supported)
- **Visual Studio:** 2022 or higher (Community/Professional/Enterprise)
- **RAM:** Minimum 4GB (8GB recommended)
- **Disk Space:** 500MB for application

### Required Visual Studio Workloads
- .NET desktop development
- Data storage and processing

---

## 🚀 Installation & Setup

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/Eng-ahmed-dev1/Inventory_Suppliers_projecct.git
cd Inventory_Suppliers_projecct
```

### 2️⃣ Database Setup

1. Open **SQL Server Management Studio (SSMS)**
2. Execute the `Inventory.sql` script to create the database:

```sql
-- The script will create:
-- - InventoryDB database
-- - Users table
-- - Suppliers table
-- - Products table
-- - Sample data for testing
```

3. Update the connection string in `InventoryDB.cs`:

```csharp
optionsBuilder.UseSqlServer("Data Source=YOUR_SERVER_NAME;Initial Catalog=InventoryDB;Integrated Security=True;Trust Server Certificate=True");
```

Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g., `localhost\SQLEXPRESS`)

### 3️⃣ Install Dependencies

Open the solution in Visual Studio and restore NuGet packages:

```bash
# Via Package Manager Console
Update-Package -reinstall

# Or via .NET CLI
dotnet restore
```

### 4️⃣ Build the Project

```bash
# In Visual Studio: Build > Build Solution
# Or via .NET CLI:
dotnet build
```

### 5️⃣ Run the Application

```bash
# In Visual Studio: Press F5 or Debug > Start Debugging
# Or via .NET CLI:
dotnet run
```

---

## 📁 Project Structure

```
Inventory_Suppliers_projecct/
├── Model/
│   ├── InventoryDB.cs          # DbContext - Database connection
│   ├── Products.cs             # Product entity model
│   ├── Suppliers.cs            # Supplier entity model
│   └── Users.cs                # User entity model
├── Views/
│   ├── AdminDashBoard.xaml     # Admin UI
│   ├── AdminDashBoard.xaml.cs  # Admin logic
│   ├── StockClerk.xaml         # Stock Clerk UI
│   ├── StockClerk.xaml.cs      # Stock Clerk logic
│   ├── Login.xaml              # Login UI
│   └── Login.xaml.cs           # Login logic
├── Inventory.sql               # Database schema & seed data
└── README.md                   # Documentation
```

---

## 🎯 Usage Guide

### 🔑 Login Credentials

Default test accounts (from seed data):

| Username | Password | Role |
|----------|----------|------|
| Ahmed | pass123 | Administrator |
| belal | belal123 | Stock Clerk |
| ziad | ziad123 | Stock Clerk |

### 👨‍💼 Administrator Operations

#### Add New Product
1. Enter Product ID, Name, Description, Price, Quantity, and Supplier ID
2. Click **"Add"** button
3. Product will be added to the database and DataGrid

#### Edit Existing Product
1. Click on a product row in the DataGrid to select it
2. Modify the fields as needed
3. Click **"Edit"** button to save changes

#### Delete Product
1. Select a product from the DataGrid
2. Click **"Delete"** button
3. Confirm the deletion

### 📦 Stock Clerk Operations

#### View Inventory
- **Stock Tab:** Shows all products with quantity > 10
- **Low Stock Tab:** Shows products with quantity ≤ 10

#### Ship Products
1. Enter **Product ID** in the ProId field
2. Enter **Quantity** to ship
3. Click **"Shipping"** button
4. Stock will be automatically reduced

---

## 🗄️ Database Schema

### Users Table
```sql
UserID (INT, PK)
Name (NVARCHAR(100), NOT NULL)
Password (NVARCHAR(100), NOT NULL)
Email (NVARCHAR(100), UNIQUE, NOT NULL)
Role (NVARCHAR(50), CHECK: 'Administrator' or 'Stock Clerk')
```

### Suppliers Table
```sql
SupplierID (INT, PK)
Name (NVARCHAR(100), NOT NULL)
Phone (NVARCHAR(20))
Email (NVARCHAR(100))
```

### Products Table
```sql
ProductID (INT, PK)
Name (NVARCHAR(100), NOT NULL)
Description (NVARCHAR(MAX))
Quantity (INT, NOT NULL)
Price (DECIMAL(10, 2))
SupplierID (INT, FK -> Suppliers)
```

---

## 🔒 Security Features

- **Password Protection:** All user accounts are password protected
- **Role-Based Access Control (RBAC):** Different permissions for Admin vs Stock Clerk
- **Input Validation:** Comprehensive validation for all user inputs
- **SQL Injection Prevention:** Entity Framework parameterized queries
- **Error Handling:** Try-catch blocks with user-friendly error messages
- **Session Management:** Secure logout functionality

---

## 🎨 UI/UX Features

### Design Elements
- **Modern WPF Styling:** Custom styles for buttons, textboxes, and DataGrids
- **Color Scheme:** Professional black and gray theme
- **Responsive Layout:** Grid-based responsive design
- **DataGrid Customization:**
  - Alternating row colors for better readability
  - Bold headers with centered alignment
  - Vertical grid lines for data separation
  - Single row selection mode

### User Experience
- **Auto-fill Forms:** Click on DataGrid rows to auto-populate forms
- **Clear Feedback:** Success/error message boxes for all operations
- **Real-time Updates:** Instant DataGrid refresh after any change
- **Intuitive Navigation:** Role-based dashboard routing

---

## 🧪 Testing

### Manual Testing Checklist

#### Login Module
- [ ] Valid credentials → Success login
- [ ] Invalid username → Error message
- [ ] Invalid password → Error message
- [ ] Empty fields → Validation errors

#### Administrator Module
- [ ] Add product with valid data
- [ ] Add product with invalid data
- [ ] Edit existing product
- [ ] Delete product
- [ ] DataGrid selection auto-fill

#### Stock Clerk Module
- [ ] View stock inventory
- [ ] View low stock items
- [ ] Ship products (valid quantity)
- [ ] Ship products (exceeding quantity)
- [ ] Quantity updates correctly

---

## 📊 Sample Data

The database comes pre-populated with:
- **3 Users** (1 Admin, 2 Stock Clerks)
- **3 Suppliers** (Global Supplies Inc., TechSource Ltd., EcoGoods Co.)
- **5 Products** (Wireless Mouse, Laptop Stand, Water Bottle, USB-C Hub, Notebook)

---

## 🐛 Troubleshooting

### Common Issues

**Issue:** Connection string error
```
Solution: Update the connection string in InventoryDB.cs with your SQL Server instance name
```

**Issue:** Database not found
```
Solution: Ensure Inventory.sql script is executed successfully in SSMS
```

**Issue:** Entity Framework error
```
Solution: Install Microsoft.EntityFrameworkCore.SqlServer via NuGet Package Manager
```

**Issue:** XAML designer errors
```
Solution: Rebuild the solution (Ctrl+Shift+B)
```

---

## 🚧 Known Limitations

- Password storage is plain text (should implement hashing in production)
- No password recovery mechanism
- Limited reporting features
- No email notification system
- Single-database connection (no connection pooling optimization)

---

## 🔮 Future Enhancements

- [ ] **Password Hashing:** Implement bcrypt/SHA256 for secure password storage
- [ ] **Advanced Reporting:** PDF/Excel export functionality
- [ ] **Email Notifications:** Low stock alerts via email
- [ ] **Barcode Integration:** Barcode scanning for products
- [ ] **Multi-language Support:** Localization (English/Arabic)
- [ ] **Backup & Restore:** Automated database backup
- [ ] **Audit Trail:** Log all user activities
- [ ] **Dashboard Analytics:** Charts and graphs for inventory insights
- [ ] **Mobile App:** Cross-platform mobile companion
- [ ] **Cloud Integration:** Azure SQL Database support

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository
2. Create a new **branch** (`git checkout -b feature/AmazingFeature`)
3. **Commit** your changes (`git commit -m 'Add some AmazingFeature'`)
4. **Push** to the branch (`git push origin feature/AmazingFeature`)
5. Open a **Pull Request**

### Coding Standards
- Follow C# naming conventions
- Add XML documentation comments
- Include error handling
- Write meaningful commit messages
- Test before submitting PR

---

## 📝 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Developer

**Ahmed** - Software Engineer

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Eng-ahmed-dev1)
**Project Link:** [https://github.com/Eng-ahmed-dev1/Inventory_Suppliers_projecct](https://github.com/Eng-ahmed-dev1/Inventory_Suppliers_projecct)

---

## 🙏 Acknowledgments

- **Microsoft** for .NET Framework and Entity Framework Core
- **SQL Server** for robust database management
- **WPF Community** for UI/UX best practices
- **Stack Overflow** community for technical support

---

## 📞 Support

For questions, issues, or suggestions:

- **Open an Issue:** [GitHub Issues](https://github.com/Eng-ahmed-dev1/Inventory_Suppliers_projecct/issues)
- **Documentation:** Check the `/docs` folder for detailed guides

## ⭐ Show Your Support

If you find this project helpful, please consider giving it a ⭐ on GitHub!

---

<div align="center">

**Made with ❤️ by Ahmed**

![Visitors](https://visitor-badge.laobi.icu/badge?page_id=Eng-ahmed-dev1.Inventory_Suppliers_projecct)

</div>
