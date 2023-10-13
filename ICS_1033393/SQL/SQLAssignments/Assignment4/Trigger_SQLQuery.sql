create trigger trr on EMP
after insert, update, delete as
begin
declare @holidayname varchar(20);
select @holidayname = holiday_name from Holidays
where holiday_date = convert(date, getdate());
if @holidayname is not null
begin
declare @errormessage varchar(50);
set @errormessage = 'Due To ' + @holidayname + ' You Cannot Manipulate Data';
throw 51000, @errormessage, 1;
--Raiserror ('Due To ', @holidayname, ' You Cannot Manipulate Data',16, 1);
--rollback transaction;
end 
end;

select * from Holidays;
insert into Holidays values ('2023-10-13', 'Testing Divas');

update EMP set salary = 9999 where empno = 7369;