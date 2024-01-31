create database if not exists sargabt;
 
use sargabt;
 
create table if not exists employees (
    Id int not null primary key auto_increment,
    Name varchar(50),
    City varchar(50),
    Salary double
);

grant all privileges
on sargabt.*
to sargabt@localhost
identified by 'titok';
