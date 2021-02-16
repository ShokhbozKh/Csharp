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

INSERT INTO RideDates VALUES (convert(date, '01-02-2020'), 21);
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


/* Avialable Seats */
INSERT INTO AvialableSeats VALUES (1, 1, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 2, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 3, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 4, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 5, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 6, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 7, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 8, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 9, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 10, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 11, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 12, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 13, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 14, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 15, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 16, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 17, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 18, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 19, 1, 2);
INSERT INTO AvialableSeats VALUES (1, 20, 1, 2);

INSERT INTO AvialableSeats VALUES (5, 1, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 2, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 3, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 4, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 5, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 6, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 7, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 8, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 9, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 10, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 11, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 12, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 13, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 14, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 15, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 16, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 17, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 18, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 19, 1, 1);
INSERT INTO AvialableSeats VALUES (5, 20, 1, 1);

--test
SELECT * FROM AvialableSeats;


/* Discount Reason */
INSERT INTO DiscountReasons VALUES ('Student');
INSERT INTO DiscountReasons VALUES ('Employee');
INSERT INTO DiscountReasons VALUES ('Promocode');
INSERT INTO DiscountReasons VALUES ('Loyal');

-- Customer --
INSERT INTO Users VALUES (1, 'John', 'Done', 'Login', 'Password', 'john@gmail.com', GETDATE(), null, 1, 1, null, null, 'Customer');
-- Employee --
INSERT INTO Users VALUES ('Robert', 'Anderson', 'Login1', 'Password1', 'robert@gmail.com', null, null, null, null, null, GETDATE(), 10, 'Employee');

/* Ticket class attribute */
INSERT INTO TicketClassAttributes VALUES (500, 20);
INSERT INTO TicketClassAttributes VALUES (700, 5);

/* Displaying */
INSERT INTO Displayings VALUES (100, 20, 0, 1, 2, GETDATE());
INSERT INTO Displayings VALUES (100, 20, 0, 5, 1, GETDATE() + 1);

-- test --
SELECT * FROM AvialableSeats;
SELECT * FROM Buses;
SELECT * FROM DiscountReasons;
SELECT * FROM Displayings;
SELECT * FROM Drivers;
SELECT * FROM Locations;
SELECT * FROM Rides;
SELECT * FROM RideStops;
SELECT * FROM TicketClassAttributes;
SELECT * FROM Tickets;
SELECT * FROM Users;

SELECT * FROM Displayings d
INNER JOIN Rides r ON d.RideId = r.IdRide
INNER JOIN Locations l1 ON r.StartPointId = l1.IdLocation
INNER JOIN Locations l2 ON r.DestinationPointId = l2.IdLocation
WHERE l1.LocationName = 'Warsaw' AND l2.LocationName = 'Gdansk';