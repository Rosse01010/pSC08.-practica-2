using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace pSC08
{
    public class cnn
    {
        public static string db = @"Data Source=REUDYS; 
                                    Initial Catalog=DBpractica04; 
                                    User ID=sa;
                                    Password=reyballoon
                                   ";
    }

    public class Busco
    {
        public static string BuscarDepartamento(string numDepto)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            string stQuery = "SELECT nombredepartamento " +
                             "  FROM DEPARTAMENTO " +
                             " WHERE IDDEPARTAMENTO ='" + numDepto + "'";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                return rcd["nombredepartamento"].ToString();
            }

            return null;
        }

        public static string BuscarFabrica(string numFabrica)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            string stQuery = "SELECT NOMBREDEFABRICA " +
                             "  FROM FABRICA " +
                             " WHERE IDFABRICA ='" + numFabrica + "'";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);   // enviamos el script al motor de SQL
            SqlDataReader rcd = cmd.ExecuteReader();  // ejecuta el script que le enviamos

            if (rcd.Read())  // aqui pregunta HasRow = true
            {
                return rcd["NOMBREDEFABRICA"].ToString(); // retorna el valor del campo registrado en la tabla
            }

            return null;  // retorna nulo si no encuentra el registro en la tabla
        }

        
    }
    
}
