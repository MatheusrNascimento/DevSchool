namespace DevSchool.Models;

public class StudentInputModel
{
    public StudentInputModel()
    {
    }

    public StudentInputModel(string fullName, DateTime birthDate, string schoolClass, bool isActive)
    {
        FullName = fullName;
        BirthDate = birthDate;
        SchoolClass = schoolClass;
        IsActive = isActive;
    }

    public string FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string SchoolClass { get; private set; }
    public bool IsActive { get; private set; }
}