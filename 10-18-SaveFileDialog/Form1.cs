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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileOk += (senderFile, eFile) =>
            {
                try
                {
                    string[] sorok = File.ReadAllLines(openFileDialog1.FileName);
                    listBoxKiir.Items.Clear();
                    foreach (var item in sorok)
                    {
                        listBoxKiir.Items.Add(item);
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Hiba, nem sikerült a betöltés");
                }
            };
            openFileDialog1.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBoxKiir.Items.Clear();
        }
    }
}
