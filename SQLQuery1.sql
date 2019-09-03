drop database TimeSheetManagement
go

create database TimeSheetManagement
go

create table Employee_Details
(Employee_Id int primary key,First_Name varchar(100),Last_Name varchar(100),
Designation varchar(max),[Password] varchar(max),Email_Id varchar(max),
[Start_Date] date,[End_Date] date,
Emp_Status bit,Employee_Type int,Address_Id int,created_Date datetime,Last_Updated_Date datetime)
go

create table [Address](Address_Id int primary key,
City varchar(100),[Address] varchar(100),PinCode int,
Geo_Id int,
Employee_Id int foreign key references Employee_Details(Employee_Id),
created_Date datetime,Last_Updated_Date datetime)
go

create table Geo_Location(Geo_Id int primary key,
Continent varchar(100),Country varchar(max),
[State] varchar(100),
created_Date datetime,Last_Updated_Date datetime)
go

create table Project_Details(Project_Id int primary key,
Project_Name varchar(100),[Start_Date] date,[End_Date] date,
Project_Status bit,created_Date datetime,Last_Updated_Date datetime)
go

Create table Employee_Project_Details(id int primary key,
Employee_Id int foreign key references Employee_Details(Employee_Id),
Project_Id int foreign key references Project_Details(Project_Id),
Geo_Id int,[Start_Date] date,
[End_Date] date,Allocation_Status bit,
created_Date datetime,Last_Updated_Date datetime)
go

create table Employee_Manager(Manager_Id int primary key,
Employee_Id int foreign key references Employee_Details(Employee_Id),
created_Date datetime,Last_Updated_Date datetime)

create table Manager_Project_Details(id int primary key,
Manager_Id int foreign key references Employee_Manager(Manager_Id),
Project_Id int references Project_Details(Project_Id),
[Start_Date] date,[End_Date] date,Allocation_Status bit,
Bill_Id int,created_Date datetime,Last_Updated_Date datetime)
go

create table Holiday_Calender(Holiday_Id int primary key,[Date] date,
[Day] varchar(15),Occasion varchar(100),Geo_Id int ,created_Date datetime,Last_Updated_Date datetime)

create table Employee_Leaves(Leave_Id int primary key,
Employee_Id int foreign key references Employee_Details(Employee_Id),
Leave_Type_Id int,[Start_Date] date,[End_Date] date,created_Date datetime,Last_Updated_Date datetime)
go

create table Leaves_Type(Leave_ID int primary key,
Leave_Type varchar(100),created_Date datetime,Last_Updated_Date datetime)
go

create table TimeSheet(TimeSheet_Id int primary key,Period_Id int,
Working_Hours int,OverTime int,Leave_Id int foreign key references Employee_Leaves(Leave_Id),
created_Date datetime,Last_Updated_Date datetime)
go

create table Time_Period(Period_Id int primary key,[Start_Date] date,
[End_Date] date,created_Date datetime,Last_Updated_Date datetime)
go

create table Task_Type(Task_Id int primary key,
Task_Type varchar(100),created_Date datetime,Last_Updated_Date datetime)
go

create table Employee_Task_Details(Employee_Task_Id int primary key,
TimeSheet_Id int foreign key references TimeSheet(Timesheet_Id),
Task_Id int foreign key references Task_Type(Task_Id),
Employee_Hours int,
created_Date datetime,
Last_Updated_Date datetime)
go

Create table Manager_Approval(Approval_ID int primary key,
TimeSheet_Id int foreign key references TimeSheet(Timesheet_Id),
Manager_Id int foreign key references Employee_Manager(Manager_Id),
Submission_Date date,
Is_Approved bit,
Created_Date date,
Last_Updated_Date date)
go

alter table [Address] add constraint FK_Address_Geo_Id foreign key(Geo_Id)references Geo_Location(Geo_Id)