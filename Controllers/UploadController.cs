using Parcial2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Parcial2.Controllers
{
    [RoutePrefix("api/UploadFiles")]
    public class UploadController : ApiController
    {
        [HttpPost]
        [Route("CargarArchivos")]
        public async Task<HttpResponseMessage> CargarArchivo(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsUpload upload = new clsUpload();
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            upload.request = request;
            return await upload.GrabarArchivo(false);
        }
        [HttpGet]
        [Route("LeerArchivo")]
        public HttpResponseMessage LeerArchivo(string NombreArchivo)
        {
            clsUpload upload = new clsUpload();
            return upload.LeerArchivo(NombreArchivo);
        }
        [HttpPut]
        [Route("Actualizar")]
        public async Task<HttpResponseMessage> Actualizar(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsUpload upload = new clsUpload();
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            upload.request = request;
            return await upload.GrabarArchivo(true);
        }
    }
}