using Inventor_2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Inventor_2.Views
{
    /// <summary>
    /// Interaction logic for StockClerk.xaml
    /// </summary>
    public partial class StockClerk : Window
    {
        private int _CurrentStockClerk;
        public StockClerk(int currentStockClerk)
        {
            InitializeComponent();
            _CurrentStockClerk = currentStockClerk;
            LoadProductStock();
            LoadProductLowStock();
            NameLab();

        }

        private void LoadProductStock()
        {
            var db = new InventoryDB();
            try
            {
                var Products = db.products.Include(x => x.suppliers).Select(x => new
                {
                    x.ProductID,
                    x.Name,
                    x.Price,
                    x.Quantity,
                    x.SupplierID
                }).Where(x => x.Quantity > 10).ToList();
                Stock.ItemsSource = Products;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void LoadProductLowStock()
        {
            var db = new InventoryDB();
            try
            {
                var Products = db.products.Include(x => x.suppliers).Select(x => new
                {
                    x.ProductID,
                    x.Name,
                    x.Price,
                    x.Quantity,
                    x.SupplierID
                }).Where(x => x.Quantity <= 10).ToList();
                LowStock.ItemsSource = Products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void NameLab()
        {
            try
            {
                using var db = new InventoryDB();
                var User = db.users.FirstOrDefault(x => x.UserID == _CurrentStockClerk);
                if (User == null)
                {
                    MessageBox.Show("User is not found ", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                labName.Content = User.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error => {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        private void btn_Shipping(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new InventoryDB();
                if (!int.TryParse(txtquant.Text, out int quantityToShip))
                {
                    MessageBox.Show("Please enter a valid quantity to ship.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!int.TryParse(txtproid.Text, out int proid))
                {
                    MessageBox.Show("Please Enter the Product Id as a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var ProToSh = db.products.FirstOrDefault(x => x.ProductID == proid);
                if (ProToSh == null)
                {
                    MessageBox.Show("The Product is not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (ProToSh.Quantity < quantityToShip)
                {
                    MessageBox.Show("Not enough stock available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ProToSh.Quantity -= quantityToShip;
                db.SaveChanges();

                LoadProductStock();
                LoadProductLowStock();
                MessageBox.Show("Product shipped successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error => {ex.InnerException?.Message ?? ex.Message}");
            }
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            new Login().Show();    // login 
            this.Close();
        }
    }
}