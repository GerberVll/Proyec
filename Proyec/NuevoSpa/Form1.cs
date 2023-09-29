using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyec.botonesM;
namespace Proyec.NuevoSpa
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }
        public void abrirPro()
        {
            this.Hide();//oculta el formulario anterior cuando se abre otro.
            Proveedores Fproveedores= new Proveedores();//abre el formulario2(menu).
            Fproveedores.ShowDialog();//abre el fomrulario en forma de cuadro de dialogo.
            this.Show();//vuelve a mostrar el formulario anterior cuando se cierra el actual.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Calcular las coordenadas para centrar el formulario en la pantalla
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;

            int x = (screenWidth - formWidth) / 2;
            int y = (screenHeight - formHeight) / 2;

            // Establecer la ubicación del formulario
            this.Location = new Point(x, y);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            abrirPro();
        }
    }
}
