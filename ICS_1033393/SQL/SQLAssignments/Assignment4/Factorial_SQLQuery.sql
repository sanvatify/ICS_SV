declare @ToFactorial bigint = 10;
declare @y int = 0;
declare @z int = 1;
declare @a int = @ToFactorial;
declare @b int = @ToFactorial;
declare @i int = @a;
while(@i > 1)
begin
declare @j int =1;
while (@j<@i)
begin 
set @z = @b + @y;
set @y = @z;
set @j = @j+1;
end
set @b = @z;
set @y = 0;
set @i = @i-1;
end
select @z as 'Factorial'