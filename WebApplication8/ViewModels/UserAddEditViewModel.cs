using System.ComponentModel.DataAnnotations.Schema;
using WebApplication8.Data.Entities;
using WebApplication8.Enums;

namespace WebApplication8.ViewModels
{
    public class UserAddEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? IDNumber { get; set; }
        public int? CityId { get; set; }
        public RoleType? RoleType { get; set; }
    }
}
