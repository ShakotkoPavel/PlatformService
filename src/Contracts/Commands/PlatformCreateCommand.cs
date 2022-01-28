namespace ApiService.Contracts.Commands
{
    using System.ComponentModel.DataAnnotations;

    public class PlatformCreateCommand
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}