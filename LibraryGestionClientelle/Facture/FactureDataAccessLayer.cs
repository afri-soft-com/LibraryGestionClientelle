using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Serialization;

namespace LibraryGestionClientelle.Facture
{
    public class FactureDataAccessLayer
    {
        public partial class TypeRistourne
        { 
            public int IdTypeRistourne { get; set; }
            public string DesignationTypeRistourne { get; set; }
            public string EtatRistourne { get; set; }
        }

        public partial class TauxRistourne
        { 
            public int IdTaux { get; set; }
            public double TauxSurMontant { get; set; }
            public double TauxSurQuantite { get; set; }

            public double tParametreTaux { get; set; }

            public int CompteRistourne { get; set; }
            
        }

        // Methode pour enregistrer une facture

        public int InsertFacture(FactureModel facture)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnexion()))
            {
                connection.Open();

                string query = "INSERT INTO tFacturation"+
                         "(RefFacture, Quantite, Montant, CodeClient,"+
                         "DateFacture, MontantRistourne)VALUES(@RefFacture, @Quantite, @Montant, " +
                         " @CodeClient, @DateFacture, @MontantRistourne)";

                SqlCommand commande = new SqlCommand(query, connection);

                commande.Parameters.AddWithValue("@RefFacture", facture.RefFacture);
                commande.Parameters.AddWithValue("@Quantite", facture.QuantiteFacture);
                commande.Parameters.AddWithValue("@Montant", facture.MontantFacture);
                commande.Parameters.AddWithValue("@CodeClient", facture.CodeClientFacture);
                commande.Parameters.AddWithValue("@DateFacture", facture.DateFacture);
                commande.Parameters.AddWithValue("@MontantRistourne", facture.MontantRistourne);

                return commande.ExecuteNonQuery();

            }
        }

        //Methode pour get tous les factures suivants le client

        public List<FactureModel> GetListeFacture(string codeClient)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<FactureModel> _listeFacture = new List<FactureModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT  * FROM tFacturation where CodeClient=@codeClient";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    objCommand.Parameters.AddWithValue("@codeClient", codeClient);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        FactureModel objCust = new FactureModel();

                        objCust.IdFacture = Convert.ToInt32(_Reader["IdFacture"]);
                        objCust.RefFacture = _Reader["RefFacture"].ToString();
                        objCust.MontantFacture= Convert.ToDouble(_Reader["Quantite"]);
                        objCust.QuantiteFacture = Convert.ToDouble(_Reader["Montant"]);
                        objCust.CodeClientFacture= _Reader["CodeClient"].ToString();
                        objCust.DateFacture = Convert.ToDateTime(_Reader["DateFacture"]);
                        objCust.MontantRistourne = Convert.ToDouble(_Reader["MontantRistourne"]);


                        _listeFacture.Add(objCust);
                    }

                    return _listeFacture;
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

        // Methode pour get les facture de tous les clients

        public List<FactureModel> GetListeFactureTous()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<FactureModel> _listeFacture = new List<FactureModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT  * FROM tFacturation";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        FactureModel objCust = new FactureModel();

                        objCust.IdFacture = Convert.ToInt32(_Reader["IdFacture"]);
                        objCust.RefFacture = _Reader["RefFacture"].ToString();
                        objCust.MontantFacture = Convert.ToDouble(_Reader["Quantite"]);
                        objCust.QuantiteFacture = Convert.ToDouble(_Reader["Montant"]);
                        objCust.CodeClientFacture = _Reader["CodeClient"].ToString();
                        objCust.DateFacture = Convert.ToDateTime(_Reader["DateFacture"]);
                        objCust.MontantRistourne = Convert.ToDouble(_Reader["MontantRistourne"]);


                        _listeFacture.Add(objCust);
                    }

                    return _listeFacture;
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


        // Liste facture par periode par client
        public List<FactureModel> GetListeFactureTouParperiode( string codeClient, DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<FactureModel> _listeFacture = new List<FactureModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "FacturePourLaPeriode";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CodeClient", codeClient);
                    objCommand.Parameters.AddWithValue("@Date1", date1);
                    objCommand.Parameters.AddWithValue("@Date2", date2);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        FactureModel objCust = new FactureModel();

                       // objCust.IdFacture = Convert.ToInt32(_Reader["IdFacture"]);
                        objCust.RefFacture = _Reader["RefFacture"].ToString();
                        try { objCust.MontantFacture = Convert.ToDouble(_Reader["Quantite"]); } catch { objCust.MontantFacture = 0; }
                      
                       
                        objCust.QuantiteFacture = Convert.ToDouble(_Reader["Montant"]);
                        objCust.CodeClientFacture = _Reader["CodeClient"].ToString();
                        try { objCust.DateFacture = Convert.ToDateTime(_Reader["DateFacture"]); } catch { objCust.DateFacture = DateTime.Now; }
                        
                        objCust.MontantRistourne = Convert.ToDouble(_Reader["MontantRistourne"]);


                        _listeFacture.Add(objCust);
                    }

                    return _listeFacture;
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


        // Somme des points facture par periode par client

        public List<FactureModel> GetSommePointsFactureTouParperiode(string codeClient, DateTime date1, DateTime date2)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<FactureModel> _listeFacture = new List<FactureModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SommeDePointFacturePourUnePeriode";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@CodeClient", codeClient);
                    objCommand.Parameters.AddWithValue("@Date1", date1);
                    objCommand.Parameters.AddWithValue("@Date2", date2);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        FactureModel objCust = new FactureModel();

                        // objCust.IdFacture = Convert.ToInt32(_Reader["IdFacture"]);
                        objCust.RefFacture = _Reader["RefFacture"].ToString();
                        try { objCust.MontantFacture = Convert.ToDouble(_Reader["Quantite"]); } catch { objCust.MontantFacture = 0; }


                        objCust.QuantiteFacture = Convert.ToDouble(_Reader["Montant"]);
                        objCust.CodeClientFacture = _Reader["CodeClient"].ToString();
                        try { objCust.DateFacture = Convert.ToDateTime(_Reader["DateFacture"]); } catch { objCust.DateFacture = DateTime.Now; }

                        objCust.MontantRistourne = Convert.ToDouble(_Reader["MontantRistourne"]);


                        _listeFacture.Add(objCust);
                    }

                    return _listeFacture;
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

        

        // Enregistrement du type de ristourne

        public int InsertTypeRistourne(TypeRistourne typeRistourne)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnexion()))
            {
                connection.Open();

                string query = "INSERT INTO tTypeRistourne"+
                                " (DesignationTypeRistourne, EtatRistourne)"+
                                " VALUES(@DesignationTypeRistourne, @EtatRistourne)";

                
                SqlCommand commande = new SqlCommand(query, connection);

                commande.Parameters.AddWithValue("@DesignationTypeRistourne",typeRistourne.DesignationTypeRistourne );
                commande.Parameters.AddWithValue("@EtatRistourne", typeRistourne.EtatRistourne);

                return commande.ExecuteNonQuery();
            }
        }

        //Get la liste des etats de ristourne

        public List<TypeRistourne> GetListeTypeRistourne()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<TypeRistourne> _listeEtatRistourne = new List<TypeRistourne>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    //string s = "SELECT  nom AS [@nom], postnom AS [@postnom], matricule AS [@matricule]," +
                    //    " dateAbonnement AS [@dateAbonnement], nombreAmpere AS [@nombreAmpere]"+
                    //         " FROM enregistrement";
                    string s = "SELECT  * FROM tTypeRistourne";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        TypeRistourne objCust = new TypeRistourne();

                        objCust.IdTypeRistourne = Convert.ToInt32(_Reader["IdTypeRistourne"]);
                        objCust.DesignationTypeRistourne= _Reader["DesignationTypeRistourne"].ToString();
                        objCust.EtatRistourne = _Reader["EtatRistourne"].ToString();

                        _listeEtatRistourne.Add(objCust);
                    }

                    return _listeEtatRistourne;
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

        // Methode pour enregistrer le taux sur le systeme

        public int InsertTauxRistourne(TauxRistourne taux)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnexion()))
            {
                connection.Open();

                string query = "INSERT INTO tParametreTaux"+
                               " (TauxRistourneMontant, TauxRistourneQuantite,CompteRistourne)" +
                                " VALUES(@TauxRistourneMontant, @TauxRistourneQuantite,@CompteRistourne)";

                SqlCommand commande = new SqlCommand(query, connection);

                commande.Parameters.AddWithValue("@TauxRistourneMontant", taux.TauxSurMontant);
                commande.Parameters.AddWithValue("@TauxRistourneQuantite", taux.TauxSurQuantite);
                commande.Parameters.AddWithValue("@CompteRistourne", taux.CompteRistourne);

                return commande.ExecuteNonQuery();

            }

        }

        public int ModifierParametreTaux(TauxRistourne taux)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnexion()))
            {
                connection.Open();

                string query = "UPDATE       tParametreTaux " +
 " SET TauxRistourneMontant = @TauxRistourneMontant, TauxRistourneQuantite = @TauxRistourneQuantite, CompteRistourne = @CompteRistourne " +
" WHERE(IdParametre = 1)";

                SqlCommand commande = new SqlCommand(query, connection);

                commande.Parameters.AddWithValue("@TauxRistourneMontant", taux.TauxSurMontant);
                commande.Parameters.AddWithValue("@TauxRistourneQuantite", taux.TauxSurQuantite);
                commande.Parameters.AddWithValue("@CompteRistourne", taux.CompteRistourne);

                return commande.ExecuteNonQuery();

            }

        }

        // Methode pour get les parametres du taux

        public List<TauxRistourne> GetListeTauxRistourne()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<TauxRistourne> _listeTauxRistourne = new List<TauxRistourne>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT  * FROM tParametreTaux";

                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        TauxRistourne objCust = new TauxRistourne();

                        objCust.IdTaux = Convert.ToInt32(_Reader["IdParametre"]);
                        objCust.TauxSurMontant = Convert.ToDouble(_Reader["TauxRistourneMontant"]);
                        objCust.TauxSurQuantite = Convert.ToDouble(_Reader["TauxRistourneQuantite"]);
                        objCust.CompteRistourne = Convert.ToInt32(_Reader["CompteRistourne"]);

                        _listeTauxRistourne.Add(objCust);
                    }

                    return _listeTauxRistourne;
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

        // Methode pour selectionner la somme des points de chaque client par rapport à son code
        public double GetLesPoints(string codeClient)
        {
            double sommeDesPoints = 0;

            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT SUM(MontantRistourne) as somme FROM tFacturation WHERE CodeClient=@codeClient";


                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    objCommand.Parameters.AddWithValue("@codeClient", codeClient);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                       

                        sommeDesPoints = Convert.ToDouble(_Reader["somme"]);

                    }

                    return sommeDesPoints;

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
