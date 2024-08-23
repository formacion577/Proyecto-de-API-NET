using System.Collections.Generic;  
using Microsoft.AspNetCore.Mvc;  

namespace TuNombreEspacio.Controllers  
{  
    [ApiController]  
    [Route("[controller]")]  
    public class ProductosController : ControllerBase  
    {  
        // GET: /productos  
        [HttpGet]  
        public IEnumerable<string> Get()  
        {  
            return new string[] { "producto1", "producto2" };  
        }  

        // Otros métodos (POST, PUT, DELETE) pueden ser añadidos aquí.  
    }  
}  