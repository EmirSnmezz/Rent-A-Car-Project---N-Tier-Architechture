using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarAddDto
    {
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int CompanyId { get; set; }

        public bool IsRented { get; set; }
        public int ModelYear { get; set; }
        public string GearBoxOption { get; set; }
        public int CarMileage { get; set; }
        public int Price { get; set; }
    }
}
