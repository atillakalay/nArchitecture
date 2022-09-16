using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public int BrandId { get; set; }
        public string? Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string? ImageUrl { get; set; }
        public Brand? Brand { get; set; }
        public Model()
        {

        }
        public Model(int id, string name, int brandId, string? imageUrl, decimal dailyPrice) : this()
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            ImageUrl = imageUrl;
            DailyPrice = dailyPrice;
        }
    }
}
