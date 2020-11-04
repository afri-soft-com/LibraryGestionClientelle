using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryGestionClientelle.Clients;
using Microsoft.AspNetCore.Mvc;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpPost]
        public void Create(ClientDataAccessLayer.tTest test)
        {
            try
            {
                ClientDataAccessLayer tEnregistrementClient = new ClientDataAccessLayer();
                Int32 message = 0;

                ///if (test.toSave != null)
                    //message = tEnregistrementClient.InsertTest(test);
                //return message.ToString();

                tEnregistrementClient.InsertTest(test);

            }
            catch
            {
                throw;
            }
        }
    }
}