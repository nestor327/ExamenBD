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
    public partial class BuscarDetCompra : Form
    {
        Conexion conex;
        public bool Modificar { get; set; }
        public BuscarDetCompra()
        {
            InitializeComponent();
        }
        public BuscarDetCompra(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<string> datos = new List<string>();
            if (maskedTextBox1.Text.Equals(""))
            {
                if (Modificar == true)
                {
                    MessageBox.Show("Debe ingresar el id del Detalle de Compra que desea Modificar", "Informacion");
                }
                else
                {
                    MessageBox.Show("Debe ingresar el id del Detalle de Compra que desea buscar", "Informacion");
                }               
                return;
            }
            datos.Add(maskedTextBox1.Text);
            DataTable dt = conex.BuscarEntidad("BuscarDetallecompra", datos);            
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("No se encontro el detalle de Compra");
            }
            else
            {
                DataRow dr = dt.Rows[0];
                label1.Text = "Detalle de la compra  " + dr[1].ToString();
                button1.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                if (Modificar == true)
                {
                    label8.Visible = true;
                    comboBox1.Visible = true;
                    maskedTextBox1.ReadOnly = true;
                    textBox1.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    btnModificar.Visible = true;
                }
            }
        }

        private void BuscarDetCompra_Load(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                this.Text = "Modificar Detalle Devolucion";
                label1.Text = "Ingrese el Id del detalle Devolucion que desea Modificar";
                label8.Visible = true;
                comboBox1.Visible = true;
            }
            btnModificar.Visible = false;
            label8.Visible = false;
            comboBox1.Visible = false;            
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            datos.Add(comboBox1.Text);
            conex.ModificarEdintidad("modificarDetalle_Compras", datos);
            this.Hide();
        }
    }
}
