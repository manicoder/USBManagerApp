using Android.App;
using Android.Content;
using Android.Hardware.Usb;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;

namespace USBManagerApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            GetUsbManager();

            UsbManager manager = (UsbManager)GetSystemService(Context.UsbService);

            BroacastReceiverSystem usbReciever = new BroacastReceiverSystem();
            IntentFilter filter = new IntentFilter(UsbManager.ActionUsbDeviceAttached);
            RegisterReceiver(usbReciever, filter);
            usbReciever.usbAttached += usbAttachedSlot;
        }

        private void GetUsbManager()
        {
            UsbManager manager = (UsbManager)GetSystemService(Context.UsbService);
            var DeviceList = manager.DeviceList;
            foreach (var device in DeviceList.Values)
            {
                var Class = device.Class;
                var DeviceClass = device.DeviceClass;
                var DeviceId = device.DeviceId;
                var DeviceName = device.DeviceName;
                var DeviceProtocol = device.DeviceProtocol;
                var DeviceSubClass = device.DeviceSubclass;
                var Type = device.GetType();
                var ManufacturerName = device.ManufacturerName;
                var ProductId = device.ProductId;
                var ProductName = device.ProductName;
                var SerialNumber = device.SerialNumber;
                var VendorId = device.VendorId;
                var Version = device.Version;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void usbAttachedSlot(object sender, EventArgs e)
        {
            GetUsbManager();
        }
    }
}