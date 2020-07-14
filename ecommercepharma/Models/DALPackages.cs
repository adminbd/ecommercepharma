using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ecommercepharma.Models.DBmodels;

namespace ecommercepharma.Models
{
    public class DALPackages
    {
        private readonly Conexion conexion = new Conexion();
        private static readonly SqlCommand sqlCommand = new SqlCommand();
        private readonly SqlCommand comando = sqlCommand;


        public List<PaqueteModel> ListarPaquetes()
        {
            DataTable dtPaquetes = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM Paquete ORDER BY Id DESC";
            comando.CommandType = CommandType.Text;

            try
            {
                List<PaqueteModel> paqueteLst = new List<PaqueteModel>();
                dtPaquetes.Load(comando.ExecuteReader());
                if (dtPaquetes.Rows.Count > 0)
                {
                    paqueteLst = (from DataRow dr in dtPaquetes.Rows
                                  select new PaqueteModel()
                                  {
                                      Id = Convert.ToInt32(dr["Id"]),
                                      Descripcion = dr["Descripcion"].ToString(),
                                      Activo = Convert.ToBoolean(dr["Activo"])
                                  }).ToList();
                }
                return paqueteLst;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public string InsertarPaquete(PaqueteModel paquete)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SPinsertarPaquetes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", paquete.Descripcion);
            try
            {
                var result = comando.ExecuteReader();
                if (result.RecordsAffected == -1)
                {
                    return "Error, no se pudo guardar el paquete";
                }
                return "El paquete se guardo correctamente";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
        }

        public int EliminarPaquete(int idPaquete)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SPeliminarPaquete";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdPaquete", idPaquete);
            try
            {
                int res = comando.ExecuteNonQuery();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            finally
            {
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
        }
    }
}
