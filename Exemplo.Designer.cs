namespace RealBoxNetCls
{
    partial class Exemplo
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
            this.tBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tBox.Location = new System.Drawing.Point(7, 7);
            this.tBox.MaxLength = 12;
            this.tBox.Multiline = true;
            this.tBox.Name = "tBox";
            this.tBox.Size = new System.Drawing.Size(335, 50);
            this.tBox.TabIndex = 0;
            this.tBox.Enter += new System.EventHandler(this.TxtRealBoxControl_Enter);
            this.tBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.tBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.tBox.Leave += new System.EventHandler(this.TxtRealBoxControl_Leave);
            // 
            // Exemplo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tBox);
            this.Name = "Exemplo";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(349, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tBox;
    }
}
