create database InfiniteDB;

create table book( --creating table book
id int primary key,
title varchar(100) not null,
author varchar(100) not null,
isbn varchar(100) unique not null,
published_date date
);

insert into book values (
1, 'My First SQL Book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'
);
insert into book values (
2, 'My Second SQL Book', 'John Mayor', '857300923713', '1972-07-03 09:22:45'
);
insert into book values (
3, 'My Third SQL Book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44'
);

select * from book; --display all
select * from book where author like '%er'; --display author names ending with er

create table reviews(
id int primary key,
book_id int not null,
reviewer_name varchar(100) not null,
content varchar(100) not null,
rating tinyint not null,
published_date date
);

insert into reviews values(
1,1,'John Smith', 'My First Review', 4, '2017-12-10 05:50:11'
);

insert into reviews values(
2,2,'John Smith', 'My Second Review', 5, '2017-10-13 15:05:12'
);

insert into reviews values(
3,2,'Alice Walker', 'Another Review', 1, '2017-10-22 23:47:10'
);
select * from reviews; --display entire table
select b.id, b.title, r.reviewer_name --display using innerjoin
from book as b
inner join reviews as r on b.id = r.book_id;

select reviewer_name from reviews group by reviewer_name
having count(book_id)>1; --display reviewer who reviewed more than one book

create table customer(
id int primary key,
name varchar(100) not null,
age int not null,
address_city varchar(100) not null,
salary int not null
);

insert into customer values(
1, 'Ramesh', 32, 'Ahmedabad', 2000
);
insert into customer values(
2, 'Khilan', 25, 'Delhi', 1500
);
insert into customer values(
3, 'Kaushik', 23, 'Kota', 2000
);
insert into customer values(
4, 'Chaitali', 25, 'Mumbai', 6500
);
insert into customer values(
5, 'Hardik', 27, 'Bhopal', 8500
);
insert into customer values(
6, 'Komal', 22, 'MP'
);
insert into customer values(
7, 'Muffy', 24, 'Indore'
);

select * from customer; --displaying the entire table
select name from customer where address_city like '%o%';

create table orders(
oid int unique not null,
order_date date,
customer_id int not null,
amount int not null
);

insert into orders values(
102, '2009-10-08 00:00:00', 3, 3000
);
insert into orders values(
100, '2009-10-08 00:00:00', 3, 1500
);
insert into orders values(
101, '2009-11-20 00:00:00', 2, 1560
);
insert into orders values(
103, '2008-05-20 00:00:00', 4, 2060
);

select * from orders; --displaying the entire table
select order_date, (select count(distinct customer_id) --using a subquery to count
from orders o2
where o1.order_date = o2.order_date) as total_customers
from orders o1
group by order_date;


create table employee(
id int primary key,
name varchar(100) not null,
age int not null,
address_city varchar(100) not null,
salary int
);

insert into employee values(
1, 'Ramesh', 32, 'Ahmedabad', 2000
);
insert into employee values(
2, 'Khilan', 25, 'Delhi', 1500
);
insert into employee values(
3, 'Kaushik', 23, 'Kota', 2000
);
insert into employee values(
4, 'Chaitali', 25, 'Mumbai', 6500
);
insert into employee values(
5, 'Hardik', 27, 'Bhopal', 8500
);
insert into employee values(
6, 'Komal', 22, 'MP', null
);
insert into employee values(
7, 'Muffy', 24, 'Indore', null
);

select * from employee; --display the entire table
select lower(name) as lower_case_name --display the employees in lower case 
from employee where salary is null;

create table student_details(
register_number int primary key,
sname varchar(100) not null,
age int not null,
qualification varchar(100) not null,
mobile_number varchar(20) not null unique,
mail_id varchar(100) not null,
location varchar(100) not null,
gender varchar(2) not null
);

insert into student_details values(
2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'
);
insert into student_details values(
3, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'
);
insert into student_details values(
4, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Salem', 'F'
);
insert into student_details values(
5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'
);
insert into student_details values(
6, 'SaiSaran', 21, 'B.A', '7893045678', 'saran@gmail.com', 'Madurai', 'f'
);
insert into student_details values(
7, 'Tom', 23, 'BCA', '89012345675', 'Tom@gmail.com', 'Pune', 'M'
);

select * from student_details; --display the entire table
select gender, count(*) as total_count --grouping by gender
from student_details group by gender;

