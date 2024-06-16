using ReHub.Domain.Enums;

namespace ReHub.Domain;

//[Table("admins")]
public class Admin : User
{
    public Admin() : base()
    {
        Type = UserType.Admin;
    }
}
