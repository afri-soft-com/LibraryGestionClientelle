﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryGestionClientelle.ConversionPoint;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        [HttpPost]
        public ConversionPointModel Create( ConversionPointModel objCust)
        {
            try
            {
                ConversionPointDataAccessLayer Dal = new ConversionPointDataAccessLayer();
                ConversionPointModel result=null;

                if (objCust.CodeClient != null)
                    result = Dal.NouvelleConversion(objCust);

                return result;

            }
            catch
            {
                return null;
                throw;
            }
        }


    }
}
