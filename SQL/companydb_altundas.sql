drop database companydb_altundas;
create database companydb_altundas;
use companydb_altundas;

create table if not exists d_dept (
d_deptno int (2) not null primary key,
d_dname varchar(20),
d_location varchar(20)
);

create table if not exists s_salgrade (
s_grade int(2) not null primary key,
s_losal decimal(10,0),
s_hisal decimal(10,0)
);

create table if not exists e_emp (
e_empno int(4) not null primary key,
e_name varchar(25),
e_job varchar(20),
e_manager int(4),
e_hiredate date,
e_salary decimal(10,2),
e_commission decimal(5,0),
e_d_deptno int(2) not null,

foreign key (e_d_deptno)
	references d_dept (d_deptno)
    on delete set null on update cascade
);

set foreign_key_checks = 0;

insert into e_emp (e_empno, e_name, e_job, e_manager, e_hiredate, e_salary, e_commission, e_d_deptno)
values
(7369,'SMITH','CLERK',7901,'1980-12-17',800,NULL,20),
(7499,'ALLEN','SALESMAN',7698,'1981-02-20',1600,300,30),
(7521,'WARD','SALESMAN',7698,'1981-02-22',1250,500,30),
(7566,'JONES','MANAGER',7839,'1981-04-02',2975,NULL,20),
(7654,'MARTIN','SALESMAN',7698,'1981-09-28',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'1981-05-01',2850,NULL,30),
(7782,'CLARK','MANAGER',7839,'1981-06-09',2450,NULL,10),
(7788,'SCOTT','ANALYST',7566,'1982-12-09',3000,NULL,20),
(7839,'KING','PRESIDENT',NULL,'1981-11-17',5000,NULL,10),
(7844,'TURNER','SALESMAN',7698,'1981-09-08',1500,0,30),
(7876,'ADAMS','CLERK',7788,'1983-01-12',1100,NULL,20),
(7900,'JAMES','CLERK',7698,'1981-12-03',950,NULL,30),
(7902,'FORD','ANALYST',7566,'1981-12-03',3000,NULL,20),
(7934,'MILLER','CLERK',7782,'1982-01-23',1300,NULL,10);

insert into d_dept (d_deptno, d_dname, d_location)
values
(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON');


insert into s_salgrade (s_grade, s_losal, s_hisal)
values
(1,700,1200),
(2,1201,1400),
(3,1401,2000),
(4,2001,3000),
(5,3001,9000);

set foreign_key_checks = 1;