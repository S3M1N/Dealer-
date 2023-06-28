using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DealerApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainView = Window.GetWindow(this) as MainWindow;
            LoginView loginView = new LoginView();
            mainView.ActionView.Content = loginView;
        }

        private async void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Password;
            string email = Email.Text;
            string Salt = "";
            HttpClient client = new HttpClient();
            string baseUrl = "https://localhost:7215/api/";

            try
            {
                var requestBody = new
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    salt = Salt
                };

                var jsonRequest = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "User/CreateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registration successful!");
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
