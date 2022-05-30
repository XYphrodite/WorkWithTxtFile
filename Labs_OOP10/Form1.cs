using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Labs_OOP10
{
    public partial class Form1 : Form
    {
        string lines(string str)
        {
            string nstr="";
            for (int i = 0, s=1; i < str.Length; i++)
            {
                if (s==1)
                {
                    nstr += "0001 ";
                    s++;
                }
                if (str[i] == '\n')
                {
                    if (s < 10)
                    {
                        nstr += str[i]+"000"+s.ToString()+" ";
                        s++;
                        continue;
                    }
                    if (s < 100)
                    {
                        nstr += str[i] + "00" + s.ToString() + " ";
                        s++;
                        continue;
                    }
                    if (s < 1000)
                    {
                        nstr += str[i] + "0" + s.ToString() + " ";
                        s++;
                        continue;
                    }
                    if (s < 10000)
                    {
                        nstr += str[i] + "" + s.ToString() + " ";
                        s++;
                        continue;
                    }
                    else
                    {
                        nstr += str[i] + "" + (s%10000).ToString() + " ";
                        s++;
                        continue;
                    }
                }
                nstr += str[i];
            }

            return nstr;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.GetEncoding(1251));
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenDlg.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog SaveDlg = new OpenFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                Writer.Write(richTextBox1.Text);
                Writer.Close();
            }
            SaveDlg.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = lines(richTextBox1.Text);
        }
    }
}
