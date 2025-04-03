using Parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial2.Clases
{
	public class clsPrendas
	{
        private DBExamenEntities dbexamen = new DBExamenEntities(); //objeto para gestionar los datos de l empleado con la base de datos

        public Prenda prenda { get; set; } //objeto tipo empleado para gestionar el CRUD en la base de datos

        public string Insertar()
        {
            try
            {
                dbexamen.Prendas
                    .Add(prenda); //agrega un empleado a la lista entity framework, se debe invocar SaveChanges para guasrdar los cambios en la base de datos
                dbexamen.SaveChanges(); //guarda los cambios en la base de datos
                return "Prenda registrado con exito"; //retorna un mensaje de exito
            }
            catch (Exception ex)
            {
                return "Error al registrar el Prenda: " + ex.Message; //retorna un mensaje de error
            }
        }
        public Prenda ConsultarPorIDPrenda(int id)
        {
            Prenda prenda = dbexamen.Prendas.FirstOrDefault(e => e.IdPrenda == id);
            return prenda; //retorna el cliente encontrado
        }
        public List<Prenda> ConsultarTodasLasPrenda()
        {
            return dbexamen.Prendas.ToList(); //retorna la lista de prendas
        }
        public string GrabarImagenPrendas(int idprenda, List<string> Archivos)
        {
            try
            {
                foreach (string archivo in Archivos)
                {
                    FotoPrenda imagenPrenda = new FotoPrenda();
                    imagenPrenda.idPrenda = idprenda;
                    imagenPrenda.FotoPrenda1= archivo;
                    dbexamen.FotoPrendas.Add(imagenPrenda);
                    dbexamen.SaveChanges();
                }
                return "Se grabó la información en la base de datos";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public IQueryable ObtenerPrendasCliente(string documento)
        {
            return from c in dbexamen.Set<Cliente>()
                   join p in dbexamen.Set<Prenda>() on c.Documento equals p.Cliente
                   join f in dbexamen.Set<FotoPrenda>() on p.IdPrenda equals f.idPrenda into fotos
                   from foto in fotos.DefaultIfEmpty() // Permite que devuelva prendas sin fotos
                   where c.Documento == documento
                   orderby p.TipoPrenda
                   select new
                   {
                       Cliente = c.Nombre,
                       Documento = c.Documento,
                       IdPrenda = p.IdPrenda,
                       TipoPrenda = p.TipoPrenda,
                       Descripcion = p.Descripcion,
                       Valor = p.Valor,
                       Imagen = foto != null ? foto.FotoPrenda1 : null // Si no hay imagen, devuelve null
                   };
        }

    }
}