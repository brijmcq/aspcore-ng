using System.ComponentModel.DataAnnotations;

namespace asp_ng.ViewModels
{
    public class Contact
    {
    public string Name { get; set; }
    [StringLength(255)]
    public string Email { get; set; }
    [Required]
    [StringLength(255)]
    public string Phone { get; set; }
    }
}