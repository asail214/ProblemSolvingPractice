//Assignment 3: Smart Home Control Center
using System;

namespace OOP_SmartHomeControlCenter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartHome home = new SmartHome();

            Console.WriteLine("Initial status:");
            home[DeviceType.Light].ShowStatus();
            home[DeviceType.Fan].ShowStatus();
            home[DeviceType.AC].ShowStatus();
            home[DeviceType.Heater].ShowStatus();

            Console.WriteLine("\nTurning on devices:");
            home[DeviceType.Light].TurnOn();
            home[DeviceType.AC].TurnOn();

            Console.WriteLine("\nUpdated status:");
            home[DeviceType.Light].ShowStatus();
            home[DeviceType.Fan].ShowStatus();
            home[DeviceType.AC].ShowStatus();
            home[DeviceType.Heater].ShowStatus();

            Console.WriteLine("\nTurning off a device:");
            home[DeviceType.AC].TurnOff();

            Console.WriteLine("\nFinal status:");
            home[DeviceType.Light].ShowStatus();
            home[DeviceType.Fan].ShowStatus();
            home[DeviceType.AC].ShowStatus();
            home[DeviceType.Heater].ShowStatus();
        }
    }

    enum DeviceType
    {
        Light,
        Fan,
        AC,
        Heater
    }

    interface ISmartDevice
    {
        void TurnOn();
        void TurnOff();
        void ShowStatus();
    }

    class Light : ISmartDevice
    {
        private bool isOn = false;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Light turned on");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Light turned off");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Light is {(isOn ? "ON" : "OFF")}");
        }
    }

    class Fan : ISmartDevice
    {
        private bool isOn = false;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Fan turned on");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Fan turned off");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Fan is {(isOn ? "ON" : "OFF")}");
        }
    }

    class AC : ISmartDevice
    {
        private bool isOn = false;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("AC turned on");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("AC turned off");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"AC is {(isOn ? "ON" : "OFF")}");
        }
    }

    class Heater : ISmartDevice
    {
        private bool isOn = false;

        public void TurnOn()
        {
            isOn = true;
            Console.WriteLine("Heater turned on");
        }

        public void TurnOff()
        {
            isOn = false;
            Console.WriteLine("Heater turned off");
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Heater is {(isOn ? "ON" : "OFF")}");
        }
    }

    class SmartHome
    {
        private Light light = new Light();
        private Fan fan = new Fan();
        private AC ac = new AC();
        private Heater heater = new Heater();

        public ISmartDevice this[DeviceType deviceType]
        {
            get
            {
                return deviceType switch
                {
                    DeviceType.Light => light,
                    DeviceType.Fan => fan,
                    DeviceType.AC => ac,
                    DeviceType.Heater => heater,
                    _ => throw new ArgumentException("Unknown device type")
                };
            }
        }
    }
}
