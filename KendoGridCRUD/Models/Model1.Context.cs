﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KendoGridCRUD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCity> tblCities { get; set; }
        public virtual DbSet<tblDesignation> tblDesignations { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tblState> tblStates { get; set; }
    
        public virtual ObjectResult<ShowState_Result> ShowState()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ShowState_Result>("ShowState");
        }
    
        public virtual ObjectResult<ShowCity_Result> ShowCity()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ShowCity_Result>("ShowCity");
        }
    
        public virtual ObjectResult<JoinEmployeeTable_Result1> JoinEmployeeTable(Nullable<int> stateID, Nullable<int> cityID, Nullable<int> salary, string search)
        {
            var stateIDParameter = stateID.HasValue ?
                new ObjectParameter("StateID", stateID) :
                new ObjectParameter("StateID", typeof(int));
    
            var cityIDParameter = cityID.HasValue ?
                new ObjectParameter("CityID", cityID) :
                new ObjectParameter("CityID", typeof(int));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<JoinEmployeeTable_Result1>("JoinEmployeeTable", stateIDParameter, cityIDParameter, salaryParameter, searchParameter);
        }
    }
}