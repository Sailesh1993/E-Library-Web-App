namespace WebApi.Domain.src.Entities
{
    public class Book: BaseEntityWithId
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}