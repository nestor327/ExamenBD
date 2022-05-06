using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenBDExamen.Entidades;
using ExamenBDExamen.Nuevos;

namespace ExamenBDExamen.Anexo
{
    public partial class Principal : Form
    {
        public Conexion conex;
        public int user { get; set; }
        List<TabPage> tabpages = new List<TabPage>();
        public static Principal principal= new Principal();
        public Principal()
        {
            InitializeComponent();
        }
        public Principal(Conexion conex)
        {
            this.conex = conex;            
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            if (user == 2)
            {
                btnModificarCoDC.Visible = false;
                btnBuscarCoDC.Visible = false;
                btnAcpDetaComp.Visible = false;
                button10.Visible = false;
                btnModificarVoDV.Visible = false;
                button12.Visible = false;
                button9.Visible = false;
                button1.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button15.Visible = false;
                btnBuscarCliente.Visible = false;
                btnModificarCliente.Visible = false;
                btnBuscarProducto.Visible = false;
                btnModificarProducto.Visible = false;
            }
            for (int i=7;i>0;i--)
            {
                tabpages.Add(tabControl1.TabPages[i]);
            }            
            tabControl1.TabPages[7].Parent = null;
            tabControl1.TabPages[6].Parent = null;
            tabControl1.TabPages[5].Parent = null;
            tabControl1.TabPages[4].Parent = null;
            tabControl1.TabPages[3].Parent = null;
            tabControl1.TabPages[2].Parent = null;
            tabControl1.TabPages[1].Parent = null;
            if (button10.Text.Equals("Detalle de Compras"))
            {
                btnAcpDetaComp.Visible = false;
            }            
        }
        public void Ocultar(int tabpage)
        {
            for (int i=7;i>0;i--)
            {
                if (i!=tabpage)
                {
                    tabControl1.TabPages[i].Parent = null;
                }                
            }
            
        }
        public void Mostrar(int item)
        {
            if (item!=1)
            {
                tabControl1.TabPages[1].Parent = null;
            }
            for (int i=6;i>=0;i--)
            {
                tabControl1.TabPages.Add(tabpages.ElementAt(i));
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(1);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            if (user==2)
            {

            }
            else
            {
                dgvVentas.DataSource = conex.ListarEntidades("ListarVentas");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(2);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            if (user == 2)
            {

            }
            else
            {
                dgvProductos.DataSource = conex.ListarEntidades("ListarProduct");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(5);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            if (user == 2)
            {

            }
            else
            {
                dgvClientes.DataSource = conex.ListarEntidades("ListarC");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(4);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            if (user == 2)
            {

            }
            else
            {
                dgvDevoluciones.DataSource = conex.ListarEntidades("ListarDevolu");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(3);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            if (user == 2)
            {

            }
            else
            {
                dgvCompras.DataSource = conex.ListarEntidades("ListarCompras");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(6);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            if (user == 2)
            {

            }
            else
            {
                dgvProveedores.DataSource = conex.ListarEntidades("ListarProv");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mostrar(tabControl1.TabPages.Count);
            Ocultar(7);
            tabControl1.SelectedTab = tabControl1.TabPages[1];                   
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text.Equals("Detalle devoluciones"))
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvDevoluciones.DataSource = conex.ListarEntidades("Listardeatlledevolucion");
                }
                button8.Text = "Devoluciones";
                btnBuscarDEoDedDe.Text = "Buscar Det Devolucion";
                btnModificarDoDD.Text = "Modificar Det Devolucion";
                btnNuevoDoDD.Text = "Nuevo det Devolucion";
            }
            else
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvDevoluciones.DataSource = conex.ListarEntidades("ListarDevolu");
                }
                btnBuscarDEoDedDe.Text = "Buscar Devolucion";
                button8.Text = "Detalle devoluciones";
                btnModificarDoDD.Text = "Modificar Devolucion";
                btnNuevoDoDD.Text = "Nueva Devolucion";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text.Equals("Detalle de Ventas"))
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvVentas.DataSource = conex.ListarEntidades("ListarDetalle_Venta");
                }
                button9.Text = "Ventas";
                button12.Text = "Buscar Det Venta";
                btnModificarVoDV.Text = "Modificar Det Venta";
                button11.Text = "Nuevo det Venta";
            }
            else
            {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvVentas.DataSource = conex.ListarEntidades("ListarVentas");
                    }
                button9.Text = "Detalle de Ventas";
                button12.Text = "Buscar Venta";
                btnModificarVoDV.Text = "Modificar Venta";
                button11.Text = "Nueva Venta";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text.Equals("Detalle de Compras"))
            {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvCompras.DataSource = conex.ListarEntidades("Listardetallecompras");
                    }
                button10.Text = "Compras";
                btnBuscarCoDC.Text = "Buscar Detalle Compra";
                btnModificarCoDC.Text = "Modificar Det Compra";
                btnNewCoDC.Text = "Nuevo det Compra";
                btnAcpDetaComp.Visible = true;
            }
            else
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvCompras.DataSource = conex.ListarEntidades("ListarCompras");
                }
                button10.Text = "Detalle de Compras";
                btnBuscarCoDC.Text = "Buscar Compra";
                btnModificarCoDC.Text = "Modificar Compra";
                btnNewCoDC.Text = "Nueva Compra";
                btnAcpDetaComp.Visible = false;
            }
        }

        private void btnAcpDetaComp_Click(object sender, EventArgs e)
        {
            List<string> datos = new List<string>();
            conex.ModificarEdintidad("ActPProd",datos);
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente buscar = new BuscarCliente(conex);
            buscar.Modificar = false;
            buscar.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnBuscarCoDC_Click(object sender, EventArgs e)
        {
            if (button10.Text.Equals("Detalle de Compras"))
            {
                BuscarCompra buscar = new BuscarCompra(conex);
                buscar.Modificar = false;
                buscar.Show();
            }
            else
            {
                BuscarDetCompra buscar = new BuscarDetCompra(conex);
                buscar.Modificar = false;
                buscar.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnBuscarDEoDedDe_Click(object sender, EventArgs e)
        {
            if (button8.Text.Equals("Detalle devoluciones"))
            {
                BuscarDevolucion buscar = new BuscarDevolucion(conex);
                buscar.Modificar = false;
                buscar.Show();
            }
            else
            {
                BuscarDetDevolucion buscar = new BuscarDetDevolucion(conex);
                buscar.Modificar = false;
                buscar.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button9.Text.Equals("Detalle de Ventas"))
            {
                BuscarVenta buscar = new BuscarVenta(conex);
                buscar.Modificar = false;
                buscar.Show();
            }
            else
            {
                BuscarDetVenta buscar = new BuscarDetVenta(conex);
                buscar.Modificar = false;
                buscar.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto buscar = new BuscarProducto(conex);
            buscar.Modificar = false;
            buscar.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button13_Click(object sender, EventArgs e)
        {
            BuscarProveedore buscar=new BuscarProveedore(conex);
            buscar.Modificar = false;
            buscar.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnModificarCoDC_Click(object sender, EventArgs e)
        {
            if (button10.Text.Equals("Detalle de Compras"))
            {
                BuscarCompra buscar = new BuscarCompra(conex);
                buscar.Modificar = true;
                buscar.Show();
            }
            else
            {
                BuscarDetCompra buscar = new BuscarDetCompra(conex);
                buscar.Modificar = true;
                buscar.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnModificarDoDD_Click(object sender, EventArgs e)
        {
            if (button8.Text.Equals("Detalle devoluciones"))
            {
                BuscarDevolucion buscar = new BuscarDevolucion(conex);
                buscar.Modificar = true;
                buscar.Show();
            }
            else
            {
                BuscarDetDevolucion buscar = new BuscarDetDevolucion(conex);
                buscar.Modificar = true;
                buscar.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente buscar = new BuscarCliente(conex);
            buscar.Modificar = true;
            buscar.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnModificarVoDV_Click(object sender, EventArgs e)
        {
            if (button9.Text.Equals("Detalle de Ventas"))
            {
                BuscarVenta buscar = new BuscarVenta(conex);
                buscar.Modificar = true;
                buscar.Show();
            }
            else
            {
                BuscarDetVenta buscar = new BuscarDetVenta(conex);
                buscar.Modificar = true;
                buscar.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto buscar = new BuscarProducto(conex);
            buscar.Modificar = true;
            buscar.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BuscarProveedore buscar = new BuscarProveedore(conex);
            buscar.Modificar = true;
            buscar.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            NuevoCliente nuevo = new NuevoCliente(conex);
            nuevo.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnNewCoDC_Click(object sender, EventArgs e)
        {
            if (button10.Text.Equals("Detalle de Compras"))
            {
             NuevaCompra nuevo= new NuevaCompra(conex);
             nuevo.Show();
            }
            else
            {
                NuevoDetCompra nuevo = new NuevoDetCompra(conex);
                nuevo.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnNewProducto_Click(object sender, EventArgs e)
        {
            NuevoProducto nuevo = new NuevoProducto(conex);
            nuevo.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            NuevoProveedor nuevo = new NuevoProveedor(conex);
            nuevo.Show();
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnNuevoDoDD_Click(object sender, EventArgs e)
        {
            if (button8.Text.Equals("Detalle devoluciones"))
            {
                NuevaDevolucion nuevo = new NuevaDevolucion(conex);
                nuevo.Show();
            }
            else
            {
                NuevoDetDevolucion nuevo = new NuevoDetDevolucion(conex);
                nuevo.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button9.Text.Equals("Detalle de Ventas"))
            {
                NuevaVenta nuevo = new NuevaVenta(conex);
                nuevo.Show();
            }
            else
            {
                NuevoDetVenta nuevo = new NuevoDetVenta(conex);
                nuevo.Show();
            }
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        public void ActualizarEntidad(string procedure)
        {
            if (procedure.Equals("ListarProduct"))
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvProductos.DataSource = conex.ListarEntidades("ListarProduc");
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.ContainsKey("tabPage2"))
            {
                if (button9.Text.Equals("Detalle de Ventas"))
                {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvVentas.DataSource = conex.ListarEntidades("ListarVentas");
                    }
                }
                else
                {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvVentas.DataSource = conex.ListarEntidades("ListarDetalle_Venta");
                    }
                }
            
            }else if (tabControl1.TabPages.ContainsKey("tabPage3"))
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvProductos.DataSource = conex.ListarEntidades("ListarProduct");
                }
            }else if (tabControl1.TabPages.ContainsKey("tabPage4"))
            {
                if (button10.Text.Equals("Detalle de Compras"))
                {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvCompras.DataSource = conex.ListarEntidades("ListarCompras");
                    }
                }
                else
                {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvCompras.DataSource = conex.ListarEntidades("Listardetallecompras");
                    }
                }
            }else if (tabControl1.TabPages.ContainsKey("tabPage5"))
            {
                if (button8.Text.Equals("Detalle devoluciones"))
                {
                    if (user == 2)
                    {

                    }
                    else
                    {
                        dgvDevoluciones.DataSource = conex.ListarEntidades("ListarDevolu");
                    }
                }
                else
                {
                    dgvDevoluciones.DataSource = conex.ListarEntidades("Listardeatlledevolucion");
                }
            }else if (tabControl1.TabPages.ContainsKey("tabPage6"))
            {
                if (user == 2)
                {

                }
                else
                {
                    dgvClientes.DataSource = conex.ListarEntidades("ListarC");
                }
            }else if (tabControl1.TabPages.ContainsKey("tabPage7"))
            {
                if (user == 2)
                {
                    MessageBox.Show("");
                }
                else
                {
                    dgvProveedores.DataSource = conex.ListarEntidades("ListarProv");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            VistasParaLector lector = new VistasParaLector(conex);
            lector.Show();
            return;
        }
    }
}
