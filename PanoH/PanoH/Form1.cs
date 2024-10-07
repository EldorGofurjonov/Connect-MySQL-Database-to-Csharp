using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace PanoH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 mf = new Form2();
            this.Hide();
            mf.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "@Login" || textBox2.Text == "Parol")
                {
                    MessageBox.Show("Fo'rmani to'liq to'ldiring!!!", "Kichik xatolik!!!", MessageBoxButtons.OK);
                    return;
                }
                if (textBox1.Text[0] != '@')
                {
                    MessageBox.Show("Siz loginni noto'g'ri kiritdingiz '@' esdan chiqardingiz.", "Kichik nosozlik", MessageBoxButtons.OK);
                    return;
                }
                Form3 mf = new Form3();
                String login = textBox1.Text;
                String password = textBox2.Text;

                MS ms = new MS();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `royhat` WHERE `parol` LIKE @uP AND `login` LIKE @uL", ms.getAloqa());


                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    mf.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login yoki parol xato!!!", "Xatolik", MessageBoxButtons.OK);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Malumot bazaga kiritilmagan yo'ki bazabilan aloqa yo'q qayta urinib ko'ring", "Kichik xatolik");
            }
        }

        

        private void label3_Click(object sender, EventArgs e)
        {
            Form4 mf= new Form4();
            this.Hide();
            mf.ShowDialog();
            this.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "@Login")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "@Login";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.UseSystemPasswordChar = true;
                textBox2.Text = "Parol";
                textBox2.ForeColor = Color.Gray;
            }
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                {
                    e.Handled = true; 
                    Control nextControl = GetNextControl((Control)sender, true);
                    if (nextControl != null)
                        nextControl.Focus();
                }
            }
        }

        //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        {
        //            e.Handled = true;
        //            Control nextControl = GetNextControl((Control)sender, true);
        //            if (nextControl != null)
        //                nextControl.Focus();
        //        }
        //    }
        //    button1.Focus();
        //}

        

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Parol")
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;
            textBox2.PasswordChar = '*';
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                {
                    e.Handled = true;
                    Control nextControl = GetNextControl((Control)sender, true);
                    if (nextControl != null)
                        nextControl.Focus();
                }
                button1.Focus();
               
            }
        }

        
    }
}
