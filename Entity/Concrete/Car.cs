﻿using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;

        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public bool IsRented { get; set; }
        public int ModelYear { get; set; }
        public string GearBoxOption { get; set; }
        public int CarMileage { get; set; }

        public int Price { get; set; }
    }
}
