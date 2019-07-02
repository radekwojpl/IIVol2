using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public class News
        {
            public News(string name, string content, string url)
            {
                this.Name = name;
                this.Content = content;
                this.Url = url;
            }

            public string Name { get; set; }
            public string Content { get; set; }
            public string Url { get; set; }
        }

        public ValuesController(AuthenticationContext context)
        {

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            var newsApiKey = "baa2e97368c5442aba7a2d47c77e3258";

            var list = new List<News>();

            var newsApiClient = new NewsApiClient(newsApiKey);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = "Apple",
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = new DateTime(2019, 6, 15),

            });

            var tmp = new List<Article>();

            tmp = articlesResponse.Articles;


            foreach (var item in tmp)
            {
                var name = new string(item.Title);

                var desp = new string(item.Description);
                var url = new string(item.Url);

                list.Add(new News(name, desp, url));
            }



            return list;
        }

        // GET api/values/5
        [HttpGet("{search}")]
        public ActionResult<IEnumerable<News>> Get(string search)
        {
            var newsApiKey = "baa2e97368c5442aba7a2d47c77e3258";

            var list = new List<News>();

            var newsApiClient = new NewsApiClient(newsApiKey);
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = search,
                SortBy = SortBys.Popularity,
                Language = Languages.PL,
                From = new DateTime(2019, 6, 15),

            });

            var tmp = new List<Article>();

            tmp = articlesResponse.Articles;


            foreach (var item in tmp)
            {
                var name = new string(item.Title);

                var desp = new string(item.Description);
                var url = new string(item.Url);

                list.Add(new News(name, desp, url));
            }



            return list;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
