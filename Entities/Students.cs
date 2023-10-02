namespace DevSchool.Entities;

public class Student
{

    public Students(string fullName, DateTime birthDate, string schoolClass, bool isActive)
    {
        FullName = fullName;
        BirthDate = birthDate;
        SchoolClass = schoolClass;
        IsActive = isActive;
    }
    
    public int StudentId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string SchoolClass { get; set; }
    public bool IsActive { get; set; }
}