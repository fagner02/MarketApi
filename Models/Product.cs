using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace market_api.Models {
    public class Product {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Time { get; set; }
        public int BB() {
            return 89;
        }
    }
}