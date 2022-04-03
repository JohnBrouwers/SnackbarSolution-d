using Snackbar.Core.Entities;
using Snackbar.Core.ValidationMessages;
using System.ComponentModel.DataAnnotations;

namespace Snackbar.MVC.Models
{
    public class SnackViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired), 
            MaxLength(SnackValidation.NameMaxLength, ErrorMessage = ValidationMessage.HasMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
