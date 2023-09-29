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
using System.Configuration;
using System.Data.SqlClient;
using Proyec.NuevoSpa;
using Npgsql;

namespace Proyec
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ConexPostgres()
        {
            try
            {
                NpgsqlConnection cn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=Proveedores;User Id=postgres;Password=password;");
                //String str = "Server=127.0.0.1;Port=5432;Database=Proveedores;User Id=postgres;Password=password;";
                NpgsqlCommand cm = new NpgsqlCommand("SELECT usuario,pass FROM usuarios WHERE usuario='" + textUser.Text+"' AND pass='"+ textPass.Text+"'",cn);
                cn.Open();
                NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Login Correcto");
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }


   
                
                
            }
            catch (Exception ex)
            {

            }
        }
        public void abriform2()
        {
            this.Hide();//oculta el formulario anterior cuando se abre otro.
            MENU formulario2 = new MENU();//abre el formulario2(menu).
            formulario2.ShowDialog();//abre el fomrulario en forma de cuadro de dialogo.
            this.Show();//vuelve a mostrar el formulario anterior cuando se cierra el actual.
        }
        public void soni()//metodo para agregar un sonido
        {
            SoundPlayer Sonido = new SoundPlayer();//definimors una variable que reproduzca un sonido
            Sonido.SoundLocation = "C://Users//Dell Latitude//Documents//UMG//sond//mess.wav";//ruta donde esta el archivo de audio
            Sonido.Play();//reproduce el audio si lo encuentra
        }
        public void sonderror()//metodo para agregar sonido
        {
            SoundPlayer Sonido = new SoundPlayer();//definimors una variable que reproduzca un sonido
            Sonido.SoundLocation = "C://Users//Dell Latitude//Documents//UMG//sond//error.wav";//ruta donde esta el archivo de audio
            Sonido.Play();//reproduce el audio si lo encuentra
        }
        public void logins()//definimos la conexion a base de datos de sql server
        {
            try//usamos un try catch para captar los posibles errores que pueden surgir
            {
                String cnn = ConfigurationManager.ConnectionStrings["Proyec.Properties.Settings.TiendaDeInformaticaConnectionString"].ConnectionString;
                using (SqlConnection conex = new SqlConnection(cnn))
                {
                    conex.Open();// Establecemos una conexion abierta
                    using (SqlCommand cmd = new SqlCommand("SELECT usuario, pass FROM USUARIO WHERE usuario='" + textUser.Text + "' AND pass='" + textPass.Text + "'", conex))//Hacemos la comparacion de los textbox con las columnas de la tabla USUARIO y sus datos para ver si coinciden.
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())//utilizamos un if y un else para confirmar si se realizo con exito el login.
                        {
                            soni();//Llamamos el metodo que tiene la instruccion de sonido.
                            MessageBox.Show("Login exitoso");//Mostramos este mensaje en caso los datos sean correctos.
                            abriform2();//abre el formulario de menu en caso logre logear el usuario.   
                        }
                        else
                        {
                            sonderror();//Llamamos el metodo que tiene la instruccion de sonido.
                            MessageBox.Show("Datos incorrectos");//Mostramos este mensaje en caso los datos sean incorrectos.
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {

            }
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
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            soni();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            //Llama el metodo que contiene la conexion a la base de datos y comprueba los datos ingresados.

            try
            {
                String selectedDataBase = comboEleccion.SelectedItem.ToString();

                
                    if (selectedDataBase == "SQL Server")
                    {
                        logins();
                    }
                    else if (selectedDataBase == "PostgreSQL")
                    {
                        ConexPostgres();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione una base de datos valida.");
                }
                
            
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    
}
