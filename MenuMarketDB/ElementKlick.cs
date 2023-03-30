using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuMarketDB
{
    public class ElementKlick
    {
        static int num_1 = 1;
        static int num_2 = 2;
        static int num_3 = 3;

        public void GetNum(LinkLabel linkLabel_1, LinkLabel linkLabel_2, LinkLabel linkLabel_3) 
        {

            linkLabel_1.Text = num_1.ToString();
            linkLabel_2.Text = num_2.ToString();
            linkLabel_3.Text = num_3.ToString();
                
        }

        public static void NewNum(LinkLabel linkLabel_1, LinkLabel linkLabel_2, LinkLabel linkLabel_3) 
        {

            num_1 ++;
            num_2 ++;
            num_3++;

            linkLabel_1.Text = num_1.ToString();
            linkLabel_2.Text = num_2.ToString();
            linkLabel_3.Text = num_3.ToString();

        }

        public static void NewNumReturn(LinkLabel linkLabel_1, LinkLabel linkLabel_2, LinkLabel linkLabel_3)
        {

            num_1--;
            num_2--;
            num_3--;

            linkLabel_1.Text = num_1.ToString();
            linkLabel_2.Text = num_2.ToString();
            linkLabel_3.Text = num_3.ToString();

        }

    }
}
