using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DealerApp.Models;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;

namespace DealerApp.Views
{
    public partial class AccountView
    {
        private readonly string baseUrl;
        private HttpClient client;
        private List<Car> cars; 
        private int userId;

        public AccountView(int id)
        {
            InitializeComponent();
            baseUrl = "https://localhost:7215/api/";
            client = new HttpClient();
            cars = new List<Car>(); 
            userId = id;
            LoadCars(); 
        }
        private async void LoadCars()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(baseUrl + "User/Cars/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<Car>>(responseBody);
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
        private async void AddCar(object sender, RoutedEventArgs e)
        {
            string mark = Mark.Text;
            string model = Model.Text;
            DateTime year = Yaer.SelectedDate ?? DateTime.Now;

            var car = new
            {
                Mark = mark,
                Model = model,
                Year = year,
                UserId = userId
            };

            try
            {
                var jsonRequest = JsonConvert.SerializeObject(car);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl + "Car?UserId=" + userId, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Car added successfully!");
                    LoadCars(); // Refresh the car display grid
                }
                else
                {
                    MessageBox.Show("Failed to add car. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private async void RemoveCar(object sender, RoutedEventArgs e)
        {
            if (Car.SelectedItem is Car selectedCar)
            {
                int carId = selectedCar.Id;

                try
                {
                    HttpResponseMessage response = await client.DeleteAsync(baseUrl + "Car/" + carId);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Car removed successfully!");
                        LoadCars(); // Refresh the car display grid
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove car. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a car to remove.");
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            CarDisplayview carview = new CarDisplayview(userId);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.ActionView.Content = carview;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.ActionView.Content = loginView;
        }
    }
}
