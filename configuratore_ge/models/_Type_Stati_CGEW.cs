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
    struct _Type_Stati_CGEW
    {

        public byte[] Raw_Data;
        // byte 0
        public bool eeprom
        {
            get
            {
                return Convert.ToBoolean((int)Raw_Data[0] & 0x1);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x1);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xFE);
            }
        }
        public bool ds1302
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x2) >> 1);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x2);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xFD);
            }
        }
        public bool v33
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x4) >> 2);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x4);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xFB);
            }
        }
        public bool v12
        {
            get
            {
                return  Convert.ToBoolean(((int)Raw_Data[0] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x8);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xF7);
            }
        }
        public bool v24
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x10) >> 4);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x10);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xEF);
            }
        }
        public bool nu1
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x20) >> 5);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x20);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xDF);
            }
        }
        public bool mcp9800
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x40) >> 6);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x40);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xBF);
            }
        }
        public bool display
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x40) >> 7);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x80);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0x7F);
            }
        }
        // byte 1
        public bool ac_power
        {
            get
            {
                return Convert.ToBoolean((int)Raw_Data[1] & 0x1);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x1);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xFE);
            }
        }
        public bool dc_power
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x2) >> 1);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x2);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xFD);
            }
        }
        public bool usb_power
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x4) >> 2);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x4);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xFB);
            }
        }
        public bool di1
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x8);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xF7);
            }
        }
        public bool di2
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x10) >> 4);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x10);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xEF);
            }
        }
        public bool nu2
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x20) >> 5);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x20);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xDF);
            }
        }
        public bool nu3
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x40) >> 6);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x40);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0xBF);
            }
        }
        public bool nu4
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[1] & 0x40) >> 7);
            }
            set
            {
                if ((value))
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] | 0x80);
                else
                    Raw_Data[1] = Convert.ToByte((int)Raw_Data[1] & 0x7F);
            }
        }
        // byte 2
        public bool run_auto_rec3
        {
            get
            {
                return Convert.ToBoolean((int)Raw_Data[2] & 0x1);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x1);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xFE);
            }
        }
        public bool run_auto_rec5
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x2) >> 1);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x2);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xFD);
            }
        }
        public bool run_auto_acqua1
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x4) >> 2);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x4);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xFB);
            }
        }
        public bool run_auto_acqua2
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x8);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xF7);
            }
        }
        public bool run_auto_acqua3
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x10) >> 4);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x10);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xEF);
            }
        }
        public bool nu5
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x20) >> 5);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x20);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xDF);
            }
        }
        public bool nu6
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x40) >> 6);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x40);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0xBF);
            }
        }
        public bool nu7
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[2] & 0x40) >> 7);
            }
            set
            {
                if ((value))
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] | 0x80);
                else
                    Raw_Data[2] = Convert.ToByte((int)Raw_Data[2] & 0x7F);
            }
        }
        public byte nu8
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
    }
}