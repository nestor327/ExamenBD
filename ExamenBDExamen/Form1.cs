using ExamenBDExamen.Anexo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenBDExamen
{
    public partial class Form1 : Form
    {
        Principal princ;
        Conexion conex;
        int escritor=0;
        public Form1()
        {
            InitializeComponent();

        }

        private void btnInicioSecion_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("") || txtContraseña.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar los campos", "Abvertencia");
                Cursor.Current = Cursors.Default;
                return;
            }
            conex = new Conexion();
            if (conex.IdentificarUsuario(txtUsuario.Text) == 3)
            {
                conex = new Conexion(txtUsuario.Text, txtContraseña.Text);
                VistasParaLector lector = new VistasParaLector(conex);
                lector.Show();
                return;
            }
            conex = new Conexion(txtUsuario.Text, txtContraseña.Text);
            if (this.conex.conect.State==ConnectionState.Open)
            {
                princ = new Principal(conex);
                princ.user = conex.IdentificarUsuario(txtUsuario.Text);
                princ.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexion, ingrese los datos correctos x3","Mesaje de Error");
            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "UserEXam";
            txtContraseña.Text = "201299";
        }
    }
}
