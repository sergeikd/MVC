using FluentValidation.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;
using Oxagile.Internal.MVC.Validator;
using System;
using System.ComponentModel.DataAnnotations;

namespace Oxagile.Internal.MVC.Models
{
    [Validator(typeof(UserManageModelValidator))]
    public class UserManageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Titles { get; set; }
        public List<string> NewTitles { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        public string PhotoFileName { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}