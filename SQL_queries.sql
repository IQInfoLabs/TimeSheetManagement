create database EmployeeDetails

create table Employee(
             FirstName nvarchar(100),
			 ManagerName nvarchar(100),
			 Country nvarchar(100),
			 Salary nvarchar(100) 

);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('aparna', 'shweta', 'India', 50000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('arshitha', 'shweta', 'India', 25000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('amrutha ', 'shweta', 'India', 25000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('Naveena', 'shweta', 'USA', 25000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('samantha', 'shweta', 'India', 50000);


insert into Employee(FirstName,ManagerName,Country,Salary) values ('Harika', 'shweta', 'USA', 5000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('Alexa', 'shweta', 'India', 7000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('Sadie', 'shweta', 'UK', 10000);
insert into Employee(FirstName,ManagerName,Country,Salary) values ('Sophie', 'shweta', 'UK', 15000);
insert into Employee(FirstName,ManagerName,Country,Salary) values ('Sabrina', 'shweta', 'India', 8000);
insert into Employee(FirstName,ManagerName,Country,Salary) values ('Savannah', 'shweta', 'USA', 9000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('Selene ', 'shweta', 'India', 25000);
insert into Employee(FirstName,ManagerName,Country,Salary) values ('Salome ', 'shweta', 'India', 25000);
insert into Employee(FirstName,ManagerName,Country,Salary) values ('Soraya', 'shweta', 'India', 25000);

insert into Employee(FirstName,ManagerName,Country,Salary) values ('Shania', 'shweta', 'USA', 25000);
insert into Employee(FirstName,ManagerName,Country,Salary) values (' Shayla ', 'shweta', 'UK', 25000);
insert into Employee(FirstName,ManagerName,Country,Salary) values ('Sonia ', 'shweta', 'India', 25000);


select * from Employee;

select FirstName, ManagerName, Country from Employee

select top 1 salary, FirstName, ManagerName, Country from Employee

select * from Employee where country = 'USA'

select * from Employee where salary  between 5000 And 10000

select  FirstName from Employee where FirstName like 's%'

select FirstName, ManagerName from Employee where FirstName like '%a' and ManagerName like '%a' 

select FirstName, ManagerName, salary  from Employee where salary < 1000 or salary > 20000 

select  top 5 salary, FirstName from Employee