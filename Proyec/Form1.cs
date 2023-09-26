using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Proyec
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

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer Sonido = new SoundPlayer();
            Sonido.SoundLocation = "C://Users//Dell Latitude//Documents//UMG//sond//mess.wav";
            Sonido.Play();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
