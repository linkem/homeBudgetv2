using System.Collections.Generic;
using System.Linq;
using HomeBudget.BussinesLogic;
using HomeBudget.Models.People;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this._peopleService = peopleService;
        }

        [HttpGet]
        [Route("list")]
        public List<PersonModel> GetAllPeople()
        {
            var people = _peopleService.GetAllPeople();

            return people.Select(s => new PersonModel {Id = s.PersonId, Name = s.Name, RelationName = s.Relation.Description, TotalAmount = s.Bills.Sum(x => x.Amount) }).ToList();
        }
    }
}