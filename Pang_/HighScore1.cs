using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Pang_
{

    public partial class HighScore1 : Form
    {
        public HighScore1()
        {
            InitializeComponent();
            ispishi();
        }
        public void ispishi()
        {
            Stream str = File.OpenRead("Scores.bin");
            BinaryFormatter bf = new BinaryFormatter();

            List<Player> aal = (List<Player>)bf.Deserialize(str);

            aal.Sort(
           delegate(Player p1, Player p2)
           {
               return -(p1.points.CompareTo(p2.points));
           }
            );
            str.Close();
            String s = "";
            if (aal.Count > 5)
            {
                while (aal.Count > 5)
                {
                    aal.RemoveAt(5);
                }
            }

            textBox1.Text = aal[0].playerName; label1.Text = aal[0].points.ToString();
            textBox2.Text = aal[1].playerName; label2.Text = aal[1].points.ToString();
            textBox3.Text = aal[2].playerName; label3.Text = aal[2].points.ToString();
            textBox4.Text = aal[3].playerName; label4.Text = aal[3].points.ToString();
            textBox5.Text = aal[4].playerName; label5.Text = aal[4].points.ToString();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void HighScore_Load(object sender, EventArgs e)
        {

        }
    }
}
