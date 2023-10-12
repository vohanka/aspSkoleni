using InsuranceCorp.Data;
using InsuranceCorp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApiPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly InsCorpDbContext _context;

        public SearchController(InsCorpDbContext context)
        {
            _context = context;
        }


        // GET: api/Search/5
        [HttpGet("{SearchByMail}")]
        public ActionResult<List<Person>> SearchByMail(string SearchByMail)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            var person = _context.Persons.Where(x => x.Email != null &&  x.Email.ToUpper().Contains(SearchByMail)).ToList();

            return person;
        }
    }
}
