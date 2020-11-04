using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryGestionClientelle.MvtCompte;
using Microsoft.AspNetCore.Mvc;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MvtCompteController : Controller
    {
        [HttpPost]
        public void Create(MvtCompteModel tbl)
        {
            try
            {
                MvtCompteDataAccessLayer objCrd = new MvtCompteDataAccessLayer();
                objCrd.AjouterMvtCompte(tbl);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public int DernierMvtCompte()
        {
            try
            {
                MvtCompteDataAccessLayer objCrd = new MvtCompteDataAccessLayer();
                int dernier_operation = objCrd.DernierMvtCompte();
                return dernier_operation;
            }
            catch
            {
                throw;
            }
        }
    }
}