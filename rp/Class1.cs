using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rp
{
    internal class Class1
    {
        SqlConnection con = new SqlConnection("Server = db.edu.cchgeu.ru; User =201s_Ermolaev; Password =Qq123123; DataBase = 201s_Ermolaev ");
        
        public void openConnection()
        {
            con.Open(); 
        }
        public void closeConnection()
        { 
            con.Close(); 
        }
        public SqlConnection GetConnection()
        { 
            return con; 
        }
    }
}
