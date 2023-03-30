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
    public partial class Form1 : Form
    {

        DbConnection connection = new DbConnection();

        int MaksPanel = 8;
        int Price_ = 0;
        int Kolvo_ = 0;
        int Name = 0;
        int PictureBox = 0;
        

        public Form1()
        {

            InitializeComponent();

            

            for (int i = 0; i < MaksPanel; i++)
            {



                PanelMenu panelMenu = new PanelMenu();
                panelMenu.ADDTextbox2Rows(Price_, Name, Kolvo_, "SELECT * FROM Product");
                panelMenu.ADDPanel(panel1);
                panelMenu.ADDTextbox1Rows();
                panelMenu.ADDPicterwBox(PictureBox, "SELECT * FROM Product");

                Price_++;
                Kolvo_++;
                Name++;
                PictureBox++;

                
            }

            Price_ = 0;
            Kolvo_ = 0;
            Name = 0;
            PictureBox = 0;

            

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {



        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            

            if (comboBox1.Text == "Сортировка по имени")
            {
                

                for (int i = 0; i < MaksPanel; i++)
                {

                    PanelMenu panelMenu = new PanelMenu();
                    panelMenu.ADDPanel(panel1);
                    panelMenu.ADDTextbox2Rows(Price_, Name, Kolvo_, "SELECT * FROM Product  ORDER BY Title");
                    panelMenu.ADDTextbox1Rows();
                    panelMenu.ADDPicterwBox(PictureBox, "SELECT * FROM Product  ORDER BY Title");

                    Price_++;
                    Kolvo_++;
                    Name++;
                    PictureBox++;

                }

                Price_ = 0;
                Kolvo_ = 0;
                Name = 0;
                PictureBox = 0;

            }
            
            if (comboBox1.Text == "Сортировка по Цене (от дешевой к дорогой)")
            {
                panel1.Controls.Clear();

                for (int i = 0; i < MaksPanel; i++)
                {

                    PanelMenu panelMenu = new PanelMenu();
                    panelMenu.ADDPanel(panel1);
                    panelMenu.ADDTextbox2Rows(Price_, Name, Kolvo_, "SELECT * FROM Product  ORDER BY ProductionPersonCount");
                    panelMenu.ADDTextbox1Rows();
                    panelMenu.ADDPicterwBox(PictureBox, "SELECT * FROM Product  ORDER BY ProductionPersonCount");

                    Price_++;
                    Kolvo_++;
                    Name++;
                    PictureBox++;

                }

            }

        }

        //Трогать
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            connection.ConOpen();

            panel1.Controls.Clear();

            string namein;
            string images;
            string price;
            string kolvo;
            SqlCommand command_1 = new SqlCommand($"SELECT * FROM Product WHERE Title LIKE '%{textBox1.Text}%'", connection.GetConnection());
            using (var reader = command_1.ExecuteReader())
            {

                while (reader.Read())
                {

                    namein = reader["name_"].ToString();
                    images = reader["newimages"].ToString();
                    price = reader["price"].ToString();
                    kolvo = reader["kolvo"].ToString();

                    PanelMenu panelMenu = new PanelMenu();
                    panelMenu.ADDPanel(panel1);
                    panelMenu.ADDTextbox2Rows(Price_, Name, Kolvo_, $"SELECT * FROM Product WHERE Title LIKE '%{textBox1.Text}%'");
                    panelMenu.ADDTextbox1Rows();
                    panelMenu.ADDPicterwBox(PictureBox, $"SELECT * FROM Product WHERE Title LIKE '%{textBox1.Text}%'");

                    Price_++;
                    Kolvo_++;
                    Name++;
                    PictureBox++;

                }

                Price_ = 0;
                Kolvo_ = 0;
                Name = 0;
                PictureBox = 0;

            }

            connection.ConClosed();

        }
    }
}