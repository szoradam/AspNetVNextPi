using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetVNextPi;
using Microsoft.AspNet.SignalR.Hubs;

namespace AspNetVNextPi.SignalRHubs
{
    [HubName("ledHub")]
    public class LedHub : Hub
    {
        public static string Red = "off";
        public static string Green = "off";
        public static string Blue = "off";

        public LedHub()
        {

        }

        public void RequestUpdate()
        {
            Clients.All.ledChangeFromServer(Red, Green, Blue);
        }

        public void RedSwitched(string state)
        {
            Red = state;
            Clients.All.ledChangeFromServer(Red,Green,Blue);
        }

        public void GreenSwitched(string state)
        {
            Green = state;
            Clients.All.ledChangeFromServer(Red, Green, Blue);
        }

        public void BlueSwitched(string state)
        {
            Blue = state;
            Clients.All.ledChangeFromServer(Red, Green, Blue);
        }
    }
}
