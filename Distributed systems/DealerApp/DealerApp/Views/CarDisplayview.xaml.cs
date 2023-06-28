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

namespace DealerApp.Views
{
    public partial class CarDisplayview : UserControl
    {
        private int userId;
        private readonly string baseUrl;
        private HttpClient client;
        public CarDisplayview(int id)
        {
            baseUrl = "https://localhost:7215/api/";
            client = new HttpClient();
            userId = id;
            InitializeComponent();
            LoadCars();
        }
        private async void LoadCars()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "Car");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(responseBody);
                    Car.ItemsSource = cars;
                }
                else
                {
                    MessageBox.Show("Failed to retrieve car information. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            AccountView accountview = new AccountView(userId);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.ActionView.Content = accountview;
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.ActionView.Content = loginView;
        }
    }
}
