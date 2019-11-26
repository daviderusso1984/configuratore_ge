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
    class funzioni_robby
    {
        public string ConVirgola(string Stringa)
        {
            string ConVirgolaRet1 = "";
            // sostituisce la virgola decimale con il punto
            Int16 LungS;
            string intero;
            string decimale;
            LungS = (Int16)Stringa.IndexOf(',');
            if ((int)LungS == 0)
            {
                ConVirgolaRet1 = Stringa;
                return ConVirgolaRet1;
            }
            if ((int)LungS == 1)
            {
                decimale = Stringa.Substring(2);
                ConVirgolaRet1 = "." + decimale;
                return ConVirgolaRet1;
            }
            intero = Stringa.Substring( 1, ((int)LungS - 1));
            decimale = Stringa.Substring(((int)LungS + 1));
            ConVirgolaRet1 = intero + "." + decimale;
            return ConVirgolaRet1;
        }

    }
}