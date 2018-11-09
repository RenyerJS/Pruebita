using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidad;
using capaDatos;

namespace capaNegocio
{
    class logicaNegocioProducto
    {
        accesoDatosProductos apro = new accesoDatosProductos();

        public int insertarproducto(producto pr)
        {
            return apro.insertarProductos(pr);
        }

        public List<producto> Listarproductos()
        {
            return apro.ListarProductos();
        }

        public int EditarProveedor(producto pro)
        {
            return apro.insertarProductos(pro);
        }

        public int Eliminarproducto(int id_producto)
        {
            return apro.Eliminarproducto(id_producto);
 
        }

        public producto BuscarProductoXcodigo(int idpro)
        {
            return apro.BuscarproductoXcodigo((idpro);
        }

        public List<producto> BuscarProductoDatos(string dato)
        {
            return apro.BuscarProductoDatos(dato);
        }

    }
}
