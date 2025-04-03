using Parcial2.Clases;
using Parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Parcial2.Controllers
{
    [RoutePrefix("api/prendas")]
    public class PrendasController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] Prenda prenda)
        {
            clsPrendas objprenda = new clsPrendas();
            objprenda.prenda = prenda;
            return objprenda.Insertar();
        }
        [HttpGet]
        [Route("ConsultarPorIDPrenda")]
        public Prenda ConsultarPorIDPrenda(int id)
        {
            clsPrendas objprenda = new clsPrendas();
            return objprenda.ConsultarPorIDPrenda(id);
        }
        [HttpGet]
        [Route("ConsultarTodasLasPrenda")]
        public List<Prenda> ConsultarTodasLasPrenda()
        {
            clsPrendas objPrendas = new clsPrendas();
            return objPrendas.ConsultarTodasLasPrenda();

        }
        [HttpGet]
        [Route("ConsultarPrendasXCliente")]
        public IQueryable ConsultarPrendasXCliente(string documento)
        {
            clsPrendas objprendas = new clsPrendas();
            return objprendas.ObtenerPrendasCliente(documento);
        }
    }
}