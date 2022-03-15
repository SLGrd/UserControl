using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealBoxNetCls
{
    public partial class Exemplo : UserControl
    {
        public Exemplo()
        {
            InitializeComponent();
        }

        #region Variables        
        private string _Mask = "";
        private string _UText = "";
        private int _FontSize = 14;
        private HorizontalAlignment _TextAlign = HorizontalAlignment.Right;
        #endregion
        #region Properties
        public HorizontalAlignment TextAlign
        { get { return _TextAlign; } set { _TextAlign = value; tBox.TextAlign = value; this.Invalidate(); } }
        public int FontSize
        {
            get { return _FontSize; }
            set
            {
                _FontSize = value;
                tBox.Font = new Font(Font.FontFamily, _FontSize, FontStyle.Regular);
            }
        }
        public string Mask
        { get { return _Mask; } set { _Mask = value; } }
        public string UText
        {
            get { return _UText; }
            set
            {
                _UText = value is null ? "" : value;
                tBox.Text = MoveText(_UText);
                tBox.Select(0, 0);
            }
        }
        #endregion

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                string Left = new(tBox.Text[..tBox.SelectionStart].Where(c => char.IsDigit(c)).ToArray());
                string Right = new(tBox.Text[tBox.SelectionStart..].Where(c => char.IsDigit(c)).ToArray());

                if ((Left.Length + Right.Length) < _Mask.Count(f => f == '_'))
                {
                    tBox.Text = MoveText(Left + e.KeyChar + Right);
                    tBox.SelectionStart = CurPosition(Left + 1);
                }
            }
            e.Handled = true;
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                string Left = new(tBox.Text[..tBox.SelectionStart].Where(c => char.IsDigit(c)).ToArray());
                string Right = new(tBox.Text[tBox.SelectionStart..].Where(c => char.IsDigit(c)).ToArray());

                if (e.KeyCode == Keys.Back && Left.Length > 0) Left = Left.Remove(Left.Length - 1, 1);
                if (e.KeyCode == Keys.Delete && Right.Length > 0) Right = Right.Remove(0, 1);

                tBox.Text = MoveText(Left + Right);

                tBox.SelectionStart = CurPosition(Left);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Home)
            {
                tBox.Text = _Mask; tBox.SelectionStart = 0; tBox.ForeColor = Color.Black; e.Handled = true;
            }

            if (e.KeyCode == Keys.End)
            {
                string Left = new(tBox.Text.Where(c => char.IsDigit(c)).ToArray());
                tBox.SelectionStart = CurPosition(Left); e.Handled = true;
            }
        }
        private string MoveText(string t)
        {
            int n = 0;
            char[] s = _Mask.ToCharArray();     // Char array para evitar new strings in a loop

            for (int i = 0; i < _Mask.Length; i++)
                if (_Mask[i] == '_')
                    if (n < t.Length) s[i] = (char)t[n++]; else break;

            tBox.ForeColor = Color.Black;
            if (t.Length == _Mask.Count(f => f == '_')) tBox.ForeColor = IsValid(t) ? Color.Black : Color.Red;

            return new string(s);
        }
        private int CurPosition(string l)
        {
            // Recalcula a posição do cursor
            int p = l.Length, j = l.Length;
            for (int i = 0; i < _Mask.Length; i++)
                if (p > 0)
                    if (_Mask[i] == '_') p--; else j++;
                else break;
            return j;
        }
        private void TxtRealBoxControl_Enter(object sender, EventArgs e) => this.BackColor = Color.Black;
        private void TxtRealBoxControl_Leave(object sender, EventArgs e) => this.BackColor = Color.Gray;
        public bool IsValid(string t)
        {
            //if ( string.IsNullOrEmpty( t) ) return false;

            string w = new(t.Where(c => char.IsDigit(c)).ToArray());    //  Clear points and hifens
            if (w.Length != 11) return false;                                   //  Numero de caracteres valido ?

            //--------------------- Primeiro digito de controle ------------------------------------------------------------
            if (w[9] != CalculaDigito(w, 9)) return false;                      //  Primeiro digito de controle valido ?

            //--------------------- Segundo digito de controle --------------------------------------------------------------
            if (w[10] != CalculaDigito(w, 10)) return false;                    //  Segundo digito de controle valido ?  

            return true;                                                        //  Verification digits matched                                  
        }
        public char CalculaDigito(string w, int DigitNumber)
        {
            int Digit = 0;
            for (int i = 0; i < DigitNumber; i++)                           //  Transforma char em binario                                                                         
            { Digit += (w[i] - '0') * (DigitNumber + 1 - i); }          //  w[i] - '0' =  Convert.ToInt32(w[i].ToString()) 

            Digit = (11 - (Digit %= 11)) > 9 ? 0 : (11 - (Digit %= 11));  //  11 - Resto da divisão por 11. Se for maior que 9 ==> digito = 0

            return (char)(Digit + '0');                                    //  Transforma em Ascii : ex 0 em Ascii é 48 binario
        }
        public void SetColor(string w)
        {
            tBox.ForeColor = Color.Black;
            if (w.Length == 11)
                tBox.ForeColor = IsValid(w) ? Color.Black : Color.Red;
        }
    }
}