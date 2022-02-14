using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tischrechner
{
    public partial class Tischrechner : Form

        //zum testen
    {
        Rechnung Re = new Rechnung(); //Rechnungsklasse implementieren
        bool AnsUsed = false; //Ans genutzt?
        bool Negierung = false; //Negierung genutzt?
        string Pfad = "Data_" + DateTime.Now.ToShortDateString();

        string zwspeicher;


        public Tischrechner()
        {
            InitializeComponent();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            if(sender == Settings || sender == SettLog)
                Main.SelectedIndex = 1;
            if (sender == Logs)
                Main.SelectedIndex = 2;
        }
        private void SetZumRech_Click(object sender, EventArgs e)
        {
            Main.SelectedIndex = 0;
        }

        private void bZahlenfeld_Click(object sender, EventArgs e)
        {

            //
            //ZAHLEN
            //

            if (sender == b1)
                {
                    Re.CurDigit = Re.CurDigit + "1";
                    Re.CurInvoice = Re.CurInvoice + "1";
                Re.CurInv.AddLast("1");
                if (!EasyMd.Checked)
                    Re.CurOperator = null; //Wenn eine Zahl eingegeben wurde, kann wieder ein neuer Operator verwendet werden. (Doppelte Operatoren vermieden)
                }
            if (sender == b2)
                {
                    Re.CurDigit = Re.CurDigit + "2";
                    Re.CurInvoice = Re.CurInvoice + "2";
                Re.CurInv.AddLast("2");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b3)
                {
                    Re.CurDigit = Re.CurDigit + "3";
                    Re.CurInvoice = Re.CurInvoice + "3";
                Re.CurInv.AddLast("3");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b4)
                {
                    Re.CurDigit = Re.CurDigit + "4";
                    Re.CurInvoice = Re.CurInvoice + "4";
                Re.CurInv.AddLast("4");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b5)
                {
                    Re.CurDigit = Re.CurDigit + "5";
                    Re.CurInvoice = Re.CurInvoice + "5";
                Re.CurInv.AddLast("5");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b6)
                {
                    Re.CurDigit = Re.CurDigit + "6";
                    Re.CurInvoice = Re.CurInvoice + "6";
                Re.CurInv.AddLast("6");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b7)
                {
                    Re.CurDigit = Re.CurDigit + "7";
                    Re.CurInvoice = Re.CurInvoice + "7";
                Re.CurInv.AddLast("7");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b8)
                {
                    Re.CurDigit = Re.CurDigit + "8";
                    Re.CurInvoice = Re.CurInvoice + "8";
                Re.CurInv.AddLast("8");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b9)
                {
                    Re.CurDigit = Re.CurDigit + "9";
                    Re.CurInvoice = Re.CurInvoice + "9";
                Re.CurInv.AddLast("9");
                if (!EasyMd.Checked)
                    Re.CurOperator = null;
            }
            if (sender == b0)
                {
                    if (Re.CurDigit != "0" && Re.CurDigit != null && Re.CurDigit != "") //Wenn die aktuelle Zahl nicht 0 ist, dann kann eine weitere Null hinzugefügt werden
                    {
                        Re.CurDigit = Re.CurDigit + "0";
                        Re.CurInvoice = Re.CurInvoice + "0";
                        Re.CurInv.AddLast("0");
                        if (!EasyMd.Checked)
                            Re.CurOperator = null;
                    }
                }
            if (sender == b00)
                {
                if (Re.CurDigit != "0" && Re.CurDigit != null && Re.CurDigit != "") 
                {
                    Re.CurDigit = Re.CurDigit + "00";
                    Re.CurInvoice = Re.CurInvoice + "00";
                    Re.CurInv.AddLast("00");
                    if (!EasyMd.Checked)
                        Re.CurOperator = null;
                }
            }
            if (sender == bPunkt)
                    {
                    if(Re.CurDigit == null)
                    {
                    Re.CurDigit = Re.CurDigit + "0,";
                    Re.CurInvoice = Re.CurInvoice + "0,";
                    Re.CurInv.AddLast("0,");
                    if (!EasyMd.Checked)
                        Re.CurOperator = null;
                    }
                    else if (!Re.CurDigit.Contains(","))
                    {
                        Re.CurDigit = Re.CurDigit + ",";
                        Re.CurInvoice = Re.CurInvoice + ",";
                    Re.CurInv.AddLast(",");
                    if (!EasyMd.Checked)
                        Re.CurOperator = null;
                    }
                }

            //
            //OPERATOREN
            //

            if (sender == bPlus)
            {
                if (Re.CurOperator == null && Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                        Ergebnis2.Text = ""; Re.CurOperator = "+";
                    Re.CurInvoice = Re.CurInvoice + " + "; //Mit Leerzeichen speichern, um für die Rechnungsmethoden lesbar zu machen
                    Re.CurInv.AddLast(" + ");
                    Re.CurDigit = null;
                    AnsUsed = false; //Ans kann wieder genutzt werden, weil ein Operator verwendet wurde. (um Eingaben wie "57575757" zu vermeiden)
                    Negierung = false;
                }
                else if (Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                    {
                        Ergebnis2.Text = "";
                        Ergebnis.Text = Re.Rechnen().ToString();
                        Re.CurOperator = "+";
                        Re.CurInvoice = Re.CurInvoice + " + ";
                    }
                }
            }
            if (sender == bMinus)
            {
                if (Re.CurOperator == null && Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                        Ergebnis2.Text = "";
                    Re.CurOperator = "-";
                    Re.CurInvoice = Re.CurInvoice + " - ";
                    Re.CurInv.AddLast(" - ");
                    Re.CurDigit = null;
                    AnsUsed = false;
                    Negierung = false;
                }
                else if (Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                    {
                        Ergebnis2.Text = "";
                        Ergebnis.Text = Re.Rechnen().ToString();
                        Re.CurOperator = "-";
                        Re.CurInvoice = Re.CurInvoice + " - ";
                    }
                }
            }
            if (sender == bMal)
            {
                if (Re.CurOperator == null && Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                        Ergebnis2.Text = "";
                    Re.CurOperator = "x";
                    Re.CurInvoice = Re.CurInvoice + " x ";
                    Re.CurInv.AddLast(" x ");
                    Re.CurDigit = null;
                    AnsUsed = false;
                    Negierung = false;
                }
                else if (Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                    {
                        Ergebnis2.Text = "";
                        Ergebnis.Text = Re.Rechnen().ToString();
                        Re.CurOperator = "x";
                        Re.CurInvoice = Re.CurInvoice + " x ";
                    }
                }
            }
            if (sender == bGeteilt)
            {
                if (Re.CurOperator == null && Re.CurDigit != null)
                {
                    if (EasyMd.Checked) 
                        Ergebnis2.Text = "";
                    Re.CurOperator = "÷";
                    Re.CurInvoice = Re.CurInvoice + " ÷ ";
                    Re.CurInv.AddLast(" ÷ ");
                    Re.CurDigit = null;
                    AnsUsed = false;
                    Negierung = false;
                }
                else if (Re.CurDigit != null)
                {
                    if (EasyMd.Checked)
                    {
                        Ergebnis2.Text = "";
                        Ergebnis.Text = Re.Rechnen().ToString();
                        Re.CurOperator = "÷";
                        Re.CurInvoice = Re.CurInvoice + " ÷ ";
                    }
                }
            }

            //
            //EXTRATASTEN
            //

            if(sender == bAns)
            {
                if (Re.AnsWert != null && AnsUsed == false) //wenn Ans nicht null ist und Die Ans noch nicht in dieser Zahl genutzt wurde
                {
                    Clear();
                    Re.CurDigit = Re.CurDigit + Re.AnsWert; //Ans wird einfach dran gehangen.
                    Re.CurInvoice = Re.CurInvoice + Re.AnsWert;
                    Re.CurInv.AddLast(Re.AnsWert);
                    AnsUsed = true;
                    if (!EasyMd.Checked)
                        Re.CurOperator = null;
                }
            }
            if(sender == bProz)
            { //im Grunde das selbe wie jeder anderer Operator
                if (Re.CurOperator == null && Re.CurDigit != null)
                {
                    Re.CurInvoice = Re.CurInvoice + " % ";
                    Re.CurInv.AddLast(" % ");
                    Re.CurDigit = null;
                    AnsUsed = false;
                    Negierung = false;
                }
            }
            if(sender == bNeg)
            {
                try
                {
                    if (Re.CurInv.Last() != " + " && Re.CurInv.Last() !=  " - " && Re.CurInv.Last() != " x " && Re.CurInv.Last() != " ÷ " && Re.CurInv.Last() != " % ")
                    {
                        if (!Negierung) //wenn Negation nicht angewandt ist, dann mach ein - vor die Zahl
                        {
                            Re.CurDigit = "-" + Re.CurDigit;
                            zwspeicher = "-" + Re.CurInv.Last();
                            Re.CurInv.RemoveLast();
                            Re.CurInv.AddLast(zwspeicher);
                            Negierung = true;
                        }
                        else if (Negierung) //andernfalls mach das - weg
                        {
                            Re.CurDigit = Re.CurDigit.Remove(0, 1);
                            zwspeicher = Re.CurInv.Last().Remove(0, 1);
                            Re.CurInv.RemoveLast();
                            Re.CurInv.AddLast(zwspeicher);
                            Negierung = false;
                        }
                    }
                }
                catch { }
            }

            if (sender == bBack)
            {
                if(Re.CurInv.Count()!=0)
                    Re.CurInv.RemoveLast();
                //letztes Item aus Liste entfernen, wenn da überhaupt noch was drin ist

            }
            if (sender == bCA)
            {
                Clear();
            }
            if (sender == bC)
            {
                ClearLast();
            }
            AnzeigeRefresh();
            if (sender == bErg)
            {
                if (EasyMd.Checked)
                {
                    Re.Rechnen(); //wenn EasyMode an ist, dann EasyMethode
                    Ergebnis2.Text = Re.CurShow;
                }
                else
                if (!PvS.Checked)
                {
                    Ergebnis2.Text = Re.OhnePvS(Re.CurInvoice); 
                    Re.SaveData.AddLast(Re.CurInvoice + " = " + Ergebnis2.Text);
                    if (AutoSaveBox.Checked && Ergebnis2.Text != "" && Ergebnis2.Text != null)
                    {
                        Speichern();
                        Rechnungen.Items.Add(Re.CurInvoice + " = " + Ergebnis2.Text);
                    }
                    Re.CurInvoice = null;
                    Re.CurInv.Clear();
                    Re.CurDigit = null;

                }
                else if(PvS.Checked)
                {
                    Ergebnis2.Text = Re.PvS(Re.CurInvoice);
                    Re.SaveData.AddLast(Re.CurInvoice + " = " + Ergebnis2.Text);
                    if (AutoSaveBox.Checked && Ergebnis2.Text != "" && Ergebnis2.Text != null)
                    {
                        Speichern();
                        Rechnungen.Items.Add(Re.CurInvoice + " = " + Ergebnis2.Text);
                    }
                    Re.CurInvoice = null;
                    Re.CurInv.Clear();
                    Re.CurDigit = null;
                }

                

            }
        }


        //
        //KLEINIGKEITEN (Spielereien für Einstellungen und so)
        //

        private void Tischrechner_Load(object sender, EventArgs e)
        {
            Clear();
            Laden();
            PfadTextBox.Text = Pfad;
            sourcelbl.Text = "Quelle: " + Pfad;
        }
        private void EasyMd_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
            if (EasyMd.Checked)
            {
                PvS.Enabled = false;
                PvS.Checked = false;
                bBack.Visible = false;
                bAns.Visible = false;
                bProz.Visible = false;
                bNeg.Visible = false;
                

                CurMode.Text = "Einfacher Modus";
            }else if (!EasyMd.Checked)
            {
                PvS.Enabled = true;
                bBack.Visible = true;
                bAns.Visible = true;
                bProz.Visible = true;
                bNeg.Visible = true;
                EasyMdError.Visible = false;

                CurMode.Text = "Erweiterter Modus: Ohne Punkt vor Strich";
            }
        }
        private void PvS_CheckedChanged(object sender, EventArgs e)
        {
            Clear();

            if (PvS.Checked)
                CurMode.Text = "Erweiterter Modus: Mit Punkt vor Strich";
            if (!PvS.Checked)
                CurMode.Text = "Erweiterter Modus: Ohne Punkt vor Strich";
        }
        private void Rechnungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Rechnungen.SelectedItem != null && !EasyMd.Checked)
                bLoadInv.Visible = true;
            else if (Rechnungen.SelectedItem == null && !EasyMd.Checked)
                bLoadInv.Visible = false;
            if (EasyMd.Checked)
                EasyMdError.Visible = true;
            else
                EasyMdError.Visible = false;
        }
        private void bLoadInv_Click(object sender, EventArgs e)
        {
            string[] Load = Convert.ToString(Rechnungen.SelectedItem).Split(' ');
            Re.CurInv.Clear();
            Re.CurInvoice = "";

            foreach (string s in Load)
            {
                if (s == "=") //Bei = ist die Rechnung zu ende. Also raus aus der Foreach
                    break;
                Re.CurInv.AddLast(s + " "); //Rechnung übernehmen aus Array
                Re.CurInvoice = Re.CurInvoice + s + " ";
                Re.CurDigit = s;
            }
            AnzeigeRefresh();
            
        }
        private void DarkModeBox_CheckedChanged(object sender, EventArgs e)
        {
            //Würde für alle Elemente jetzt zu lange dauern 
            if (DarkModeBox.Checked)
            {
                SettingsPage.BackColor = Color.FromArgb(42, 42, 46);
            }
            else
            {
                SettingsPage.BackColor = Color.FromArgb(255, 255, 255);
            }
        }
        private void AdminClick_Click(object sender, EventArgs e)
        {
            Main.SelectedIndex = 3;
        }

        //
        //METHODEN
        //

        private void AnzeigeRefresh()
        {
            if (!EasyMd.Checked) //Bei Erweitertem Modus
            {

                //Alle Werte auf Null
                Re.CurShow = "";
                Re.CurShow2 = "";
                Re.CurInvoice = "";

                foreach (string s in Re.CurInv) //Rechnung wird aus dem RechnungsArray errechnet.
                {
                    Re.CurInvoice = Re.CurInvoice + s;

                    //Zeilensystem (nicht optimal)
                    if (Re.CurShow.Length <= 22)
                        Re.CurShow = Re.CurShow + s;
                    if (Re.CurShow.Length >= 23)
                        Re.CurShow2 = Re.CurShow2 + s;
                }
                Ergebnis.Text = Re.CurShow;
                Ergebnis2.Text = Re.CurShow2;
            }
            else
                Ergebnis.Text = Re.CurInvoice; //Beim EasyMode ist die Anzeige einfach die aktuelle Rechnung.
        }
        private void Clear()
        {
            //alles clearen halt
            Re.CurDigit = null;
            Re.CurInvoice = null;
            Re.CurShow = null;
            Re.CurInv.Clear();
            Re.CurOperator = null;
            Re.CurShow2 = null;
            Re.WhInvoice = null;
            Ergebnis2.Text = "";
            AnsUsed = false;


            AnzeigeRefresh();
        }
        private void ClearLast()
        {
            if (EasyMd.Checked) //geht nur beim EasyMode
            {

                try
                {
                    string[] Array = Re.CurInvoice.Split(' ');
                    Clear();
                    if (Array[2] == "")
                        Array[1] = "";
                    if (Array[2] != "")
                        Array[2] = "";


                    Re.CurInvoice = "";
                    foreach (string s in Array)
                    {
                        if (s != "")
                            Re.CurInvoice = Re.CurInvoice + s + " ";
                    }
                }
                catch { }
                AnzeigeRefresh();
            }
        }
        public void Speichern()
        {
            if (File.Exists(@"" + Pfad + ".csv")) //Wenn die File schon existiert, dann
                File.WriteAllLines(@"" + Pfad + ".csv", Re.SaveData); //SaveData Liste einschreiben
        }
        public void Laden()
        {
            if (File.Exists(@"" + Pfad + ".csv"))
            {
                Re.SaveData.Clear();
                foreach (string s in File.ReadAllLines(@"" + Pfad + ".csv")) //Alles lesen
                {
                    //In SaveData Liste und in Verlauf Anzeige alle Items adden
                    Re.SaveData.AddLast(s);
                    Rechnungen.Items.Add(s);

                    if (s == "+" || s == "-" || s == "x" || s == "÷" || s == "%")
                        //Aktuellen Operator aktualisieren
                        Re.CurOperator = s;

                }
            }
            else
                File.Create(@"" + Pfad + ".csv"); //Wenn Datei nicht existiert, dann erstell die
            //Pfad: Data_[Aktuelles Datum].csv
        }
        private void PfadTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(@"" + PfadTextBox.Text + ".csv"))
            {
                if (Pfad == PfadTextBox.Text)
                    Pfad = PfadTextBox.Text;
                FehlerLbl.Text = "";
                pathCreate.Visible = false;
                sourcelbl.Text = "Quelle: " + Pfad;
                Rechnungen.Items.Clear();
                Re.SaveData.Clear();
                foreach (string s in File.ReadAllLines(@"" + PfadTextBox.Text + ".csv")) //Alles lesen
                {
                    //In SaveData Liste und in Verlauf Anzeige alle Items adden
                    Re.SaveData.AddLast(s);
                    Rechnungen.Items.Add(s);

                    if (s == "+" || s == "-" || s == "x" || s == "÷" || s == "%")
                        //Aktuellen Operator aktualisieren
                        Re.CurOperator = s;

                }
            }
            else
            {
                FehlerLbl.Text = "Der Pfad existiert nicht.";
                pathCreate.Visible = true;
            }

        }
        private void pathCreate_Click(object sender, EventArgs e)
        {
            if(!File.Exists(@"" + PfadTextBox.Text + ".csv") && PfadTextBox.Text != "")
            {
                File.Create(@"" + PfadTextBox.Text + ".csv");
                Pfad = PfadTextBox.Text;
                FehlerLbl.Text = "";
                sourcelbl.Text = "Quelle: " + Pfad;
                pathCreate.Visible = false;
                Re.SaveData.Clear();
                Rechnungen.Items.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Uhrzeitlbl.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}