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

namespace configuratore_ge
{
    class Class_alge_byte
    {
        public UInt16 Make16(byte ByteH, byte ByteL)
        {
            UInt16 tu;
            tu = (ushort)(ByteH * 256);
            tu = (ushort)(tu | ByteL);
            return (tu);
        }

        public float Bytes_to_Float(byte[] data, byte start_index)
        {
            byte[] tb = new byte[4];
            float tf;
            tb[0] = data[(int)start_index];
            tb[1] = data[(int)start_index + 1];
            tb[2] = data[(int)start_index + 2];
            tb[3] = data[(int)start_index + 3];
            tf = BitConverter.ToSingle(tb, 0);
            return (tf);
        }

        public UInt16 Bytes_to_Uint16(byte[] data, byte start_index)
        {
            byte[] tb = new byte[2];
            UInt16 tu;
            tb[1] = data[(int)start_index];
            tb[0] = data[(int)start_index + 1];
            tu = BitConverter.ToUInt16(tb, 0);
            return (tu);
        }

        public Int16 Bytes_to_Int16(byte[] data, byte start_index)
        {
            byte[] tb = new byte[2];
            Int16 ts;
            tb[1] = data[(int)start_index];
            tb[0] = data[(int)start_index + 1];
            ts = BitConverter.ToInt16(tb, 0);
            return (ts);
        }





    }
}