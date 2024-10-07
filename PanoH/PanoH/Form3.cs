using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoH
{
    
    public partial class Form3 : Form
    {
       public int natija = 0;
        public Form3()
        {
            InitializeComponent();
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            Matem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (label2.Text == button1.Text)
                natija++;
            Matem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text == button2.Text)
                natija++;
            Matem();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text == button3.Text)
                natija++;
            Matem();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label2.Text == button4.Text)
                natija++;
            Matem();
        }
        private void Matem()
        {
            int a = new Random().Next(50);
            int b = new Random().Next(50);
            while(a == b)
            {
                a = new Random().Next(50);
                b = new Random().Next(50);
            }
            label2.Text = $"{a}+{b}";

            button1.Text = new Random().Next(100).ToString();
            button2.Text = new Random().Next(100).ToString();
            button3.Text = new Random().Next(100).ToString();
            button4.Text = new Random().Next(100).ToString();
            
            
            while (button1.Text == button2.Text && button1.Text == button3.Text && button1.Text == button4.Text && button2.Text == button3.Text && button2.Text == button4.Text && button3.Text == button4.Text)
            {
                button1.Text = new Random().Next(100).ToString();
                button2.Text = new Random().Next(100).ToString();
                button3.Text = new Random().Next(100).ToString();
                button4.Text = new Random().Next(100).ToString();
            }
            switch (new Random().Next(1, 5))
            {
                case 1: button1.Text = (a + b).ToString(); break;
                case 2: button2.Text = (a + b).ToString(); break;
                case 3: button3.Text = (a + b).ToString(); break;
                case 4: button4.Text = (a + b).ToString(); break;
            }
        }
    }
}
