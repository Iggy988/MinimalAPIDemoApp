--give all rows in user
if not exists (select 1 from dbo.[User])

begin
	insert into dbo.[User] (FirstName, LastName)
	values
		('Vidoje', 'Vidojevic'),
		('Pero', 'Peric'),
		('Marko', 'Markovic'),
		('Djuro', 'Palica');

end