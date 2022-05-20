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
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementController : ControllerBase
    {

        BaseData db = new BaseData(); 
        Anuncios anuncios = new Anuncios(); 
        // GET: api/<AdController>
        [HttpGet]
        public List<object> Get([FromQuery] Anuncios Ad)
        {
            string sql = $"SELECT * FROM anuncios";
            return db.ConvertDataTabletoString(sql);
        }


        // GET api/<AdController>/5
        [HttpGet("{id}")]
        public List<object> GetAd(int id)
        {
            string sql = $"SELECT * FROM anuncios where idanuncio = '{id}'";
            return db.ConvertDataTabletoString(sql);
        }

        // POST api/<AdController>
        [HttpPost]
        public string Post([FromBody] Anuncios Ad)
        {
            string sql = "INSERT INTO anuncios (idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4) VALUES ('" + Ad.idusuario + "','" + Ad.titulo + "','" + Ad.direccion + "','" + Ad.descripcion + "','" + Ad.modalidad + "','" + Ad.zona + "','" + Ad.edificacion + "','" + Ad.habitaciones + "','" + Ad.garaje + "','" + Ad.precio + "','" + Ad.fecha + "','" + Ad.url1 + "','" + Ad.url2 + "','" + Ad.url3 + "','" + Ad.url4 + "');";
            return db.executeSql(sql);
        }

        // PUT api/<AdController>/5
        [HttpPut("{id}")]
        public string Put([FromBody] Anuncios ad)
        {
            string sql = "UPDATE anuncios SET titulo = '" + ad.titulo + "', descripcion = '" + ad.descripcion + "', puntuacion = '" + ad.puntuacion + "', direccion ='" + ad.direccion + "', estado ='" + ad.estado + "', tipoEstructura ='" + ad.tipoEstructura + "', valor ='" + ad.precio + "', fecha ='" + ad.fecha + "', certificado ='" + ad.certificado + "'  WHERE idanuncio = '" + ad.idanuncio + "'";
            return db.executeSql(sql);
        }

        // DELETE api/<AdController>/5
        [HttpDelete("{id}")]
        public string Delete([FromBody] Anuncios ad)
        {
            string sql = $"DELETE FROM anuncios WHERE idanuncio =" + ad.idanuncio;
            return db.executeSql(sql);
        }
    }
}
