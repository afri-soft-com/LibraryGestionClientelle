using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryGestionClientelle.Compte;
using Microsoft.AspNetCore.Mvc;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        [HttpGet]
        public List<CompteModel> ListDeComptes()
        {
            try
            {
                CompteDataAccessLayer objCrd = new CompteDataAccessLayer();
                List<CompteModel> list_result = objCrd.ListeDeComptes();
                return list_result;
            }
            catch
            {
                throw;
            }
        }
    }
}