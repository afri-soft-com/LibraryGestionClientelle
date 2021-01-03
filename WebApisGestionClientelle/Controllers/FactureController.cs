using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryGestionClientelle.Facture;
using Microsoft.AspNetCore.Mvc;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        //Post Type ristourne
        [HttpPost]
        public string Create(FactureDataAccessLayer.TypeRistourne objCust)
        {
            try
            {
                FactureDataAccessLayer tEnregistrementClient = new FactureDataAccessLayer();
                Int32 message = 0;

                if (objCust.DesignationTypeRistourne != null)
                    message = tEnregistrementClient.InsertTypeRistourne(objCust);

                return message.ToString();

            }
            catch
            {
                throw;
            }
        }

        //Post la facture elle meme


        [HttpPost]
        public string CreateFacture(FactureModel objCust)
        {
            try
            {
                FactureDataAccessLayer tEnregistrementFacture = new FactureDataAccessLayer();
                Int32 message = 0;

                if (objCust.RefFacture != null)
                    message = tEnregistrementFacture.InsertFacture(objCust);

                return message.ToString();

            }
            catch
            {
                throw;
            }
        }

        //Post le taux de ristourne
        [HttpPost]
        public string CreateTaux(FactureDataAccessLayer.TauxRistourne objCust)
        {
            try
            {
                FactureDataAccessLayer tEnregistrementClient = new FactureDataAccessLayer();
                Int32 message = 0;
                
                    message = tEnregistrementClient.InsertTauxRistourne(objCust);

                return message.ToString();

            }
            catch
            {
                throw;
            }
        }


        //Post le taux de ristourne
        [HttpPost]
        public string ModifierParametreRistourne(FactureDataAccessLayer.TauxRistourne objCust)
        {
            try
            {
                FactureDataAccessLayer tEnregistrementClient = new FactureDataAccessLayer();
                Int32 message = 0;

                message = tEnregistrementClient.ModifierParametreTaux(objCust);

                return message.ToString();

            }
            catch
            {
                throw;
            }
        }

        //Get tous from typeRistourne
        [HttpGet]
        public IEnumerable<FactureDataAccessLayer.TypeRistourne> GetListeTypeRistourne()
        {
            try
            {
                FactureDataAccessLayer factureDataAccess = new FactureDataAccessLayer();
                List<FactureDataAccessLayer.TypeRistourne> listeClients = factureDataAccess.GetListeTypeRistourne();

                return listeClients;
            }
            catch
            {
                throw;
            }
        }

        //Get tous from facture

        [HttpGet]
        public IEnumerable<FactureModel> GetLesFacturesTous()
        {
            try
            {
                FactureDataAccessLayer factureDataAccess = new FactureDataAccessLayer();
                List<FactureModel> listeFactures = factureDataAccess.GetListeFactureTous();

                return listeFactures;
            }
            catch
            {
                throw;
            }
        }

        //Get les factures from Facture suivant le code client

        [HttpGet]
        public IEnumerable<FactureModel> GetLesFacturesParClient(string codeClient)
        {
            try
            {
                FactureDataAccessLayer factureDataAccess = new FactureDataAccessLayer();
                List<FactureModel> listeFactres = factureDataAccess.GetListeFacture(codeClient);

                return listeFactres;
            }
            catch
            {
                throw;
            }
        }

        //Get les factures from Facture suivant le code client et par periode
        [HttpGet]
        public IEnumerable<FactureModel> GetLesFacturesParClientParPeriode(string codeClient, DateTime date1, DateTime date2)
        {
            try
            {
                FactureDataAccessLayer factureDataAccess = new FactureDataAccessLayer();
                List<FactureModel> listeFactres = factureDataAccess.GetListeFactureTouParperiode(codeClient, date1, date2);

                return listeFactres;
            }
            catch
            {
                throw;
            }
        }

        //Get les factures from Facture suivant le code client

        [HttpGet]
        public IEnumerable<FactureDataAccessLayer.TauxRistourne> GetLesTauxRistourne()
        {
            try
            {
                FactureDataAccessLayer tauxDataAccess = new FactureDataAccessLayer();
                List<FactureDataAccessLayer.TauxRistourne> listeTaux = tauxDataAccess.GetListeTauxRistourne();

                return listeTaux;
            }
            catch
            {
                throw;
            }
        }

        //Get les points du client suivant son code

        [HttpGet]

        public double GetLesPointsDuClient(string codeClient)
        {
            double sommeDesPoints = 0;
            try
            {
                FactureDataAccessLayer factureDataAccess = new FactureDataAccessLayer();
                sommeDesPoints = factureDataAccess.GetLesPoints(codeClient);

                return sommeDesPoints;
            }
            catch
            {
                throw;
            }
        }

    }
}