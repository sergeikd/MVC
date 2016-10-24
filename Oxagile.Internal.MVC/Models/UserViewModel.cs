using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oxagile.Internal.MVC.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoFileName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        public string Company { get; set; }
        public List<string> Titles { get; set; }
    }
}