namespace jobFinder.Entities.Models;

public class CVForVacancy : BaseEntity {
    public Guid CVID { get; set; }
    public virtual CV? CV { get; set; }
    
    public Guid VacancyID { get; set; }
    public virtual Vacancy? Vacancy { get; set; }
}