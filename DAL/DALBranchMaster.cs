using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DALBranchMaster
    {

     public int   Branch_Id	{get;set;}
  public string Branch_Name	{get;set;}
  public string Branch_Address	{get;set;}
  public string Contact_No	{get;set;}
  public int CreatedByID	{get;set;}
  public string CreatedDate	{get;set;}
  public int UpdatedByID	{get;set;}
  public string UpdatedDate	{get;set;}
  public int DeletedByID	{get;set;}
  public string DeletedDate { get; set; }
  public string Flag { get; set; }

    }
}
