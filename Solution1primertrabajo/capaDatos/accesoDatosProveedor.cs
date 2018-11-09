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
    
    public class accesoDatosProveedor
    {
        SqlConnection cnx; //conexion
        provedor p = new provedor(); //capa de entidad
        Conexion cn = new Conexion();//para la cobexion
        SqlCommand cm = null; //para los comando sql
        int indicador = 0; //variablae k indica si el metodo se ejecuto
        SqlDataReader dr=null;
        List<provedor> listaProv = null;

        #region ///Insertar Proveedor///
        public int insertarProveedor(provedor pv)
        {
           
            try
            {
                SqlConnection cnx = cn.conectar(); //conexion

                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.Parameters.AddWithValue("@nombre", pv.nombre);
                cm.Parameters.AddWithValue("@direccion", pv.direccion);
                cm.Parameters.AddWithValue("@telefono", pv.telefono);

                cm.CommandType = CommandType.StoredProcedure; //PARA EL PROCEDIMIENTO ALMACENADO
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

        #region///LIstar Proveedores///
        public List<provedor> ListarProveedores()
           {
            try{ 
                   SqlConnection cnx =cn.conectar();
                   cm= new SqlCommand("nuevoProveedor",cnx); 
                   cm.Parameters.AddWithValue("@b",2);
                   cm.Parameters.AddWithValue("@idcodigoP", "");
                   cm.Parameters.AddWithValue("@nombre", pv.nombre);
                   cm.Parameters.AddWithValue("@direccion", pv.direccion);
                   cm.Parameters.AddWithValue("@telefono", pv.telefono);
                   cm.CommandType = CommandType.StoredProcedure; //PARA EL PROCEDIMIENTO ALMACENADO
                   cnx.Open();

               listaProv= new List<provedor>();
               while(dr.Read())
                {
                  provedor p= new provedor();
                  p.idcodigoP=Convert.ToInt32(dr["idcodigoP"].ToString());
                  p.nombre =dr["nombre"].ToString();
                  p.direccion=dr["direccion"].ToString();
                  p.telefono=dr["telefono"].ToString();
                  listaProv.Add(p);
                } 
              }
              catch (Exception e){
              e.Message.ToString();
              listaProv=null;  
          }     
           finally 
          {
          cm.Connection.Close();
          }
         return listaProv;
    }
        #endregion

        #region///Eliminar Proveedor////
        public int EliminarProveedor(int idproveedor )
{
   try
    {
     SqlConnection cnx =cn.conectar();
     cm= new SqlCommand("nuevoProveedor",cnx); 
     cm.Parameters.AddWithValue("@b",4);
     cm.Parameters.AddWithValue("@idcodigoP", idproveedor);
     cm.Parameters.AddWithValue("@nombre", "");
     cm.Parameters.AddWithValue("@direccion", "");
     cm.Parameters.AddWithValue("@telefono", "");
     
      cm.CommandType = CommandType.StoredProcedure;
      cnx.Open();
      cm.ExecuteNonQuery();
      indicador=1;
    }
    catch (Exception e)
    {
       e.Message.ToString();
       indicador=0;
    }
    finally
    {
     cm.Connection.Close();
    } 
  return indicador;
}

        #endregion

        #region ///Editar Proveedor///
        public int EditarProveedor(provedor pv)
{

    try
    {
        SqlConnection cnx = cn.conectar();
        cm = new SqlCommand("nuevoProveedor", cnx);
        cm.Parameters.AddWithValue("@b", 3);
        cm.Parameters.AddWithValue("@idcodigoP", pv.idcodigoP);
        cm.Parameters.AddWithValue("@nombre", pv.nombre);
        cm.Parameters.AddWithValue("@direccion", pv.direccion);
        cm.Parameters.AddWithValue("@telefono", pv.telefono);

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
        public List<provedor> BuscarProveedorDatos(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@b", 6);
                cm.Parameters.AddWithValue("@idcodigoP", "");
                cm.Parameters.AddWithValue("@nombre", dato);
                cm.Parameters.AddWithValue("@direccion", dato);
                cm.Parameters.AddWithValue("@telefono", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaProv = new List<provedor>();

                while (dr.Read())
                {
                    provedor p = new provedor();
                    p.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                    p.nombre = dr["nombre"].ToString();
                    p.direccion = dr["direccion"].ToString();
                    p.telefono = dr["telefono"].ToString();
                    listaProv.Add(p);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaProv = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaProv;
        }
        #endregion

        #region ///Buscar Por Codigo///
        public provedor BuscarProveedorXcodigo(int idpro)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoProveedor", cnx);
                cm.Parameters.AddWithValue("@", 5);
                cm.Parameters.AddWithValue("@idcodigoP", idpro);
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@direccion", "");
                cm.Parameters.AddWithValue("@telefono", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                provedor p = new provedor();
                p.idcodigoP = Convert.ToInt32(dr["idcodigoP"].ToString());
                p.nombre = dr["nombre"].ToString();
                p.direccion = dr["direccion"].ToString();
                p.telefono = dr["telefono"].ToString();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                p = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return p;

        }
        #endregion


    }
}
