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
    class globali
    {
        public static byte Max_Record_Engine_Start = 133;
        public static byte Start_Record;


        public static Single conv_vb_min = 0.027529f;      //conv_vb * 0.8
        public static Single conv_vb_max = 0.041293f;       // conv_vb * 1.2
        public static Single conv_vb_def = 0.034411f;



        public static Single conv_h2o = 0.0146627f;


    }
}