using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DemoSOA.Models;

namespace DemoSOA.Controllers
{
    public class BillmasterApiController : ApiController
    {


        private soadb db = new soadb();

        // GET api/BillmasterApi
        public IEnumerable<billmaster> Getbillmasters()
        {
            return db.billsmaster.AsEnumerable();
        }

        // GET api/BillmasterApi/5
        public billmaster Getbillmaster(int id)
        {
            billmaster billmaster = db.billsmaster.Find(id);
            if (billmaster == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return billmaster;
        }

        // PUT api/BillmasterApi/5
        public HttpResponseMessage Putbillmaster(int id, billmaster billmaster)
        {
            if (ModelState.IsValid && id == billmaster.id)
            {
                db.Entry(billmaster).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/BillmasterApi

        public HttpResponseMessage Postbillmaster(billmaster billmaster)
        {
            if (ModelState.IsValid)
            {
                db.billsmaster.Add(billmaster);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, billmaster);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = billmaster.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/BillmasterApi/5
        public HttpResponseMessage Deletebillmaster(int id)
        {
            billmaster billmaster = db.billsmaster.Find(id);
            if (billmaster == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.billsmaster.Remove(billmaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, billmaster);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}