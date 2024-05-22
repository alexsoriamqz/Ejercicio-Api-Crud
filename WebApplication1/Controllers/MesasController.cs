using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MesasController
    {
        //GET api/<controller>
        public List<Mesas> Get()
        {
            return OrdenesData.Listar();
        }



    }
}
