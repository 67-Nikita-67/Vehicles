using System;
using System.Windows;
using System.Windows.Controls;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly Garage carsGarage = new("Cars Garage");
        private readonly Garage boatsGarage = new("Boats Garage");

        public MainWindow()
        {
            InitializeComponent();

            carsGarage.LogMessage += AddLog;
            boatsGarage.LogMessage += AddLog;
        }

        private void AddLog(string message)
        {
            LogTextBox.AppendText(message + Environment.NewLine);
            LogTextBox.ScrollToEnd();
        }

        private void RefreshLists()
        {
            CarsListBox.ItemsSource = null;
            CarsListBox.ItemsSource = carsGarage.GetVehicles();

            BoatsListBox.ItemsSource = null;
            BoatsListBox.ItemsSource = boatsGarage.GetVehicles();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a vehicle name.");
                return;
            }

            if (TypeComboBox.SelectedItem is not ComboBoxItem item)
                return;

            string type = item.Content.ToString() ?? "";

            Vehicle vehicle;
            Garage garage;

            switch (type)
            {
                case "Car":
                    vehicle = new Car(name);
                    garage = carsGarage;
                    break;

                case "Boat":
                    vehicle = new Boat(name);
                    garage = boatsGarage;
                    break;

                case "AmphibiousCar":
                    vehicle = new AmphibiousCar(name);
                    garage = carsGarage;
                    break;

                default:
                    return;
            }

            garage.AddVehicle(vehicle);

            RefreshLists();
            NameTextBox.Clear();
        }

        private void RemoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Vehicle car)
            {
                carsGarage.RemoveVehicle(car);
            }
            else if (BoatsListBox.SelectedItem is Vehicle boat)
            {
                boatsGarage.RemoveVehicle(boat);
            }
            else
            {
                MessageBox.Show("Please select a vehicle.");
                return;
            }

            RefreshLists();
        }

        private void MoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            Vehicle? vehicle =
                CarsListBox.SelectedItem as Vehicle ??
                BoatsListBox.SelectedItem as Vehicle;

            if (vehicle == null)
            {
                MessageBox.Show("Please select a vehicle.");
                return;
            }

            AddLog(vehicle.Move(10));
        }

        private void CarsListBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            if (CarsListBox.SelectedItem != null)
                BoatsListBox.SelectedItem = null;
        }

        private void BoatsListBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            if (BoatsListBox.SelectedItem != null)
                CarsListBox.SelectedItem = null;
        }
    }
}
