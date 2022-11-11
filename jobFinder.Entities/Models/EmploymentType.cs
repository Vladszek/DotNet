namespace jobFinder.Entities.Models;

public class EmploymentType : BaseEntity {
    public string Name { get; set; }
    public virtual ICollection<Vacancy>? Vacancies { get; set; }
}