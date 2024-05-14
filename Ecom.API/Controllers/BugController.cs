using Ecom.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BugController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("Not Found")]
        public ActionResult GetNotFound()
        {
            var product = _context.Products.Find(50);
            if (product != null)
                return Ok(product);
                return NotFound();
        }
    }
}
