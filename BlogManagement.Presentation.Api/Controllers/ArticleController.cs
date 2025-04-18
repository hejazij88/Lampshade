﻿using System.Collections.Generic;
using _01_LampshadeQuery.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleController(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        [HttpGet]
        public List<ArticleQueryModel> GetLatestArticles()
        {
            return _articleQuery.LatestArticles();
        }
    }
}
