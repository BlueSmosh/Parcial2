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
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] Cliente cliente)
        {
            clsCliente objcliente = new clsCliente();
            objcliente.cliente = cliente;
            return objcliente.Insertar();
        }
        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Cliente ConsultarPorDocumento(string documento)
        {
            clsCliente objcliente = new clsCliente();
            return objcliente.ConsultarPorDocumento(documento);
        }

    }
}