using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;

namespace fromProveedorProducto
{
    #region 
    public partial class Proveedor : Form
    {
        public Proveedor()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btguardar_Click(object sender, EventArgs e)
        {
            logicaNegocioProvedor lN = new logicaNegocioProvedor();

            try
            {
                if (btguardar.Text == "Guardar")
                {
                    provedor objProveedor = new provedor();
                    objProveedor.nombre = txtnombre.Text;
                    objProveedor.direccion = txtdireccion.Text;
                    objProveedor.telefono = txttelefono.Text;

                    if (lN.insertarProveedor(objProveedor) > 0)
                    {
                        MessageBox.Show("Agregado con exito");
                        dgvProveedores.DataSource = lN.ListarProveedores();
                        txtdireccion.Text = "";
                        txtnombre.Text = "";
                        txttelefono.Text = "";
                        tabproveedor.SelectedTab = tabPage2;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar proveedor");
                    }

                    if (btneditar.Text == "Actualizar")
                    {
                        provedor objProveedor = new provedor();
                        objProveedor.idcodigoP = Convert.ToInt32(txtcodigo.Text);
                        objProveedor.nombre = txtnombre.Text;
                        objProveedor.direccion = txtdireccion.Text;
                        objProveedor.telefono = txttelefono.Text;

                        if (lN.EditarProveedor(objProveedor) > 0)
                        {
                            MessageBox.Show("Actualizado con exito");
                            dgvProveedores.DataSource = lN.ListarProveedores();
                            txtdireccion.Text = "";
                            txtnombre.Text = "";
                            txttelefono.Text = "";
                            tabproveedor.SelectedTab = tabPage2;
                        }

                    }
                }
            }
            catch { MessageBox.Show("errooorrrrrr"); }

        }
    #endregion ///////para guardar 

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            txtcodigo.Visible = false;
            lbid.Visible = false;
            dgvProveedores.DataSource = lN.listaProveedor();

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            List<Proveedor> lista = lN.BuscarProveedorDatos(txtbuscar.Text);
            dgvProveedores.DataSource = lista;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            txtcodigo.visible = true;
            txtcodigo.Enabled = false;
            lbid.Visible = true;

            txtnombre.Text = dgvProveedores.CurrentRow.Cells["nombre"].Value.ToString();
            txtdireccion.Text = dgvProveedores.CurrentRow.Cells["direccion"].Value.ToString();
            txttelefono.Text = dgvProveedores.CurrentRow.Cells["telefono"].Value.ToString();
            txtcodigo.Text = dgvProveedores.CurrentRow.Cells["idcodigoP"].Value.ToString();

            tabproveedor.SelectedTab = tabPage1;
            button1.Text = "Actualizar";
        }


        

        #region
        //private void btGuardar_Click(object sender, EventArgs e)
        //{
        //    logicaNegocioProvedor lN = new logicaNegocioProvedor();

        //    try
        //    {
        //        provedor objProveedor = new provedor();
        //        objProveedor.nombre = txtNombre.Text;
        //        objProveedor.direccion = txtDireccion.Text;
        //        objProveedor.telefono = txtTelefono.Text;

        //        if (lN.insertarProveedor(objProveedor) > 0)
        //        {
        //            MessageBox.Show("Agregado con exito");
        //            txtDireccion.Text = "";
        //            txtNombre.Text = "";
        //            txtTelefono.Text = "";
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al agregar proveedor");
        //        }
        //    }
        //    catch { MessageBox.Show("errooorrrrrr"); }
        //}
        #endregion
    }
}
