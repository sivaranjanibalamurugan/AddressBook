create Procedure RetriveAllDetails
(
  @firstName varchar(200),
 @lastName varchar(200),
 @address varchar(200),
 @city varchar(100),
 @state varchar(100),
 @zipCode bigint,
 @phoneNumber bigint,
 @email varchar(100)
)
as
begin
select * from AddressBookTable;
end
