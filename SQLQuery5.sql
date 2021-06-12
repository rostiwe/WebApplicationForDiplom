--select SUBSTRING( sys.fn_varbintohexstr(HASHBYTES('MD2',[Код] + convert(nvarchar,[Id_клиента]) + convert(nvarchar, GETDATE()) )), 3, 100) + [Код] as f
--from [dbo].[Коды_отходов] where [Id_Кода] = 2

--insert into [dbo].[Коды_отходов] (Код, Количество, Id_клиента)
--values (HASHBYTES('SHA2_256','блабла'), 5, 1)
update [dbo].[Коды_отходов]
set Код =l.f from (select SUBSTRING(sys.fn_varbintohexstr(HASHBYTES('MD2',[Код])), 3, 100) + [Код] as f
from [dbo].[Коды_отходов]
where Id_Кода = 2) as l
where Id_Кода = 2

