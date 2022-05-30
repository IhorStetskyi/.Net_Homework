INSERT INTO [Person]([FirstName], [LastName])
VALUES ('John', 'Ceena'), ('Will', 'Smith'), ('Tom', 'Hanks'), ('Morgan', 'Freeman'), ('Jack', 'Nicholson');

INSERT INTO [Address]([Street], [City], [State], [ZipCode])
VALUES ('Street1', 'City1', 'State1', 'ZipCode1'), ('Street2', 'City2', 'State2', 'ZipCode2'), ('Street3', 'City3', 'State3', 'ZipCode3'),
('Street4', 'City4', 'State4', 'ZipCode4'), ('Street5', 'City5', 'State5', 'ZipCode5');

INSERT INTO [Employee]([AddressId], [PersonId], [CompanyName], [Position], [EmployeeName])
VALUES (1, 1, 'Company1', 'Position1', 'Ceena J.'), (2, 2, 'Company2', 'Position2', null), (3, 3, 'Company3', 'Position3', 'Hanks T.'),
(4, 4, 'Company4', 'Position4', null), (5, 5, 'Company5', 'Position5', 'Nicholson J.');