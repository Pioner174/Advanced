using Advanced.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Controllers
{
    [ApiController]
    [Route("/api/people")]
    public class DataController : ControllerBase
    {
        private DataContext _dataContext;

        public DataController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            IEnumerable<Person> people = _dataContext.People.Include(p => p.Department)
                .Include(p => p.Location);

            foreach (Person person in people)
            {
                if (person.Department?.People != null)
                {
                    person.Department.People = null;
                }
                if (person.Location?.People != null)
                {
                    person.Location.People = null;
                }

            }
            return people;
        }

        [HttpGet("{id}")]
        public async Task<Person> GetDetails(long id)
        {
            Person person = await _dataContext.People.Include(p => p.Department)
                .Include(p => p.Location).FirstAsync(p => p.PersonId == id);

            if (person.Department?.People != null)
            {
                person.Department.People = null;
            }
            if (person.Location?.People != null)
            {
                person.Location.People = null;
            }

            return person;
        }

        [HttpPost]
        public async Task Save([FromBody] Person p)
        {
            await _dataContext.People.AddAsync(p);
            await _dataContext.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update([FromBody] Person p)
        {
            _dataContext.Update(p);
            await _dataContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            _dataContext.People.Remove(new Person() { PersonId = id });
            await _dataContext.SaveChangesAsync();
        }

        [HttpGet("/api/locations")]
        public IAsyncEnumerable<Location> GetLocations() =>
            _dataContext.Locations.AsAsyncEnumerable();

        [HttpGet("/api/departments")]
        public IAsyncEnumerable<Department> GetDepts() =>
            _dataContext.Departments.AsAsyncEnumerable();
    }
}

