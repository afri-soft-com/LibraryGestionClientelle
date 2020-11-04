using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGestionClientelle.Compte
{
    public class CompteModel
    {
        public int NumCompte { get; set; }
        public string DesignationCompte { get; set; }
        public int GroupeCompte { get; set; }
        public int Unite { get; set; }
        public string Solde { get; set; }
    }
}
