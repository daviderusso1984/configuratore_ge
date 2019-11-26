﻿using Android.Content;
using Android.Hardware.Usb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usb.Net.Android;

namespace Device.Net
{
    /// <summary>
    /// TODO: Merge this factory class with other factory classes
    /// </summary>
    public class AndroidUsbDeviceFactory : IDeviceFactory
    {
        #region Public Properties
        public UsbManager UsbManager { get; }
        public Context Context { get; }
        public ILogger Logger { get; set; }
        #endregion

        #region Public Static Properties
        public DeviceType DeviceType => DeviceType.Usb;
        #endregion

        #region Constructor
        public AndroidUsbDeviceFactory(UsbManager usbManager, Context context)
        {
            UsbManager = usbManager;
            Context = context;
        }
        #endregion

        #region Public Methods
        protected void Log(string message, Exception ex)
        {
            var callerMemberName = "";
            Logger?.Log(message, $"{ nameof(AndroidUsbDeviceFactory)} - {callerMemberName}", ex, ex != null ? LogLevel.Error : LogLevel.Information);
        }

        public Task<IEnumerable<ConnectedDeviceDefinition>> GetConnectedDeviceDefinitionsAsync(FilterDeviceDefinition deviceDefinition)
        {
            return Task.Run<IEnumerable<ConnectedDeviceDefinition>>(() =>
            {
                //TODO: Get more details about the device.
                return UsbManager.DeviceList.Select(kvp => kvp.Value).Where(d => deviceDefinition.VendorId == d.VendorId && deviceDefinition.ProductId == d.ProductId).Select(GetAndroidDeviceDefinition).ToList();
            });
        }

        public IDevice GetDevice(ConnectedDeviceDefinition deviceDefinition)
        {
            if (!int.TryParse(deviceDefinition.DeviceId, out var deviceId))
            {
                throw new Exception($"The device Id '{deviceDefinition.DeviceId}' is not a valid integer");
            }

            return new AndroidUsbDevice(UsbManager, Context, deviceId) { Logger = Logger };
        }
        #endregion

        #region Public Static Methods
        public static ConnectedDeviceDefinition GetAndroidDeviceDefinition(UsbDevice usbDevice)
        {
            var deviceId = usbDevice.DeviceId.ToString(Helpers.ParsingCulture);

            return new ConnectedDeviceDefinition(deviceId)
            {
                ProductName = usbDevice.ProductName,
                Manufacturer = usbDevice.ManufacturerName,
                SerialNumber = usbDevice.SerialNumber,
                ProductId = (uint)usbDevice.ProductId,
                VendorId = (uint)usbDevice.VendorId,
                DeviceType = DeviceType.Usb
            };
        }

        public static void Register(UsbManager usbManager, Context context)
        {
            Register(usbManager, context, null);
        }

        public static void Register(UsbManager usbManager, Context context, ILogger logger)
        {
            DeviceManager.Current.DeviceFactories.Add(new AndroidUsbDeviceFactory(usbManager, context) { Logger = logger });
        }
        #endregion
    }
}
