namespace WebApi.Domain.src.Entities
{
    public class Book: BaseEntityWithId
    {
        public string Name;
        public string Author;
        public string Publisher;
        public string Description;
        public double price;
    }
}