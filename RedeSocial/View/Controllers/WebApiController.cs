#region --Using--
using Services;
using System.Web.Http;
#endregion

namespace View.Controllers
{
    public class WebApiController : ApiController
    {
        private static WebApiService WebApiService = null;
 
        public WebApiController()
        {
            WebApiService = new WebApiService();
        }

        [HttpGet()]
        [Route("api/Usuarios/{id}")]
        public object BuscarUsuario(int id)
        {
            return WebApiService.BuscarUsuario(id);
        }

        [HttpPost]
        [Route("api/Usuarios/EstaCadastrado")]
        public IHttpActionResult Post([FromBody]EstaCadastradoRequest estaCadastradoRequest)
        {
            return Ok(WebApiService.UsuarioEstaCadastrado(estaCadastradoRequest.email));
        }
        

    }

    public class EstaCadastradoRequest
    {
        public string email { get; set; }
    }
    
}
