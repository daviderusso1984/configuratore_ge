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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct _Type_Battery
    {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 896)]
        public byte[] Raw_Data;
        public UInt16 indice;
        public float vn_max
        {
            get
            {
                return BitConverter.ToSingle(Raw_Data, ((int)indice * 28) + 0);
            }
            set
            {
                byte[] byteArray = BitConverter.GetBytes(value);
                Raw_Data[((int)indice * 52) + 0] = byteArray[0];
                Raw_Data[((int)indice * 52) + 1] = byteArray[1];
                Raw_Data[((int)indice * 52) + 2] = byteArray[2];
                Raw_Data[((int)indice * 52) + 3] = byteArray[3];
            }
        }
        public float vn_min
        {
            get
            {
                return BitConverter.ToSingle(Raw_Data, ((int)indice * 28) + 4);
            }
            set
            {
                byte[] byteArray = BitConverter.GetBytes(value);
                Raw_Data[((int)indice * 52) + 4] = byteArray[0];
                Raw_Data[((int)indice * 52) + 5] = byteArray[1];
                Raw_Data[((int)indice * 52) + 6] = byteArray[2];
                Raw_Data[((int)indice * 52) + 7] = byteArray[3];
            }
        }
        public byte nu1
        {
            get
            {
                return Convert.ToByte(Raw_Data[((int)indice * 28) + 8]);
            }
            set
            {
                Raw_Data[((int)indice * 28) + 8] = value;
            }
        }
        public byte nu2
        {
            get
            {
                return System.Convert.ToByte(Raw_Data[((int)indice * 28) + 9]);
            }
            set
            {
                Raw_Data[((int)indice * 28) + 9] = value;
            }
        }
        public byte nu3
        {
            get
            {
                return System.Convert.ToByte(Raw_Data[((int)indice * 28) + 10]);
            }
            set
            {
                Raw_Data[((int)indice * 28) + 10] = value;
            }
        }
        public byte is_valid
        {
            get
            {
                return System.Convert.ToByte(Raw_Data[((int)indice * 28) + 11]);
            }
            set
            {
                Raw_Data[((int)indice * 28) + 11] = value;
            }
        }
        public string Nome
        {
            get
            {
                return System.Text.Encoding.ASCII.GetString(Raw_Data, (((int)indice * 28) + 12), 16);
            }
            set
            {
                System.Text.Encoding.ASCII.GetBytes(value, 0, 16, Raw_Data, (((int)indice * 28) + 12));
            }
        }
    }
}