// OOP Assignment 7: Smart Home Device Control
using System;

namespace oop_Smart_Home_Device_Control
{
    interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void ShowStatus();
    }

    class Light : IDevice
    {
        public bool IsOn { get; private set; }
        public int BrightnessLevel { get; private set; }
        public string Location { get; set; }

        public Light(string location)
        {
            Location = location;
            IsOn = false;
            BrightnessLevel = 0;
        }

        public void TurnOn()
        {
            IsOn = true;
            BrightnessLevel = 100; 
            Console.WriteLine($"Light in {Location} turned ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            BrightnessLevel = 0;
            Console.WriteLine($"Light in {Location} turned OFF.");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Light in {Location} - Status: {(IsOn ? "ON" : "OFF")}, Brightness: {BrightnessLevel}%");
        }

        public void AdjustBrightness(int level)
        {
            if (level >= 0 && level <= 100)
            {
                BrightnessLevel = level;
                if (level > 0 && !IsOn)
                {
                    IsOn = true;
                }
                else if (level == 0 && IsOn)
                {
                    IsOn = false;
                }
                Console.WriteLine($"Light in {Location} - Brightness adjusted to {BrightnessLevel}%");
            }
            else
            {
                Console.WriteLine("Error: Brightness level must be between 0 and 100.");
            }
        }
    }

    class Thermostat : IDevice
    {
        public bool IsOn { get; private set; }
        public double CurrentTemperature { get; private set; }
        public double TargetTemperature { get; private set; }
        public string Location { get; set; }

        public Thermostat(string location, double currentTemp = 22.0)
        {
            Location = location;
            IsOn = false;
            CurrentTemperature = currentTemp;
            TargetTemperature = currentTemp;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"Thermostat in {Location} turned ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"Thermostat in {Location} turned OFF.");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Thermostat in {Location} - Status: {(IsOn ? "ON" : "OFF")}, Current Temp: {CurrentTemperature}°C, Target Temp: {TargetTemperature}°C");
        }

        public void SetTemperature(double temperature)
        {
            if (temperature >= 10 && temperature <= 30)
            {
                TargetTemperature = temperature;
                if (!IsOn)
                {
                    IsOn = true;
                    Console.WriteLine($"Thermostat in {Location} automatically turned ON.");
                }
                Console.WriteLine($"Thermostat in {Location} - Target temperature set to {TargetTemperature}°C");
            }
            else
            {
                Console.WriteLine("Error: Temperature must be between 10°C and 30°C.");
            }
        }

        public void UpdateCurrentTemperature(double newTemperature)
        {
            CurrentTemperature = newTemperature;
            Console.WriteLine($"Thermostat in {Location} - Current temperature updated to {CurrentTemperature}°C");
        }
    }

    class Controller
    {
        public string Name { get; set; }

        public Controller(string name)
        {
            Name = name;
        }

        public void OperateDevice(IDevice device, bool turnOn)
        {
            Console.WriteLine($"\nController '{Name}' operating device:");
            if (turnOn)
            {
                device.TurnOn();
            }
            else
            {
                device.TurnOff();
            }
            device.ShowStatus();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Smart Home Device Control");
            Console.WriteLine("-----------------------");

            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            Thermostat bedroomThermostat = new Thermostat("Bedroom", 21.5);

            Controller homeController = new Controller("Main Controller");

            Console.WriteLine("\nDemonstrating device-specific methods:");
            livingRoomLight.AdjustBrightness(75);
            livingRoomLight.ShowStatus();

            bedroomThermostat.SetTemperature(23.5);
            bedroomThermostat.UpdateCurrentTemperature(22.0);
            bedroomThermostat.ShowStatus();

            // Demonstrate controller operating different devices through interface
            homeController.OperateDevice(livingRoomLight, false);
            homeController.OperateDevice(kitchenLight, true);
            homeController.OperateDevice(bedroomThermostat, false);

            Console.WriteLine("\nPress any key to exit:");
            Console.ReadKey();
        }
    }
}
