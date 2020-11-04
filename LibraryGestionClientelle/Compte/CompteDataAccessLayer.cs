using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryGestionClientelle.Compte
{
    public class CompteDataAccessLayer
    {
        public List<CompteModel> ListeDeComptes()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<CompteModel> _list = new List<CompteModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();


                    String s1 = " SELECT ISNULL(NumCompte, 0) as NumCompte, " +
                        "ISNULL(DesignationCompte, '') as DesignationCompte, " +
                        "ISNULL(GroupeCompte, 0) as GroupeCompte, " +
                        "ISNULL(Unite, 0) as Unite, " +
                        "ISNULL(Solde, '') as Solde  FROM tCompte";

                    SqlCommand objCommand = new SqlCommand(s1, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        CompteModel objCust = new CompteModel();
                        objCust.NumCompte = Convert.ToInt32(_Reader["NumCompte"]);
                        objCust.DesignationCompte = _Reader["DesignationCompte"].ToString();
                        objCust.GroupeCompte = Convert.ToInt32(_Reader["GroupeCompte"]);
                        objCust.Unite = Convert.ToInt32(_Reader["Unite"]);
                        objCust.Solde = _Reader["Solde"].ToString();
                        _list.Add(objCust);
                    }

                    return _list;
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
