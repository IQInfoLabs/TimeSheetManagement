select FirstName,ManagerName,Country from Employee

select * from employee order by salary desc

select * from employee where country='USA'

select * from employee where salary between 5000 and 10000

select * from employee where firstName like 's%'

select * from employee where FirstName like '%a'

select * from Employee where salary < 1000 or salary > 20000

select top 5 salary,FirstName from employee where country='India' order by salary desc