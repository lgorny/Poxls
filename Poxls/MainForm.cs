using Poxls.Format;
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

namespace Poxls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void XLSToPOButton_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Excel Files|*.xlsx";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var progressHandler = new Progress<string>(value =>
                {
                    logsText.AppendText(value + Environment.NewLine);
                    logsText.Select(logsText.TextLength - 1, 0);
                    logsText.ScrollToCaret();
                });

                var xlsx = new XLSFormat();
                await xlsx.Read(dialog.FileName, progressHandler);

                var po = new POFormat(xlsx.Entries, xlsx.MetaData);
                po.Write(Path.GetDirectoryName(dialog.FileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(dialog.FileName) + ".po", progressHandler);
            }
        }

        private async void POToXLSButton_Click(object sender, EventArgs e)
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

                var po = new POFormat();
                await po.Read(dialog.FileName, progressHandler);

                var xlsx = new XLSFormat(po.Entries, po.MetaData);
                xlsx.Write(Path.GetDirectoryName(dialog.FileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(dialog.FileName) + ".xlsx", progressHandler);

            }
        }

    }
}
