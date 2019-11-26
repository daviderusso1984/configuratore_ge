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
    struct _Type_Allarmi_CGEW
    {
        public byte[] Raw_Data;
        // byte low
        public bool hardware
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
        public bool vcb_max
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
        public bool vcb_min
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
        public bool temperatura_alta
        {
            get
            {
                return Convert.ToBoolean(((int)Raw_Data[0] & 0x8) >> 3);
            }
            set
            {
                if ((value))
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] | 0x8);
                else
                    Raw_Data[0] = Convert.ToByte((int)Raw_Data[0] & 0xF7);
            }
        }
        public bool acqua1
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
        public bool acqua2
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
        public bool acqua3
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
        public bool volvo_penta
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
        // byte high
        public bool start_rec_max
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
        public bool start_rec_min
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
        public bool run_rec_max
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
        public bool run_rec_min
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
        public bool rec_time_max
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
        public bool start_negative_slope
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
        public bool start_positive_slope
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
        public bool run_positive_slope
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
    }
}