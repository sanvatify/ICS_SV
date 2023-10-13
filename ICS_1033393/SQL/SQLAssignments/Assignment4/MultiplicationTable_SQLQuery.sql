create procedure MultiplicationTTable @table int
as 
begin
declare @i int
declare @j int
if @table <= 0
begin
print 'Invalid Input Please Input A Positive Integer'
return
end
set @i = 7
while @i <= @table 
begin 
print 'Multiplication Table For ' + cast(@i as varchar(10)) + ':'
set @j = 1
while @j<=10
begin
print cast(@i as varchar(10)) + ' * ' + cast(@j as varchar(10)) + ' = ' + cast(@i * @j as varchar(10))
set @j = @j+1
end
print ''
set @i = @j + 1
end
end

exec MultiplicationTTable @table = 10;

select * from EMP;