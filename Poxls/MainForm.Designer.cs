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
            this.convertFileButton = new System.Windows.Forms.Button();
            this.logsText = new System.Windows.Forms.RichTextBox();
            this.convertDirectoryButton = new System.Windows.Forms.Button();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.conversionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outputDirText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.singleXLSXCheckBox = new System.Windows.Forms.CheckBox();
            this.ue4StructureCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // convertFileButton
            // 
            this.convertFileButton.Location = new System.Drawing.Point(12, 59);
            this.convertFileButton.Name = "convertFileButton";
            this.convertFileButton.Size = new System.Drawing.Size(114, 23);
            this.convertFileButton.TabIndex = 0;
            this.convertFileButton.Text = "Convert File";
            this.convertFileButton.UseVisualStyleBackColor = true;
            this.convertFileButton.Click += new System.EventHandler(this.convertFileButton_Click);
            // 
            // logsText
            // 
            this.logsText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logsText.Location = new System.Drawing.Point(132, 12);
            this.logsText.MaxLength = 0;
            this.logsText.Name = "logsText";
            this.logsText.ReadOnly = true;
            this.logsText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logsText.Size = new System.Drawing.Size(358, 173);
            this.logsText.TabIndex = 4;
            this.logsText.Text = "";
            this.logsText.WordWrap = false;
            // 
            // convertDirectoryButton
            // 
            this.convertDirectoryButton.Location = new System.Drawing.Point(12, 88);
            this.convertDirectoryButton.Name = "convertDirectoryButton";
            this.convertDirectoryButton.Size = new System.Drawing.Size(114, 23);
            this.convertDirectoryButton.TabIndex = 5;
            this.convertDirectoryButton.Text = "Convert Directory";
            this.convertDirectoryButton.UseVisualStyleBackColor = true;
            this.convertDirectoryButton.Click += new System.EventHandler(this.convertDirectoryButton_Click);
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.browseOutputButton.Location = new System.Drawing.Point(399, 19);
            this.browseOutputButton.Margin = new System.Windows.Forms.Padding(0);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(72, 20);
            this.browseOutputButton.TabIndex = 6;
            this.browseOutputButton.Text = "Browse...";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            // 
            // conversionType
            // 
            this.conversionType.FormattingEnabled = true;
            this.conversionType.Items.AddRange(new object[] {
            "*.PO to *.XLSX",
            "*.XLSX to *.PO"});
            this.conversionType.Location = new System.Drawing.Point(12, 32);
            this.conversionType.Name = "conversionType";
            this.conversionType.Size = new System.Drawing.Size(114, 21);
            this.conversionType.SelectedIndex = 0;
            this.conversionType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Conversion:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.outputDirText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.browseOutputButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 121);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // outputDirText
            // 
            this.outputDirText.Location = new System.Drawing.Point(98, 19);
            this.outputDirText.Name = "outputDirText";
            this.outputDirText.Size = new System.Drawing.Size(295, 20);
            this.outputDirText.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(5, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output Directory:";
            // 
            // singleXLSXCheckBox
            // 
            this.singleXLSXCheckBox.AutoSize = true;
            this.singleXLSXCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.singleXLSXCheckBox.Location = new System.Drawing.Point(3, 3);
            this.singleXLSXCheckBox.Name = "singleXLSXCheckBox";
            this.singleXLSXCheckBox.Size = new System.Drawing.Size(92, 17);
            this.singleXLSXCheckBox.TabIndex = 9;
            this.singleXLSXCheckBox.Text = "Single *.XLSX";
            this.singleXLSXCheckBox.UseVisualStyleBackColor = true;
            // 
            // ue4StructureCheckBox
            // 
            this.ue4StructureCheckBox.AutoSize = true;
            this.ue4StructureCheckBox.Checked = true;
            this.ue4StructureCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ue4StructureCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ue4StructureCheckBox.Location = new System.Drawing.Point(3, 27);
            this.ue4StructureCheckBox.Name = "ue4StructureCheckBox";
            this.ue4StructureCheckBox.Size = new System.Drawing.Size(115, 17);
            this.ue4StructureCheckBox.TabIndex = 10;
            this.ue4StructureCheckBox.Text = "Use UE4 Structure";
            this.ue4StructureCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.singleXLSXCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ue4StructureCheckBox, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 236);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 74);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conversionType);
            this.Controls.Add(this.convertDirectoryButton);
            this.Controls.Add(this.logsText);
            this.Controls.Add(this.convertFileButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Poxls";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convertFileButton;
        private System.Windows.Forms.RichTextBox logsText;
        private System.Windows.Forms.Button convertDirectoryButton;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.ComboBox conversionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox singleXLSXCheckBox;
        private System.Windows.Forms.TextBox outputDirText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ue4StructureCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

