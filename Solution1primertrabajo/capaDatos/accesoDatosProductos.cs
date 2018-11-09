using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using capaEntidad;
using System.Data;

namespace capaDatos
{
    public class accesoDatosProductos
    {
        SqlConnection cnx;
        producto pro = new producto(); 
        Conexion cn = new Conexion();
        SqlCommand cm = null; 
        int indicador = 0;
        SqlDataReader dr = null;
        List<producto> listaProduc = null;

        #region ///Insertar Productos///
        public int insertarProductos(producto pr)
        {

            try
            {
                SqlConnection cnx = cn.conectar(); 

                cm = new SqlCommand("nuevoproducto", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@descripcion", pr.descripcion);
                

                cm.CommandType = CommandType.StoredProcedure; 
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally { cm.Connection.Close(); }
            return indicador;

        }
        #endregion

        #region///LIstar Productos///
        public List<producto> ListarProductos()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProducto", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@descripcion", pv.descripcion);
                cm.CommandType = CommandType.StoredProcedure; 
                cnx.Open();

                listaProduc = new List<producto>();
                while (dr.Read())
                {
                    producto pro = new producto();
                    pro.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                    pro.descripcion = dr["descripcion"].ToString();
                    listaProduc.Add(p);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProduc = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaProduc;
        }
        #endregion

        #region///Eliminar Productor////
        public int Eliminarproducto(int id_producto)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProducto", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@id_producto",id_producto );
                cm.Parameters.AddWithValue("@descripcion", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }

        #endregion

        #region ///Editar Producto///
        public int Editarproducto(producto pro)
        {

            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProducto", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@id_producto", pro.id_producto);
                cm.Parameters.AddWithValue("@descripcion", pro.descripcion);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;

        }
        #endregion

        #region///Buscar Proveedor por nombre y direccion///
        public List<provedor> BuscarProductoDatos(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 6);
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@descripcion", dato);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaProduc = new List<producto>();

                while (dr.Read())
                {
                    producto pro = new producto();
                    pro.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                    pro.descripcion = dr["descripcion"].ToString();
                    
                    listaProduc.Add(pro);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProduc = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaProduc;
        }
        #endregion

        #region ///Buscar Por Codigo///
        public provedor BuscarproductoXcodigo(int idprod)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProducto", cnx);
                cm.Parameters.AddWithValue("@", 5);
                cm.Parameters.AddWithValue("@id_producto", idprod);
                cm.Parameters.AddWithValue("@descipcion", "");
                
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                producto pr = new producto();
                pro.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                pro.descripcion = dr["descripcion"].ToString();
              
            }
            catch (Exception e)
            {
                e.Message.ToString();
                pro = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return pro;

        }
        #endregion
    }
}
