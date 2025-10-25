using Inventor_2.Model;
using Inventor_2.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventor_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbtn(object sender, RoutedEventArgs e)
        {

            try
            {
                using var db = new InventoryDB();


                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    ErrorMessageLab.Content = "Enter Valied UserName ";
                    txtUsername.Text = "";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    ErrorMessageLab.Content = "Enter Valied Password ";
                    txtPassword.Password = "";
                    return;
                }

                var user = db.users.FirstOrDefault(x => x.Name == txtUsername.Text);
                if (user == null)
                {
                    ErrorMessageLab.Content = "User Not Found !!";
                    txtUsername.Text = "";
                    txtPassword.Password = "";
                    return;
                }
                if (user?.Password != txtPassword.Password)
                {
                    ErrorMessageLab.Content = "Incorrect Password !!";
                    txtPassword.Password = "";
                    return;
                }
                if (user.Role == "Administrator")
                {
                    new AdminDashBoard().Show();
                    this.Close();
                }
                else if (user.Role == "Stock Clerk")
                {
                    new StockClerk(user.UserID).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Access Denied !!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
                return;
            }
        }
    }
}