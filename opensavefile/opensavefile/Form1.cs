using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace opensavefile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                SaveFile();
            textBox1.Clear();
        }

        private void czyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        private void sprawdżToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String txt, sprawdz = "";
            try
            {
                txt = textBox1.Text;
                for (int i = 0; i < txt.Length; i++)
                {
                    if (txt[i] >= '0' && txt[i] <= '9' && txt[i] % 2 != 0)
                        sprawdz += (char)('N');
                    else
                        if (txt[i] >= '0' && txt[i] <= '9'+'9' && txt[i] % 2 == 0)
                            sprawdz += (char)('T');
                            else
                                if (txt[i] == 13) sprawdz += Environment.NewLine;
                                else sprawdz += txt[i];
                }
                textBox1.Text = sprawdz;
                textBox1.Select(sprawdz.Length, 0);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void SaveFile()
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    sw.Write(textBox1.Text);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 info = new Form2();
            info.Show();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 autor = new Form3();
            autor.Show();
        }
    }
}
