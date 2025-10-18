using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Globalization;

namespace IbasSupportApp.Models
{
    public class SupportMessage
    {
        [Required]
        public string id { get; set; } = $"KH-{DateTime.UtcNow.Year}-{new Random().Next(100000, 999999)}";
        
        [Required(ErrorMessage = "Navn er påkrævet")]
        [StringLength(100, ErrorMessage = "Navn må max være 100 tegn")]
        public string name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email er påkrævet")]
        [EmailAddress(ErrorMessage = "Ugyldig email adresse")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon er påkrævet")]
        [Phone(ErrorMessage = "Ugyldigt telefonnummer")]
        public string phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori er påkrævet")]
        public string category { get; set; } = string.Empty;

        [Required(ErrorMessage = "Beskrivelse er påkrævet")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Beskrivelse skal være mellem 10 og 1000 tegn")]
        public string description { get; set; } = string.Empty;

        [Required]
        public string date { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);
    }
}