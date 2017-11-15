using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALHsnCode
    {
        public string HsnId { get; set; }
        public string HsnCode { get; set; }
        public string Description { get; set; }
        public string GstCategory { get; set; }
        public string IsActive { get; set; }
        public string CreatedById { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedById { get; set; }
        public string UpdatedDate { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public string Flag { get; set; }

    }
}
