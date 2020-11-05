use DotNetMilos

insert into Airplanes(model, capacity, name)values
('Boeing', 250, '737'),
('Airbus', 200, 'A380'),
('Boeing', 300, '747');

insert into Airports(name, city, country)values
('Nikola Tesla', 'Beograd', 'Serbia'),
('Aerodrom Tivat', 'Tivat', 'Montenegro'),
('Franc List', 'Budapest', 'Hungary');

insert into Airlines(name, airplane, departureAirport, destinationAirport) values
('Beograd-Tivat', 1, 1, 2),
('Tivat-Budapest', 3, 2, 3),
('Budapest-Tivat', 2, 3, 1);