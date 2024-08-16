using DevApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : MainController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> GetAll()
        {
            return Ok();
        }
    }
}
