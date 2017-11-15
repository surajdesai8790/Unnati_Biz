using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public   class DALCategoryMaster
    {


        public int Group_Id { get; set; }
        public string Category_Name { get; set; }
        public int Category_Id { get; set; }
        public int CreatedByID { get; set; }
        public string CreatedDate { get; set; }
        public int UpdatedByID { get; set; }
        public string UpdatedDate { get; set; }
        public int DeletedByID { get; set; }
        public string DeletedDate { get; set; }
        public string Flag { get; set; }
    }
}
