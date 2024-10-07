using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace PanoH
{
    class MS
    {
        MySqlConnection aloqa= new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=panoh");
        
        public void aloqaOchish()
        {
          
            
                if (aloqa.State == System.Data.ConnectionState.Closed)
                {
                    aloqa.Open();
                }
       

        }
        public void aloqaYopish()
        {
            if (aloqa.State == System.Data.ConnectionState.Open)
            {
                aloqa.Close();
            }
        }
        public MySqlConnection getAloqa()
        {
            return aloqa;
        }
    }
}
