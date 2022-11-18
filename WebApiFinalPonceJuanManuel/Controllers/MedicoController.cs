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
    public class MedicoController : ControllerBase
    {

        public MedicoController(DbHospitalAPIContext context)
        {
            Context = context;
        }
        public DbHospitalAPIContext Context { get; set; }

        [HttpGet]
        public List<Doctor> Get()
        {
            //EF
            List<Doctor> doctores = Context.Doctores.ToList();
            return doctores;
        }
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
            //EF
            Doctor doctor = Context.Doctores.Find(id);

            return doctor;
        }

        [HttpGet("especialidad/{especialidad}")]
        public Doctor Get(string especialidad)
        {
            Doctor doctor = (from d in Context.Doctores
                             where especialidad == d.Especialidad
                             select d).SingleOrDefault();
            return doctor;
        }

        [HttpPost]
        public ActionResult Post(Doctor doctor)
        {
            //EF -- memoria
            Context.Doctores.Add(doctor);
            //EF - Guardar en la DB
            Context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Doctor> Delete(int id)
        {
            //EF
            var doctor = Context.Doctores.Find(id);

            if (doctor == null)
            {
                return NotFound();
            }

            //EF
            Context.Doctores.Remove(doctor);
            Context.SaveChanges();

            return doctor;

        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.DoctorNo)
            {
                return BadRequest();
            }

            //EF para modificar en la DB
            Context.Entry(doctor).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }


    }
}
