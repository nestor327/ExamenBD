using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenBDExamen.Anexo;

namespace ExamenBDExamen.Nuevos
{
    public partial class NuevoDetCompra : Form
    {
        Conexion conex;
        public NuevoDetCompra()
        {
            InitializeComponent();
        }
        public NuevoDetCompra(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        public class Item
            {
            string name;            
            public Item(string name)
        {
                this.name = name;
        }
            }
        private void NuevoDetCompra_Load(object sender, EventArgs e)
        {
            /*
            DataTable dt = conex.ListarEntidades("ListarCompras");
            DataTable dtD = conex.ListarEntidades("Listardetallecompras");
            bool veracidad = false;
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataRow rows in dtD.Rows)
                {
                    if (row[0].ToString().Equals(rows[0].ToString()))
                    {
                        veracidad = true;
                    }
                    if (veracidad==false)
                    {
                        comboBox1.Items.Add(new Item(row[0].ToString()));
                    }
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar los datos obligatorios");
                return;
            }
            DataTable dt = conex.ListarEntidades("ListarCompras");
            bool existencia = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row[0].ToString().Equals(textBox4.Text))
                {
                    existencia = true;
                }
            }
            if (existencia==false)
            {
                MessageBox.Show("La compra de id "+textBox4.Text+" no esta registrada");
                return;
            }
            DataTable dtD = conex.ListarEntidades("Listardetallecompras");
            foreach (DataRow row in dtD.Rows)
            {
                if (row[1].ToString().Equals(textBox4.Text))
                {
                    MessageBox.Show("La compra de id " + textBox4.Text + " ya posee un detalle de venta");
                    return;
                }
            }
            List<string> datos = new List<string>();
            datos.Add(textBox4.Text);
            datos.Add(textBox1.Text);
            datos.Add(textBox2.Text);
            datos.Add(textBox3.Text);
            conex.NuevaEntidad("NDetalleCompra", datos);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
