﻿using EasyHouseRent.Model;
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
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        BaseData db = new BaseData();
        [HttpGet]
        public IEnumerable<Anuncios> GetAd([FromQuery] string value)
        {
            if(value == null)
            {
                return null;
            }
            else
            {
                string sql = $"SELECT idanuncio,idusuario,titulo,descripcion,direccion,estado,valor,fecha,zona,calificacion,url1,url2,url3,url4 FROM anuncios a WHERE zona LIKE '%{value}%' OR titulo LIKE '%{value}%' OR direccion LIKE '%{value}%';";
                DataTable dt = db.getTable(sql);
                List<Anuncios> dataAd = new List<Anuncios>();
                dataAd = (from DataRow dr in dt.Rows
                          select new Anuncios()
                          {
                              idanuncio = Convert.ToInt32(dr["idanuncio"]),
                              idusuario = Convert.ToInt32(dr["idusuario"]),
                              titulo = dr["titulo"].ToString(),
                              descripcion = dr["descripcion"].ToString(),
                              direccion = dr["direccion"].ToString(),
                              estado = dr["estado"].ToString(),
                              valor = Convert.ToInt32(dr["valor"]),
                              fecha = dr["fecha"].ToString(),
                              zona = dr["zona"].ToString(),
                              url1 = dr["url1"].ToString(),
                              url2 = dr["url2"].ToString(),
                              url3 = dr["url3"].ToString(),
                              url4 = dr["url4"].ToString()

                          }).ToList();

                return dataAd;
            }
        }

        //GET api/<HomeController>/5
        [HttpGet("{id}")]
        public void Get([FromQuery] string value)
        {
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromQuery] string value)
        {    
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("/busquedaFiltro{id}")]
        public async Task filtrosPost([FromBody] string value)
        {

        }
    }
}
