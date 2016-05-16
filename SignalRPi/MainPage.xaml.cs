using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SignalRPi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static LedController ledController;
        public MainPage()
        {
            this.InitializeComponent();
            ledController = new LedController(this);
        }

        private void RedBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ledController.isOn(ledController.RedLed))
            {
                ledController.TurnOffRed(true);
            }
            else
            {
                ledController.TurnOnRed(true);
            }
        }

        private void GreenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ledController.isOn(ledController.GreenLed))
            {
                ledController.TurnOffGreen(true);
            }
            else
            {
                ledController.TurnOnGreen(true);
            }
        }

        private void BlueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ledController.isOn(ledController.BlueLed))
            {
                ledController.TurnOffBlue(true);
            }
            else
            {
                ledController.TurnOnBlue(true);
            }
        }
    }
}
