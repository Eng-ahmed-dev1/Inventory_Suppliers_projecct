using Inventor_2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inventor_2.Views
{
    /// <summary>
    /// Interaction logic for AdminDashBoard.xaml
    /// </summary>
    public partial class AdminDashBoard : Window
    {
        public AdminDashBoard()
        {
            InitializeComponent();
            LoadProduct();
        }
        private void LoadProduct()
        {
            var db = new InventoryDB();
            try
            {
                var Products = db.products.Include(x => x.suppliers).Select(x => new
                {
                    x.ProductID,
                    x.Name,
                    x.Description,
                    x.Price,
                    x.Quantity,
                    x.SupplierID
                }).ToList();
                ProductGrid.ItemsSource = Products;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {

            try
            {

                using var db = new InventoryDB();

                if (!int.TryParse(txtProid.Text, out int proid))
                {
                    MessageBox.Show("Please Enter the Product Id as a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(NamePro.Text))
                {
                    MessageBox.Show("Please Enter the Product Name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDesc.Text))
                {
                    MessageBox.Show("Please Enter the Product Description", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!int.TryParse(supid.Text, out int SpiID))
                {
                    MessageBox.Show("Please Enter the Supplier Id as a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!decimal.TryParse(Price.Text, out decimal price))
                {
                    MessageBox.Show("Please Enter the Price as a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!int.TryParse(txtquant.Text, out int Quant))
                {
                    MessageBox.Show("Please Enter the Quantity as a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var NewPro = new Products()
                {
                    ProductID = proid,
                    Name = NamePro.Text,
                    Description = txtDesc.Text,
                    SupplierID = SpiID,
                    Price = price,
                    Quantity = Quant,
                };
                db.products.Add(NewPro);
                db.SaveChanges();
                ClearInputs();
                MessageBox.Show("Product Added Sucessfully", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new InventoryDB();
                var EdiPro = db.products.FirstOrDefault(x => x.ProductID == int.Parse(txtProid.Text));
                if (EdiPro == null)
                {
                    MessageBox.Show("The Product is Not Found", "Not Found!!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                EdiPro.ProductID = int.Parse(txtProid.Text);
                EdiPro.Name = NamePro.Text;
                EdiPro.Description = txtDesc.Text;
                EdiPro.SupplierID = int.Parse(supid.Text);
                EdiPro.Price = decimal.Parse(Price.Text);
                EdiPro.Quantity = int.Parse(txtquant.Text);
                db.SaveChanges();
                ClearInputs();
                LoadProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new InventoryDB();

                var delPro = db.products.FirstOrDefault(x => x.ProductID == int.Parse(txtProid.Text));
                if (delPro == null)
                {
                    MessageBox.Show("The Product is not found enter the correct id", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                db.products.Remove(delPro);
                db.SaveChanges();
                LoadProduct();
                MessageBox.Show("The Product Deleted Sucessfully", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


        private void TasksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductGrid.SelectedItem == null)
                return;

            dynamic SI = ProductGrid.SelectedItem;
            txtProid.Text = SI.ProductID.ToString() ?? "";
            NamePro.Text = SI.Name?.ToString() ?? "";
            txtDesc.Text = SI.Description?.ToString() ?? "";
            supid.Text = SI.SupplierID.ToString() ?? "";
            Price.Text = SI.Price.ToString() ?? "";
            txtquant.Text = SI.Quantity.ToString() ?? "";
        }
        private void ClearInputs()
        {
            txtProid.Clear();
            NamePro.Clear();
            txtDesc.Clear();
            supid.Clear();
            Price.Clear();
            txtquant.Clear();
        }
        private void Logout(object sender, RoutedEventArgs e)
        {
            new Login().Show();    // login 
            this.Close();
        }
    }
}