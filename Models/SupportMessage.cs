using System.ComponentModel.DataAnnotations;

namespace IbasSupportApp.Models
{
    public class SupportMessage
    {
        [Required]
        public string id { get; set; } = Guid.NewGuid().ToString();
        
        [Required(ErrorMessage = "Navn er påkrævet")]
        [StringLength(100, ErrorMessage = "Navn må max være 100 tegn")]
        public string navn { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email er påkrævet")]
        [EmailAddress(ErrorMessage = "Ugyldig email adresse")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon er påkrævet")]
        [Phone(ErrorMessage = "Ugyldigt telefonnummer")]
        public string telefon { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kategori er påkrævet")]
        public string kategori { get; set; } = string.Empty;

        [Required(ErrorMessage = "Beskrivelse er påkrævet")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Beskrivelse skal være mellem 10 og 1000 tegn")]
        public string beskrivelse { get; set; } = string.Empty;

        [Required]
        public string dato { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}

