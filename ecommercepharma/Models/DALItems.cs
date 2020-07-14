using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ecommercepharma.Models.DBmodels;

namespace ecommercepharma.Models
{
    public class DALItems
    {
        private readonly Conexion conexion = new Conexion();
        private static readonly SqlCommand sqlCommand = new SqlCommand();
        private readonly SqlCommand Comando = sqlCommand;

        public List<ItemModel> ListarArticulos()
        {
            DataTable dtArticulos = new DataTable();
            Comando.Connection = conexion.AbrirConexion();
            Comando.CommandText = "SELECT * FROM Items";
            Comando.CommandType = CommandType.Text;

            try
            {
                List<ItemModel> articulosLst = new List<ItemModel>();
                dtArticulos.Load(Comando.ExecuteReader());
                if (dtArticulos.Rows.Count > 0) {
                    articulosLst = (from DataRow dr in dtArticulos.Rows
                                    select new ItemModel()
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        IdCategory = Convert.ToInt32(dr["IdCategory"]),
                                        IdSeller = Convert.ToInt32(dr["IdSeller"]),
                                        Name = dr["Name"].ToString(),
                                        Description = dr["Description"].ToString(),
                                        Price = Convert.ToDecimal(dr["Price"]),
                                        Stock = Convert.ToInt32(dr["Stock"]),
                                        Detail = dr["Detail"].ToString(),
                                        CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                                        IsActive = Convert.ToBoolean(dr["IsActive"])
                                    }).ToList();
                }
                return articulosLst;

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

    }
}
