namespace Poxls
{
    partial class MainForm
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
            this.POToXLSButton = new System.Windows.Forms.Button();
            this.XLSToPOButton = new System.Windows.Forms.Button();
            this.logsText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // POToXLSButton
            // 
            this.POToXLSButton.Location = new System.Drawing.Point(12, 12);
            this.POToXLSButton.Name = "POToXLSButton";
            this.POToXLSButton.Size = new System.Drawing.Size(75, 23);
            this.POToXLSButton.TabIndex = 0;
            this.POToXLSButton.Text = "PO -> XLS";
            this.POToXLSButton.UseVisualStyleBackColor = true;
            this.POToXLSButton.Click += new System.EventHandler(this.POToXLSButton_Click);
            // 
            // XLSToPOButton
            // 
            this.XLSToPOButton.Enabled = false;
            this.XLSToPOButton.Location = new System.Drawing.Point(93, 12);
            this.XLSToPOButton.Name = "XLSToPOButton";
            this.XLSToPOButton.Size = new System.Drawing.Size(75, 23);
            this.XLSToPOButton.TabIndex = 1;
            this.XLSToPOButton.Text = "XLS -> PO";
            this.XLSToPOButton.UseVisualStyleBackColor = true;
            this.XLSToPOButton.Click += new System.EventHandler(this.XLSToPOButton_Click);
            // 
            // logsText
            // 
            this.logsText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logsText.Location = new System.Drawing.Point(12, 41);
            this.logsText.MaxLength = 0;
            this.logsText.Name = "logsText";
            this.logsText.ReadOnly = true;
            this.logsText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logsText.Size = new System.Drawing.Size(478, 173);
            this.logsText.TabIndex = 4;
            this.logsText.Text = "";
            this.logsText.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 226);
            this.Controls.Add(this.logsText);
            this.Controls.Add(this.XLSToPOButton);
            this.Controls.Add(this.POToXLSButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Poxls";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button POToXLSButton;
        private System.Windows.Forms.Button XLSToPOButton;
        private System.Windows.Forms.RichTextBox logsText;
    }
}

