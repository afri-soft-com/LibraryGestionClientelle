using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LibraryGestionClientelle.Clients;
using System.Web.Http.Description;
using System.Reflection;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // Metodes post (Enregistrement des clients)

        [HttpPost]
        public string Create(ClientModel objCust)
        {
            try
            {
                ClientDataAccessLayer tEnregistrementClient = new ClientDataAccessLayer();
                Int32 message = 0;

                if (objCust.PhoneClient != null)
                    message = tEnregistrementClient.InsertNewClient(objCust);

                return message.ToString();

            }
            catch
            {
                throw;
            }
        }

        // Methode get (select clients)

        [HttpGet]

        public IEnumerable<ClientModel> GetListeClient()
        {
            try
            {
                ClientDataAccessLayer clientDataAccess = new ClientDataAccessLayer();
                List<ClientModel> listeClients = clientDataAccess.GetListeClient();

                return listeClients;
            }
            catch
            {
                throw;
            }
        }

        // Methode pour se login

        [HttpGet]
        public IEnumerable<ClientModel> GetSeConnecter(string phone_number)
        {
            try
            {
                ClientDataAccessLayer clientDataAccess = new ClientDataAccessLayer();

                List<ClientModel> listeClients = clientDataAccess.GetLogin(phone_number);

                return listeClients;
            }
            catch
            {
                throw;
            }
        }

        //methode pour verifier si le username existe
        [HttpGet]
        public bool IsPhoneExist(string isPhoneExist)
        {

            try
            {
                ClientDataAccessLayer objCrdClient = new ClientDataAccessLayer();
                bool message = false;
                message = objCrdClient.isUserExist(isPhoneExist);
                return message;

            }
            catch
            {
                throw;
            }
        }
    }
}