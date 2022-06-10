using KendoGridCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoGridCRUD.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetEmployees(int StateID = 0, int CityID = 0, int Salary = 0, string Search = "")
        {
            var Data = db.JoinEmployeeTable(StateID, CityID, Salary, Search).ToList();
            List<Employee> employeeList = new List<Employee>();
            List<StateClass> stateList = new List<StateClass>();
            List<CityClass> cityList = new List<CityClass>();
            foreach (var item in Data)
            {
                employeeList.Add(new Employee
                {
                    tblEmployeeID = item.tblEmployeeID,
                    Name = item.Name,
                    Designation = item.Designation,
                    StateName = item.StateName,
                    CityName = item.CityName,
                    Salary = item.Salary
                });

                stateList.Add(new StateClass
                {
                    tblStateID = item.tblStateID,
                    StateName = item.StateName
                });

                cityList.Add(new CityClass
                {
                    tblCityID = item.tblCityID,
                    CityName = item.CityName
                });

            }

            return Json(new { cityList = cityList, employeeList = employeeList, stateList = stateList.GroupBy(x => x.tblStateID).Select(y => y.First()).ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetState()
        {
            var Data = db.ShowState().ToList();
            List<Employee> employeeList = new List<Employee>();
            foreach (var item in Data)
            {
                employeeList.Add(new Employee
                {
                    tblStateID = item.tblStateID,
                    StateName = item.StateName
                });
            }
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetCity()
        {
            var Data = db.ShowCity().ToList();
            List<Employee> emp = new List<Employee>();
            foreach (var item in Data)
            {
                emp.Add(new Employee
                {
                    tblCityID = item.tblCityID,
                    CityName = item.CityName,
                    //tblStateID = item.tblStateID
                });
            }
            return Json(emp, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult GetCityByStateId(int stateid)
        //{
        //    int id = Convert.ToInt32(stateid);
        //    var city = from b in db.tblCities where b.tblStateID == stateid select b;
        //    return Json(city);
        //}


        [HttpGet]
        public JsonResult GetCityByStateId(int StateID)
        {
            var City = db.tblCities.AsQueryable();
            if (StateID > 0)
            {
                City = City.Where(c => c.tblStateID == StateID);
                return Json(City.Select(c => new { tblCityID = c.tblCityID, CityName = c.CityName }).ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(db.tblCities.Select(c => new { tblCityID = c.tblCityID, CityName = c.CityName }).ToList(), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}