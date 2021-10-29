using ExploreCalifornia.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Principal;
using ExploreCalifornia.DataAccess;
using ExploreCalifornia.Helpers;
namespace ExploreCalifornia.Controllers
{
    public class AuthorizeController : ApiController
    {
        //public IHttpActionResult Post(AuthorizeRequestDto request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return Ok();
        //}

        private readonly AppDataContext _db = new AppDataContext();
        private readonly JwtTokenHelper _tokenHelper = new JwtTokenHelper();

        public List<AppDto> Get()
        {
            return _db.AuthorizedApps
                    .Select(i => new AppDto
                    {
                        Name = i.Name,
                        TokenExpiration = i.TokenExpiration
                    }).ToList();
        }

        public IHttpActionResult Post(AuthorizeRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var authApp = _db.AuthorizedApps
                .FirstOrDefault(i => i.AppToken == request.AppToken
                                     && i.AppSecret == request.AppSecret
                                     && DateTime.UtcNow < i.TokenExpiration);

            if (authApp == null) return Unauthorized();

            var token = _tokenHelper.CreateToken(authApp);
            return Ok(token);
        }
    }
}
}
