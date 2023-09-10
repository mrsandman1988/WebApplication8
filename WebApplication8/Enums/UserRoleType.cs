using System.ComponentModel.DataAnnotations;
namespace WebApplication8.Enums
{
    public enum RoleType : byte
    {
        Admin = 1,
        //StandartUser = 2,
        Manager = 3,
        Moderator = 4,
        [Display(Name = "Super Admin")]
        SuperAdmin = 5
    }
}
