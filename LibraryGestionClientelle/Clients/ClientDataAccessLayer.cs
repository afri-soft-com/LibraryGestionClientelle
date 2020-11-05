using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryGestionClientelle.Clients
{
    public class ClientDataAccessLayer
    {
        public partial class tTest
        { 
            public int Id { get; set; }
            public string ToSave { get; set; }
        }

        // Methode for inserting a new client in database

        public int InsertNewClient(ClientModel clientModel)
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnexion()))
            {
                  connection.Open();

                    

                    string query = "INSERT INTO tClients" +
                                    "(PhoneClient, PseudoClient, PinClient, CompteClient, CodeClient, IdCategorieUt)" +
                                    "VALUES(@PhoneClient, @PseudoClient, @PinClient, @CompteClient, @CodeClient, @IdCategorieUt)";

                    SqlCommand commande = new SqlCommand(query, connection);
                    int code_client = getDernierClient();

                    commande.Parameters.AddWithValue("@PhoneClient", clientModel.PhoneClient);
                    commande.Parameters.AddWithValue("@PseudoClient", clientModel.PseudoClient);
                    commande.Parameters.AddWithValue("@PinClient", clientModel.PinClient);
                    commande.Parameters.AddWithValue("@CompteClient", clientModel.CompteClient);
                    commande.Parameters.AddWithValue("@CodeClient", code_client);
                    commande.Parameters.AddWithValue("@IdCategorieUt", clientModel.IdCategorieUt);
                                   

                    return commande.ExecuteNonQuery();
              

            }
        }

        public void InsertTest(tTest test) 
        {
            using (SqlConnection connection = new SqlConnection(ClassVariableGlobal.SetConnexion()))
            {
                connection.Open();

                string query = "INSERT INTO tTest(SavedTest) VALUES(@a)";

                //SqlCommand commande = new SqlCommand(query, connection);

                //commande.Parameters.AddWithValue("@SavedTest", test.ToSave);

                string[] r = { test.ToSave };
                DateTime[] rd = {DateTime.UtcNow};

                ClassRequette req = new ClassRequette();

                req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnexion(), query, r, rd);


            }
        }

        // Metode pour retrieve all the clients from database 

        public List<ClientModel> GetListeClient()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<ClientModel> _listeClient = new List<ClientModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    //string s = "SELECT  nom AS [@nom], postnom AS [@postnom], matricule AS [@matricule]," +
                    //    " dateAbonnement AS [@dateAbonnement], nombreAmpere AS [@nombreAmpere]"+
                    //         " FROM enregistrement";
                    string s = "SELECT  * FROM tClients";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ClientModel objCust = new ClientModel();

                        objCust.IdClient = Convert.ToInt32(_Reader["IdClient"].ToString());
                        objCust.PhoneClient = _Reader["PhoneClient"].ToString();
                        objCust.PseudoClient = _Reader["PseudoClient"].ToString();
                        objCust.PinClient = _Reader["PinClient"].ToString();
                        objCust.CompteClient = _Reader["CompteClient"].ToString();
                        objCust.CodeClient = _Reader["CodeClient"].ToString();

                        _listeClient.Add(objCust);
                    }

                    return _listeClient;
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

        // Methode de login pour le client

        public List<ClientModel> GetLogin(string phone_number)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<ClientModel> _listeClient = new List<ClientModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    //string s = "SELECT  nom AS [@nom], postnom AS [@postnom], matricule AS [@matricule]," +
                    //    " dateAbonnement AS [@dateAbonnement], nombreAmpere AS [@nombreAmpere]"+
                    //         " FROM enregistrement";
                    string s = "SELECT  * FROM tClients WHERE PhoneClient = @PhoneNumber";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    objCommand.Parameters.AddWithValue("@PhoneNumber", phone_number);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ClientModel objCust = new ClientModel();

                        objCust.IdClient = Convert.ToInt32(_Reader["IdClient"].ToString());
                        objCust.PhoneClient = _Reader["PhoneClient"].ToString();
                        objCust.PseudoClient = _Reader["PseudoClient"].ToString();
                        objCust.PinClient = _Reader["PinClient"].ToString();
                        objCust.CompteClient = _Reader["CompteClient"].ToString();
                        objCust.CodeClient = _Reader["CodeClient"].ToString();

                        _listeClient.Add(objCust);
                    }

                    return _listeClient;
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

        // Methode pour verifier si l utilisateur existe dans le systeme

        public bool isUserExist(string isUserPhoneExist)
        {
            // dbConnector objConn = new dbConnector();
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();


                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT PhoneClient FROM tClients WHERE  (PhoneClient = @phonenumber)  ";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@phonenumber", isUserPhoneExist); ;
                    //objCommand.Parameters.AddWithValue("@IsPaging", IsPaging);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    if (_Reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


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

        // Formation du code de l utilisateur

        public int getDernierClient()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();


                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT MAX(IdCLient) AS maxIDClient FROM tClients ";
                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    int dernier = 0;
                    if (_Reader.Read())
                    {

                        dernier = Convert.ToInt32(_Reader["maxIDClient"]);
                        return dernier + 1;
                    }
                    else
                    {
                        return 1;
                    }



                }
                catch
                {
                    return 1;
                    // throw; 
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
