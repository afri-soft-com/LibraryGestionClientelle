using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LibraryGestionClientelle.Article
{
    public class ArticleDataAccessLayer
    {

        public partial class tCatArticle
        {
            public int IdCategorieArtilcle { get; set; }
            public string DesCategorieA { get; set; }
            public string Compte { get; set; }
        }

        public void AjouterArticle(ArticleModel Art)
        {

        string s = "INSERT INTO tArticle" +
                "(CodeArticle, CodeDepartement, DesegnationArticle, CategorieArticle, PrixAchat," +
                " Critique, PrixVente, Compte, UniteEngro, UiniteEnDetaille, QteEnDet, Enstock," +
                " Solde, CompteFournisseur) " +
                "VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @j, @k, @l, @m, @n, @o)";

            string[] r = { Art.CodeArticle, Art.CodeDepartement, Art.DesegnationArticle, 
            Art.CategorieArticle.ToString(), Art.PrixAchat.ToString(), Art.Critique.ToString(), Art.PrixVente.ToString()
            , Art.Compte.ToString(), Art.UniteEngro, Art.UiniteEnDetaille.ToString(), Art.QteEnDet.ToString(),
                Art.Enstock.ToString(), Art.Solde.ToString(), Art.CompteFournisseur.ToString()};

            DateTime[] d = { };
            ClassRequette req = new ClassRequette();

            req.ExecuterSqlAvecDate(ClassVariableGlobal.SetConnexion(), s, r, d); ;

        }


        //Liste des tous les produits

        public List<ArticleModel> ListDesArticles()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    List<ArticleModel> _list = new List<ArticleModel>();

                    string s1 = "SELECT ISNULL(IdArticle, 0) as IdArticle, " +
                        "ISNULL(CodeArticle, '') as CodeArticle, " +
                        "ISNULL(CodeDepartement, '') as CodeDepartement," +
                        "ISNULL(DesegnationArticle, '') as DesegnationArticle, " +
                        "ISNULL(CategorieArticle, 0) as CategorieArticle, " +
                        "ISNULL(PrixAchat, 0.0) as PrixAchat, " +
                        "ISNULL(Critique, 0) as Critique, " +
                        "ISNULL(PrixVente, 0.0) as PrixVente, " +
                        "ISNULL(Compte, 0) as Compte, " +
                        "ISNULL(UniteEngro, '') as UniteEngro, " +
                        "ISNULL(UiniteEnDetaille, '') as UiniteEnDetaille, " +
                        "ISNULL(QteEnDet, 0.0) as QteEnDet, " +
                        "ISNULL(Enstock, 0.0) as Enstock, " +
                        "ISNULL(Solde, 0.0) as Solde, " +
                        "ISNULL(CompteFournisseur, 0) as CompteFournisseur " +
                        "FROM tArticle ";

                    string s = "select * from tArticle";

                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ArticleModel objCust = new ArticleModel();
                        objCust.IdArticle = Convert.ToInt32(_Reader["IdArticle"]);
                        objCust.CodeArticle = _Reader["CodeArticle"].ToString();
                        objCust.DesegnationArticle = _Reader["DesegnationArticle"].ToString();
                        objCust.CategorieArticle = Convert.ToInt32(_Reader["CategorieArticle"]);
                        try { objCust.PrixAchat = Convert.ToDouble(_Reader["PrixAchat"]); } catch { objCust.PrixAchat = 0; }
                        try { objCust.PrixVente = Convert.ToDouble(_Reader["PrixVente"]); } catch { objCust.PrixVente = 0; }

                       
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

        // Methode pour liste les produits par categorie

        public List<ArticleModel> GetStockPListe(string Categorie)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<ArticleModel> _listtStock = new List<ArticleModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    //Compte=310100

                    string s = "SELECT tArticle.CodeArticle AS CodeMarchandise, tArticle.DesegnationArticle AS DesignationMarchandise, tArticle.PrixAchat, tArticle.PrixVente,"+
                        " tCompte.DesignationCompte, tCatArticle.DesCategorieA FROM tArticle INNER JOIN tCompte ON tArticle.Compte = tCompte.NumCompte INNER JOIN"+
                         " tCatArticle ON tArticle.CategorieArticle = tCatArticle.IdCategorieArtilcle WHERE(tCatArticle.IdCategorieArtilcle = @CategorieArticle)";
                    
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    objCommand.Parameters.AddWithValue("@CategorieArticle ", Categorie);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ArticleModel objCust = new ArticleModel();

                        objCust.CodeArticle = (_Reader["CodeMarchandise"]).ToString();
                        objCust.DesegnationArticle = (_Reader["DesignationMarchandise"]).ToString();
                        objCust.PrixAchat = float.Parse((_Reader["PrixAchat"]).ToString());
                        objCust.PrixVente = float.Parse((_Reader["PrixVente"]).ToString());
                        //objCust.CategorieArticle = Convert.ToInt32((_Reader["CategorieArticle"]).ToString());

                        _listtStock.Add(objCust);
                    }

                    return _listtStock;
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

        // Methodes pour selectionner tous les categories d articles

        public List<ArticleModel> GetTousLesArticles()
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<ArticleModel> _listtStock = new List<ArticleModel>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT tArticle.CodeArticle AS CodeMarchandise, tArticle.DesegnationArticle AS DesignationMarchandise, tArticle.PrixAchat, tArticle.PrixVente,"+
                        " tCompte.DesignationCompte, tCatArticle.DesCategorieA FROM tArticle INNER JOIN tCompte ON tArticle.Compte = tCompte.NumCompte INNER JOIN"+
                         " tCatArticle ON tArticle.CategorieArticle = tCatArticle.IdCategorieArtilcle ";

                    SqlCommand objCommand = new SqlCommand(s, Conn);

                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        ArticleModel objCust = new ArticleModel();
                        objCust.CodeArticle = (_Reader["CodeMarchandise"]).ToString();
                        objCust.DesegnationArticle = (_Reader["DesignationMarchandise"]).ToString();
                        objCust.PrixAchat = float.Parse((_Reader["PrixAchat"]).ToString());
                        objCust.PrixVente = float.Parse((_Reader["PrixVente"]).ToString());
                        objCust.CategorieArticle = Int32.Parse((_Reader["CategorieArticle"]).ToString());
                        //objCust.DateDujour = Convert.ToDateTime(_Reader["DesignationClasse"]);
                        _listtStock.Add(objCust);
                    }

                    return _listtStock;
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

        // Methodes pour selection les categories des articles

        public List<tCatArticle> GetCatArticlePListe(string OP)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<tCatArticle> _listCatArticle = new List<tCatArticle>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT IdCategorieArtilcle, DesCategorieA      " +
                                " FROM            tCatArticle  ";


                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tCatArticle objCust = new tCatArticle();
                        objCust.IdCategorieArtilcle = Convert.ToInt32(_Reader["IdCategorieArtilcle"]);
                        objCust.DesCategorieA = (_Reader["DesCategorieA"]).ToString(); ;
                        //objCust.DateDujour = Convert.ToDateTime(_Reader["DesignationClasse"]);
                        _listCatArticle.Add(objCust);
                    }

                    return _listCatArticle;
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

        // Methode pour selectionner toutes les categories des articles

        public List<tCatArticle> GetListCategorieArticle(String index)
        {
            using (SqlConnection Conn = new SqlConnection(ClassVariableGlobal.SetConnexion()))

                try
                {
                    Conn.Open();
                    List<tCatArticle> _list = new List<tCatArticle>();

                    if (Conn.State != System.Data.ConnectionState.Open)
                        Conn.Open();

                    string s = "SELECT * FROM tCatArticle";

                    //SELECT * FROM tClasse
                    SqlCommand objCommand = new SqlCommand(s, Conn);
                    SqlDataReader _Reader = objCommand.ExecuteReader();

                    while (_Reader.Read())
                    {
                        tCatArticle objCust = new tCatArticle();
                        objCust.IdCategorieArtilcle = Convert.ToInt32(_Reader["IdCategorieArtilcle"]);
                        objCust.DesCategorieA = (_Reader["DesCategorieA"]).ToString();
                        objCust.Compte = (_Reader["Compte"].ToString());
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
