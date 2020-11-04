using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryGestionClientelle.MvtCompte
{
    public class MvtCompteDataAccessLayer
    {
        public void AjouterMvtCompte(MvtCompteModel MvtC)
        {
            string s = " INSERT INTO tMvtCompte " +
                "(NumCompte, NumOperation, Details, Qte, Entree, Sortie, CodeProject) " +
                "VALUES(@a, @b, @c, @d, @e, @f, @g)";

            string[] r = { MvtC.NumCompte, MvtC.NumOperation, MvtC.Details.ToString(),
                MvtC.Qte.ToString(), MvtC.Entree.ToString(), MvtC.Sortie.ToString(), MvtC.CodeProject };

            DateTime[] d = { };
            ClassRequette req = new ClassRequette();

            req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnexion(), s, r, d);
        }

        public int DernierMvtCompte()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    int dernier_mvt_compte = 0;

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();
                    string s = "select max(IdMouvement) as IdMouvement from tMvtCompte";
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    //SqlDataReader _Reader = objCommand.ExecuteReader();

                    //while (_Reader.Read())
                    //{
                    //    dernier_mvt_compte = Convert.ToInt32(_Reader["IdMouvement"].ToString());
                    //}
                    dernier_mvt_compte = int.Parse(objCommand.ExecuteScalar().ToString());

                    return dernier_mvt_compte;
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
