using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrdenesController
    {
        //GET api/<controller>/?
        public Ordenes Get(int id)
        {
            return OrdenesData.Obtener(id);
        }

        //POST api/<controller>
        public bool Post([FromBody]Ordenes oOrdenes)
        {
            return OrdenesData.Agregar(oOrdenes);
        }

        //PUT api/<controller>/?
        public bool Put([FromBody] Ordenes oOrdenes)
        {
            return OrdenesData.Actualizar(oOrdenes);
        }
    }
}
