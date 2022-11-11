namespace jobFinder.Entities.Models;

public class CV : BaseEntity {
    public string PrivateInformation { get; set; }
    public string SkillsInformation { get; set; }
    public string JobTitle { get; set; }
    public string AdditionalInformation { get; set; }
    
    public Guid UserEmployeeID { get; set; }
    public virtual UserEmployee? UserEmployee { get; set; }
    
    public virtual ICollection<CVForVacancy>? CVForVacancies { get; set; }
}