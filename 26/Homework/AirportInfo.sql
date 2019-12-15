CReate DATABASE AirportInfo;

USE AirportInfo;
GO

Create TABLE DepartureBoard(
    FLightNumber VARCHAR(5),
    DepartureCountry VARCHAR(50),
    DepartureCity VARCHAR(50),
    ArrivalCountry VARCHAR(50),
    ArrivalCity VARCHAR(50),
    DepartureDate DATETIMEOFFSET,
    ArrivalDate DATETIMEOFFSET,
    FlightTime TIME,
    AirLine VARCHAR(50),
    ModelAirplane VARCHAR(20)
);

SELECT * FROM DepartureBoard;

INSERT INTO DepartureBoard
VALUES ('1452B','Russia','Moscow','USA' ,'New-York','2019-12-15 23:30:00.0 +3:0', '2019-12-16 9:00:00.0 -5:0','9:30:00.0','Emirates','Boeing 777-300' );

INSERT INTO DepartureBoard
VALUES ('523BC','Russia','Moscow','Japan' ,'Tokyo','2019-12-30 12:45:00.0 +3:0', '2019-12-30 23:00:00.0 +9:0','10:15:00.0','Etihad Airways','Airbus A320' );

DROP DATABASE AirportInfo;