using System;

namespace LibraryGestionClientelle
{
    public class ClassVariableGlobal
    {
        public static string connexionString;
        public static string SetConnexion()
        {

            //seteconnexionLoc = "Data Source=SQL5046.site4now.net;Initial Catalog=DB_A54EFD_BaseKapa;User Id=DB_A54EFD_BaseKapa_admin;Password=12345678GL";
            //seteconnexionLoc = "Server =(localdb)\\mssqllocaldb;Database=BaseCTC; Trusted_Connection=True; MultipleActiveResultSets=true";
            //seteconnexionLoc = @"Data Source=127.0.0.1;Initial Catalog=BaseKpBatiment;Integrated Security=false ;User ID=YAN; Password =123456789"; 
            //seteconnexionLoc = @"Data Source=192.168.0.106;Initial Catalog=BaseKpBatiment;Integrated Security=false ;User ID=MANDAL; Password =12345678"; 
            connexionString = @"Data Source=127.0.0.1;Initial Catalog= BaseGestionBistroStandard;User Id=Ushindi;Password= Usher097"; 




            return connexionString;
        }

    }
}
