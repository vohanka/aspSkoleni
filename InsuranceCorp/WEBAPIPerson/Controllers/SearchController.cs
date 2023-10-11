using InsuranceCorp.Data;
using InsuranceCorp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPIPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly InsCorpDbContext context;

        public SearchController(InsCorpDbContext context) 
        {
            this.context = context;
        }

        [HttpGet("[action]/{term}")]
        public ActionResult<IEnumerable<Person>> ByEmail(string term) 
        {
            return context.Persons.Where(x => x.Email.ToUpper().Contains(term.ToUpper())).ToList();
        }
    }
}
