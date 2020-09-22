using System.ComponentModel.DataAnnotations;
using AutoCreateApiTest.Enums;

namespace AutoCreateApiTest.Models
{
    public class CreateApplicationModel
    {

        public CreateApplicationModel()
        {

        }
        [Required(ErrorMessage = "title is obligatory")]
        public Title title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "username is obligatory")]
        public string username { get; set; } = default!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "firtsName is obligatory")]
        [RegularExpression("^[a-zA-Z-α-ωΑ-Ω.-]+\\s?[a-zA-Z-α-ωΑ-Ω.]+?$",
            ErrorMessage = "first name must have only characters, numbers not allowed")]
        [StringLength(32, MinimumLength = 2)]
        public string firstName { get; set; } = default;

        [Required(AllowEmptyStrings = false, ErrorMessage = "last name is obligatory")]
        [RegularExpression("^[a-zA-Z-α-ωΑ-Ω.-]+\\s?[a-zA-Z-α-ωΑ-Ω.]+?$",
            ErrorMessage = "last name must have only characters, numbers not allowed")]
        [StringLength(32, MinimumLength = 2)]
        public string lastName { get; set; } = default!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "email is obligatory")]
        [StringLength(150, MinimumLength = 2)]
        [EmailAddress(ErrorMessage = "The email address is no valid")]
        public string email { get; set; } = default!;

#nullable enable
        public string? telCountryCode { set; get; }

        public string? telephone { get; set; }

    }
}
