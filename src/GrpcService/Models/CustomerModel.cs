namespace GrpcService.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public bool Vip { get; set; }

    public CustomerModel(int id, string firstName, string lastName, string email, int age, bool vip)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
        Vip = vip;
    }
}
