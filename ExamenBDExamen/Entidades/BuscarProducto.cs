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
    public partial class BuscarProducto : Form
    {
        Conexion conex;
        public bool Modificar { get; set; }
        public BuscarProducto()
        {
            InitializeComponent();
        }
        public BuscarProducto(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                this.Text = "Modificar Producto";
                label1.Text = "Ingrese el codigo del Producto que desea Modificar";
            }
            btnModificar.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<string> datos = new List<string>();
            if (maskedTextBox1.Text.Equals(""))
            {
                if (Modificar == true)
                {
                    MessageBox.Show("Debe ingresar el Id del Producto que desea Modificar", "Informacion");
                }
                else
                {
                    MessageBox.Show("Debe ingresar el Id del Producto que desea buscar", "Informacion");                  
                }
                return;
            }
            if (maskedTextBox1.Text.Length>5)
            {
                MessageBox.Show("El codigo del producto no existe");
                return;
            }
            datos.Add(maskedTextBox1.Text);
            DataTable dt = conex.BuscarEntidad("BuscarProduc", datos);            
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("No se encontro el producto");
            }
            else
            {
                DataRow dr = dt.Rows[0];
                label1.Text = "Producto " + dr[1].ToString();
                button1.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                if (Modificar == true)
                {
                    maskedTextBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    btnModificar.Visible = true;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            if (textBox1.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("")|| textBox6.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar los campos que desea modificar");
                return;
            }
            datos.Add(maskedTextBox1.Text);
            datos.Add(textBox1.Text);
            datos.Add(textBox3.Text);
            datos.Add(textBox4.Text);
            datos.Add(textBox6.Text);
            conex.ModificarEdintidad("ModificarProducto", datos);
            this.Hide();
        }
    }
}
