using System.ComponentModel;

namespace txtRealBoxNet;
[ToolboxItem(true)]
[DefaultEvent("_TextChanged")]
public partial class txtRealBoxControl : UserControl
{        
    public txtRealBoxControl() { InitializeComponent(); }

    #region Variables
    const   char      Minus        = '-';
    const   string    MinusStr     = "-";
    private decimal dp             = 1.0m;
    private string  fmt            = "N0";
    private int     _DecimalPlaces = 0;
    private int     _MaxLength     = 12;        
    private HorizontalAlignment _TextAlign = HorizontalAlignment.Right;
    #endregion 
    public event EventHandler? _TextChanged;
    #region Properties
    public HorizontalAlignment TextAlign
    {   get { return _TextAlign; } set { _TextAlign = value; txtBox.TextAlign = value; this.Invalidate(); }} 
    public int MaxLength
    {   get { return _MaxLength; } set { _MaxLength = value; }}
    public int DecimalPlaces
    {   get { return _DecimalPlaces; }
        set { _DecimalPlaces = value;
              dp = (decimal)Math.Pow(10, DecimalPlaces); fmt = $"N{value}"; }}
    public string UText
    {   get { return txtBox.Text; }
        set {               
                txtBox.Text = UFormat(value);
                SetPlusMinusColor();                
                txtBox.Select( txtBox.Text.Length, 0); }}
    #endregion
    private void OnKeyPress(object sender, KeyPressEventArgs e)
    {
        if (char.IsDigit(e.KeyChar) || e.KeyChar == Minus)
        {
            int cursorPosition = txtBox.Text.Length - txtBox.SelectionStart;

            if (e.KeyChar == Minus)                  
                txtBox.Text = txtBox.Text[0] == Minus ? txtBox.Text.Remove(0, 1) : Minus + txtBox.Text;                                    
            else
            {
                if (txtBox.Text[0] == Minus && txtBox.SelectionStart == 0) txtBox.SelectionStart = 1;
                if (txtBox.Text.Length < MaxLength)
                    txtBox.Text = UFormat( txtBox.Text.Insert(txtBox.SelectionStart, e.KeyChar.ToString()));                        
            }
            txtBox.SelectionStart = cursorPosition > txtBox.Text.Length ? 0 : txtBox.Text.Length - cursorPosition;
            SetPlusMinusColor();
        }            
        e.Handled = true;
    }
    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
        {        
            string Left  = txtBox.Text[..txtBox.SelectionStart].Replace(".", "").Replace(",", "");
            string Right = txtBox.Text[txtBox.SelectionStart..].Replace(".", "").Replace(",", "");

            if (e.KeyCode == Keys.Back   && Left.Length  > 0) Left  = Left.Remove(Left.Length - 1, 1);
            if (e.KeyCode == Keys.Delete && Right.Length > 0) Right = Right.Remove(0, 1);

            txtBox.Text = UFormat( Left + Right);

            int cursorPosition = Right.Length > DecimalPlaces
                                 ? UFormat( new string('1', Right.Length)).Length : Right.Length;
            txtBox.SelectionStart = cursorPosition > txtBox.Text.Length ? 0 : txtBox.Text.Length - cursorPosition;

            SetPlusMinusColor();
            e.Handled = true;
        }

        if (e.KeyCode == Keys.End || e.KeyCode == Keys.Home) 
        {
            if (e.KeyCode == Keys.Home) txtBox.Text = 0.ToString(fmt);
            txtBox.SelectionStart = txtBox.Text.Length;

            SetPlusMinusColor();
            e.Handled = true;
        }
    }
    private void SetPlusMinusColor() => txtBox.ForeColor = (txtBox.Text[0] == Minus) ? Color.Red : Color.Black;
    private void TxtRealBoxControl_Enter(object sender, EventArgs e)
    {
        this.BorderStyle = BorderStyle.FixedSingle;
        this.BackColor = Color.Black;
    }
    private void TxtRealBoxControl_Leave(object sender, EventArgs e) => this.BackColor = Color.Gray;
    private string UFormat(string t)
    {
        if ( t.Equals(string.Empty) || t.Equals(MinusStr) )  t = "0";        
        return (decimal.Parse(t.Replace(",", "").Replace(".", "")) / dp).ToString(fmt);
    }
    private void TxtBox_TextChanged(object sender, EventArgs e) { if (_TextChanged != null) _TextChanged.Invoke(sender, e); }       
}