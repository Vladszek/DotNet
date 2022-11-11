namespace jobFinder.Entities.Models;

public class UserEmployer : BaseEntity {
    public string Surname { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string PasswordHash { get; set; }
    
    public Guid CityID { get; set; }
    public virtual City? City { get; set; }

    public virtual ICollection<Vacancy>? Vacancies { get; set; }
}