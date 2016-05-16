using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Windows.UI.Xaml.Controls;

namespace SignalRPi
{
    class LedController
    {
        private const int RED_LED_PIN = 26;
        private const int GREEN_LED_PIN = 19;
        private const int BLUE_LED_PIN = 13;
        private GpioController gpio;

        public GpioPin RedLed;
        public GpioPin GreenLed;
        public GpioPin BlueLed;

        HubConnection LedHubConnection;
        IHubProxy LedHubProxy;
        MainPage mainPage;

        public LedController(MainPage main)
        {
            mainPage = main;
            InitGPIO();
            InitHubConnection();
        }

        private void InitHubConnection()
        {
            LedHubConnection = new HubConnection("http://localhost:5005/signalr");
            LedHubProxy = LedHubConnection.CreateHubProxy("ledHub");
            LedHubProxy.On<string, string, string>("ledChangeFromServer", (red, green, blue) =>
               {
                   if (red == "on") TurnOnRed();
                   else TurnOffRed();
                   if (green == "on") TurnOnGreen();
                   else TurnOffGreen();
                   if (blue == "on") TurnOnBlue();
                   else TurnOffBlue();
               });
            LedHubConnection.Start();
        }

        private void InitGPIO()
        {
            gpio = GpioController.GetDefault();
            if (gpio == null)
            {
                RedLed = GreenLed = BlueLed = null;
                return;
            }

            RedLed = gpio.OpenPin(RED_LED_PIN);
            RedLed.SetDriveMode(GpioPinDriveMode.Output);
            RedLed.Write(GpioPinValue.Low);
            GreenLed = gpio.OpenPin(GREEN_LED_PIN);
            GreenLed.SetDriveMode(GpioPinDriveMode.Output);
            GreenLed.Write(GpioPinValue.Low);
            BlueLed = gpio.OpenPin(BLUE_LED_PIN);
            BlueLed.SetDriveMode(GpioPinDriveMode.Output);
            BlueLed.Write(GpioPinValue.Low);
        }

        public void TurnOnRed(bool notifyServer=false)
        {
            RedLed.Write(GpioPinValue.High);
            if(notifyServer)
                LedHubProxy.Invoke("RedSwitched", "on");
        }

        public void TurnOffRed(bool notifyServer = false)
        {
            RedLed.Write(GpioPinValue.Low);
            if(notifyServer)
                LedHubProxy.Invoke("RedSwitched", "off");
        }

        public void TurnOnGreen(bool notifyServer = false)
        {
            GreenLed.Write(GpioPinValue.High);
            if(notifyServer)
                LedHubProxy.Invoke("GreenSwitched", "on");
        }

        public void TurnOffGreen(bool notifyServer = false)
        {
            GreenLed.Write(GpioPinValue.Low);
            if(notifyServer)
                LedHubProxy.Invoke("GreenSwitched", "off");
        }

        public void TurnOnBlue(bool notifyServer = false)
        {
            BlueLed.Write(GpioPinValue.High);
            if(notifyServer)
                LedHubProxy.Invoke("BlueSwitched", "on");
        }

        public void TurnOffBlue(bool notifyServer = false)
        {
            BlueLed.Write(GpioPinValue.Low);
            if(notifyServer)
                LedHubProxy.Invoke("BlueSwitched", "off");
        }

        public bool isOn(GpioPin Led)
        {
            if (Led.Read() == GpioPinValue.High)
                return true;
            return false;
        }

    }
}
