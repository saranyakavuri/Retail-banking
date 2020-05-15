use DB03TMS24_1819
create table logincastle_3 (loginid int primary key identity(1,1),username varchar(20),password varchar(20),timestamp datetime )
insert into logincastle_3 values('primeadmin','Access@333',null)
insert into logincastle_3 values('customer','Cust@333',null)

select * from logincastle_3
exec sp_helptext update_customer


alter proc updatecastle(@custid int out, @custSsnId bigint,@custName varchar(20),@Age int,@Address1 varchar(20),
@Address2  varchar(20),@city varchar(20), @state varchar(20)) as
begin
declare @tmp datetime
set @tmp=current_timestamp
update Custdet_1288 set custName=@custName,Age=@Age,Address1=@Address1,Address2=@Address2,city=@city,state=@state,lastupdated=@tmp
where custSsnId=@custSsnId
set @custid=@@identity 
end
select * from
 Custdet_1288
 alter proc update_customer(@custid int out, @custSsnId bigint,@custName varchar(20),@Age int,@Address1 varchar(20),



@Address2  varchar(20),@city varchar(20), @state varchar(20)) as



begin

declare @tmp datetime
set @tmp=current_timestamp

update Custdet_1288 set custName=@custName,Age=@Age,Address1=@Address1,Address2=@Address2,city=@city,state=@state,lastupdated=@tmp



where custSsnId=@custSsnId



set @custid=@@identity 



end


drop table castleaccount33
select * from castleaccount33
create table castleaccount33(AccountId int primary key identity (5555,1),CustomerId int foreign key references Custdet_1288(custid),AccountType varchar(20)
,DepositAmmount int ,lastupdated datetime,ShowMessage varchar(50),AccountStatus varchar(20))

alter proc addaccount33 (@CustomerId int,@AccountType varchar(20),@ShowMessage varchar(50),@AccountStatus varchar(20),@Balance int,@flagg int out) as
begin
declare @tmp datetime
declare @acsts varchar(20)
set @acsts =(select AccountStatus from Custdet_1288 where custid =@CustomerId)

set @tmp=current_timestamp
declare @aid int
set @aid =(select count(*) from castleaccount33 where CustomerId =@CustomerId and AccountType=@AccountType)
if (@aid<1)
begin
if(@acsts='Active')
begin
insert into castleaccount33(CustomerId ,AccountType , lastupdated,ShowMessage ,AccountStatus,Balance ) values (@CustomerId ,@AccountType ,@tmp,@ShowMessage ,@AccountStatus,@Balance  )
set @flagg=1
end 
else
begin
set @flagg=0
end

end
else
begin
set @flagg=2
end
print @flagg

end
exec addaccount33 1026,'Current','success','Active',5555,null

select * from transaction33
select * from Custdet_1288
select * from castleaccount33

alter proc deleteaccount33(@AccountId int ) as
begin
declare @tmp datetime
set @tmp=current_timestamp
update castleaccount33 set AccountStatus='Inactive',ShowMessage ='Account deactivated',lastupdated=@tmp
where AccountId=@AccountId
end
ALTER TABLE Custdet_1288
ADD lastupdated datetime,DisplayMessage varchar(50),AccountStatus varchar(20)
select * from
 Custdet_1288
 select * from
 castleaccount33
 alter proc sp_Custdet_1288(@custid int out, @custSsnId bigint,@custName varchar(20),@Age int,@Address1 varchar(20),
@Address2  varchar(20),@city varchar(20), @state varchar(20),@DisplayMessage varchar(50),@AccountStatus varchar(20))
as 
begin
declare @tmstp datetime
set @tmstp=current_timestamp
insert into Custdet_1288(custSsnId,custName,Age,Address1,Address2,city,state,lastupdated,DisplayMessage ,AccountStatus) values(@custSsnId, @custName, @Age, @Address1 ,@Address2 ,@city, @state,@tmstp,@DisplayMessage ,@AccountStatus )
set @custid=@@identity
end
 
exec sp_helptext delete_castle
alter proc delete_castle(@custid int )

as

begin
declare @tmstp datetime
set @tmstp=current_timestamp
update Custdet_1288 set AccountStatus='Inactive',DisplayMessage ='Customer deactivated',lastupdated=@tmstp
WHERE custid = @custid

end

alter table castleaccount33 drop column DepositAmmount 
alter table castleaccount33 add Balance int 
select * from castleaccount33

alter proc deposit(@AccountId int,@ShowMessage varchar(50),@depositamount int,@TransactionId int out) as
begin
declare @tmpstp datetime
set @tmpstp=CURRENT_TIMESTAMP
declare @bal int
set @bal =(select Balance from castleaccount33 where AccountId=@AccountId) +  @depositamount
update castleaccount33 set Balance=@bal,lastupdated=@tmpstp,ShowMessage=@ShowMessage where AccountId=@AccountId
insert into transaction33 values(@AccountId,@ShowMessage,@tmpstp,@depositamount )
set @TransactionId=@@identity 
end
exec deposit 5560,'deposited',5000,null

alter proc withdrawl(@AccountId int,@ShowMessage varchar(50),@withdrawlamount int,@flag int out,@TransactionId int out) as
begin
declare @tmpstp datetime
set @tmpstp=CURRENT_TIMESTAMP
declare @bal int
if @withdrawlamount <=(select Balance from castleaccount33 where AccountId=@AccountId)
begin
set @bal =(select Balance from castleaccount33 where AccountId=@AccountId) - @withdrawlamount
update castleaccount33 set Balance=@bal,lastupdated=@tmpstp,ShowMessage=@ShowMessage where AccountId=@AccountId
insert into transaction33 values(@AccountId,@ShowMessage,@tmpstp,@withdrawlamount )
set @flag=1
set @TransactionId=@@identity 
end
else
begin
set @flag=0
end
print @flag
print @TransactionId
end
exec withdrawl 5560,'withdrawl',100,null,null

create table transaction33 (TransactionId bigint primary key identity(7000,1),TransAccountId int foreign key references castleaccount33(AccountId)
,TransDescription varchar(50),Transdate datetime ,TransAmount bigint )
select * from  transaction33 

alter proc transfermoney(@accid1 int,@accid2 int,@amount int,@ShowMessage varchar(50),@transid int out,@flag int out) as
begin
declare @tmpstp datetime
set @tmpstp=CURRENT_TIMESTAMP
declare @bal int
declare @as1 varchar(30)
declare @as2 varchar(30)

SET @as1 = (SELECT m.AccountStatus 
                  FROM castleaccount33 m
                 WHERE m.AccountId = @accid1)
SET @as2 = (SELECT m.AccountStatus 
                  FROM castleaccount33 m
                 WHERE m.AccountId = @accid2)
--set @as1=(select AccountStatus from castleaccount33 where AccountId=@accid1)
--set @as2=(select AccountStatus from castleaccount33 where AccountId=@accid2)
if(@as1='Active' and @as2='Active')
begin
if(@accid1=@accid2)
begin
set @flag=0
end
else
begin
set @bal=(select Balance from castleaccount33 where AccountId=@accid1)
if(@bal>@amount and @bal>@bal-@amount )
begin
update castleaccount33 set Balance=Balance-@amount,lastupdated=@tmpstp,ShowMessage=@ShowMessage where AccountId=@accid1
insert into transaction33 values(@accid1,@ShowMessage,@tmpstp,@amount )
set @transid=@@IDENTITY
update castleaccount33 set Balance=Balance+@amount,lastupdated=@tmpstp,ShowMessage=@ShowMessage where AccountId=@accid2
insert into transaction33 values(@accid2,@ShowMessage,@tmpstp,@amount )
set @transid=@@IDENTITY
set @flag=1
end
else
begin
set @flag=2
end
end
end
else
begin
set @flag=3
end
print @flag
end
exec transfermoney 5563,5561,1440,'transfer',null,null

select * from transaction33
truncate table transaction33
select * from Custdet_1288
select * from castleaccount33
delete from castleaccount33 where AccountId=5560
truncate table transaction33