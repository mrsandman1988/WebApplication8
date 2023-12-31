﻿using System.ComponentModel.DataAnnotations.Schema;
using WebApplication8.Enums;
namespace WebApplication8.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? IDNumber { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
       
        public City? City { get; set; }
        public RoleType? RoleType { get; set; }
    }
}
