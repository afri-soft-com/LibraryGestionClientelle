﻿using System;

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
           
            //connexionString = @"Data Source=SQL5092.site4now.net;Initial Catalog=DB_A54EFD_BasiClientIshango;User Id=DB_A54EFD_BasiClientIshango_admin;Password=12345678GL";
           // connexionString = @"Data Source = SQL5069.site4now.net; Initial Catalog = DB_A54EFD_ClientKpshop; User Id = DB_A54EFD_ClientKpshop_admin; Password =12345678GL";
            connexionString = @"Data Source = SQL5069.site4now.net; Initial Catalog = DB_A6D169_BaseClientAlbertin; User Id = DB_A6D169_BaseClientAlbertin_admin; Password = 12345678GL";
            

            //pointapis.afri-soft.org 
            //afrisofttech-002-site22.btempurl.com

            return connexionString;
        }


        public static string seteconnexion()
        {

            //seteconnexionLoc = "Data Source=SQL5046.site4now.net;Initial Catalog=DB_A54EFD_BaseKapa;User Id=DB_A54EFD_BaseKapa_admin;Password=12345678GL";
            //seteconnexionLoc = "Server =(localdb)\\mssqllocaldb;Database=BaseCTC; Trusted_Connection=True; MultipleActiveResultSets=true";
            //seteconnexionLoc = @"Data Source=127.0.0.1;Initial Catalog=BaseKpBatiment;Integrated Security=false ;User ID=YAN; Password =123456789"; 
            //seteconnexionLoc = @"Data Source=192.168.0.106;Initial Catalog=BaseKpBatiment;Integrated Security=false ;User ID=MANDAL; Password =12345678"; 

           // connexionString = @"Data Source=SQL5092.site4now.net;Initial Catalog=DB_A54EFD_BasiClientIshango;User Id=DB_A54EFD_BasiClientIshango_admin;Password=12345678GL";


            //pointapis.afri-soft.org 
            //afrisofttech-002-site22.btempurl.com

            return SetConnexion();
        }

    }
}
