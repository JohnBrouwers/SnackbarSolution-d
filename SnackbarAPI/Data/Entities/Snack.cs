using System.ComponentModel.DataAnnotations;

namespace SnackbarAPI.Data.Entities
{
    public class Snack
    {
        public int Id { get; set; }

        public decimal Price { get; set; }


        [StringLength(100, MinimumLength = 2), Required]
        public string Name { get; set; }


    }
}
