using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALState
    {
        public string StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string CreatedById { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedById { get; set; }
        public string UpdatedDate { get; set; }
        public string DeletedById { get; set; }
        public string DeletedDate { get; set; }
        public string Flag { get; set; }

    }
}
