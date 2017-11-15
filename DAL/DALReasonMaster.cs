using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALReasonMaster
    {
        public string ReasonId { get; set; }
        public string ReasonCode { get; set; }
        public string Reason { get; set; }
        public string CreatedById { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedById { get; set; }
        public string UpdatedDate { get; set; }
        public string DeletedById { get; set; }
        public string DeletedDate { get; set; }
        public string Flag { get; set; }


    }
}
