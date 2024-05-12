using System.ComponentModel.DataAnnotations.Schema;

namespace ReHub.DbDataModel.Models;

[Table("admins")]
public class Admin : User
{
    public Admin():base()
    {
        Type = UserType.Admin;
    }
}
