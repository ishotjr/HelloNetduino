using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace HelloNetduino
{
    public class Program
    {
        public static void Main()
        {

            Debug.Print("Hello World");

            // blink LED
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            // note: no glitch filtering
            InputPort button = new InputPort(Pins.ONBOARD_BTN, false, Port.ResistorMode.Disabled);
            bool buttonState = false;

            while(true)
            {
                buttonState = button.Read();

                // only blink while button is pressed
                if (buttonState)
                {
                    led.Write(true);
                    Thread.Sleep(250);
                    led.Write(false);
                    Thread.Sleep(250);
                }
            }
        }

    }
}
