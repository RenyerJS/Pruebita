using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioProvedor
    {
        accesoDatosProveedor ap = new accesoDatosProveedor();

        public int insertarProveedor(provedor pv)
        {
            return ap.insertarProveedor(pv);
        }

        public List<provedor> ListarProveedores()
        {
            return ap.ListarProveedores();
        }

        public int EditarProveedor(provedor pv)
        {
            return ap.insertarProveedor(pv);
        }

        public int EliminarProveedor(int idproveedor)
        {
            return ap.EliminarProveedor(idproveedor);
 
        }

        public provedor BuscarProveedorXcodigo(int idpro)
        {
            return ap.BuscarProveedorXcodigo(idpro);
        }

        public List<provedor> BuscarProveedorDatos(string dato)
        {
            return ap.BuscarProveedorDatos(dato);
        }
    }
}
