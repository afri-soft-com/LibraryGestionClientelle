using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGestionClientelle.RapportPoint
{
   public class DashBoardClient
    {


        public string PhoneClient { get; set; }
        public string PseudoClient { get; set; }
       
        
        public string CodeClient { get; set; }

        public double PointConvertie { get; set; }
        public double PointFacture { get; set; }

        public double BalanseDePoint { get; set; }
        public double PointInitial { get; set; }

    }
}
