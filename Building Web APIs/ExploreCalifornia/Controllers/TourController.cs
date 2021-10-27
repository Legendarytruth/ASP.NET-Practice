using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExploreCalifornia.DataAccess;
using ExploreCalifornia.DataAccess.Models;
using ExploreCalifornia.DTOs;

namespace ExploreCalifornia.Controllers
{
    [RoutePrefix("api/tour")]
    public class TourController : ApiController
    {
        private AppDataContext _context = new AppDataContext();
        [HttpGet]
        public List<Tour> GetAllTours([FromUri] bool freeOnly = false)
        {
            var query = _context.Tours.AsQueryable();
            if (freeOnly)
            {
                query = query.Where(i => i.Price == 0.0m);
            }
            return query.ToList();
        }

        [Route("/{id:identity}")]
        public Tour GetById(int id)
        {
            var query = _context.Tours
                .Where(i => i.TourId == id)
                .FirstOrDefault();
            return query;
        }

        [Route("/{name}")]
        public Tour GetByName(string name)
        {
            var query = _context.Tours
                .Where(i => i.Name.Contains(name))
                .FirstOrDefault();
            return query;
        }

        [HttpPost]
        public IHttpActionResult SearchTour([FromBody] TourSearchRequestDto request)
        {
            if(request.MinPrice > request.MaxPrice)
            {
                return BadRequest("MinPrice must be less than MaxPrice.");

                //Used when return type is List<Tour> as a way to catch exceptions.
                //throw new HttpResponseException(new HttpResponseMessage
                //{
                //    StatusCode = HttpStatusCode.BadRequest,
                //    Content = new StringContent("MinPrice must be less than MaxPrice.")
                //});
            }
            var query = _context.Tours.AsQueryable()
                .Where(i => i.Price >= request.MinPrice && i.Price <= request.MaxPrice);
            //return query.ToList(); if return type is List<Tour>
            return Ok(query.ToList());
        }
        [HttpPut]
        
        public IHttpActionResult Put(int id, Tour tour)
        {
            return Ok($"{id}: {tour.Name}");
        }
        [HttpPatch]
        public IHttpActionResult Patch()
        {
            return Ok("Patch");
        }
        [HttpDelete]
        public IHttpActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}