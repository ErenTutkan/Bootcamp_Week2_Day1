namespace Bootcamp_Week2_Day1.DTOs
{
    public class UpdateProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
