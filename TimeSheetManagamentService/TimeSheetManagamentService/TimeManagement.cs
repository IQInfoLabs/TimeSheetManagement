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
                        var firstName = dataValues[0];
                        //Employee_Details
                        int empId = 0;
                        if (dbContext.Employee_Details.Any())
                        {
                            empId = dbContext.Employee_Details.Where(emp => emp.First_Name == firstName).OrderByDescending(e => e.Employee_Id).FirstOrDefault().Employee_Id;
                        }
                        empId = empId + 1;
                        Employee_Details employee_Details = new Employee_Details();
                        employee_Details.Employee_Id = empId;
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
                        address.Address_Id = empId;
                        address.Employee_Id = empId;
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
                        if (File.Exists(fileWatchLocation ))
                            File.Move(fileWatchLocation, archiveDirectory + "DataFile.csv" + "_" + System.DateTime.Now.ToString().Replace('-', '_').Replace(':', '_'));
                    }
                    else
                    {
                        if (File.Exists(fileWatchLocation))
                            File.Move(fileWatchLocation, archiveDirectory + "DataFile.csv" + "_" + System.DateTime.Now.ToString().Replace('-', '_').Replace(':', '_'));
                    }

                }
                catch (Exception ex)
                {
                    if (!Directory.Exists(failureDirectory))
                    {
                        Directory.CreateDirectory(failureDirectory);
                        if (File.Exists(fileWatchLocation))
                            File.Move(fileWatchLocation, failureDirectory + "DataFile.csv" + "_" + System.DateTime.Now.ToString().Replace('-', '_').Replace(':', '_'));
                    }
                    else
                    {
                        if (File.Exists(fileWatchLocation))
                            File.Move(fileWatchLocation, failureDirectory + "DataFile.csv" + "_" + System.DateTime.Now.ToString().Replace('-', '_').Replace(':', '_'));
                    }
                }
                Task.Delay(10000);
            }

        }
    }
}
