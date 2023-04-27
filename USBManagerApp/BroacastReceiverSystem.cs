using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManagerApp
{
    public class BroacastReceiverSystem : BroadcastReceiver
    {
        public BroacastReceiverSystem() { }
        public event EventHandler usbAttached;
        public override void OnReceive(Context c, Intent i)
        {
            usbAttached(this, EventArgs.Empty);
        }
    }
}