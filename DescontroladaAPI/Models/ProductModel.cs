using System.ComponentModel.DataAnnotations;

namespace DescontroladaAPI.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field SellPrice is required")]
        public double SellPrice { get; set; }

        [Required(ErrorMessage = "The field Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The field Type is required")]
        public bool IsOrganic { get; set; }

        [Required(ErrorMessage = "The field RegisterDate is required")]
        public DateTime RegisterDate { get; set; }

        public string RegisterDateString { get => RegisterDate.ToString("yyyy-MM-dd"); }
    }
}
