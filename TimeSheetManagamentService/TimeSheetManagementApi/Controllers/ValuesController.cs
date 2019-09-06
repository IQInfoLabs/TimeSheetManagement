using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeSheetManagementApi.Models;
using System.Web.Http.Cors;

namespace TimeSheetManagementApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class ValuesController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        TimeSheetManagementEntities dbContext = new TimeSheetManagementEntities();

        [HttpPost]
        [ActionName("EmployeeDetials")]
        public void PostEmpDetails([FromBody]Employee_Details employee_Details)
        {

            //Employee_Details
            int empId = 0;
            if (dbContext.Employee_Details.Any())
            {
                empId = dbContext.Employee_Details.OrderByDescending(e => e.Employee_Id).FirstOrDefault().Employee_Id;
            }
            empId = empId + 1;
            employee_Details.Employee_Id = empId;
            employee_Details.created_Date = System.DateTime.Now;
            employee_Details.Last_Updated_Date = System.DateTime.Now;
            dbContext.Employee_Details.Add(employee_Details);
            dbContext.SaveChanges();
        }

        [HttpPost]
        [ActionName("GeoLocations")]
        public void PostGeoLocations([FromBody]Geo_Location geo_Location)
        {

            //Employee_Details
            int geo_id = 0;
            if (dbContext.Employee_Details.Any())
            {
                geo_id = dbContext.Geo_Location.OrderByDescending(e => e.Geo_Id).FirstOrDefault().Geo_Id;
            }
            geo_id = geo_id + 1;
            geo_Location.Geo_Id = geo_id;
            geo_Location.created_Date = System.DateTime.Now;
            geo_Location.Last_Updated_Date = System.DateTime.Now;
            dbContext.Geo_Location.Add(geo_Location);
            dbContext.SaveChanges();
        }

        [HttpGet]
        [ActionName("EmployeeDetials")]
        public Geo_Location GetEmployee_details()
        {
            Geo_Location geo_Location = new Geo_Location();

            var g = from gl in dbContext.Geo_Location select gl;

            return geo_Location;
        }


        [HttpGet]
        [ActionName("GeoLocations")]
        public string GetGeo_Location()
        {
            var g = from gl in dbContext.Geo_Location
                    select new { Continent = gl.Continent, Geo_Id = gl.Geo_Id, Country = gl.Country, State = gl.State };
            return JsonConvert.SerializeObject(g);
        }

        [HttpGet]
        [ActionName("GeoLocations")]
        public Geo_Location GetGeo_Location(int id)
        {
            Geo_Location geo_Location = new Geo_Location();

            var g = from gl in dbContext.Geo_Location where gl.Geo_Id == id select gl;

            return geo_Location;
        }
    }
}
