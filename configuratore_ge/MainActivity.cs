using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Hardware.Usb;
using Device.Net;
using System;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace configuratore_ge
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.DesignDemo", MainLauncher = true )]
    public class MainActivity : AppCompatActivity
    {

        private TextView Connessione;
        private bool in_connessione;
        private bool connesso;
        
        public bool In_connessione
        {
            get
            {
                return in_connessione;
            }
            set
            {
                if (value)
                {
                    Connessione.Text = "In Connessione";
                    Connessione.SetBackgroundResource(Resource.Color.orange_400);
                    in_connessione = true;
                    connesso = false;
                }
                else
                {
                    in_connessione = false;
                    if (connesso)
                    {
                        Connessione.Text = "Connesso";
                        Connessione.SetBackgroundResource(Resource.Color.green_A400);
                    }
                    else
                    {
                        Connessione.Text = "Non Connesso";
                        Connessione.SetBackgroundResource(Resource.Color.red_400);
                    }
                }


            }
        }

        public static usb USB = new usb();
        public static bool inizializzato;

        //comandi usb
        public const byte comamdo_iniziale = 1;
        public const byte comando_lettura_configurazione = 5; //comando 5


        private models._Type_Config_CGEW Config_CGEW;
        private models._Type_Config_Display Config_Display;
        private models._Type_Dati_CGEW Dati_CGEW;
        private models._Type_Stati_CGEW Stati_CGEW;
        private models._Type_Allarmi_CGEW Allarmi_CGEW;
        private models._Type_Battery Type_Battery;

        private UInt16 Ver;
        private UInt16 ID;
        private Single k_vb;
        private UInt16 Value_Acqua1;
        private UInt16 Value_Acqua2;
        private UInt16 Value_Acqua3;
        private UInt16 Value_Acqua4;
        private UInt16 V_CB;
        private UInt16 V_24;
        private UInt16 V_12;
        private UInt16 V_33;
        private byte Digital_Input;
        private Int16 Temperature;

        private byte giorno;
        private byte mese;
        private byte anno;
        private byte ore;
        private byte minuti;
        private byte secondi;
        private UInt16 Punta_Event;


        //grafica
        private TextView TxtFirmware;
        private TextView Tx_Num_Rec;
        private TextView Tx_Num_Ev;

        private TextView TOn_Acqua1;
        private TextView F_Acqua1;
        private TextView TA_Acqua1;
        private TextView TOut_Acqua1;
        private TextView TE_Acqua1;

        private TextView TOn_Acqua2;
        private TextView F_Acqua2;
        private TextView TA_Acqua2;
        private TextView TOut_Acqua2;
        private TextView TE_Acqua2;

        private TextView TOn_Acqua3;
        private TextView F_Acqua3;
        private TextView TA_Acqua3;
        private TextView TOut_Acqua3;
        private TextView TE_Acqua3;

        private TextView Ton_Tensione;
        private TextView TOut_Tensione;
        private TextView TA_CB_Min;
        private TextView TA_CB_Max;
        private TextView T_Custom_Battery;
        private TextView TB_Type_Battery;
        private TextView TE_Tensione;


        private TextView Ton_Record;
        private TextView TOut_Record;
        private TextView TA_Soglia_Rec;
        private TextView TA_Start_Max_Rec;
        private TextView TA_Start_Min_Rec;
        private TextView TA_Run_Max_Rec;
        private TextView TA_Run_Min_Rec;
        private TextView TA_Time_Rec;
        private TextView TA_Rec_Max_T;
        private TextView TA_Start_Negative_Slope;
        private TextView TA_Start_Positive_Slope;
        private TextView TA_RUN_POsitive_Slope;
        private TextView TE_Record;




        private TextView TOn_Temperature;
        private TextView TOut_Temperature;
        private TextView TA_Temperature_Max;
        private TextView TE_Temperature;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            inizializze();



            Connessione = FindViewById<TextView>(Resource.Id.textView_connessione);
            var button_connessione = FindViewById<Button>(Resource.Id.button_connessione);
            button_connessione.Click += Button_connessione_Click;
            //grafica
            TxtFirmware = FindViewById<TextView>(Resource.Id.textView_firmware);
            Tx_Num_Rec = FindViewById<TextView>(Resource.Id.textView_tx_num_rec);
            Tx_Num_Ev = FindViewById<TextView>(Resource.Id.textView_tx_num_ev);
            TOn_Acqua1 = FindViewById<TextView>(Resource.Id.TOn_Acqua1);
            TOn_Acqua2 = FindViewById<TextView>(Resource.Id.TOn_Acqua2);
            TOn_Acqua3 = FindViewById<TextView>(Resource.Id.TOn_Acqua3);
            F_Acqua1 = FindViewById<TextView>(Resource.Id.F_Acqua1);
            F_Acqua2 = FindViewById<TextView>(Resource.Id.F_Acqua2);
            F_Acqua3 = FindViewById<TextView>(Resource.Id.F_Acqua3);
            TA_Acqua1 = FindViewById<TextView>(Resource.Id.TOn_Acqua1);
            TA_Acqua2 = FindViewById<TextView>(Resource.Id.TOn_Acqua2);
            TA_Acqua3 = FindViewById<TextView>(Resource.Id.TOn_Acqua3);
            TOut_Acqua1 = FindViewById<TextView>(Resource.Id.TOut_Acqua1);
            TOut_Acqua2 = FindViewById<TextView>(Resource.Id.TOut_Acqua2);
            TOut_Acqua3 = FindViewById<TextView>(Resource.Id.TOut_Acqua3);
            TE_Acqua1 = FindViewById<TextView>(Resource.Id.TE_Acqua1);
            TE_Acqua2 = FindViewById<TextView>(Resource.Id.TE_Acqua2);
            TE_Acqua3 = FindViewById<TextView>(Resource.Id.TE_Acqua3);

            Ton_Tensione = FindViewById<TextView>(Resource.Id.Ton_Tensione);
            TOut_Tensione = FindViewById<TextView>(Resource.Id.TOut_Tensione);
            TA_CB_Min = FindViewById<TextView>(Resource.Id.TA_CB_Min);
            TA_CB_Max = FindViewById<TextView>(Resource.Id.TA_CB_Max);
            T_Custom_Battery = FindViewById<TextView>(Resource.Id.T_Custom_Battery);
            TB_Type_Battery = FindViewById<TextView>(Resource.Id.TB_Type_Battery);
            TE_Tensione = FindViewById<TextView>(Resource.Id.TE_Tensione);

            Ton_Record = FindViewById<TextView>(Resource.Id.Ton_Record);
            TOut_Record = FindViewById<TextView>(Resource.Id.TOut_Record);
            TA_Soglia_Rec = FindViewById<TextView>(Resource.Id.TA_Soglia_Rec);
            TA_Start_Max_Rec = FindViewById<TextView>(Resource.Id.TA_Start_Max_Rec);
            TA_Start_Min_Rec = FindViewById<TextView>(Resource.Id.TA_Start_Min_Rec);
            TA_Run_Max_Rec = FindViewById<TextView>(Resource.Id.TA_Run_Max_Rec);
            TA_Run_Min_Rec = FindViewById<TextView>(Resource.Id.TA_Run_Min_Rec);
            TA_Time_Rec = FindViewById<TextView>(Resource.Id.TA_Time_Rec);
            TA_Rec_Max_T = FindViewById<TextView>(Resource.Id.TA_Rec_Max_T);
            TA_Start_Negative_Slope = FindViewById<TextView>(Resource.Id.TA_Start_Negative_Slope);
            TA_Start_Positive_Slope = FindViewById<TextView>(Resource.Id.TA_Start_Positive_Slope);
            TA_RUN_POsitive_Slope = FindViewById<TextView>(Resource.Id.TA_RUN_POsitive_Slope);
            TE_Record = FindViewById<TextView>(Resource.Id.TE_Record);

            TOn_Temperature = FindViewById<TextView>(Resource.Id.TOn_Temperature);
            TOut_Temperature = FindViewById<TextView>(Resource.Id.TOut_Temperature);
            TA_Temperature_Max = FindViewById<TextView>(Resource.Id.TA_Temperature_Max);
            TE_Temperature = FindViewById<TextView>(Resource.Id.TE_Temperature);


            In_connessione = true;
            inizializzato = false;
            //connetti usb
            connetti_usb();
            
           

        }

        private void inizializze()
        {
            Type_Battery = new models._Type_Battery();
            Type_Battery.Raw_Data = new byte[896];
            Config_Display = new models._Type_Config_Display();
            Config_Display.Raw_Data = new byte[10];
            Allarmi_CGEW = new models._Type_Allarmi_CGEW();
            Allarmi_CGEW.Raw_Data = new byte[2];
            Stati_CGEW = new models._Type_Stati_CGEW();
            Stati_CGEW.Raw_Data = new byte[4];
            Dati_CGEW = new models._Type_Dati_CGEW();
            Dati_CGEW.Raw_Data = new byte[14];
            Config_CGEW = new models._Type_Config_CGEW();
            Config_CGEW.Raw_Data = new byte[46];
  
        }

        #region "Chiamate comando"

        private bool scompatta_comando_1(byte[] leggi)
        {
            if(leggi[0] != 1)
            {
                return false;
            }
            var alge = new Class_alge_byte();
            Ver = alge.Make16(leggi[1], leggi[2]);
            ID = alge.Make16(leggi[3], leggi[4]);
            if(ID < 30)
            {
                DisplayMessage("Utilizza il Software CGE!");
                return false;
            }
            if(Ver < 258)
            {
                DisplayMessage("è richiesta la versione 2.58 o successive!");
                return false;
            }
            Dati_CGEW = new models._Type_Dati_CGEW();
            Dati_CGEW.Raw_Data = new byte[14];
            for (int i = 0; i < 14; i++)
            {
                Dati_CGEW.Raw_Data[i] = leggi[i + 45];
            }
            
            if ((Dati_CGEW.punta_rec > globali.Max_Record_Engine_Start))
            {
                Dati_CGEW.punta_rec = 0;
            }
            if (Dati_CGEW.over_punta_rec)
            {
                globali.Start_Record = Dati_CGEW.punta_rec;
                Dati_CGEW.punta_rec = globali.Max_Record_Engine_Start;
            }           
            Stati_CGEW.Raw_Data[3] = leggi[5];
            Stati_CGEW.Raw_Data[2] = leggi[6];
            Stati_CGEW.Raw_Data[1] = leggi[7];
            Stati_CGEW.Raw_Data[0] = leggi[8];
            Allarmi_CGEW.Raw_Data = new byte[2];
            Allarmi_CGEW.Raw_Data[1] = leggi[9];
            Allarmi_CGEW.Raw_Data[0] = leggi[10];
            k_vb = alge.Bytes_to_Float(leggi, 11);
            Value_Acqua1 = alge.Bytes_to_Uint16(leggi, 15);
            Value_Acqua2 = alge.Bytes_to_Uint16(leggi, 17);
            Value_Acqua3 = alge.Bytes_to_Uint16(leggi, 19);
            Value_Acqua4 = alge.Bytes_to_Uint16(leggi, 21);
            V_CB = alge.Bytes_to_Uint16(leggi, 23);
            V_33 = alge.Bytes_to_Uint16(leggi, 25);
            V_12 = alge.Bytes_to_Uint16(leggi, 27);
            V_24 = alge.Bytes_to_Uint16(leggi, 29);
            Temperature = alge.Bytes_to_Int16(leggi, 31);
            Digital_Input = leggi[33];
            giorno = leggi[34];
            mese = leggi[35];
            anno = leggi[36];
            ore = leggi[37];
            minuti = leggi[38];
            secondi = leggi[39];
            Punta_Event = alge.Bytes_to_Uint16(leggi, 43);
            if ((k_vb > globali.conv_vb_max))
            {
                DisplayMessage("La calibrazione è troppo Alta!");
                k_vb = globali.conv_vb_def;
            }
            if ((k_vb < globali.conv_vb_min))
            {
                DisplayMessage("La calibrazione è troppo Bassa!");
                k_vb = globali.conv_vb_def;
            }
            if ((float.IsInfinity(k_vb)))
            {
                DisplayMessage("La calibrazione è infinito!");
                k_vb = globali.conv_vb_def;
            }
            if ((float.IsNaN(k_vb)))
            {
                DisplayMessage("La calibrazione è numerica!");
                k_vb = globali.conv_vb_def;
            }






            return true;
        }

        private bool scompatta_comando_5(byte[] leggi)
        {
            if (leggi[0] != 5)
            {
                return false;
            }
            Config_CGEW = new models._Type_Config_CGEW();
            Config_CGEW.Raw_Data = new byte[46];
            for (int i = 1; i < 46; i++)
            {
                Config_CGEW.Raw_Data[i - 1] = leggi[i];
            }
            Config_Display = new models._Type_Config_Display();
            Config_Display.Raw_Data = new byte[9];
            for (int i = 0; i < 9; i++)
            {
                Config_Display.Raw_Data[i] = leggi[i + 47];
            }
            Config_CGEW.index_battery = leggi[56];
            //connesso
            connesso = true;
            in_connessione = false;
            return true;
        }

        #endregion

        private void popola_grafica()
        {
            var fun = new funzioni_robby();
            TxtFirmware.Text ="Firmware: " +  fun.ConVirgola(string.Format((((Single)Ver / 100)).ToString(), "##0.00"));
            Tx_Num_Rec.Text ="Record Salvati: " + Dati_CGEW.punta_rec.ToString();
            Tx_Num_Ev.Text ="Eventi Salvati: " + Punta_Event.ToString();
            if (Config_CGEW.on_acqua1)
            {
                TOn_Acqua1.Text = "Abilitato = Si";
            }
            else
            {
                TOn_Acqua1.Text = "Abilitato = NO";
            }
            if (Config_CGEW.on_acqua2)
            {
                TOn_Acqua2.Text = "Abilitato = Si";
            }
            else
            {
                TOn_Acqua2.Text = "Abilitato = NO";
            }
            if (Config_CGEW.on_acqua3)
            {
                TOn_Acqua3.Text = "Abilitato = Si";
            }
            else
            {
                TOn_Acqua3.Text = "Abilitato = NO";
            }
            if (Config_CGEW.on_cb)
            {
                Ton_Tensione.Text = "Abilitato = Si";
            }
            else
            {
                Ton_Tensione.Text = "Abilitato = NO";
            }
            if (Config_CGEW.on_rec)
            {
                Ton_Record.Text = "Abilitato = Si";
            }
            else
            {
                Ton_Record.Text = "Abilitato = NO";
            }
            if (Config_CGEW.on_temperature)
            {
                TOn_Temperature.Text = "Abilitato = Si";
            }
            else
            {
                TOn_Temperature.Text = "Abilitato = NO";
            }
            if((Config_CGEW.frequenza1 < 25) || (Config_CGEW.frequenza1 > 250))
            {
                Config_CGEW.frequenza1 = 150;
            }
            F_Acqua1.Text ="Frequenza = " + (Config_CGEW.frequenza1 * 2).ToString() + "Hz";
            if ((Config_CGEW.frequenza2 < 25) || (Config_CGEW.frequenza2 > 250))
            {
                Config_CGEW.frequenza2 = 150;
            }
            F_Acqua2.Text = "Frequenza = " + (Config_CGEW.frequenza2 * 2).ToString() + "Hz";
            if ((Config_CGEW.frequenza3 < 25) || (Config_CGEW.frequenza3 > 250))
            {
                Config_CGEW.frequenza3 = 150;
            }
            F_Acqua3.Text = "Frequenza = " + (Config_CGEW.frequenza3 * 2).ToString() + "Hz";
            TA_Acqua1.Text = "Soglia Min = " + string.Format((Config_CGEW.level_acqua1 * globali.conv_h2o).ToString(), "#0.0");
            TA_Acqua2.Text = "Soglia Min = " + string.Format((Config_CGEW.level_acqua2 * globali.conv_h2o).ToString(), "#0.0");
            TA_Acqua3.Text = "Soglia Min = " + string.Format((Config_CGEW.level_acqua3 * globali.conv_h2o).ToString(), "#0.0");
            switch (Config_CGEW.out_acqua1)
            {
                case 0:
                    TOut_Acqua1.Text ="Rele' = " + "No";
                    break;
                case 1:
                    TOut_Acqua1.Text = "Rele' = " + "1";
                    break;
                case 2:
                    TOut_Acqua1.Text = "Rele' = " + "2";
                    break;
                case 3:
                    TOut_Acqua1.Text = "Rele' = " + "3";
                    break;
                case 4:
                    TOut_Acqua1.Text = "Rele' = " + "4";
                    break;
                default:
                    TOut_Acqua1.Text = "Rele' = " + "N:" + Config_CGEW.out_acqua1.ToString();
                    break;
            }
            switch (Config_CGEW.out_acqua2)
            {
                case 0:
                    TOut_Acqua2.Text = "Rele' = " + "No";
                    break;
                case 1:
                    TOut_Acqua2.Text = "Rele' = " + "1";
                    break;
                case 2:
                    TOut_Acqua2.Text = "Rele' = " + "2";
                    break;
                case 3:
                    TOut_Acqua2.Text = "Rele' = " + "3";
                    break;
                case 4:
                    TOut_Acqua2.Text = "Rele' = " + "4";
                    break;
                default:
                    TOut_Acqua2.Text = "Rele' = " + "N:" + Config_CGEW.out_acqua2.ToString();
                    break;
            }
            switch (Config_CGEW.out_acqua3)
            {
                case 0:
                    TOut_Acqua3.Text = "Rele' = " + "No";
                    break;
                case 1:
                    TOut_Acqua3.Text = "Rele' = " + "1";
                    break;
                case 2:
                    TOut_Acqua3.Text = "Rele' = " + "2";
                    break;
                case 3:
                    TOut_Acqua3.Text = "Rele' = " + "3";
                    break;
                case 4:
                    TOut_Acqua3.Text = "Rele' = " + "4";
                    break;
                default:
                    TOut_Acqua3.Text = "Rele' = " + "N:" + Config_CGEW.out_acqua3.ToString();
                    break;
            }
            switch (Config_CGEW.out_cb)
            {
                case 0:
                    TOut_Tensione.Text = "Rele' = " + "No";
                    break;
                case 1:
                    TOut_Tensione.Text = "Rele' = " + "1";
                    break;
                case 2:
                    TOut_Tensione.Text = "Rele' = " + "2";
                    break;
                case 3:
                    TOut_Tensione.Text = "Rele' = " + "3";
                    break;
                case 4:
                    TOut_Tensione.Text = "Rele' = " + "4";
                    break;
                default:
                    TOut_Tensione.Text = "Rele' = " + "N:" + Config_CGEW.out_cb.ToString();
                    break;
            }
            switch (Config_CGEW.out_rec)
            {
                case 0:
                    TOut_Record.Text = "Rele' = " + "No";
                    break;
                case 1:
                    TOut_Record.Text = "Rele' = " + "1";
                    break;
                case 2:
                    TOut_Record.Text = "Rele' = " + "2";
                    break;
                case 3:
                    TOut_Record.Text = "Rele' = " + "3";
                    break;
                case 4:
                    TOut_Record.Text = "Rele' = " + "4";
                    break;
                default:
                    TOut_Record.Text = "Rele' = " + "N:" + Config_CGEW.out_rec.ToString();
                    break;
            }
            switch (Config_CGEW.out_temperature)
            {
                case 0:
                    TOut_Temperature.Text = "Rele' = " + "No";
                    break;
                case 1:
                    TOut_Temperature.Text = "Rele' = " + "1";
                    break;
                case 2:
                    TOut_Temperature.Text = "Rele' = " + "2";
                    break;
                case 3:
                    TOut_Temperature.Text = "Rele' = " + "3";
                    break;
                case 4:
                    TOut_Temperature.Text = "Rele' = " + "4";
                    break;
                default:
                    TOut_Temperature.Text = "Rele' = " + "N:" + Config_CGEW.out_temperature.ToString();
                    break;
            }
            TA_CB_Min.Text = "Tensione Min = " +  string.Format((Config_CGEW.level_cb_min * k_vb).ToString(), "#0.00");
            TA_CB_Max.Text = "Tensione Max = " + string.Format((Config_CGEW.level_cb_max * k_vb).ToString(), "#0.00");
            TA_Temperature_Max.Text = (Config_CGEW.temperature_max / 2).ToString();
            if (Config_CGEW.use_custom_battery)
            {
                T_Custom_Battery.Text = "Custom = " + "Si";
            }
            else
            {
                T_Custom_Battery.Text = "Custom = " + "No";
            }
            if(Config_CGEW.index_battery > 31)
            {
                Config_CGEW.index_battery = 0;
            }
            Type_Battery.indice = Config_CGEW.index_battery; //carico l indice
            TB_Type_Battery.Text ="Tipo Batteria = " + Type_Battery.Nome;
            TA_Soglia_Rec.Text = "Soglia di Avvio = " +  string.Format((Config_CGEW.level_rec_start * k_vb).ToString(), "#0.00");
            TA_Start_Max_Rec.Text = "Max Avvio: = " + string.Format((Config_CGEW.start_rec_max * k_vb).ToString(), "#0.00");
            TA_Start_Min_Rec.Text = "Min Avvio: = " + string.Format((Config_CGEW.start_rec_min * k_vb).ToString(), "#0.00");
            TA_Run_Max_Rec.Text = "Max Run = " + string.Format((Config_CGEW.run_rec_max * k_vb).ToString(), "#0.00");
            TA_Run_Min_Rec.Text = "Min Run = " + string.Format((Config_CGEW.run_rec_min * k_vb).ToString(), "#0.00");
            TA_Time_Rec.Text = string.Format((Config_CGEW.time_rec_max * 0.01).ToString(), "#0.00");
            TA_Rec_Max_T.Text = string.Format((Config_CGEW.run_rec_time_max * 0.01).ToString(), "#0.00");
            TA_Start_Negative_Slope.Text = string.Format((Config_CGEW.start_negative_slope).ToString(), "####0");
            TA_Start_Positive_Slope.Text = Config_CGEW.start_positive_slope.ToString();
            TA_RUN_POsitive_Slope.Text = Config_CGEW.run_positive_slope.ToString();
            //analizzo gli allarmi
            bool te = false;
            if(Allarmi_CGEW.vcb_max || Allarmi_CGEW.vcb_min)
            {
                TE_Tensione.Text ="Allarme = " + "Si";
            }
            else
            {
                TE_Tensione.Text = "Allarme = " + "No";
            }
            if (Allarmi_CGEW.temperatura_alta)
            {
                TE_Temperature.Text = "Allarme = " + "Si";
            }
            else
            {
                TE_Temperature.Text = "Allarme = " + "No";
            }
            if (Allarmi_CGEW.acqua1)
            {
                TE_Acqua1.Text = "Allarme = " + "Si";
            }
            else
            {
                TE_Acqua1.Text = "Allarme = " + "No";
            }
            if (Allarmi_CGEW.acqua2)
            {
                TE_Acqua2.Text = "Allarme = " + "Si";
            }
            else
            {
                TE_Acqua2.Text = "Allarme = " + "No";
            }
            if (Allarmi_CGEW.acqua3)
            {
                TE_Acqua3.Text = "Allarme = " + "Si";
            }
            else
            {
                TE_Acqua3.Text = "Allarme = " + "No";
            }
            if (Allarmi_CGEW.start_rec_max)
            {
                te = true;
            }
            if (Allarmi_CGEW.start_rec_min)
            {
                te = true;
            }
            if (Allarmi_CGEW.run_rec_max)
            {
                te = true;
            }
            if (Allarmi_CGEW.run_rec_min)
            {
                te = true;
            }
            if (Allarmi_CGEW.rec_time_max)
            {
                te = true;
            }
            if (Allarmi_CGEW.start_negative_slope)
            {
                te = true;
            }
            if (Allarmi_CGEW.start_positive_slope)
            {
                te = true;
            }
            if (Allarmi_CGEW.run_positive_slope)
            {
                te = true;
            }
            if (te)
            {
                TE_Record.Text = "Allarme = " + "Si";
            }
            else
            {
                TE_Record.Text = "Allarme = " + "No";
            }
            /*
        

     

    

    

  
  */
        }

        #region "USB"

        private void connetti_usb()
        {
            var usbManager = GetSystemService(UsbService) as UsbManager;
            if (usbManager == null) throw new Exception("UsbManager is null");
            //Register the factory for creating Usb devices. This only needs to be done once.
            AndroidUsbDeviceFactory.Register(usbManager, base.ApplicationContext);
            USB.TrezorDisconnected += USB_TrezorDisconnected;
            USB.TrezorInitialized += USB_TrezorInitialized;
            USB.StartListening();
        }

        private async void USB_TrezorInitialized(object sender, EventArgs e)
        {

            try
            {
                bool ok = true;
                byte[] scrivi = new byte[64];
                scrivi[0] = comamdo_iniziale;
                var readBuffer = await USB.WriteAndReadFromDeviceAsync(scrivi);
                
                if (readBuffer != null && readBuffer.Length > 0)
                {
                    ok = scompatta_comando_1(readBuffer);
                }
                else
                {
                    DisplayMessage($"Errore nel comando 1");
                    return;
                }
                scrivi = new byte[64];
                scrivi[0] = comando_lettura_configurazione;
                readBuffer = await USB.WriteAndReadFromDeviceAsync(scrivi);
                if (readBuffer != null && readBuffer.Length > 0)
                {
                    ok = scompatta_comando_5(readBuffer);
                }
                else
                {
                    DisplayMessage($"Errore nel comando 5");
                    return;
                }
                popola_grafica();
                
            }
            catch (Exception ex)
            {
                DisplayMessage($"No good: {ex.Message}");
            }
        }

        private void USB_TrezorDisconnected(object sender, EventArgs e)
        {
            //DisplayMessage("Device disconnected. Waiting for device...");
        }

        #endregion

        private void DisplayMessage(string message)
        {
            Toast.MakeText(this, message, ToastLength.Long).Show();
        }

        private void Button_connessione_Click(object sender, System.EventArgs e)
        {
            //connetti usb
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}