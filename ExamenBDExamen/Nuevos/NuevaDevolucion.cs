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
    public partial class NuevaDevolucion : Form
    {
        Conexion conex;
        public NuevaDevolucion()
        {
            InitializeComponent();
        }
        public NuevaDevolucion(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NuevaDevolucion_Load(object sender, EventArgs e)
        {
            DataTable dt = conex.ListarEntidades("ListarDevolu");
            DataRow dr = dt.Rows[dt.Rows.Count - 1];
            textBox2.Text = (Convert.ToInt32(dr[0].ToString()) + 1).ToString();
            textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") && maskedTextBox1.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar almenos uno de los datos obligatorios");
                return;
            }
            List<string> datos = new List<string>();
            datos.Add(maskedTextBox1.Text);
            datos.Add(textBox1.Text);
            conex.NuevaEntidad("nueva_dev", datos);
            this.Hide();
        }
    }
}
