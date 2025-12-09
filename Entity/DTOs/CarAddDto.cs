using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarAddDto : IDto
    {
        public string BrandId { get; set; }
        public string ModelId { get; set; }
        public string ColorId { get; set; }
        public string CompanyId { get; set; }

        public bool IsRented { get; set; }
        public int ModelYear { get; set; }
        public string GearBoxOption { get; set; }
        public int CarMileage { get; set; }
        public int Price { get; set; }
    }
}
