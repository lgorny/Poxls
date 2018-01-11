using Poxls.Format;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poxls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void XLSToPOButton_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = dialog.FileName;


            }
        }

        private void POToXLSButton_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "PO Files|*.po";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var progressHandler = new Progress<string>(value =>
                {
                    logsText.AppendText(value + Environment.NewLine);
                    logsText.Select(logsText.TextLength - 1, 0);
                    logsText.ScrollToCaret();
                });

                string fileToOpen = dialog.FileName;
                var po = new POFormat();
                po.Read(fileToOpen, progressHandler);
            }
        }

    }
}
