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
    public partial class NuevaVenta : Form
    {
        Conexion conex;
        public NuevaVenta()
        {
            InitializeComponent();
        }
        public NuevaVenta(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }

        private void NuevaVenta_Load(object sender, EventArgs e)
        {
            DataTable dt = conex.ListarEntidades("ListarVentas");
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            maskedTextBox1.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
            maskedTextBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar los datos obligatorios");
                return;
            }
            List<string> datos = new List<string>();
            datos.Add(textBox1.Text);
            conex.NuevaEntidad("Nventas", datos);
            this.Hide();
        }
    }
}
