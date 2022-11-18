using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiFinalPonceJuanManuel.Data;
using WebApiFinalPonceJuanManuel.Models;


namespace WebApiFinalPonceJuanManuel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        public HospitalController(DbHospitalAPIContext context)
        {
            Context = context;
        }
        public DbHospitalAPIContext Context { get; set; }

        [HttpGet]
        public dynamic Get()
        {
            dynamic hospitales = (from h in Context.Hospitales
                                  select new { h.Nombre ,h.Telefono, h.NumCama}).ToList();
            return hospitales;
        }

        [HttpGet("{numCama}")]

        public dynamic Get(int numCama)
        {
            dynamic hospitales = (from h in Context.Hospitales
                                  where h.NumCama > numCama
                                  select new { h.Nombre, h.Telefono, h.NumCama }).ToList();
            return hospitales;
        }

    }
}
