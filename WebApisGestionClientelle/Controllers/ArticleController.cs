using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using LibraryGestionClientelle.Article;
using Microsoft.AspNetCore.Mvc;

namespace WebApisGestionClientelle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        [HttpGet]
        public List<ArticleModel> ListDesArticles()
        {
            try
            {
                ArticleDataAccessLayer objCrd = new ArticleDataAccessLayer();
                List<ArticleModel> list_result = objCrd.ListDesArticles();
                return list_result;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<ArticleModel> GetStockPListeParCat(string IdCategorie)
        {
            try
            {
                //int pageNumber = 0;
                // int IsPaging = 0;
                ArticleDataAccessLayer objCrd = new ArticleDataAccessLayer();
                List<ArticleModel> modelArticle = objCrd.GetStockPListe(IdCategorie);
                return modelArticle;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<ArticleModel> GetListeArticles(string Tous)
        {
            try
            {
                //int pageNumber = 0;
                // int IsPaging = 0;
                ArticleDataAccessLayer objCrd = new ArticleDataAccessLayer();
                List<ArticleModel> modelArticle = objCrd.GetTousLesArticles();
                return modelArticle;
            }
            catch
            {
                throw;
            }
        }

         [HttpGet]
        public List<ArticleModel> GetCatArticlePListe(string Cat)
        {
            try
            {
                //int pageNumber = 0;
                // int IsPaging = 0;
                ArticleDataAccessLayer objCrd = new ArticleDataAccessLayer();
                List<ArticleModel> modelCatArticle = objCrd.GetStockPListe(Cat);
                return modelCatArticle;
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<ArticleDataAccessLayer.tCatArticle> GetListeCategorieArticle(string index)
        {
            try
            {
                ArticleDataAccessLayer objCrd = new ArticleDataAccessLayer();
                List<ArticleDataAccessLayer.tCatArticle> model = objCrd.GetListCategorieArticle(index);
                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}