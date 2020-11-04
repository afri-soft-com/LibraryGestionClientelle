using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGestionClientelle.MvtCompte
{
    public class MvtCompteModel
    {
        public int IdMouvement { get; set; }
        public string NumCompte { get; set; }
        public string NumOperation { get; set; }
        public string Details { get; set; }
        public double Qte { get; set; }
        public double Entree { get; set; }
        public double Sortie { get; set; }
        public string CodeProject { get; set; }
    }
}
