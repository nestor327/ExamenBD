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

namespace ExamenBDExamen.Entidades
{
    public partial class BuscarProveedore : Form
    {
        Conexion conex;
        public bool Modificar { get; set; }
        public BuscarProveedore()
        {
            InitializeComponent();
        }
        public BuscarProveedore(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            List<string> datos = new List<string>();
            if (maskedTextBox1.Text.Equals(""))
            {
                if (Modificar == true)
                {
                    MessageBox.Show("Debe ingresar el Id del Proveedor que desea Modificar", "Informacion");
                }
                else
                {
                    MessageBox.Show("Debe ingresar el Id del Proveedor que desea buscar", "Informacion");
                }
               
                return;
            }
            if (maskedTextBox1.Text.Length>4)
            {
                MessageBox.Show("El proveedor de codigo"+ maskedTextBox1.Text + " no esta registrado");
                return;
            }
            datos.Add(maskedTextBox1.Text);
            DataTable dt = conex.BuscarEntidad("BuscarProv", datos);            
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("No se encontro el Proveedor");
            }
            else
            {
                DataRow dr = dt.Rows[0];
                label1.Text = "Proveedor " + dr[1].ToString();
                button1.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label7.Visible = true;            
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                if (Modificar == true)
                {
                    maskedTextBox1.ReadOnly = true;
                    textBox1.ReadOnly = true;
                    btnModificar.Visible = true;
                }
            }
        }

        private void BuscarProveedore_Load(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                this.Text = "Modificar Proveedor";
                label1.Text = "Ingrese el Id del Proveedor que desea Modificar";
            }
            btnModificar.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            if (textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar los campos que desea modificar");
                return;
            }
            datos.Add(maskedTextBox1.Text);
            datos.Add(textBox2.Text);
            datos.Add(textBox3.Text);
            datos.Add(textBox4.Text);
            conex.ModificarEdintidad("ModificarProvee", datos);
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
