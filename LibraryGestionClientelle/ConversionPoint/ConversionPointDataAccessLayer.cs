using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LibraryGestionClientelle.ConversionPoint
{
   public class ConversionPointDataAccessLayer
    {

        public string DernierCon()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.seteconnexion()))

                try
                {
                    //  Conn.Open();
                    int dernier_operation = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "SELECT        MAX(IdConversion)  Dernier " +
" FROM tConversionPoint ";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.Text;
                    
                    dernier_operation = int.Parse(objCommand.ExecuteScalar().ToString()) + 1;
                    return "CV" + dernier_operation.ToString();
                }
                catch
                {
                    return "CV";
                    throw;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            Conn.Dispose();
                        }
                    }
                }
        }



        public ConversionPointModel NouvelleConversion(ConversionPointModel Obj)
        {
            try
            {
                // string dernier_EB = DernierEtatBesoin() + "EB" + InitialNomUtilisateur;
                string s = "INSERT INTO tConversionPoint " +
                         " (CodeConversion,CodeClient,  PointConvertie, RefOperation,DateOperation) " +
" VALUES(@a,@b, @c,@d,@da) ";

                //Em.CodeEtatdeBesoin, change par dernier_EB

                string[] r = { DernierCon(), Obj.CodeClient, Obj.PointConvertie, Obj.RefOperation,  };

                DateTime[] d = { DateTime.Now };
                // Verification de solde 
                //double solde.
                //Clients.ClientDataAccessLayer Dal = new Clients.ClientDataAccessLayer();


                ClassRequette req = new ClassRequette();

                req.ExecuterSqlAvecDate(ClassVariableGlobal.seteconnexion(), s, r, d); ;
                //EtatBesoinModel etat = new EtatBesoinModel();
                //etat.CodeEtatdeBesoin = dernier_EB;
                //etat.DesignationEtatDeBesion = Em.DesignationEtatDeBesion;

                return Obj;
            }
            catch
            {
                return null ;
                throw;
            }

        }



        public int AnnulerConversion( string CodeConversion)
        {
            try
            {
                // string dernier_EB = DernierEtatBesoin() + "EB" + InitialNomUtilisateur;
                string s = " DELETE FROM tConversionPoint " +
                         "  WHERE  CodeConversion=@a ";


                //Em.CodeEtatdeBesoin, change par dernier_EB

                string[] r = { CodeConversion };

                DateTime[] d = { DateTime.Now };
                // Verification de solde 
                //double solde.
                //Clients.ClientDataAccessLayer Dal = new Clients.ClientDataAccessLayer();


                ClassRequette req = new ClassRequette();

                req.ExecuterSqlAvecDate(ClassVariableGlobal.seteconnexion(), s, r, d); ;
                //EtatBesoinModel etat = new EtatBesoinModel();
                //etat.CodeEtatdeBesoin = dernier_EB;
                //etat.DesignationEtatDeBesion = Em.DesignationEtatDeBesion;

                return 1;
            }
            catch
            {
                return 0;
                throw;
            }

        }





    }
}
