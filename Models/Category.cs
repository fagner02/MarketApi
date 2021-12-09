using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace market_api.Models {
    public class Category {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}