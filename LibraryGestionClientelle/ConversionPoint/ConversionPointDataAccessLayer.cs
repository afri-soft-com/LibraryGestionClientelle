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

        // Liste point converti par periode par client

        public List<ConversionPointModel> GetListePointsConvertisTouParperiode(string codeClient, DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<ConversionPointModel> _listePointConvertis = new List<ConversionPointModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "ConversionPourLaPeriode";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CodeClient", codeClient);
                    objCommand.Parameters.AddWithValue("@Date1", date1);
                    objCommand.Parameters.AddWithValue("@Date2", date2);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ConversionPointModel objCust = new ConversionPointModel();

                        // objCust.IdFacture = Convert.ToInt32(_Reader["IdFacture"]);
                        objCust.CodeClient = _Reader["codeClient"].ToString();
                        objCust.CodeConversion = (_Reader["codeConversion"].ToString());
                        try { objCust.DateOperation = (_Reader["dateOperation"].ToString()); } catch { objCust.DateOperation = DateTime.Now.ToString(); }
                        try { objCust.PointConvertie = _Reader["pointConvertie"].ToString(); } catch { objCust.PointConvertie = "0"; }
                        objCust.RefOperation = (_Reader["refOperation"].ToString());


                        _listePointConvertis.Add(objCust);
                    }

                    return _listePointConvertis;
                }
                catch
                {
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


    }
}
