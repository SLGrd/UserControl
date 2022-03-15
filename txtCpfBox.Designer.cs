namespace RealBoxNetCls
{
    partial class txtCpfBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tBox
            // 
            this.tBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBox.CausesValidation = false;
            this.tBox.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.tBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tBox.ForeColor = System.Drawing.Color.Black;
            this.tBox.HideSelection = false;
            this.tBox.Location = new System.Drawing.Point(7, 7);
            this.tBox.MaxLength = 14;
            this.tBox.Multiline = true;
            this.tBox.Name = "tBox";
            this.tBox.Size = new System.Drawing.Size(343, 51);
            this.tBox.TabIndex = 0;
            this.tBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox.Enter += new System.EventHandler(this.TxtRealBoxControl_Enter);
            this.tBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.tBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.tBox.Leave += new System.EventHandler(this.TxtRealBoxControl_Leave);
            // 
            // txtCpfBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tBox);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "txtCpfBox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(357, 65);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private TextBox tBox;
    }
}