namespace APP.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Nullable olarak işaretleyin
        public decimal Price { get; set; }
        public string? Description { get; set; } // Nullable olarak işaretleyin
    }


}
