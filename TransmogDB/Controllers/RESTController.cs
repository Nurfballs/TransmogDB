using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace TransmogDB.Models
{
    public class RESTController : ApiController
    {
        private TransmogDataContext db = new TransmogDataContext();

        // GET: api/REST
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/REST/Lookup
        // http://localhost:50392/api/REST/Lookup?realm=Aggrama&character=Orwell
        [System.Web.Mvc.HttpGet]
        public string Lookup(string realm, string character)
        {

            return "FUCKER";
            // Lookup the character
            //if ((db.Database.SqlQuery<TransmogDataContext>($"SELECT COUNT(id) FROM Transmog WHERE Realm = {realm} AND Name = {character}").Count() > 0))
            //{
            //    return new HttpResponseMessage(HttpStatusCode.Found);
            //}
            //else
            //{
            //    return new HttpResponseMessage(HttpStatusCode.NotFound);
            //}

        }

        // GET: api/REST/5
        public Transmog Get(int? id)
        {

            if (id == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            Transmog transmog = db.Transmogs.Find(id);
            if (transmog == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return transmog;
        }


        // POST: api/REST/Add
        public HttpResponseMessage Add([FromBody]Transmog transmog)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            if (ModelState.IsValid)
            {
                 db.Transmogs.Add(transmog);
                db.SaveChanges();
                response.StatusCode = HttpStatusCode.Created;
            } else
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }


        // PUT: api/REST/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/REST/5
        public void Delete(int id)
        {
        }
    }
}
