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

namespace _10_18_SaveFileDialog
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileOk += (senderFile, eFile) =>
            {
                try
                {
                    string fileName = saveFileDialog1.FileName;
                    File.WriteAllLines(fileName, listBoxKiir.Items.Cast<string>().ToArray());
                }
                catch (Exception)
                {

                    MessageBox.Show("Hiba, nem sikerült a kiirás");
                }
            };
            saveFileDialog1.ShowDialog();
        }

        private void textBoxBevitel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBoxKiir.Items.Add(textBoxBevitel.Text);
                textBoxBevitel.Text = "";

            }
        }
    }
}
