USE SmartRides;

/* Locations */
INSERT INTO Locations VALUES ('Warsaw');
INSERT INTO Locations VALUES ('Gdansk');
INSERT INTO Locations VALUES ('Krakow');
INSERT INTO Locations VALUES ('Wroclaw');
INSERT INTO Locations VALUES ('Gdynia');
INSERT INTO Locations VALUES ('Lodz');

SELECT * FROM Locations;

/* Rides */
INSERT INTO Rides VALUES (8, 2, 1, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 3, 1, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 4, 1, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 5, 1, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 1, 2, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 3, 2, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 4, 2, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 5, 2, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 1, 3, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 2, 3, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 4, 3, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 5, 3, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 1, 4, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 2, 4, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 3, 4, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 5, 4, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 1, 5, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 2, 5, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 3, 5, 'Warszawa Centralna', 'Gdansk stacja');
INSERT INTO Rides VALUES (8, 4, 5, 'Warszawa Centralna', 'Gdansk stacja');

SELECT * FROM Rides;

/* Ride stops */
INSERT INTO RideStops VALUES (1, 3);
INSERT INTO RideStops VALUES (1, 4);
INSERT INTO RideStops VALUES (1, 5);
INSERT INTO RideStops VALUES (4, 1);
INSERT INTO RideStops VALUES (3, 2);

/* Drivers */
INSERT INTO Drivers VALUES ('John', 'Done', GETDATE(), 4000);
INSERT INTO Drivers VALUES ('Jan', 'Kowalski', GETDATE(), 5000);
INSERT INTO Drivers VALUES ('Robert', 'Robertson', GETDATE(), 3000);

/* Buses */
INSERT INTO Buses VALUES ('Super bus', 20, 1, 1, 2, 2, 1);
INSERT INTO Buses VALUES ('Hundai express', 20, 1, 1, 1, 1, 2);
INSERT INTO Buses VALUES ('Mercedez bus go', 20, 1, 1, 0, 0, 3);

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

/* Bus seats */

INSERT INTO AvialableSeats VALUES (1, 1, 1);
INSERT INTO BusSeats VALUES (1, 2, 1);
INSERT INTO BusSeats VALUES (1, 3, 1);
INSERT INTO BusSeats VALUES (1, 4, 1);
INSERT INTO BusSeats VALUES (1, 5, 1);
INSERT INTO BusSeats VALUES (1, 6, 1);
INSERT INTO BusSeats VALUES (1, 7, 1);
INSERT INTO BusSeats VALUES (1, 8, 1);
INSERT INTO BusSeats VALUES (1, 9, 1);
INSERT INTO BusSeats VALUES (1, 10, 1);
INSERT INTO BusSeats VALUES (1, 11, 1);
INSERT INTO BusSeats VALUES (1, 12, 1);
INSERT INTO BusSeats VALUES (1, 13, 1);
INSERT INTO BusSeats VALUES (1, 14, 1);
INSERT INTO BusSeats VALUES (1, 15, 1);
INSERT INTO BusSeats VALUES (1, 16, 1);
INSERT INTO BusSeats VALUES (1, 17, 1);
INSERT INTO BusSeats VALUES (1, 18, 1);
INSERT INTO BusSeats VALUES (1, 19, 1);
INSERT INTO BusSeats VALUES (1, 20, 1);

INSERT INTO BusSeats VALUES (2, 1, 1);
INSERT INTO BusSeats VALUES (2, 2, 1);
INSERT INTO BusSeats VALUES (2, 3, 1);
INSERT INTO BusSeats VALUES (2, 4, 1);
INSERT INTO BusSeats VALUES (2, 5, 1);
INSERT INTO BusSeats VALUES (2, 6, 1);
INSERT INTO BusSeats VALUES (2, 7, 1);
INSERT INTO BusSeats VALUES (2, 8, 1);
INSERT INTO BusSeats VALUES (2, 9, 1);
INSERT INTO BusSeats VALUES (2, 10, 1);
INSERT INTO BusSeats VALUES (2, 11, 1);
INSERT INTO BusSeats VALUES (2, 12, 1);
INSERT INTO BusSeats VALUES (2, 13, 1);
INSERT INTO BusSeats VALUES (2, 14, 1);
INSERT INTO BusSeats VALUES (2, 15, 1);
INSERT INTO BusSeats VALUES (2, 16, 1);
INSERT INTO BusSeats VALUES (2, 17, 1);
INSERT INTO BusSeats VALUES (2, 18, 1);
INSERT INTO BusSeats VALUES (2, 19, 1);
INSERT INTO BusSeats VALUES (2, 20, 1);

INSERT INTO BusSeats VALUES (3, 1, 1);
INSERT INTO BusSeats VALUES (3, 2, 1);
INSERT INTO BusSeats VALUES (3, 3, 1);
INSERT INTO BusSeats VALUES (3, 4, 1);
INSERT INTO BusSeats VALUES (3, 5, 1);
INSERT INTO BusSeats VALUES (3, 6, 1);
INSERT INTO BusSeats VALUES (3, 7, 1);
INSERT INTO BusSeats VALUES (3, 8, 1);
INSERT INTO BusSeats VALUES (3, 9, 1);
INSERT INTO BusSeats VALUES (3, 10, 1);
INSERT INTO BusSeats VALUES (3, 11, 1);
INSERT INTO BusSeats VALUES (3, 12, 1);
INSERT INTO BusSeats VALUES (3, 13, 1);
INSERT INTO BusSeats VALUES (3, 14, 1);
INSERT INTO BusSeats VALUES (3, 15, 1);
INSERT INTO BusSeats VALUES (3, 16, 1);
INSERT INTO BusSeats VALUES (3, 17, 1);
INSERT INTO BusSeats VALUES (3, 18, 1);
INSERT INTO BusSeats VALUES (3, 19, 1);
INSERT INTO BusSeats VALUES (3, 20, 1);

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