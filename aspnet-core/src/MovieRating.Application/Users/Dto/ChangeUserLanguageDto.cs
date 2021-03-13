using System.ComponentModel.DataAnnotations;

namespace MovieRating.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}