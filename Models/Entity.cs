using System;

namespace market_api.Models {
    public abstract class Entity {
        public Guid Id { get; set; }

        public Entity() {
            Id = Guid.NewGuid();
        }
    }
}