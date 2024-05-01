using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConsole.DL.DB
{
    public class ConnectionDB
    {
        public static string GetConnectionString()
        {
            return "workstation id=CryptoYard.mssql.somee.com;packet size=4096;user id=XDGAMING_SQLLogin_1;pwd=12345678;data source=CryptoYard.mssql.somee.com;persist security info=False;initial catalog=CryptoYard;";
            //  return "Data Source=26.214.37.57,1433;Initial Catalog=CryptoYard;User ID=Crypto;Password=123;";
        }
    }
}
