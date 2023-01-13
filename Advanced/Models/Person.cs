using System.ComponentModel.DataAnnotations;

namespace Advanced.Models
{
    public class Person
    {
        public long PersonId { get; set; }

        [Required(ErrorMessage = "Имя - обязательное поле")]
        [MinLength(3, ErrorMessage ="Имя, должно быть длиннее 3 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия - обязательное поле")]
        [MinLength(3, ErrorMessage = "Фамилия, должно быть длиннее 3 символов")]
        public string Surname { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "A department must be selected")]
        public long DepartmentId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "A location must be selected")]

        public long LocationId { get; set; }

        public Department Department { get; set; }

        public Location Location { get; set; }
    }
}
