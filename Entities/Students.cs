namespace DevSchool.Entities;

public class Students
{

    public Students()
    {
        
    }
    
    public int StudentId { get; private set; }
    public string FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string SchoolClass { get; private set; }
    public bool IsActive { get; private set; }
}