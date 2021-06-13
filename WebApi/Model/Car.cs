using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApı.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public string Descriptions { get; set; }

        public DateTime CarImageDate { get; set; }
        public string ImagePath { get; set; }
    }
}
