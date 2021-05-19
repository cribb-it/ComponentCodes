using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ComponentCodes
{
    public partial class MainForm : Form
    {
        Graphics ResGraphics;
        string[] CapacitorValues = { "pƑ", "nƑ", "µƑ", "mƑ", "Ƒ", "kƑ", "MƑ" };
        string[] ohmControls = new string[2];
        string[] wattControls = new string[2];
        const int _Thousand = 1000;
        const string ZERO = "0";
        const string VA = "V, A";
        bool AutoChanged = false;
        Region Resistor1Region = new Region();

        Brush black = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush brown = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
        Brush red = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush orange = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        Brush yellow = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
        Brush green = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush blue = new System.Drawing.SolidBrush(System.Drawing.Color.DodgerBlue);
        Brush violet = new System.Drawing.SolidBrush(System.Drawing.Color.DarkViolet);
        Brush gray = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
        Brush white = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush gold = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGoldenrod);
        Brush silver = new System.Drawing.SolidBrush(System.Drawing.Color.Silver);


        public MainForm()
        {
            InitializeComponent();
            ResGraphics = gbxRes.CreateGraphics();
            //gbxCap.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            //gbxRes.MouseMove += new MouseEventHandler(MainForm_MouseMove);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbxAmps.SelectedIndex = 0;
            cbxOhms.SelectedIndex = 0;
            cbxVolts.SelectedIndex = 1;
            cbxWAmps.SelectedIndex = 0;
            cbxWVolts.SelectedIndex = 1;
            cbxWWatts.SelectedIndex = 1;
            cbxTCOhms.SelectedIndex = 0;
            cbxTCFarads.Items.AddRange(CapacitorValues);
            cbxTCFarads.SelectedIndex = 2;
            ohmControls[0] = tbxVolts.Name;
            ohmControls[1] = tbxAmps.Name;
            wattControls[0] = tbxWVolts.Name;
            wattControls[1] = tbxWAmps.Name;
        }

        private void tmiClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CalcResistor()
        {
            double fourValue, fiveValue = 0;
            int fourCount, fiveCount = 0;

            fourValue = Convert.ToDouble(Multiplier(Convert.ToInt32((FistDigit() + SecondDigit()))));
            fiveValue = Convert.ToDouble(Multiplier(Convert.ToInt32((FistDigit() + SecondDigit() + ThirdDigit()))));
            fourCount = CountThounds(ref fourValue);
            fiveCount = CountThounds(ref fiveValue);
            lbl4Band.Text = Value2String(fourValue, fourCount) + " " + Tolerance();
            lbl5Band.Text = Value2String(fiveValue, fiveCount) + " " + Tolerance();
        }

        private string Value2String(double Value, int Count)
        {
            switch (Count)
            {
                case 1: return Value.ToString() + "k - Ohm";
                case 2: return Value.ToString() + "M - Ohm";
                default: return Value.ToString() + " - Ohm";
            }
        }

        private int CountThounds(ref double Value)
        {
            if (Value < _Thousand)
            {
                return 0;
            }
            else
            {
                Value = (Value / _Thousand);
                return CountThounds(ref Value, 1);
            }
        }

        private int CountThounds(ref double Value, int Count)
        {
            if (Value < _Thousand)
            {
                return Count;
            }
            else
            {
                Value = (Value / _Thousand);
                Count++;
                return CountThounds(ref Value, Count);
            }
        }

        private string FistDigit()
        {
            Rectangle four1 = new Rectangle(225, 5, 10, 70);
            Rectangle five1 = new Rectangle(225, 345, 10, 70);
            ResGraphics.SetClip(Resistor1Region, CombineMode.Replace);

            if (FirstBlack.Checked)
            {
                ResGraphics.FillRectangle(black, four1);
                ResGraphics.FillRectangle(black, five1);
                return "0";
            }
            else if (FirstBrown.Checked)
            {
                ResGraphics.FillRectangle(brown, four1);
                ResGraphics.FillRectangle(brown, five1);
                return "1";
            }
            else if (FirstRed.Checked)
            {
                ResGraphics.FillRectangle(red, four1);
                ResGraphics.FillRectangle(red, five1);
                return "2";
            }
            else if (FirstOrange.Checked)
            {
                ResGraphics.FillRectangle(orange, four1);
                ResGraphics.FillRectangle(orange, five1);
                return "3";
            }
            else if (FirstYellow.Checked)
            {
                ResGraphics.FillRectangle(yellow, four1);
                ResGraphics.FillRectangle(yellow, five1);
                return "4";
            }
            else if (FirstGreen.Checked)
            {
                ResGraphics.FillRectangle(green, four1);
                ResGraphics.FillRectangle(green, five1);
                return "5";
            }
            else if (FirstBlue.Checked)
            {
                ResGraphics.FillRectangle(blue, four1);
                ResGraphics.FillRectangle(blue, five1);
                return "6";
            }
            else if (FirstViolet.Checked)
            {
                ResGraphics.FillRectangle(violet, four1);
                ResGraphics.FillRectangle(violet, five1);
                return "7";
            }
            else if (FirstGray.Checked)
            {
                ResGraphics.FillRectangle(gray, four1);
                ResGraphics.FillRectangle(gray, five1);
                return "8";
            }
            else
            {
                ResGraphics.FillRectangle(white, four1);
                ResGraphics.FillRectangle(white, five1);
                return "9";
            }
        }

        private string SecondDigit()
        {
            Rectangle four2 = new Rectangle(240, 5, 10, 70);
            Rectangle five2 = new Rectangle(240, 345, 10, 70);
            ResGraphics.SetClip(Resistor1Region, CombineMode.Replace);

            if (SecondBlack.Checked)
            {
                ResGraphics.FillRectangle(black, four2);
                ResGraphics.FillRectangle(black, five2);
                return "0";
            }
            else if (SecondBrown.Checked)
            {
                ResGraphics.FillRectangle(brown, four2);
                ResGraphics.FillRectangle(brown, five2);
                return "1";
            }
            else if (SecondRed.Checked)
            {
                ResGraphics.FillRectangle(red, four2);
                ResGraphics.FillRectangle(red, five2);
                return "2";
            }
            else if (SecondOrange.Checked)
            {
                ResGraphics.FillRectangle(orange, four2);
                ResGraphics.FillRectangle(orange, five2);
                return "3";
            }
            else if (SecondYellow.Checked)
            {
                ResGraphics.FillRectangle(yellow, four2);
                ResGraphics.FillRectangle(yellow, five2);
                return "4";
            }
            else if (SecondGreen.Checked)
            {
                ResGraphics.FillRectangle(green, four2);
                ResGraphics.FillRectangle(green, five2);
                return "5";
            }
            else if (SecondBlue.Checked)
            {
                ResGraphics.FillRectangle(blue, four2);
                ResGraphics.FillRectangle(blue, five2);
                return "6";
            }
            else if (SecondViolet.Checked)
            {
                ResGraphics.FillRectangle(violet, four2);
                ResGraphics.FillRectangle(violet, five2);
                return "7";
            }
            else if (SecondGray.Checked)
            {
                ResGraphics.FillRectangle(gray, four2);
                ResGraphics.FillRectangle(gray, five2);
                return "8";
            }
            else
            {
                ResGraphics.FillRectangle(white, four2);
                ResGraphics.FillRectangle(white, five2);
                return "9";
            }
        }
        private string ThirdDigit()
        {
            Rectangle five3 = new Rectangle(255, 345, 10, 70);
            ResGraphics.SetClip(Resistor1Region, CombineMode.Replace);

            if (ThirdBlack.Checked)
            {
                ResGraphics.FillRectangle(black, five3);
                return "0";
            }
            else if (ThirdBrown.Checked)
            {
                ResGraphics.FillRectangle(brown, five3);
                return "1";
            }
            else if (ThirdRed.Checked)
            {
                ResGraphics.FillRectangle(red, five3);
                return "2";
            }
            else if (ThirdOrange.Checked)
            {
                ResGraphics.FillRectangle(orange, five3);
                return "3";
            }
            else if (ThirdYellow.Checked)
            {
                ResGraphics.FillRectangle(yellow, five3);
                return "4";
            }
            else if (ThirdGreen.Checked)
            {
                ResGraphics.FillRectangle(green, five3);
                return "5";
            }
            else if (ThirdBlue.Checked)
            {
                ResGraphics.FillRectangle(blue, five3);
                return "6";
            }
            else if (ThirdViolet.Checked)
            {
                ResGraphics.FillRectangle(violet, five3);
                return "7";
            }
            else if (ThirdGray.Checked)
            {
                ResGraphics.FillRectangle(gray, five3);
                return "8";
            }
            else
            {
                ResGraphics.FillRectangle(white, five3);
                return "9";
            }
        }

        private decimal Multiplier(int Value)
        {
            Rectangle four3 = new Rectangle(255, 5, 10, 70);
            Rectangle five4 = new Rectangle(270, 345, 10, 70);
            ResGraphics.SetClip(Resistor1Region, CombineMode.Replace);

            if (MultiBlack.Checked)
            {
                ResGraphics.FillRectangle(black, four3);
                ResGraphics.FillRectangle(black, five4);
                return (Value * 1);
            }
            else if (MultiBrown.Checked)
            {
                ResGraphics.FillRectangle(brown, four3);
                ResGraphics.FillRectangle(brown, five4);
                return (Value * 10);
            }
            else if (MultiRed.Checked)
            {
                ResGraphics.FillRectangle(red, four3);
                ResGraphics.FillRectangle(red, five4);
                return (Value * 100);
            }
            else if (MultiOrange.Checked)
            {
                ResGraphics.FillRectangle(orange, four3);
                ResGraphics.FillRectangle(orange, five4);
                return (Value * 1000);
            }
            else if (MultiYellow.Checked)
            {
                ResGraphics.FillRectangle(yellow, four3);
                ResGraphics.FillRectangle(yellow, five4);
                return (Value * 10000);
            }
            else if (MultiGreen.Checked)
            {
                ResGraphics.FillRectangle(green, four3);
                ResGraphics.FillRectangle(green, five4);
                return (Value * 100000);
            }
            else if (MultiBlue.Checked)
            {
                ResGraphics.FillRectangle(blue, four3);
                ResGraphics.FillRectangle(blue, five4);
                return (Value * 1000000);
            }
            else if (MultiGold.Checked)
            {
                ResGraphics.FillRectangle(gold, four3);
                ResGraphics.FillRectangle(gold, five4);
                return (Convert.ToDecimal(Value) * Convert.ToDecimal(0.1));
            }
            else if (MultiSilver.Checked)
            {
                ResGraphics.FillRectangle(silver, four3);
                ResGraphics.FillRectangle(silver, five4);
                return (Convert.ToDecimal(Value) * Convert.ToDecimal(0.01));
            }
            return Value;
        }
        private string Tolerance()
        {
            Rectangle four4 = new Rectangle(291, 5, 10, 70);
            Rectangle five5 = new Rectangle(291, 345, 10, 70);
            ResGraphics.SetClip(Resistor1Region, CombineMode.Replace);

            if (TolBrown.Checked)
            {
                ResGraphics.FillRectangle(brown, four4);
                ResGraphics.FillRectangle(brown, five5);
                return "±1%";
            }
            else if (TolRed.Checked)
            {
                ResGraphics.FillRectangle(red, four4);
                ResGraphics.FillRectangle(red, five5);
                return "±2%";
            }
            else if (TolGreen.Checked)
            {
                ResGraphics.FillRectangle(green, four4);
                ResGraphics.FillRectangle(green, five5);
                return "±0.5%";
            }
            else if (TolBlue.Checked)
            {
                ResGraphics.FillRectangle(blue, four4);
                ResGraphics.FillRectangle(blue, five5);
                return "±0.25%";
            }
            else if (TolViolet.Checked)
            {
                ResGraphics.FillRectangle(violet, four4);
                ResGraphics.FillRectangle(violet, five5);
                return "±0.1%";
            }
            else if (TolGold.Checked)
            {
                ResGraphics.FillRectangle(gold, four4);
                ResGraphics.FillRectangle(gold, five5);
                return "±5%";
            }
            else if (TolSilver.Checked)
            {
                ResGraphics.FillRectangle(silver, four4);
                ResGraphics.FillRectangle(silver, five5);
                return "±10%";
            }
            else
            {
                return "±20%";
            }
        }
        private void btnCapacitor_Click(object sender, EventArgs e)
        {
            try
            {
                string input = tbxValue.Text;
                string number = ParseDigits(input, true);
                bool hasPoint = (ParseDigits(input, false).Length != number.Length);
                string capTol = "None";
                int value = 0;
                decimal p, n, u, m, f, k, mi, multi = 0;
                if (number.Length > 0)
                {
                    lblText.Text = tbxValue.Text.ToUpper();
                    if (number.Length > 2 && !hasPoint)
                    {
                        value = Convert.ToInt32(number.Substring(0, number.Length - 1));
                        multi = Convert.ToInt32(number.Substring(number.Length - 1));
                        switch (Convert.ToInt32(multi))
                        {
                            case 8:
                                multi = 0.01M; 
                                break;
                            case 9:
                                multi = 0.1M; 
                                break;
                        }
                        //if (multi < 1) multi = 1;
                        if (multi > 0 && multi < 1)
                            p = Convert.ToDecimal(value * multi);
                        else
                            p = Convert.ToDecimal(value * Math.Pow(10, Convert.ToDouble(multi)));
                    }
                    else
                    {
                        p = Convert.ToDecimal(number);
                    }
                    n = (p / _Thousand);
                    u = (n / _Thousand);
                    m = (u / _Thousand);
                    f = (m / _Thousand);
                    k = (f / _Thousand);
                    mi = (k / _Thousand);

                    if (number.Length < input.Length)
                    {
                        char Tol = Convert.ToChar(input.Substring(input.Length - 1, 1).ToUpper());
                        switch (Tol)
                        {
                            case 'B':
                                capTol = "± 0.1pF";
                                break;
                            case 'C':
                                capTol = "± 0.25pF";
                                break;
                            case 'D':
                                if (p > 10) capTol = "± 0.5%"; else capTol = "± 0.5pF";
                                break;
                            case 'E':
                                capTol = "± 0.5%";
                                break;
                            case 'F':
                                if (p > 10) capTol = "± 1%"; else capTol = "± 1pF";
                                break;
                            case 'G':
                                if (p > 10) capTol = "± 2%"; else capTol = "± 2pF";
                                break;
                            case 'H':
                                capTol = "± 3%";
                                break;
                            case 'J':
                                capTol = "± 5%";
                                break;
                            case 'K':
                                capTol = "± 10%";
                                break;
                            case 'M':
                                capTol = "± 20%";
                                break;
                            case 'N':
                                capTol = "± 0.05% Or ± 30%";
                                break;
                            case 'P':
                                capTol = "+100%,-0%";
                                break;
                            case 'Q':
                                capTol = "+30%,-10%";
                                break;
                            case 'S':
                                capTol = "+50%,-20%";
                                break;
                            case 'T':
                                capTol = "+50%,-10%";
                                break;
                            case 'W':
                                capTol = "+200%,-0%";
                                break;
                            case 'X':
                                capTol = "+40%,-20%";
                                break;
                            case 'Z':
                                capTol = "+80%,-20%";
                                break;
                            default:
                                if (Char.IsWhiteSpace(Tol))
                                    capTol = "None";
                                else
                                    capTol = "Unknown";
                                break;

                        }
                    }

                    lblValue.Text = string.Format("{0}{1}\n{2}{3}\n{4}{5}\n{6}{7}\n{8}{9}\n{10}{11}\n{12}{13}\nTolerance: {14}", p, CapacitorValues[0], n, CapacitorValues[1], u, CapacitorValues[2], m, CapacitorValues[3], f, CapacitorValues[4], k, CapacitorValues[5], mi, CapacitorValues[6], capTol);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private string ParseDigits(string strRawValue, bool withPoints)
        {
            string strDigits = "";
            if (strRawValue == null) return strDigits;
            foreach (char c in strRawValue.ToCharArray())
            {
                if (withPoints)
                {
                    if (Char.IsDigit(c) || c.Equals('.'))
                    {
                        strDigits += c;
                    }
                }
                else
                {
                    if (Char.IsDigit(c))
                    {
                        strDigits += c;
                    }
                }
            }
            return strDigits;
        }

        private void gbxCap_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle ellipse = new System.Drawing.Rectangle(
                60, 70, 100, 100);
            System.Drawing.Rectangle[] peruLeg = {new System.Drawing.Rectangle(
                75, 150, 10, 20),new System.Drawing.Rectangle(135, 150, 10, 20)};
            System.Drawing.Rectangle[] sliverLeg = {new System.Drawing.Rectangle(
                75, 170, 10, 20),new System.Drawing.Rectangle(135, 170, 10, 20)};
            Brush peru = new System.Drawing.SolidBrush(System.Drawing.Color.Peru);
            e.Graphics.FillRectangles(new System.Drawing.SolidBrush(System.Drawing.Color.Silver), sliverLeg);
            e.Graphics.FillRectangles(peru, peruLeg);
            e.Graphics.FillEllipse(peru, ellipse);
        }

        private void gbxRes_Paint(object sender, PaintEventArgs e)
        {
            gbxRes.SuspendLayout();
            Brush bgBlue = new System.Drawing.SolidBrush(System.Drawing.Color.SteelBlue);
            Brush bgYellow = new System.Drawing.SolidBrush(System.Drawing.Color.Wheat);
            Brush silver = new System.Drawing.SolidBrush(System.Drawing.Color.Silver);
            Pen blackPen = new Pen(Color.Black, 2);

            System.Drawing.Rectangle ellipse1 = new System.Drawing.Rectangle(
                200, 10, 70, 60);
            System.Drawing.Rectangle rectangle1 = new System.Drawing.Rectangle(
                240, 15, 60, 50);
            System.Drawing.Rectangle ellipse2 = new System.Drawing.Rectangle(
                260, 10, 70, 60);
            System.Drawing.Rectangle bar1 = new System.Drawing.Rectangle(
                10, 35, 520, 10);

            System.Drawing.Rectangle ellipse3 = new System.Drawing.Rectangle(
                200, 350, 70, 60);
            System.Drawing.Rectangle rectangle2 = new System.Drawing.Rectangle(
                240, 355, 60, 50);
            System.Drawing.Rectangle ellipse4 = new System.Drawing.Rectangle(
                260, 350, 70, 60);
            System.Drawing.Rectangle bar2 = new System.Drawing.Rectangle(
                10, 375, 520, 10);

            Point[] line1 = { new Point(56, 109), new Point(56, 80), new Point(230, 80), new Point(230, 69) };
            Point[] line2 = { new Point(160, 109), new Point(160, 95), new Point(245, 95), new Point(245, 69) };
            Point[] line3 = { new Point(375, 109), new Point(375, 95), new Point(260, 95), new Point(260, 65) };
            Point[] line4 = { new Point(480, 109), new Point(480, 80), new Point(296, 80), new Point(296, 70) };

            Point[] line5 = { new Point(56, 292), new Point(56, 335), new Point(230, 335), new Point(230, 351) };
            Point[] line6 = { new Point(160, 292), new Point(160, 320), new Point(245, 320), new Point(245, 352) };
            Point[] line7 = { new Point(260, 292),  new Point(260, 355) };
            Point[] line8 = { new Point(375, 292), new Point(375, 320), new Point(275, 320), new Point(275, 355) };
            Point[] line9 = { new Point(480, 292), new Point(480, 335), new Point(296, 335), new Point(296, 351) };

            e.Graphics.DrawLines(blackPen, line1);
            e.Graphics.DrawLines(blackPen, line2);
            e.Graphics.DrawLines(blackPen, line3);
            e.Graphics.DrawLines(blackPen, line4);

            e.Graphics.DrawLines(blackPen, line5);
            e.Graphics.DrawLines(blackPen, line6);
            e.Graphics.DrawLines(blackPen, line7);
            e.Graphics.DrawLines(blackPen, line8);
            e.Graphics.DrawLines(blackPen, line9);

            GraphicsPath gpath = new GraphicsPath();
            gpath.FillMode = FillMode.Winding;
            gpath.AddRectangle(bar1);
            gpath.AddRectangle(rectangle1);
            gpath.AddEllipse(ellipse1);
            gpath.AddEllipse(ellipse2);
            gpath.CloseFigure();

            Resistor1Region.MakeEmpty();
            Resistor1Region.Union(gpath);
            Region temp = Resistor1Region.Clone();
            temp.Translate(0, 340);
            Resistor1Region.Union(temp);

            //e.Graphics.SetClip(Resistor1Region, CombineMode.Replace);

            e.Graphics.FillRectangle(silver, bar1);
            e.Graphics.FillRectangle(bgYellow, rectangle1);
            e.Graphics.FillEllipse(bgYellow, ellipse1);
            e.Graphics.FillEllipse(bgYellow, ellipse2);

            e.Graphics.FillRectangle(silver, bar2);
            e.Graphics.FillRectangle(bgBlue, rectangle2);
            e.Graphics.FillEllipse(bgBlue, ellipse3);
            e.Graphics.FillEllipse(bgBlue, ellipse4);

            CalcResistor();

            gbxRes.ResumeLayout();
        }

        private void tbxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnCapacitor.PerformClick();
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            //lblMouseMove.Text = e.Location.ToString();
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            CalcResistor();
        }

        private void OhmText_TextChanged(object sender, EventArgs e)
        {
            TextBox tmpTbox = ((TextBox)sender);
            //new code
            if (ohmControls[0] != tmpTbox.Name && !AutoChanged)
            {
                ohmControls[1] = ohmControls[0];
                ohmControls[0] = tmpTbox.Name;
                lblOhmControls.Text = ohmControls[0].Substring(3, 1) + ", " + ohmControls[1].Substring(3, 1);
            }
            //end new code
            NumberTextChange(tmpTbox);
        }

        private void WattText_TextChanged(object sender, EventArgs e)
        {
            TextBox tmpTbox = ((TextBox)sender);
            //new code
            if ((wattControls[0] != tmpTbox.Name) && !AutoChanged)
            {
                wattControls[1] = wattControls[0];
                wattControls[0] = tmpTbox.Name;
                lblWattControls.Text = wattControls[0].Substring(4, 1) + ", " + wattControls[1].Substring(4, 1);
            }
            //end new code
            NumberTextChange(tmpTbox);
        }

        private void NumberTextChange(TextBox tmpTbox)
        {
            string temp;
            temp = tmpTbox.Text;
            tmpTbox.Text = ParseDigits(tmpTbox.Text, true);
            if (temp.Length != tmpTbox.Text.Length)
            {
                tmpTbox.SelectionStart = tmpTbox.Text.Length;
            }
            if (tmpTbox.Text == "" || tmpTbox.Text == ZERO)
            {
                tmpTbox.Text = ZERO;
                tmpTbox.Select(0, tmpTbox.Text.Length);
            }
        }

        private void TimeConstant_TextChanged(object sender, EventArgs e)
        {
            NumberTextChange(((TextBox)sender));
            CalcTimeConstant();
        }

        private void TextBox_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox tmpTbox = ((TextBox)sender);
            if (tmpTbox.Text == ZERO)
            {
                tmpTbox.Select(0, tmpTbox.Text.Length);
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox tmpTbox = ((TextBox)sender);
            if (tmpTbox.Text == ZERO)
            {
                tmpTbox.Select(0, tmpTbox.Text.Length);
            }
        }

        private void btnOhms_Click(object sender, EventArgs e)
        {
            try
            {
                double volts = GetValue(Convert.ToDouble(tbxVolts.Text), false, ref cbxVolts);
                double amps = GetValue(Convert.ToDouble(tbxAmps.Text), false, ref cbxAmps);
                double ohms = GetOhms(Convert.ToDouble(tbxOhms.Text), false, ref cbxOhms);

                double tmpValue = 0;

                AutoChanged = true;
                if (((ohmControls[0] == tbxVolts.Name) && (ohmControls[1] == tbxAmps.Name)) || (ohmControls[1] == tbxVolts.Name && ohmControls[0] == tbxAmps.Name))
                {
                    tmpValue = (volts / amps);
                    tbxOhms.Text = GetOhms(tmpValue, true, ref cbxOhms).ToString();
                }
                else if ((ohmControls[0] == tbxVolts.Name && ohmControls[1] == tbxOhms.Name) || (ohmControls[1] == tbxVolts.Name && ohmControls[0] == tbxOhms.Name))
                {
                    tmpValue = (volts / ohms);
                    tbxAmps.Text = GetValue(tmpValue, true, ref cbxAmps).ToString();
                }
                else
                {
                    tmpValue = (ohms * amps);
                    tbxVolts.Text = GetValue(tmpValue, true, ref cbxVolts).ToString();
                }
                
                /*if (volts != 0 && amps != 0)
                {
                    tmpValue = (volts / amps);
                    tbxOhms.Text = GetOhms(tmpValue, true, ref cbxOhms).ToString();
                }
                else if (volts != 0 && ohms != 0)
                {
                    tmpValue = (volts / ohms);
                    tbxAmps.Text = GetValue(tmpValue, true, ref cbxAmps).ToString();
                }
                else
                {
                    tmpValue = (ohms * amps);
                    tbxVolts.Text = GetValue(tmpValue, true, ref cbxVolts).ToString();
                }*/
            }
            catch (Exception ex)
            {

            }
            finally
            {
                AutoChanged = false;
            }
        }

        private double GetValue(double value, bool reverse, ref ComboBox ComBox)
        {
            switch (ComBox.SelectedIndex)
            {
                case 0:
                    if (!reverse)
                    {
                        value = Convert.ToDouble(value / _Thousand);
                    }
                    else
                    {
                        value = Convert.ToDouble(value * _Thousand);
                    }
                    break;
                case 2:
                    if (!reverse)
                    {
                        value = Convert.ToDouble(value * _Thousand);
                    }
                    else
                    {
                        value = Convert.ToDouble(value / _Thousand);
                    }
                    break;

            }
            return value;
        }

        private double GetOhms(double ohms, bool reverse, ref ComboBox ComBox)
        {
            switch (ComBox.SelectedIndex)
            {
                case 1:
                    if (!reverse)
                    {
                        ohms = Convert.ToDouble(ohms * _Thousand);
                    }
                    else
                    {
                        ohms = Convert.ToDouble(ohms / _Thousand);
                    }
                    break;
                case 2:
                    if (!reverse)
                    {
                        ohms = Convert.ToDouble(Convert.ToDouble(ohms * _Thousand) * _Thousand);
                    }
                    else
                    {
                        ohms = Convert.ToDouble(Convert.ToDouble(ohms / _Thousand) / _Thousand);
                    }
                    break;

            }
            return ohms;
        }

        private decimal GetFarads(decimal farads, ref ComboBox ComBox)
        {
            switch (ComBox.SelectedIndex)
            {
                case 0: farads = Convert.ToDecimal(Convert.ToDouble(Convert.ToDecimal(Convert.ToDouble(farads / _Thousand) / _Thousand) / _Thousand) / _Thousand);
                    break;
                case 1: farads = Convert.ToDecimal(Convert.ToDecimal(Convert.ToDecimal(farads / _Thousand) / _Thousand) / _Thousand);
                    break;
                case 2: farads = Convert.ToDecimal(Convert.ToDecimal(farads / _Thousand) / _Thousand);
                    break;
                case 3: farads = Convert.ToDecimal(farads / _Thousand);
                    break;
                case 5: farads = Convert.ToDecimal(farads * _Thousand);
                    break;
                case 6: farads = Convert.ToDecimal(Convert.ToDecimal(farads * _Thousand) * _Thousand);
                    break;
            }
            return farads;
        }

        private void btnWatts_Click(object sender, EventArgs e)
        {
            try
            {
                double volts = GetValue(Convert.ToDouble(tbxWVolts.Text), false, ref cbxWVolts);
                double amps = GetValue(Convert.ToDouble(tbxWAmps.Text), false, ref cbxWAmps);
                double watts = GetValue(Convert.ToDouble(tbxWWatts.Text), false, ref cbxWWatts);

                double tmpValue = 0;

                AutoChanged = true;

                if ((wattControls[0] == tbxWVolts.Name && wattControls[1] == tbxWAmps.Name) || (wattControls[1] == tbxWVolts.Name && wattControls[0] == tbxWAmps.Name))
                {
                    tmpValue = (volts * amps);
                    tmpValue = GetValue(tmpValue, true, ref cbxWWatts);
                    tbxWWatts.Text = Convert.ToString(tmpValue); //0.0001
                }
                else if ((wattControls[0] == tbxWVolts.Name && wattControls[1] == tbxWWatts.Name) || (wattControls[1] == tbxWVolts.Name && wattControls[0] == tbxWWatts.Name))
                {
                    tmpValue = (volts / watts);
                    tbxWAmps.Text = GetValue(tmpValue, true, ref cbxWAmps).ToString();
                }
                else //Watts and Amps
                {
                    tmpValue = (watts / amps);
                    tbxWVolts.Text = GetValue(tmpValue, true, ref cbxWVolts).ToString();
                }

                /*if (volts != 0 && amps != 0)
                {
                    tmpValue = (volts * amps);
                    tbxWWatts.Text = GetValue(tmpValue, true, ref cbxWWatts).ToString();
                }
                else if (volts != 0 && watts != 0)
                {
                    tmpValue = (volts / watts);
                    tbxWAmps.Text = GetValue(tmpValue, true, ref cbxWAmps).ToString();
                }
                else
                {
                    tmpValue = (watts / amps);
                    tbxWVolts.Text = GetValue(tmpValue, true, ref cbxWVolts).ToString();
                }*/
            }
            catch (Exception ex)
            {

            }
            finally
            {
                AutoChanged = false;
            }
        }

        private void CalcTimeConstant()
        {
            try
            {
                double ohms = GetOhms(Convert.ToDouble(tbxTCOhms.Text), false, ref cbxTCOhms);
                decimal farads = GetFarads(Convert.ToDecimal(tbxTCFarads.Text), ref cbxTCFarads);

                tbxTCTime.Text = Convert.ToDecimal(Convert.ToDecimal(ohms) * farads).ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void TimeConstant_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcTimeConstant();
        }

        private void tmiRST_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                FirstBlack.Checked = true;
                SecondBlack.Checked = true;
                ThirdBlack.Checked = true;
                MultiBlack.Checked = true;
                TolBrown.Checked = true;
                tbxValue.Text = "";
                lblText.Text = "XXX";
                lblValue.Text = "";
            }
            else
            {
                AutoChanged = true;
                tbxVolts.Text = ZERO;
                tbxAmps.Text = ZERO;
                tbxOhms.Text = ZERO;

                tbxWAmps.Text = ZERO;
                tbxWVolts.Text = ZERO;
                tbxWWatts.Text = ZERO;

                tbxTCOhms.Text = ZERO;
                tbxTCFarads.Text = ZERO;
                AutoChanged = false;

                ohmControls[0] = tbxVolts.Name;
                ohmControls[1] = tbxAmps.Name;
                lblOhmControls.Text = VA;
                wattControls[0] = tbxWVolts.Name;
                wattControls[1] = tbxWAmps.Name;
                lblWattControls.Text = VA;
            }
        }

        private void tmiAbout_Click(object sender, EventArgs e)
        {
            ComponentAboutBox myAbout = new ComponentAboutBox();
            myAbout.ShowDialog();
        }
    }
}
