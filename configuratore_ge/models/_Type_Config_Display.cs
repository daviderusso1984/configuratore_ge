using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace configuratore_ge.models
{
    struct _Type_Config_Display
    {
        public byte[] Raw_Data;
        public UInt16 luminosita
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 0);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[1] = my_byte[1];
                Raw_Data[0] = my_byte[0];
            }
        }
        public byte contrasto
        {
            get
            {
                return (Raw_Data[2]);
            }
            set
            {
                Raw_Data[2] = value;
            }
        }
        public byte tout_led
        {
            get
            {
                return (Raw_Data[3]);
            }
            set
            {
                Raw_Data[3] = value;
            }
        }
        public byte tout_menu
        {
            get
            {
                return (Raw_Data[4]);
            }
            set
            {
                Raw_Data[4] = value;
            }
        }
        public byte tout_power
        {
            get
            {
                return (Raw_Data[5]);
            }
            set
            {
                Raw_Data[5] = value;
            }
        }
        public byte tout_rele
        {
            get
            {
                return (Raw_Data[6]);
            }
            set
            {
                Raw_Data[6] = value;
            }
        }
        public byte tout_update_display
        {
            get
            {
                return (Raw_Data[7]);
            }
            set
            {
                Raw_Data[7] = value;
            }
        }
        public byte tout_misure
        {
            get
            {
                return (Raw_Data[8]);
            }
            set
            {
                Raw_Data[8] = value;
            }
        }
        public byte tout_disp_off
        {
            get
            {
                return (Raw_Data[9]);
            }
            set
            {
                Raw_Data[9] = value;
            }
        }
    }
}