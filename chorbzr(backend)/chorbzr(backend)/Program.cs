using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using chorbzr.BL; 
using chorbzr.DLInterface;
using chorbzr;


namespace chorbzr_backend_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserSignUI userUI = new UserSignUI();
            userUI.Start();
        }
       
    }
}
