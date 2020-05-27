create proc up_GetPhoneByPage
@pageSize int,
@currentPage int,
@totalPages int output
as
begin
	select top (@pageSize) * from Complaints where tid not in
	(select top (@pageSize*(@currentPage-1)) tid from Complaints order by tid)
	declare @totalCounts int
	select @totalCounts = COUNT(tid) from Complaints
	set @totalPages = ceiling(@totalCounts*1.0/@pageSize)
end

declare @totalPages int
exec up_GetPhoneByPage 5,2,@totalPages output
select @totalPages