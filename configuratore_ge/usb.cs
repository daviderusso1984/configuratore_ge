using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Device.Net;

namespace configuratore_ge
{
    public sealed class usb : IDisposable
    {
        #region Fields
#if (LIBUSB)
        private const int PollMilliseconds = 6000;
#else
        private const int PollMilliseconds = 3000;
#endif
        //Define the types of devices to search for. This particular device can be connected to via USB, or Hid
        private readonly List<FilterDeviceDefinition> _DeviceDefinitions = new List<FilterDeviceDefinition>
        {
            new FilterDeviceDefinition{ DeviceType= DeviceType.Usb, VendorId= 0x0981, ProductId=0x0006 }          
        };
        #endregion

        #region Events
        public event EventHandler TrezorInitialized;
        public event EventHandler TrezorDisconnected;
        #endregion

        #region Public Properties
        public IDevice TrezorDevice { get; private set; }
        public DeviceListener DeviceListener { get; }
        #endregion

        #region Constructor
        public usb()
        {
            DeviceListener = new DeviceListener(_DeviceDefinitions, PollMilliseconds) { Logger = new DebugLogger() };
        }
        #endregion

        #region Event Handlers
        private void DevicePoller_DeviceInitialized(object sender, DeviceEventArgs e)
        {
            TrezorDevice = e.Device;
            TrezorInitialized?.Invoke(this, new EventArgs());
        }

        private void DevicePoller_DeviceDisconnected(object sender, DeviceEventArgs e)
        {
            TrezorDevice = null;
            TrezorDisconnected?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Public Methods
        public void StartListening()
        {
            TrezorDevice?.Close();
            DeviceListener.DeviceDisconnected += DevicePoller_DeviceDisconnected;
            DeviceListener.DeviceInitialized += DevicePoller_DeviceInitialized;
            DeviceListener.Start();
        }

        public async Task InitializeTrezorAsync()
        {
            //Get the first available device and connect to it
            var devices = await DeviceManager.Current.GetDevicesAsync(_DeviceDefinitions);
            TrezorDevice = devices.FirstOrDefault();

            if (TrezorDevice == null) throw new Exception("There were no devices found");

            await TrezorDevice.InitializeAsync();
        }

        public async Task<byte[]> WriteAndReadFromDeviceAsync(byte[] writeBuffer)
        {
            //write byte to hid
            return await TrezorDevice.WriteAndReadAsync(writeBuffer);
        }



        public void Dispose()
        {
            DeviceListener.DeviceDisconnected -= DevicePoller_DeviceDisconnected;
            DeviceListener.DeviceInitialized -= DevicePoller_DeviceInitialized;
            DeviceListener.Dispose();
            TrezorDevice?.Dispose();
        }
        #endregion
    }

}