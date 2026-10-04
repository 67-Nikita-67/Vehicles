using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Vehicles.Core;

namespace Vehicles.WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly List<Vehicle> vehicles = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddLog(string message)
        {
            LogTextBox.AppendText(message + Environment.NewLine);
            LogTextBox.ScrollToEnd();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a vehicle name.");
                    return;
                }

                if (TypeComboBox.SelectedItem is not ComboBoxItem selectedItem)
                {
                    MessageBox.Show("Please select a vehicle type.");
                    return;
                }

                string type = selectedItem.Content.ToString() ?? "";

                Vehicle vehicle;

                switch (type)
                {
                    case "Car":
                        vehicle = new Car(name);
                        break;

                    case "Boat":
                        vehicle = new Boat(name);
                        break;

                    case "AmphibiousCar":
                        vehicle = new AmphibiousCar(name);
                        break;

                    default:
                        MessageBox.Show("Unknown vehicle type.");
                        return;
                }

                vehicles.Add(vehicle);

                VehicleListBox.Items.Add(
                    $"{vehicle.Name} ({vehicle.GetType().Name})");

                AddLog(
                    $"Added: {vehicle.Name} ({vehicle.GetType().Name})");

                NameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void MoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            int index = VehicleListBox.SelectedIndex;

            if (index < 0 || index >= vehicles.Count)
            {
                MessageBox.Show("Please select a vehicle.");
                return;
            }

            Vehicle vehicle = vehicles[index];

            string message = vehicle.Move(10);

            AddLog(message);
        }
    }
}