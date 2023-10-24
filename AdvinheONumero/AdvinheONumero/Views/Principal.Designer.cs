namespace AdvinheONumero
{
    partial class Principal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelCheckedListBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanelCheckedListBox
            // 
            this.PanelCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.PanelCheckedListBox.Name = "PanelCheckedListBox";
            this.PanelCheckedListBox.Size = new System.Drawing.Size(776, 348);
            this.PanelCheckedListBox.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelCheckedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelCheckedListBox;
    }
}

