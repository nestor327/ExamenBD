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
    public partial class NuevaCompra : Form
    {
        Conexion conex;
        public NuevaCompra()
        {
            InitializeComponent();
        }
        public NuevaCompra(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        private void NuevaCompra_Load(object sender, EventArgs e)
        {
            DataTable dt = conex.ListarEntidades("ListarCompras");
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            maskedTextBox1.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
            maskedTextBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar los datos obligatorios, Primer Nombre, Pirmer Apellido y telefono");
                return;
            }
            List<string> datos = new List<string>();
            datos.Add(textBox1.Text);
            datos.Add(textBox2.Text);
            conex.NuevaEntidad("Ncompra", datos);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
