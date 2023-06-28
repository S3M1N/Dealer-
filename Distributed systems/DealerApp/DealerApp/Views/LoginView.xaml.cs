using DealerApp.Models;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private readonly string baseUrl;
        public LoginView()
        {
            InitializeComponent(); 
            baseUrl = "https://localhost:7215/api/";
        }
        private async void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Password;

            HttpClient client = new HttpClient(); 

            try
            {
                var requestBody = new
                {
                    Username = username,
                    Password = password
                };

                var jsonRequest = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "User/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(responseBody);
                    AccountView accountview = new AccountView(user.Id);
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    mainWindow.ActionView.Content = accountview;
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your credentials and try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpView signupView = new SignUpView();
            MainWindow mainWindow= Window.GetWindow(this) as MainWindow;
            mainWindow.ActionView.Content = signupView;
        }
    }
}
