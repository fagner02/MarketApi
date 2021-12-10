using System;

namespace market_api.Dtos {
    public class ProductCreateDto {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Time { get; set; }
    }
}