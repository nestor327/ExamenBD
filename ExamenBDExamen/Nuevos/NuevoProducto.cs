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
    public partial class NuevoProducto : Form
    {
        Conexion conex;
        public NuevoProducto()
        {
            InitializeComponent();
        }
        public NuevoProducto(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        private void NuevoProducto_Load(object sender, EventArgs e)
        {
            DataTable dt = conex.ListarEntidades("ListarProduct");
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            maskedTextBox1.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
            maskedTextBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("")|| textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar los datos obligatorios");
                return;
            }
            List<string> datos = new List<string>();
            datos.Add(maskedTextBox1.Text);
            datos.Add(textBox1.Text);
            datos.Add(textBox2.Text);
            datos.Add(textBox3.Text);
            datos.Add(textBox4.Text);
            datos.Add(textBox5.Text);
            datos.Add(textBox6.Text);
            conex.NuevaEntidad("NProductos", datos);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
