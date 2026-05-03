using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTCPayServer.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool RequiresEmailConfirmation { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Profile Picture")]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public string? LanguageCode { get; set; }
        public IEnumerable<SelectListItem> AvailableLanguages { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
