using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryGestionClientelle.Operations;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpPost]
        public void Create(OperationModel tbl)
        {
            try
            {
                OperationDataAccessLayer objCrd = new OperationDataAccessLayer();
                objCrd.AjouterOperation(tbl);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public int DernierOperation()
        {
            try
            {
                OperationDataAccessLayer objCrd = new OperationDataAccessLayer();
                int dernier_operation = objCrd.DernierOperation();
                return dernier_operation;
            }
            catch
            {
                throw;
            }
        }
    }
}