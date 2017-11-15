using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class DALItemMaster
    {

  public int  Item_Id	{get;set;}
 public string Item_Name	{get;set;}
 public string Item_Code	{get;set;}
  public int Group_Id	{get;set;}
 public int Category_Id	{get;set;}
 public string Drawing_No	{get;set;}
 public string Rev_No	{get;set;}
 public int Unit_Id	{get;set;}
 public int HSN_Code	{get;set;}
 public decimal WIP_Rate	{get;set;}
public decimal Finish_Rate	{get;set;}
public decimal Net_Weight	{get;set;}
 public string Item_Level	{get;set;}
 public string Metel_Sec	{get;set;}
public decimal Qty	{get;set;}
public decimal Qty_Pack	{get;set;}
public int CreatedByID { get; set; }
public string CreatedDate { get; set; }
public int UpdatedByID { get; set; }
public string UpdatedDate { get; set; }
public int DeletedByID { get; set; }
public string DeletedDate { get; set; }
public string Flag { get; set; }
		



    }
}
