using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Textfiles(*.txt)|*.txt|Allfiles(*.*) | *.* ";
            if (save_dialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = save_dialog.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }
        private long Calculate_e(long m)
        {
            long ee=0;
            Boolean b = true;
            for (long i = 2; i < m; i++)
            { 
                    if ((i % 2 != 0) && (m%i!=0)&&(b == true)) //если имеют общие делители
                    {
                    b = false;
                    ee = i;
                    }
            }
            return ee;
        }
        private long Calculate_d(long e, long m)
        {
            long d = 10;
            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    d++;
            }
            return d;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<int> a = new List<int>();
            List<long> b = new List<long>();
            a.Clear();
            b.Clear();
            long p = Convert.ToInt64(textBox2.Text);
            long q = Convert.ToInt64(textBox3.Text);
            long n = (long)p * (long)q;
            long m = (long)(p - 1) * (long)(q - 1);
            long E = Calculate_e(m);
            long d = Calculate_d(E, m);
            textBox4.Text = E.ToString();
            textBox5.Text = n.ToString();
            textBox6.Text = d.ToString();
            textBox7.Text = n.ToString();
            string s = Convert.ToString(textBox1.Text);  
            foreach (char c in s)
            {                      
                a.Add(System.Convert.ToInt32(c));               
            }
            //for (int i = 0; i < a.Count; i++)
            //{
            //    textBox1.Text += a[i].ToString() + "\r\n";
            //}
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] >= n - 1)
                {
                    MessageBox.Show("Подбери другие ключи");
                    i = a.Count;
                }
                else
                {
                    textBox1.Clear();
                    for (int j = 0; j < a.Count; j++)
                    {
                        b.Add((long)Math.Pow((double)a[j], (double)E) % (long)n);
                        textBox1.Text += Convert.ToString(b[j]) + " ";
                    }
                    i = a.Count;
                }
            }

            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Textfiles(*.txt)|*.txt|Allfiles(*.*)| *.*";
            if (open_dialog.ShowDialog() == DialogResult.Cancel)
            { return; }
            // получаем выбранный файл
            string filename = open_dialog.FileName;
            // читаем файл в строку
            string fileText =
            System.IO.File.ReadAllText(filename, System.Text.Encoding.GetEncoding(1251));
            textBox1.Text = fileText;
            if (fileText.Length == 0)
            {
                errorProvider1.SetError(textBox1, "данное поле пусто");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<long> z = new List<long>();
            z.Clear();
            String a = Convert.ToString(textBox1.Text);
            long d = Convert.ToInt64(textBox6.Text);
            long n = Convert.ToInt64(textBox7.Text);
            long[] w = textBox1.Text.Split(' ').
            Where(x => !string.IsNullOrWhiteSpace(x)).
            Select(x => long.Parse(x)).ToArray();

            textBox1.Clear();
            for (int i = 0; i < w.Length; i++)
            {
                textBox1.Text += Convert.ToString(w[i]) + " ";
                
            }
            //for (int i = 0; i < z.Count; i++)
            //    {
            //   textBox1.Text += Convert.ToString(z[i]) + " ";
            //    }
            for (int j = 0; j < w.Length; j++)
            {
                z.Add((long)Math.Pow(w[j], (double)d) % (long)n);
                textBox1.Text += z[j].ToString() + "\r\n";
            }

        }
    }
            
          
}
