using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ecommercepharma.Models
{
    public class Conexion
    {
        //private static readonly string CadenaConexion = "Data Source=ANTONIOV24;Initial Catalog=Pharma;User Id=pharmadmin;Password=Admin$123.;Integrated Security=True";
        private static readonly string CadenaConexion = "workstation id=PharmaDBUNI.mssql.somee.com;packet size=4096;user id=sntobi24_SQLLogin_1;pwd=cwyaawruje;data source=PharmaDBUNI.mssql.somee.com;persist security info=False;initial catalog=PharmaDBUNI";
        private readonly SqlConnection conexion = new SqlConnection(CadenaConexion);

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
