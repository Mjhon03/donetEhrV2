using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        BaseData db = new BaseData();
        Municipios municipios = new Municipios(); 
        // GET: api/<MunicipalityController>
        [HttpGet]
        public IEnumerable<Municipios> Get()
        {
            string sql = "SELECT * FROM municipios WHERE nombre != 'desconocido'";
            return municipios.GetAllMunicipality(sql);
        }

        // GET api/<MunicipalityController>/nombreDepartamento
        [HttpGet("{iddepartamento}")]
        [Route("api/Municipality/{iddepartamento}")]
        public IEnumerable<Municipios>Get([FromQuery]int iddepartamento)
        {
            string sql = $"select m.* FROM municipios m INNER JOIN departamento d on m.departamento=d.iddepartamento where d.iddepartamento = {iddepartamento}";
            return municipios.GetMunicipalityById(sql);
        }

        // POST api/<MunicipalityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<MunicipalityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MunicipalityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
