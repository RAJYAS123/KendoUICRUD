using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoGridCRUD.Models
{
    public class Employee
    {
        public int tblEmployeeID { get; set; }
        public string Name { get; set; }
        public Nullable<int> tblDesignationID { get; set; }
        public string Designation { get; set; }
        public Nullable<int> tblCityID { get; set; }
        public int tblStateID { get; set; }
        public Nullable<int> Salary { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }

        public List<tblCity> ListCity { get; set; }
        public List<tblState> ListState { get; set; }
    }

    public class CityClass
    {
        public int tblCityID { get; set; }
        public string CityName { get; set; }
    }

    public class StateClass
    {
        public int tblStateID { get; set; }
        public string StateName { get; set; }
    }
}