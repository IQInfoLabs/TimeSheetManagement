using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManagamentService.Model;

namespace TimeSheetManagamentService
{
    class TimeManagement
    {
        public static TimeManagement Instance = new TimeManagement();
        string fileWatchLocation = ConfigurationManager.AppSettings["FileWatchLocation"].ToString();
        string archiveDirectory = ConfigurationManager.AppSettings["ArchiveDirectory"].ToString();
        string failureDirectory = ConfigurationManager.AppSettings["FailureDirectory"].ToString();

        public void EnableFileWatch()
        {
            Task.Run(() => Load());
        }

        private void Load()
        {
            while (true)
            {
                try
                {
                    TimeSheetManagementEntities dbContext = new TimeSheetManagementEntities();

                    string[] dataFile = File.ReadAllLines(fileWatchLocation);
                    int i = 1;
                    foreach (var data in dataFile.Skip(1))
                    {

                        var dataValues = data.Split(',');

                        //Employee_Details
                        Employee_Details employee_Details = new Employee_Details();
                        employee_Details.Employee_Id = dbContext.Employee_Details.Where(emp => emp.First_Name == dataValues[0]).FirstOrDefault().Employee_Id == 0 ? 1 : dbContext.Employee_Details.Where(emp => emp.First_Name == dataValues[0]).FirstOrDefault().Employee_Id + 1;
                        employee_Details.First_Name = dataValues[0];
                        employee_Details.Last_Name = dataValues[1];
                        employee_Details.Designation = dataValues[2];
                        employee_Details.Email_Id = dataValues[3];
                        employee_Details.Start_Date = Convert.ToDateTime(dataValues[4]);
                        employee_Details.Emp_Status = dataValues[5].ToLower() == "active" ? true : false;
                        employee_Details.Employee_Type = dataValues[6].ToLower() == "permanent" ? 1 : 0;
                        employee_Details.created_Date = System.DateTime.Now;
                        employee_Details.Last_Updated_Date = System.DateTime.Now;
                        dbContext.Employee_Details.Add(employee_Details);
                        dbContext.SaveChanges();


                        // Address
                        Address address = new Address();
                        var firstName = dataValues[0];
                        int employeeId = dbContext.Employee_Details.Where(emp => emp.First_Name == firstName).FirstOrDefault().Employee_Id;
                        address.Address_Id = employeeId;
                        address.Employee_Id = employeeId;
                        address.City = dataValues[7];
                        address.Address1 = dataValues[8];
                        address.PinCode = Convert.ToInt32(dataValues[9]);
                        address.Geo_Id = dbContext.Geo_Location.Where(geo => geo.Country.ToLower() == "india" && geo.State.ToLower() == "telangana").FirstOrDefault().Geo_Id;
                        address.created_Date = System.DateTime.Now;
                        address.Last_Updated_Date = System.DateTime.Now;
                        dbContext.Addresses.Add(address);
                        dbContext.SaveChanges();
                        i++;
                    }

                    if (!Directory.Exists(archiveDirectory))
                    {
                        Directory.CreateDirectory(archiveDirectory);
                    }
                    else
                    {
                        Directory.Move(fileWatchLocation, archiveDirectory);
                    }

                }
                catch (Exception ex)
                {
                    if (!Directory.Exists(failureDirectory))
                    {
                        Directory.CreateDirectory(failureDirectory);
                    }
                    else
                    {
                        Directory.Move(fileWatchLocation, failureDirectory);
                    }
                }
                Task.Delay(10000);
            }

        }
    }
}
