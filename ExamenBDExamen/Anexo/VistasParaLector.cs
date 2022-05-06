using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenBDExamen.Anexo
{
    public partial class VistasParaLector : Form
    {
        Conexion conex;
        public VistasParaLector()
        {
            InitializeComponent();
        }
        public VistasParaLector(Conexion conex)
        {
            this.conex = conex;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= conex.Vistas("Comprasporproveedor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.Vistas("Comprasporproveedor");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conex.Vistas("Ventasporcliente");
        }
    }
}
