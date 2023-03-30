using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Net.Mime.MediaTypeNames;

namespace MenuMarketDB
{

    public class PanelMenu
    {

        DbConnection connection = new DbConnection();

        public Panel panel = new Panel();

        System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label2 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label3 = new System.Windows.Forms.Label();

        System.Windows.Forms.Label label4 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label5 = new System.Windows.Forms.Label();
        System.Windows.Forms.Label label6 = new System.Windows.Forms.Label();

        PictureBox pictureBox = new PictureBox();

        public void ADDPanel(Panel sender) 
        {
            if (sender.Width == 1417)
            {
                sender.Width = 625;
            }

            panel.Location = new Point(3, sender.Width - 620);
                panel.Size = new Size(618, 79);
                panel.BackColor = Color.Brown;
                sender.Width += 99;
                sender.Controls.Add(panel);
           
            

        }

        public void ADDTextbox1Rows() 
        {

            string[] Name_ = new string[1000];



            panel.Controls.Add(label1);
            label1.Location = new Point(4, 4);
            label1.Text = "Название";

            label2.Location = new Point(3 , 32);
            label2.Text = "Цена";
            panel.Controls.Add(label2);
            

            panel.Controls.Add(label3);
            label3.Location = new Point(3, 56);
            label3.Text = "Колличество";

        }

        //Сделал
        public void ADDTextbox2Rows(int Price_, int Neme_In, int KKolVo_, string zapros)
        {

            connection.ConOpen();

            
            int i = 0;
            int j = 0;
            int k = 0;

            string[] Name_ = new string[8];
            string[] Price = new string[8];
            string[] kOLvO = new string[8];

            SqlCommand npgsqlCommand = new SqlCommand(zapros, connection.GetConnection());

            using (var reader = npgsqlCommand.ExecuteReader())
            {

                while (reader.Read())
                {
                    Name_[i] = reader["Title"].ToString();
                    i++;
                }
            }

            using (var reader = npgsqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Price[j] = reader["ProductPrice"].ToString();
                    j++;
                }
            }

            using (var reader = npgsqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    kOLvO[k] = reader["ProductionWorkshopNumber"].ToString();
                    k++;
                }
            }


            label4.Location = new Point(72, 4);
            label4.AutoSize = true;
            label4.Text = Name_[Neme_In];
            panel.Controls.Add(label4);          

            panel.Controls.Add(label5);
            label5.Location = new Point(72, 32);
            label5.AutoSize= true;
            label5.Text = Price[Price_];

            panel.Controls.Add(label6);
            label6.Location = new Point(72, 56);
            label6.AutoSize = true;
            label6.Text = kOLvO[KKolVo_];

            connection.ConClosed();
        }

        //изиенл
        public void ADDPicterwBox(int ImageIn, string zapros)
        {
            connection.ConOpen();

            string[] images = new string[1000];
            int i = 0;


            SqlCommand npgsqlCommand = new SqlCommand(zapros, connection.GetConnection());
            using (var reader = npgsqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    images[i] = reader["Image"].ToString();
                    i++;
                }
            }

            System.Drawing.Image img = System.Drawing.Image.FromFile($@"{images[ImageIn]}");
            pictureBox.Image = img;
            panel.Controls.Add(pictureBox);
            pictureBox.Location = new Point(507, 7);
            pictureBox.Size = new Size(108, 69);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            connection.ConClosed();

        }

        public void ClearPanel(Panel sender) 
        {
        
            sender.Controls.Clear();
        
        }

    }
}
