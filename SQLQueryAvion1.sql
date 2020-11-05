use DotNetMilos



drop table if exists Airplanes 
drop table if exists Airports
drop table if exists Airlines


create table Airplanes
(
id int primary key identity (1,1),
model nvarchar(20),
capacity int,
name nvarchar(20)
);

create table Airports
(
id int primary key identity (1,1),
name nvarchar(20),
city nvarchar(20),
country nvarchar(20)
);

create table Airlines
(
id int primary key identity (1,1),
name nvarchar(20),
airplane int,
departureAirport int,
destinationAirport int,
foreign key (airplane) references Airplanes(id),
foreign key (departureAirport) references Airports(id),
foreign key (destinationAirport) references Airports(id)
);

