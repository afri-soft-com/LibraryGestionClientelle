using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGestionClientelle.Facture
{
    public class FactureModel
    {
        public int IdFacture { get; set; }
        public string RefFacture { get; set; }
        public double QuantiteFacture { get; set; }
        public double MontantFacture { get; set; }
        public string CodeClientFacture { get; set; }
        public DateTime DateFacture { get; set; }
        public double MontantRistourne { get; set; }
    }
}
