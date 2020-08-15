using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SooftApi.Bussines;
using SooftApi.ViewModel;

namespace SooftApi.Controllers
{
    [RoutePrefix("api/singer")]
    public class SingerController : ApiController
    {
        private SingerBussines singerBussines;

        public SingerController()
        {
            singerBussines = new SingerBussines();
        }

        #region Public Methods
        [Route("getSingers")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(singerBussines.GetSingers());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("getSingerByKindOfMusic/{kindOfMusic}")]
        [HttpGet]
        public IHttpActionResult GetByKindOfMusic(string kindOfMusic)
        {
            try
            {
                return Ok(singerBussines.GetSingersByKindOfMusic(kindOfMusic));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("createSinger")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]SingerViewModel singer)
        {
            try
            {
                if (singerBussines.CreateSinger(singer))
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion
    }
}
