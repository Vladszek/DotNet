namespace jobFinder.Entities.Models;

public class City : BaseEntity {
    public string Name { get; set; }
    public virtual ICollection<UserEmployee>? UserEmployees { get; set; }
    public virtual ICollection<UserEmployer>? UserEmployers { get; set; }
    public virtual ICollection<Vacancy>? Vacancies { get; set; } 
}