using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Advanced.Models
{
    public class Department
    {
        public long DepartmentId { get; set; }

        public string Name { get; set; }

        
        public IEnumerable<Person>? People { get; set; }
    }
}
