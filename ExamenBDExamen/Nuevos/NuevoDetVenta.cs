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

namespace ExamenBDExamen.Nuevos
{
    public partial class NuevoDetVenta : Form
    {
        Conexion conex;
        public NuevoDetVenta()
        {
            InitializeComponent();
        }
        public NuevoDetVenta(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        private void NuevoDetVenta_Load(object sender, EventArgs e)
        {
            /*DataTable dt = conex.ListarEntidades("ListarVentas");
            DataTable dtD = conex.ListarEntidades("ListarDetalle_Venta");
            bool veracidad = false;
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataRow rows in dtD.Rows)
                {
                    if (row[0].ToString().Equals(rows[0].ToString()))
                    {
                        veracidad = true;
                    }
                    if (veracidad == false)
                    {
                        comboBox1.Items.Add(row[0].ToString());
                    }
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar los datos obligatorios");
                return;
            }
            DataTable dt = conex.ListarEntidades("ListarVentas");
            bool existencia = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString().Equals(textBox3.Text))
                {
                    existencia = true;
                }
            }
            if (existencia == false)
            {
                MessageBox.Show("La venta de id " + textBox3.Text + " no esta registrada");
                return;
            }
            DataTable dtD = conex.ListarEntidades("ListarDetalle_Venta");
            foreach (DataRow row in dtD.Rows)
            {
                if (row[1].ToString().Equals(textBox3.Text))
                {
                    MessageBox.Show("La venta de id " + textBox3.Text + " ya posee un detalle de venta");
                    return;
                }
            }
            List<string> datos = new List<string>();
            datos.Add(textBox3.Text);
            datos.Add(textBox1.Text);
            datos.Add(textBox2.Text);
            conex.NuevaEntidad("NDetalleVenta", datos);
            this.Hide();
        }
    }
}
