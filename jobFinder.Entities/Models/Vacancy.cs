namespace jobFinder.Entities.Models;

public class Vacancy : BaseEntity {
    public string JobTitle { get; set; }
    public int Salary { get; set; }
    public string Company { get; set; }
    public string Schedule { get; set; }
    public double Experience { get; set; }
    public string Information { get; set; }
    public DateTime PublicationDate { get; set; }
    
    public Guid CityID { get; set; }
    public virtual City? City { get; set; }

    public Guid EmploymentTypeID { get; set; }
    public virtual EmploymentType? EmploymentType { get; set; }

    public Guid UserEmployerID { get; set; }
    public virtual UserEmployer? UserEmployer { get; set; }

    public virtual ICollection<CVForVacancy>? CVForVacancies { get; set; }
}