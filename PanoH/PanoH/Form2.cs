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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "Ism" || textBox2.Text == "Familya" || textBox3.Text == "Birinchi ustozingiz ismi" || textBox4.Text == "Parol" || textBox5.Text == "Parolni qayta kiriting" || jins.Text == "Jins")
                {
                    MessageBox.Show("Fo'rmani to'g'ri to'ldiring va to'liq to'ldiring!!!", "Kichik xatolik", MessageBoxButtons.OK);
                    return;
                }
                if (textBox4.Text != textBox5.Text)
                {
                    MessageBox.Show("Parol noto'g'ri kiritdingiz", "Kichik xatolig");
                    return;
                }
                //vaqtni MB ga tayyorlandi
                string k = dataTime.Value.ToString().Substring(0, 10);
                string tugilganKun = k.Substring(6, 4) + "-" + k.Substring(3, 2) + "-" + k.Substring(0, 2);


                MS mS = new MS();

                MySqlCommand command = new MySqlCommand("INSERT INTO `royhat` (`ism`, `familya`, `birinchi_ustozingiz_ismi`,`tugilgan_sana`, `jins`, `parol`, `login`) VALUES ( @ism, @familya, @ustoz, @vaqt, @jins, @parol, @login)", mS.getAloqa());

                command.Parameters.Add("@ism", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("@familya", MySqlDbType.VarChar).Value = textBox2.Text;
                command.Parameters.Add("@ustoz", MySqlDbType.VarChar).Value = textBox3.Text;
                command.Parameters.Add("@vaqt", MySqlDbType.VarChar).Value = tugilganKun;
                command.Parameters.Add("@jins", MySqlDbType.VarChar).Value = jins.Text;
            if (textBox4.Text.Length > 8)
            {
                command.Parameters.Add("@parol", MySqlDbType.VarChar).Value = textBox4.Text.Substring(0, 8);
            }
            else
            {
                command.Parameters.Add("@parol", MySqlDbType.VarChar).Value = textBox4.Text;
            }
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = $"@{textBox1.Text + textBox2.Text}";


                mS.aloqaOchish();

                if (command.ExecuteNonQuery() == 1)
                {
                    // Bazada unikal login yaratish
                    MySqlCommand getIdCommand = new MySqlCommand("SELECT LAST_INSERT_ID()", mS.getAloqa());
                    int userId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                    string newLogin = $"@{textBox1.Text.ToLower() + textBox2.Text.ToLower() + userId}"; // Здесь укажите новый логин

                    command = new MySqlCommand("UPDATE `royhat` SET `login` = @newLogin WHERE `id` = @userId", mS.getAloqa());
                    command.Parameters.Add("@newLogin", MySqlDbType.VarChar).Value = newLogin;
                    command.Parameters.Add("@userId", MySqlDbType.Int32).Value = userId;
                    command.ExecuteNonQuery();
                    if (textBox4.Text.Length > 8)
                    {
                        MessageBox.Show($"Login:{newLogin}\nParol:{textBox4.Text.Substring(0, 8)}", "Siz muvaffaqiyatli ro'yhatdan o'tdingiz");
                    }
                    else
                    {
                        MessageBox.Show($"Login:{newLogin}\nParol:{textBox4.Text}", "Siz muvaffaqiyatli ro'yhatdan o'tdingiz");
                    }
                    Form3 mf = new Form3();
                    this.Hide();
                    mf.ShowDialog();
                    this.Close();
                }


                else
                {
                    MessageBox.Show("Malumot bazaga kiritilmadi qayta urinib ko'ring", "Kichik xatolik");
                }

                mS.aloqaYopish();


            }
            catch (Exception t)
            {

                MessageBox.Show("Baza bilan aloqa yo'q,serverda xatolig!!!", "Kichik xatolik" + t);
                return;
            }

            //mS.aloqaOchish();

            //if (command.ExecuteNonQuery() == 1)
            //    MessageBox.Show("Muvoffaqiyatli bazaga kiritildi.");
            //else
            //    MessageBox.Show("Malumot bazaga kiritilmadi.");

            //mS.aloqaYopish();
            //Form3 mf= new Form3();
            //if (textBox4.Text == textBox5.Text)
            //{
            //    string Login = "@" + textBox1.Text + textBox2.Text;
            //    string Password = "@" + textBox5.Text;
            //    MessageBox.Show($"Sizni loginingiz:{Login}\nSizni parolingiz:{Password}", "Bu malumotlarni xechkimga bermang!!!", MessageBoxButtons.OK);
            //    mf.ShowDialog();
            //}
        }



        

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Parol")
            {
                textBox4.Text = "";
            }
            textBox4.ForeColor= Color.Black;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Parolni qayta kiriting")
            {
                textBox5.Text = "";
            }
            textBox5.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Ism";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {          
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Familya";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {          
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Birinchi ustozingiz ismi";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {          
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "Parol";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {          
                textBox5.ForeColor = Color.Gray;
                textBox5.Text = "Parolni qayta kiriting";
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
            textBox1_KeyPress (sender, e);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1_KeyPress(sender, e);

        }

        private void dataTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1_KeyPress(sender, e);

        }

        private void jins_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1_KeyPress(sender, e);

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1_KeyPress(sender, e);

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ism")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Familya")
            {
                textBox2.Text = "";
            }
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Birinchi ustozingiz ismi")
            {
                textBox3.Text = "";
            }
            textBox3.ForeColor = Color.Black;
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
            button1_Click(sender, e);

            }

        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.AliceBlue;
          
        }
    }
}
