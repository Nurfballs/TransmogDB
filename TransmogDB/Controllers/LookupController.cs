using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TransmogDB.Models;

namespace TransmogDB.Controllers
{
    public class LookupController : ApiController
    {

        private TransmogDataContext db = new TransmogDataContext();


        // GET: Lookup
        //[System.Web.Mvc.Route("{controller}/{action}/{realm}/{character}")]
        public HttpResponseMessage Get(string realm, string character) // http://localhost:50392/api/Lookup?realm=elune&character=sweetthing
        {
            // Lookup the character
            string query = $"SELECT COUNT(id) FROM Transmogs WHERE Realm = '{realm} 'AND Name = '{character}'";
            int resultCount = db.Database.SqlQuery<int>(query).Single();

            if ( resultCount > 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Found);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}