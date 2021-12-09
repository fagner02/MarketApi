using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace market_api.Models {
    public class Category : Entity {
        public string Name { get; set; }
    }
}