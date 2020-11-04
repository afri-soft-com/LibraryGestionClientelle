using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGestionClientelle.Article
{
    public class ArticleModel
    {
        public int IdArticle { get; set; }
        public string CodeArticle { get; set; }
        public string CodeDepartement { get; set; }
        public string DesegnationArticle { get; set; }
        public int CategorieArticle { get; set; }
        public double PrixAchat { get; set; }
        public int Critique { get; set; }
        public double PrixVente { get; set; }
        public int Compte { get; set; }
        public string UniteEngro { get; set; }
        public string UiniteEnDetaille { get; set; }
        public double QteEnDet { get; set; }
        public double Enstock { get; set; }
        public double Solde { get; set; }
        public int CompteFournisseur { get; set; }
    }
}
