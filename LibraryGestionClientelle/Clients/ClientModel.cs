using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGestionClientelle.Clients
{
    public class ClientModel
    {
        public int IdClient { get; set; }
        public string PhoneClient { get; set; }
        public string PseudoClient { get; set; }
        public string PinClient { get; set; }
        public string CompteClient { get; set; }
        public string CodeClient { get; set; }
        public string IdCategorieUt { get; set; }
    }
}
