using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Brand
    {
        [Key]
        public int MarkaID { get; set; }
        public string MarkaName { get; set; }
        public string MarkaDescription { get; set; }
        public string MarkaLogo { get; set; }
        public bool MarkaStatus { get; set; }
    }
}
