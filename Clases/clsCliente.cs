using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Parcial2.Models;

namespace Parcial2.Clases
{
	public class clsCliente
	{
        private DBExamenEntities dbexamen = new DBExamenEntities(); //objeto para gestionar los datos de l empleado con la base de datos

        public Cliente cliente { get; set; } //objeto tipo empleado para gestionar el CRUD en la base de datos

        public string Insertar()
        {
            try
            {
                dbexamen.Clientes
                    .Add(cliente); //agrega un empleado a la lista entity framework, se debe invocar SaveChanges para guasrdar los cambios en la base de datos
                dbexamen.SaveChanges(); //guarda los cambios en la base de datos
                return "Cliente registrado con exito"; //retorna un mensaje de exito
            }
            catch (Exception ex)
            {
                return "Error al registrar el Cliente: " + ex.Message; //retorna un mensaje de error
            }
        }

        public Cliente ConsultarPorDocumento(string documento)
        {
            Cliente cliente = dbexamen.Clientes.FirstOrDefault(e => e.Documento == documento);
            return cliente; //retorna el cliente encontrado
        }
    }
}