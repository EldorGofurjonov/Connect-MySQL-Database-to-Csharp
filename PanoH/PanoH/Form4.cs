using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PanoH
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

       

        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string birinchiUstoz = textBox1.Text;
                string familya = textBox2.Text;
                if (birinchiUstoz == "Birinchi ustozingiz ismi" || familya == "Familyangiz")
                {
                    MessageBox.Show("Fo'rmani to'liq to'ldiring!!!", "Kichik xatolik", MessageBoxButtons.OK);
                    return;
                }
                MS mS = new MS();

                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `royhat` WHERE `birinchi_ustozingiz_ismi` = @birinchiUstoz AND `familya` = @familya", mS.getAloqa());
                command.Parameters.Add("@birinchiUstoz", MySqlDbType.VarChar).Value = birinchiUstoz;
                command.Parameters.Add("@familya", MySqlDbType.VarChar).Value = familya;

                mS.aloqaOchish();

                int count = Convert.ToInt32(command.ExecuteScalar());

                mS.aloqaYopish();

                if (count > 0)
                {

                    birinchiUstoz = textBox1.Text;
                    familya = textBox2.Text;



                    command = new MySqlCommand("SELECT `login`, `parol` FROM `royhat` WHERE `birinchi_ustozingiz_ismi` = @birinchiUstoz AND `familya` = @familya", mS.getAloqa());
                    command.Parameters.Add("@birinchiUstoz", MySqlDbType.VarChar).Value = birinchiUstoz;
                    command.Parameters.Add("@familya", MySqlDbType.VarChar).Value = familya;

                    mS.aloqaOchish();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string login = reader["login"].ToString();
                        string parol = reader["parol"].ToString();

                        MessageBox.Show($"Login: {login}\nParol: {parol}", "Login va parol tiklandi", MessageBoxButtons.OK);
                    }


                    reader.Close();
                    mS.aloqaYopish();
                    Form3 mf = new Form3();
                    this.Hide();
                    mf.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Parol tiklanmadi siz yangi akkaunt yaratishingiz mumkin.");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Malumot bazaga kiritilmadi qayta urinib ko'ring", "Kichik xatolik");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Birinchi ustozingiz ismi";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Familyangiz";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                {
                    e.Handled = true;
                    Control nextControl = GetNextControl((Control)sender, true);
                    if (nextControl != null)
                        nextControl.Focus();
                }
            }
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Birinchi ustozingiz ismi")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Familyangiz")
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;
        }
    }
}
