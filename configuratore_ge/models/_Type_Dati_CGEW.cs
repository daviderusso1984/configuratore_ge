using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace configuratore_ge.models
{
   
    struct _Type_Dati_CGEW
    {
        public byte[] Raw_Data;
        public UInt16 t_avv
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
        public UInt16 t_avv_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 2);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[3] = my_byte[1];
                Raw_Data[2] = my_byte[0];
            }
        }
        public UInt16 t_avv_min
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 4);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[5] = my_byte[1];
                Raw_Data[4] = my_byte[0];
            }
        }
        public UInt16 low_peak
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 6);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[7] = my_byte[1];
                Raw_Data[6] = my_byte[0];
            }
        }
        public byte eff_avvio
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
        public byte eff_avvio_max
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
        public byte eff_avvio_min
        {
            get
            {
                return (Raw_Data[10]);
            }
            set
            {
                Raw_Data[10] = value;
            }
        }
        public byte nu
        {
            get
            {
                return (Raw_Data[11]);
            }
            set
            {
                Raw_Data[11] = value;
            }
        }
        public byte punta_rec
        {
            get
            {
                return (Raw_Data[12]);
            }
            set
            {
                Raw_Data[12] = value;
            }
        }
        public bool over_punta_rec
        {
            get
            {
                return Convert.ToBoolean(Raw_Data[13] & 0x1);
            }
            set
            {
                if ((value))
                    Raw_Data[13] = Convert.ToByte((int)Raw_Data[13] | 0x1);
                else
                    Raw_Data[13] = Convert.ToByte((int)Raw_Data[13] & 0xFE);
            }
        }
    }

}