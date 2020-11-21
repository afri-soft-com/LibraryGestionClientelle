using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryGestionClientelle.RapportPoint;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashBoarClientController : ControllerBase
    {

        [HttpGet]

        public DashBoardClient GetDashBoardSituationDuClient( string CodeClient ,DateTime date1 , DateTime date2)
        {
            try
            {
                DashBoardDattaAcceessLayer clientDataAccess = new DashBoardDattaAcceessLayer();
                DashBoardClient listeClients = clientDataAccess.totalAficherDashBoardCleient(CodeClient, date1, date2);

                return listeClients;
            }
            catch
            {
                throw;
            }
        }


        [HttpGet]

        public DashBoardClient GetDashBoardSituationGenerale( DateTime date1, DateTime date2)
        {
            try
            {
                DashBoardAdminDataAccessLayer GenDataAccess = new DashBoardAdminDataAccessLayer();
                DashBoardClient Model = GenDataAccess.AfficherSituationGgeneralAdmin ( date1, date2);

                return Model;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public List<DashBoardClient>listedesBalancedetousLesClients()
        {
            try
            {
                DashBoardAdminDataAccessLayer converDal = new DashBoardAdminDataAccessLayer();
                List<DashBoardClient> listeConversion = converDal.GetListeBalancedePoint();

                return listeConversion;
            }
            catch
            {
                throw;
            }
        }

    }
}
