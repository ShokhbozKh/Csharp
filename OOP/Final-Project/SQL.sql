USE SmartRides;

/* Locations */
INSERT INTO Locations VALUES ('Warsaw');
INSERT INTO Locations VALUES ('Gdansk');
INSERT INTO Locations VALUES ('Krakow');
INSERT INTO Locations VALUES ('Wroclaw');
INSERT INTO Locations VALUES ('Gdynia');
INSERT INTO Locations VALUES ('Lodz');
INSERT INTO Locations VALUES ('Warsaw', 'Wschodnia');
INSERT INTO Locations VALUES ('Warsaw', 'Mlociny');
INSERT INTO Locations VALUES ('Gdansk', 'Gdansk Wrzeszcz');
INSERT INTO Locations VALUES ('Gdansk', 'Gdansk Zaspa');
INSERT INTO Locations VALUES ('Krakow', 'Krakow Biezanow Drozdzownia');
INSERT INTO Locations VALUES ('Gdynia', 'Gdynia Chylonia');
INSERT INTO Locations VALUES ('Gdynia', 'Gdynia Grabówek');

SELECT * FROM Locations;

UPDATE Locations SET StationName = 'Warszawa Centralna' WHERE IdLocation = 1;
UPDATE Locations SET StationName = 'Gdanks Glowny' WHERE IdLocation = 2;
UPDATE Locations SET StationName = 'Krakow Glowny' WHERE IdLocation = 3;
UPDATE Locations SET StationName = 'Wroclaw Glowny' WHERE IdLocation = 4;
UPDATE Locations SET StationName = 'Gdynia Glowna' WHERE IdLocation = 5;
UPDATE Locations SET StationName = 'Lodz Fabryczna' WHERE IdLocation = 6;

/* Rides */
INSERT INTO Rides VALUES (8, 2, 1)
INSERT INTO Rides VALUES (4, 3, 1)
INSERT INTO Rides VALUES (5.5, 4, 1)
INSERT INTO Rides VALUES (6.5, 5, 1)
INSERT INTO Rides VALUES (12, 6, 1)

INSERT INTO Rides VALUES (5, 1, 2)
INSERT INTO Rides VALUES (8, 3, 2)
INSERT INTO Rides VALUES (4, 4, 2)
INSERT INTO Rides VALUES (2, 5, 2)
INSERT INTO Rides VALUES (4, 6, 2)

INSERT INTO Rides VALUES (7.5, 1, 3)
INSERT INTO Rides VALUES (6, 2, 3)
INSERT INTO Rides VALUES (3, 4, 3)
INSERT INTO Rides VALUES (2, 5, 3)
INSERT INTO Rides VALUES (4, 6, 3)

INSERT INTO Rides VALUES (8, 1, 4)
INSERT INTO Rides VALUES (6.5, 2, 4)
INSERT INTO Rides VALUES (7.5, 3, 4)
INSERT INTO Rides VALUES (6, 5, 4)
INSERT INTO Rides VALUES (4, 6, 4)

INSERT INTO Rides VALUES (6, 1, 5)
INSERT INTO Rides VALUES (5, 2, 5)
INSERT INTO Rides VALUES (2, 3, 5)
INSERT INTO Rides VALUES (3, 4, 5)
INSERT INTO Rides VALUES (9, 6, 5)

INSERT INTO Rides VALUES (1, 6)
INSERT INTO Rides VALUES (2, 6)
INSERT INTO Rides VALUES (3, 6)
INSERT INTO Rides VALUES (4, 6)
INSERT INTO Rides VALUES (5, 6)

-- test
SELECT * FROM Rides;

/* Ride stops */
INSERT INTO RideStops VALUES (1002, 21)
INSERT INTO RideStops VALUES (1003, 21)
INSERT INTO RideStops VALUES (1003, 22)
INSERT INTO RideStops VALUES (1005, 22)
INSERT INTO RideStops VALUES (1006, 23)
INSERT INTO RideStops VALUES (1007, 23)
INSERT INTO RideStops VALUES (1008, 24)
INSERT INTO RideStops VALUES (1002, 24)
INSERT INTO RideStops VALUES (1004, 25)
INSERT INTO RideStops VALUES (1005, 25)

INSERT INTO RideStops VALUES (1006, 26)
INSERT INTO RideStops VALUES (1004, 26)
INSERT INTO RideStops VALUES (1003, 27)
INSERT INTO RideStops VALUES (1002, 27)
INSERT INTO RideStops VALUES (1003, 28)
INSERT INTO RideStops VALUES (1002, 28)
INSERT INTO RideStops VALUES (1006, 29)
INSERT INTO RideStops VALUES (1002, 29)
INSERT INTO RideStops VALUES (1007, 30)
INSERT INTO RideStops VALUES (1005, 30)

INSERT INTO RideStops VALUES (1002, 31)
INSERT INTO RideStops VALUES (1007, 31)
INSERT INTO RideStops VALUES (1008, 32)
INSERT INTO RideStops VALUES (1002, 32)
INSERT INTO RideStops VALUES (1004, 33)
INSERT INTO RideStops VALUES (1002, 33)
INSERT INTO RideStops VALUES (1003, 34)
INSERT INTO RideStops VALUES (1004, 34)
INSERT INTO RideStops VALUES (1002, 35)
INSERT INTO RideStops VALUES (1005, 35)

INSERT INTO RideStops VALUES (1005, 36)
INSERT INTO RideStops VALUES (1006, 36)
INSERT INTO RideStops VALUES (1007, 37)
INSERT INTO RideStops VALUES (1004, 37)
INSERT INTO RideStops VALUES (1003, 38)
INSERT INTO RideStops VALUES (1002, 38)
INSERT INTO RideStops VALUES (1005, 39)
INSERT INTO RideStops VALUES (1006, 39)
INSERT INTO RideStops VALUES (1008, 40)
INSERT INTO RideStops VALUES (1007, 40)

INSERT INTO RideStops VALUES (1008, 41)
INSERT INTO RideStops VALUES (1002, 41)
INSERT INTO RideStops VALUES (1005, 42)
INSERT INTO RideStops VALUES (1003, 42)
INSERT INTO RideStops VALUES (1004, 43)
INSERT INTO RideStops VALUES (1005, 43)
INSERT INTO RideStops VALUES (1002, 44)
INSERT INTO RideStops VALUES (1006, 44)
INSERT INTO RideStops VALUES (1007, 45)
INSERT INTO RideStops VALUES (1008, 45)

-- test
SELECT * FROM RideStops;

/* Drivers */
INSERT INTO Drivers VALUES ('John', 'Done', GETDATE(), 4000);
INSERT INTO Drivers VALUES ('Jan', 'Kowalski', GETDATE(), 5000);
INSERT INTO Drivers VALUES ('Robert', 'Robertson', GETDATE(), 3000);
INSERT INTO Drivers VALUES ('Alex', 'Richard', GETDATE(), 3000);

-- test
SELECT * FROM Drivers;

/* Buses */
INSERT INTO Buses VALUES ('Super bus', 20, 1, 1, 2, 2, 1);
INSERT INTO Buses VALUES ('Hundai express', 20, 1, 1, 1, 1, 2);
INSERT INTO Buses VALUES ('Mercedez bus go', 20, 1, 1, 0, 0, 3);
INSERT INTO Buses VALUES ('Flix bus', 20, 0, 1, 2, 2, 4);
INSERT INTO Buses VALUES ('Floride red line', 20, 1, 1, 0, 0, 1002);

-- test
SELECT * FROM Buses;

/* Seats */

INSERT INTO Seats VALUES (1, 1, 1);
INSERT INTO Seats VALUES (1, 2, 1);
INSERT INTO Seats VALUES (1, 3, 1);
INSERT INTO Seats VALUES (1, 4, 1);
INSERT INTO Seats VALUES (1, 5, 1);
INSERT INTO Seats VALUES (2, 1, 1);
INSERT INTO Seats VALUES (2, 2, 0);
INSERT INTO Seats VALUES (2, 3, 0);
INSERT INTO Seats VALUES (2, 4, 0);
INSERT INTO Seats VALUES (2, 5, 0);
INSERT INTO Seats VALUES (3, 1, 0);
INSERT INTO Seats VALUES (3, 2, 0);
INSERT INTO Seats VALUES (3, 3, 0);
INSERT INTO Seats VALUES (3, 4, 0);
INSERT INTO Seats VALUES (3, 5, 0);
INSERT INTO Seats VALUES (4, 1, 1);
INSERT INTO Seats VALUES (4, 2, 1);
INSERT INTO Seats VALUES (4, 3, 1);
INSERT INTO Seats VALUES (4, 4, 1);
INSERT INTO Seats VALUES (4, 5, 1);

-- test
SELECT * FROM Seats;

/* Schedules */

INSERT INTO Schedules VALUES (convert(datetime,'01-01-20 8:30:00 AM',5), convert(datetime,'01-01-20 4:15:00 PM',5));
INSERT INTO Schedules VALUES (convert(datetime,'01-01-20 10:30:00 AM',5), convert(datetime,'01-01-20 10:15:00 PM',5));
INSERT INTO Schedules VALUES (convert(datetime,'01-01-20 11:30:00 AM',5), convert(datetime,'01-01-20 9:15:00 PM',5));
INSERT INTO Schedules VALUES (convert(datetime,'01-01-20 9:30:00 AM',5), convert(datetime,'01-01-20 8:15:00 PM',5));
INSERT INTO Schedules VALUES (convert(datetime,'01-01-20 12:30:00 AM',5), convert(datetime,'01-01-20 6:15:00 PM',5));
INSERT INTO Schedules VALUES (convert(datetime,'01-01-20 1:30:00 AM',5), convert(datetime,'01-01-20 5:15:00 PM',5));

-- test
SELECT * FROM Schedules;

/* Ride dates */

DBCC CHECKIDENT ('RideDates', RESEED, 0);
INSERT INTO RideDates VALUES (convert(date, '01-JAN-2020'), 21);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 22);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 23);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 24);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 25);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 26);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 27);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 28);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 29);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 30);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 31);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 32);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 33);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 34);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 35);
INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 36);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 37);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 38);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 39);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 40);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 41);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 42);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 43);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 44);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 45);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 21);
INSERT INTO RideDates VALUES (convert(date, '02-02-2020'), 22);
INSERT INTO RideDates VALUES (convert(date, '03-02-2020'), 23);
INSERT INTO RideDates VALUES (convert(date, '03-02-2020'), 24);
INSERT INTO RideDates VALUES (convert(date, '03-02-2020'), 25);
INSERT INTO RideDates VALUES (convert(date, '03-02-2020'), 26);
INSERT INTO RideDates VALUES (convert(date, '03-02-2020'), 27);
INSERT INTO RideDates VALUES (convert(date, '03-02-2020'), 28);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 29);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 30);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 31);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 32);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 33);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 34);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 35);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 36);
INSERT INTO RideDates VALUES (convert(date, '04-02-2020'), 37);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 38);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 39);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 40);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 41);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 42);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 43);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 44);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 45);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 21);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 22);
INSERT INTO RideDates VALUES (convert(date, '05-02-2020'), 23);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 24);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 25);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 26);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 27);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 28);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 29);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 30);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 31);
INSERT INTO RideDates VALUES (convert(date, '06-02-2020'), 32);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 33);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 34);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 35);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 36);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 37);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 38);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 39);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 40);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 41);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 42);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 43);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 44);
INSERT INTO RideDates VALUES (convert(date, '07-02-2020'), 45);

--test
SELECT * FROM RideDates;

SELECT rs.* FROM RideSchedules rs
INNER JOIN RideDates rd ON rs.RideDateId = rd.IdRideData
WHERE rd.Date = convert(date, '07-02-2020');

/* Avialable Seats */

--test
SELECT * FROM AvialableSeats;

/* Discount Reason */
INSERT INTO DiscountReasons VALUES ('Student');
INSERT INTO DiscountReasons VALUES ('Employee');
INSERT INTO DiscountReasons VALUES ('Promocode');
INSERT INTO DiscountReasons VALUES ('Loyal');

-- Customer --
INSERT INTO Users VALUES (1, 'Alex', 'Steveson', 'Login2', 'Password2', 'alex@gmail.com', GETDATE(), null, 1, 1, null, null, 'Customer', 'Passport2');
-- Employee --
INSERT INTO Users VALUES ('Robert', 'Anderson', 'Login1', 'Password1', 'robert@gmail.com', null, null, null, null, null, GETDATE(), 10, 'Employee');

select * from Users;

/* Ticket class attribute */
INSERT INTO TicketClassAttributes VALUES (500, 20);
INSERT INTO TicketClassAttributes VALUES (700, 5);

/* Displaying */

INSERT INTO Displayings VALUES (50, 20, 0, 3);
INSERT INTO Displayings VALUES (50, 20, 0, 4);
INSERT INTO Displayings VALUES (50, 20, 0, 5);
INSERT INTO Displayings VALUES (50, 20, 0, 6);
INSERT INTO Displayings VALUES (50, 20, 0, 7);
INSERT INTO Displayings VALUES (50, 20, 0, 8);
INSERT INTO Displayings VALUES (50, 20, 0, 9);
INSERT INTO Displayings VALUES (50, 20, 0, 10);
INSERT INTO Displayings VALUES (50, 20, 0, 11);
INSERT INTO Displayings VALUES (50, 20, 0, 12);
INSERT INTO Displayings VALUES (50, 20, 0, 13);
INSERT INTO Displayings VALUES (50, 20, 0, 14);
INSERT INTO Displayings VALUES (50, 20, 0, 15);
INSERT INTO Displayings VALUES (50, 20, 0, 16);
INSERT INTO Displayings VALUES (50, 20, 0, 17);
INSERT INTO Displayings VALUES (50, 20, 0, 18);
INSERT INTO Displayings VALUES (50, 20, 0, 19);
INSERT INTO Displayings VALUES (50, 20, 0, 20);
INSERT INTO Displayings VALUES (50, 20, 0, 21);
INSERT INTO Displayings VALUES (50, 20, 0, 22);
INSERT INTO Displayings VALUES (50, 20, 0, 23);
INSERT INTO Displayings VALUES (50, 20, 0, 24);
INSERT INTO Displayings VALUES (50, 20, 0, 25);
INSERT INTO Displayings VALUES (50, 20, 0, 26);
INSERT INTO Displayings VALUES (50, 20, 0, 27);
INSERT INTO Displayings VALUES (50, 20, 0, 28);
INSERT INTO Displayings VALUES (50, 20, 0, 29);
INSERT INTO Displayings VALUES (50, 20, 0, 30);
INSERT INTO Displayings VALUES (50, 20, 0, 31);
INSERT INTO Displayings VALUES (50, 20, 0, 32);
INSERT INTO Displayings VALUES (50, 20, 0, 33);
INSERT INTO Displayings VALUES (50, 20, 0, 34);
INSERT INTO Displayings VALUES (50, 20, 0, 35);
INSERT INTO Displayings VALUES (50, 20, 0, 36);
INSERT INTO Displayings VALUES (50, 20, 0, 37);
INSERT INTO Displayings VALUES (50, 20, 0, 38);
INSERT INTO Displayings VALUES (50, 20, 0, 39);
INSERT INTO Displayings VALUES (50, 20, 0, 40);
INSERT INTO Displayings VALUES (50, 20, 0, 41);
INSERT INTO Displayings VALUES (50, 20, 0, 42);
INSERT INTO Displayings VALUES (50, 20, 0, 43);
INSERT INTO Displayings VALUES (50, 20, 0, 44);
INSERT INTO Displayings VALUES (50, 20, 0, 45);
INSERT INTO Displayings VALUES (50, 20, 0, 46);
INSERT INTO Displayings VALUES (50, 20, 0, 47);
INSERT INTO Displayings VALUES (50, 20, 0, 48);
INSERT INTO Displayings VALUES (50, 20, 0, 49);
INSERT INTO Displayings VALUES (50, 20, 0, 50);
INSERT INTO Displayings VALUES (50, 20, 0, 51);
INSERT INTO Displayings VALUES (50, 20, 0, 52);
INSERT INTO Displayings VALUES (50, 20, 0, 53);
INSERT INTO Displayings VALUES (50, 20, 0, 54);
INSERT INTO Displayings VALUES (50, 20, 0, 55);
INSERT INTO Displayings VALUES (50, 20, 0, 56);
INSERT INTO Displayings VALUES (50, 20, 0, 57);
INSERT INTO Displayings VALUES (50, 20, 0, 58);
INSERT INTO Displayings VALUES (50, 20, 0, 59);
INSERT INTO Displayings VALUES (50, 20, 0, 60);
INSERT INTO Displayings VALUES (50, 20, 0, 61);
INSERT INTO Displayings VALUES (50, 20, 0, 62);
INSERT INTO Displayings VALUES (50, 20, 0, 63);
INSERT INTO Displayings VALUES (50, 20, 0, 64);
INSERT INTO Displayings VALUES (50, 20, 0, 65);
INSERT INTO Displayings VALUES (50, 20, 0, 66);
INSERT INTO Displayings VALUES (50, 20, 0, 67);
INSERT INTO Displayings VALUES (50, 20, 0, 68);
INSERT INTO Displayings VALUES (50, 20, 0, 69);
INSERT INTO Displayings VALUES (50, 20, 0, 70);
INSERT INTO Displayings VALUES (50, 20, 0, 71);
INSERT INTO Displayings VALUES (50, 20, 0, 72);
INSERT INTO Displayings VALUES (50, 20, 0, 73);
INSERT INTO Displayings VALUES (50, 20, 0, 74);
INSERT INTO Displayings VALUES (50, 20, 0, 75);
INSERT INTO Displayings VALUES (50, 20, 0, 76);
INSERT INTO Displayings VALUES (50, 20, 0, 77);
INSERT INTO Displayings VALUES (50, 20, 0, 78);

update AvialableSeats set IsAvialable = 1 where IsAvialable = 0;

-- test --
SELECT * FROM AvialableSeats;
SELECT * FROM Buses;
SELECT * FROM DiscountReasons;
SELECT * FROM Displayings;
SELECT * FROM Drivers;
SELECT * FROM Locations;
SELECT * FROM Rides;
SELECT * FROM RideStops;
SELECT * FROM RideDates;
SELECT * FROM Schedules;
SELECT * FROM RideSchedules;
SELECT * FROM TicketClassAttributes;
SELECT * FROM Tickets;
SELECT * FROM Users;

/* clear changes in main tables */
DELETE FROM Tickets;
DELETE FROM TicketSeats;
UPDATE AvialableSeats SET IsAvialable = 1 WHERE IsAvialable = 0;

/* queries */
select l.LocationName, l.StationName
from Rides r
inner join RideStops rs on r.IdRide = rs.RideId
inner join Locations l on rs.LocationId = l.IdLocation
inner join Locations l1 on r.StartPointId = l1.IdLocation
inner join Locations l2 on r.DestinationPointId = l2.IdLocation
where l1.IdLocation = 1 and l2.IdLocation = 2;