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
    struct _Type_Config_CGEW
    {
        public byte[] Raw_Data;
        public UInt16 level_acqua1
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
        public UInt16 level_acqua2
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
        public UInt16 level_acqua3
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
        public UInt16 nu1
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
        public UInt16 level_cb_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 8);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[9] = my_byte[1];
                Raw_Data[8] = my_byte[0];
            }
        }
        public UInt16 level_cb_min
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 10);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[11] = my_byte[1];
                Raw_Data[10] = my_byte[0];
            }
        }
        public UInt16 level_rec_start
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 12);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[13] = my_byte[1];
                Raw_Data[12] = my_byte[0];
            }
        }
        public UInt16 start_rec_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 14);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[15] = my_byte[1];
                Raw_Data[14] = my_byte[0];
            }
        }
        public UInt16 start_rec_min
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 16);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[17] = my_byte[1];
                Raw_Data[16] = my_byte[0];
            }
        }
        public UInt16 run_rec_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 18);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[19] = my_byte[1];
                Raw_Data[18] = my_byte[0];
            }
        }
        public UInt16 run_rec_min
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 20);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[21] = my_byte[1];
                Raw_Data[20] = my_byte[0];
            }
        }
        public UInt16 run_rec_time_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 22);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[23] = my_byte[1];
                Raw_Data[22] = my_byte[0];
            }
        }
        public UInt16 time_rec_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 24);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[25] = my_byte[1];
                Raw_Data[24] = my_byte[0];
            }
        }
        public UInt16 temperature_max
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 26);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[27] = my_byte[1];
                Raw_Data[26] = my_byte[0];
            }
        }
        public UInt16 start_negative_slope
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 28);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[29] = my_byte[1];
                Raw_Data[28] = my_byte[0];
            }
        }
        public UInt16 start_positive_slope
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 30);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[31] = my_byte[1];
                Raw_Data[30] = my_byte[0];
            }
        }
        public UInt16 run_positive_slope
        {
            get
            {
                return BitConverter.ToUInt16(Raw_Data, 32);
            }
            set
            {
                byte[] my_byte = BitConverter.GetBytes(value);
                Raw_Data[33] = my_byte[1];
                Raw_Data[32] = my_byte[0];
            }
        }
        public byte frequenza1
        {
            get
            {
                return (Raw_Data[34]);
            }
            set
            {
                Raw_Data[34] = value;
            }
        }
        public byte frequenza2
        {
            get
            {
                return (Raw_Data[35]);
            }
            set
            {
                Raw_Data[35] = value;
            }
        }
        public byte frequenza3
        {
            get
            {
                return (Raw_Data[36]);
            }
            set
            {
                Raw_Data[36] = value;
            }
        }
        public byte nu2
        {
            get
            {
                return (Raw_Data[37]);
            }
            set
            {
                Raw_Data[37] = value;
            }
        }
        public byte serial
        {
            get
            {
                return (Raw_Data[38]);
            }
            set
            {
                Raw_Data[38] = value;
            }
        }
        // campi nibble
        public byte out_acqua1
        {
            get
            {
                return (byte)(Raw_Data[39] & 0xF);                // maschero nibble high
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[39] = Convert.ToByte((int)Raw_Data[39] & 0xF0);      // azzero nibble low
                    Raw_Data[39] = (byte)(Raw_Data[39] | value);      // aggiungo il nuovo nibble
                }
            }
        }
        public byte out_acqua2
        {
            get
            {
                return (byte)((byte)(Raw_Data[39] & 0xF0) >> 4);        // maschero nibble low
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[39] = Convert.ToByte((int)Raw_Data[39] & 0xF);       // azzero nibble high
                    Raw_Data[39] = (byte)(Raw_Data[39] | (byte)(value << 4));      // aggiungo il nuovo nibble
                }
            }
        }
        public byte out_acqua3
        {
            get
            {
                return (byte)(Raw_Data[40] & 0xF);                // maschero nibble high
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[40] = Convert.ToByte((int)Raw_Data[40] & 0xF0);      // azzero nibble low
                    Raw_Data[40] = (byte)(Raw_Data[40] | value);      // aggiungo il nuovo nibble
                }
            }
        }
        public byte out_volvo_penta
        {
            get
            {
                return (byte)((byte)(Raw_Data[40] & 0xF0) >> 4);        // maschero nibble low
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[40] = Convert.ToByte((int)Raw_Data[40] & 0xF);       // azzero nibble high
                    Raw_Data[40] = (byte)((byte)Raw_Data[40] | (value << 4));      // aggiungo il nuovo nibble
                }
            }
        }
        public byte out_cb
        {
            get
            {
                return (byte)(Raw_Data[41] & 0xF);                // maschero nibble high
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[41] = Convert.ToByte((int)Raw_Data[41] & 0xF0);      // azzero nibble low
                    Raw_Data[41] = (byte)(Raw_Data[41] | value);      // aggiungo il nuovo nibble
                }
            }
        }
        public byte out_rec
        {
            get
            {
                return (byte)((byte)(Raw_Data[41] & 0xF0) >> 4);        // maschero nibble low
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[41] = Convert.ToByte((int)Raw_Data[41] & 0xF);       // azzero nibble high
                    Raw_Data[41] = (byte)(Raw_Data[41] | (value << 4));      // aggiungo il nuovo nibble
                }
            }
        }
        // campi di bit
        public bool on_acqua1
        {
            get
            {
                return Convert.ToBoolean(Raw_Data[42] & 0x1);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x1);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xFE);
            }
        }
        public bool on_acqua2
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x2) >> 1);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x2);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xFD);
            }
        }
        public bool on_acqua3
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x4) >> 2);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x4);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xFB);
            }
        }
        public bool on_volvo_penta
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x8);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xF7);
            }
        }
        public bool presenza1
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x10) >> 4);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x10);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xEF);
            }
        }
        public bool presenza2
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x20) >> 5);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x20);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xDF);
            }
        }
        public bool presenza3
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x40) >> 6);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x40);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0xBF);
            }
        }
        public bool num3
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[42] & 0x80) >> 7);
            }
            set
            {
                if ((value))
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] | 0x80);
                else
                    Raw_Data[42] = Convert.ToByte((int)Raw_Data[42] & 0x7F);
            }
        }
        // campi bit
        public bool on_cb
        {
            get
            {
                return Convert.ToBoolean(Raw_Data[43] & 0x1);
            }
            set
            {
                if ((value))
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] | 0x1);
                else
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] & 0xFE);
            }
        }
        public bool on_rec
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[43] & 0x2) >> 1);
            }
            set
            {
                if ((value))
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] | 0x2);
                else
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] & 0xFD);
            }
        }
        public bool use_custom_battery
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[43] & 0x4) >> 2);
            }
            set
            {
                if ((value))
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] | 0x4);
                else
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] & 0xFB);
            }
        }
        public bool on_temperature
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[43] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] | 0x8);
                else
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] & 0xF7);
            }
        }
        // campo nibble
        public byte out_temperature
        {
            get
            {
                return (byte)((byte)(Raw_Data[43] & 0xF0) >> 4);        // maschero nibble low
            }
            set
            {
                if (((int)value < 0x10))
                {
                    Raw_Data[43] = Convert.ToByte((int)Raw_Data[43] & 0xF);       // azzero nibble high
                    Raw_Data[43] = (byte)(Raw_Data[43] | (byte)(value << 4));      // aggiungo il nuovo nibble
                }
            }
        }
        // campo di bytes
        public byte index_battery
        {
            get
            {
                return (Raw_Data[44]);
            }
            set
            {
                Raw_Data[44] = value;
            }
        }
        // campi di bit
        public bool auto_rec3
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x1));
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x1);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xFE);
            }
        }
        public bool auto_rec5
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x2) >> 1);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x2);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xFD);
            }
        }
        public bool auto_acqua1
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x4) >> 2);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x4);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xFB);
            }
        }
        public bool auto_acqua2
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x8);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xF7);
            }
        }
        public bool auto_acqua3
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x10) >> 4);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x10);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xEF);
            }
        }
        public bool num4
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x20) >> 5);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x20);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xDF);
            }
        }
        public bool nu5
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x40) >> 6);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x40);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0xBF);
            }
        }
        public bool nu6
        {
            get
            {
                return Convert.ToBoolean((byte)(Raw_Data[45] & 0x40) >> 7);
            }
            set
            {
                if ((value))
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] | 0x80);
                else
                    Raw_Data[45] = Convert.ToByte((int)Raw_Data[45] & 0x7F);
            }
        }
    
    }
}