--Functionalities 1-5

USE WeManageDB;

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Address NVARCHAR(255)
);

USE WeManageDB;

INSERT INTO Employees (FirstName, LastName, Email, DateOfBirth, Gender, Address)
VALUES
('James', 'Smith', 'jamessmith@email.com', '1990-01-10', 'Male', '123 Main St, Anytown, USA'),
('Maria', 'Garcia', 'mariag@email.com', '1985-02-20', 'Female', '456 Elm St, Anytown, USA'),
('Brian', 'Johnson', 'brianj@email.com', '1978-03-15', 'Male', '789 Oak St, Anytown, USA'),
('Sophia', 'Brown', 'sophiab@email.com', '1992-04-25', 'Female', '101 Pine St, Anytown, USA'),
('Ethan', 'Davis', 'ethand@email.com', '1983-05-30', 'Male', '202 Maple St, Anytown, USA'),
('Emma', 'Miller', 'emmam@email.com', '1989-06-18', 'Female', '303 Birch St, Anytown, USA'),
('Ava', 'Wilson', 'avaw@email.com', '1975-07-22', 'Female', '404 Cedar St, Anytown, USA'),
('Jacob', 'Moore', 'jacobm@email.com', '1980-08-14', 'Male', '505 Cherry St, Anytown, USA'),
('Olivia', 'Taylor', 'oliviat@email.com', '1991-09-05', 'Female', '606 Dogwood St, Anytown, USA'),
('Noah', 'Anderson', 'noaha@email.com', '1979-10-28', 'Male', '707 Fir St, Anytown, USA'),
('Mia', 'Thomas', 'miat@email.com', '1987-11-11', 'Female', '808 Elm St, Anytown, USA'),
('William', 'Jackson', 'williamj@email.com', '1984-12-20', 'Male', '909 Holly St, Anytown, USA');

-- Note: The above data is randomly generated for sample purposes.

Select * from Employees

CREATE TABLE Positions (
    PositionID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    PositionName NVARCHAR(100),
    StartDate DATE,
    EndDate DATE NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TRIGGER trg_CheckPositionOverlap
ON Positions
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @overlapExists INT;

    SELECT @overlapExists = COUNT(*)
    FROM Positions p
    INNER JOIN inserted i ON p.EmployeeID = i.EmployeeID
    WHERE (p.StartDate < i.EndDate OR i.EndDate IS NULL)
    AND (i.StartDate < p.EndDate OR p.EndDate IS NULL)
    AND p.PositionID != i.PositionID;

    IF (@overlapExists > 0)
    BEGIN
        RAISERROR ('An overlapping position period was detected for the same employee.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

INSERT INTO Positions (EmployeeID, PositionName, StartDate, EndDate)
VALUES 
(1, 'Software Developer', '2018-01-01', '2019-12-31'),
(1, 'Senior Software Developer', '2020-01-01', NULL),

(2, 'Project Manager', '2017-01-01', '2018-12-31'),
(2, 'Senior Project Manager', '2019-01-01', NULL),

(3, 'Designer', '2018-06-01', '2019-05-31'),
(3, 'Senior Designer', '2019-06-01', '2020-05-31'),
(3, 'Art Director', '2020-06-01', NULL),

(4, 'Marketing Analyst', '2016-01-01', '2017-12-31'),
(4, 'Marketing Manager', '2018-01-01', NULL),

(5, 'HR Specialist', '2017-02-01', '2018-01-31'),
(5, 'HR Manager', '2018-02-01', NULL),

(6, 'Sales Representative', '2019-03-01', '2020-02-29'),
(6, 'Sales Manager', '2020-03-01', NULL),

(7, 'Product Manager', '2017-04-01', '2018-03-31'),
(7, 'Senior Product Manager', '2018-04-01', NULL),

(8, 'Data Analyst', '2019-05-01', '2020-04-30'),
(8, 'Senior Data Analyst', '2020-05-01', NULL),

(9, 'Customer Service Rep', '2018-06-01', '2019-05-31'),
(9, 'Customer Service Manager', '2019-06-01', NULL),

(10, 'IT Support', '2017-07-01', '2018-06-30'),
(10, 'IT Manager', '2018-07-01', NULL),

(11, 'Software Engineer', '2016-08-01', '2017-07-31'),
(11, 'Senior Software Engineer', '2017-08-01', '2018-07-31'),
(11, 'Tech Lead', '2018-08-01', NULL),

(12, 'Accountant', '2017-09-01', '2018-08-31'),
(12, 'Senior Accountant', '2018-09-01', '2019-08-31'),
(12, 'Chief Accountant', '2019-09-01', NULL);

select * from positions

CREATE TABLE Salaries (
    SalaryID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    Salary DECIMAL(10, 2),
    StartDate DATE,
    EndDate DATE NULL,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TRIGGER trg_CheckSalaryOverlap
ON Salaries
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @overlapExists INT;

    SELECT @overlapExists = COUNT(*)
    FROM Salaries s
    INNER JOIN inserted i ON s.EmployeeID = i.EmployeeID
    WHERE (s.StartDate < i.EndDate OR i.EndDate IS NULL)
    AND (i.StartDate < s.EndDate OR s.EndDate IS NULL)
    AND s.SalaryID != i.SalaryID;

    IF (@overlapExists > 0)
    BEGIN
        RAISERROR ('An overlapping salary period was detected for the same employee.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

INSERT INTO Salaries (EmployeeID, Salary, StartDate, EndDate)
VALUES
(1, 5000, '2018-01-01', '2019-06-30'),
(1, 5500, '2019-07-01', '2020-06-30'),
(1, 6000, '2020-07-01', NULL),

(2, 7000, '2017-01-01', '2018-06-30'),
(2, 7500, '2018-07-01', '2019-06-30'),
(2, 8000, '2019-07-01', NULL),

(3, 4000, '2018-01-01', '2019-12-31'),
(3, 4500, '2020-01-01', NULL),

(4, 6000, '2016-01-01', '2017-12-31'),
(4, 6500, '2018-01-01', NULL),

(5, 5500, '2017-02-01', '2018-01-31'),
(5, 6000, '2018-02-01', NULL),

(6, 5000, '2019-03-01', '2020-02-29'),
(6, 5500, '2020-03-01', NULL),

(7, 8000, '2017-04-01', '2018-03-31'),
(7, 8500, '2018-04-01', NULL),

(8, 4000, '2019-05-01', '2020-04-30'),
(8, 4500, '2020-05-01', NULL),

(9, 4800, '2018-06-01', '2019-05-31'),
(9, 5000, '2019-06-01', NULL),

(10, 4300, '2017-07-01', '2018-06-30'),
(10, 4600, '2018-07-01', NULL),

(11, 5200, '2016-08-01', '2017-07-31'),
(11, 5600, '2017-08-01', '2018-07-31'),
(11, 6000, '2018-08-01', NULL),

(12, 6200, '2017-09-01', '2018-08-31'),
(12, 6600, '2018-09-01', '2019-08-31'),
(12, 7000, '2019-09-01', NULL);

CREATE TABLE EmployeeSchedules (
    EmployeeID INT NOT NULL,
    Date DATE NOT NULL,
    StartHour TIME NOT NULL,
    EndHour TIME NOT NULL,
    PRIMARY KEY (EmployeeID, Date),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO EmployeeSchedules (EmployeeID, Date, StartHour, EndHour) VALUES
-- Week for Employee 1
(1, '2024-01-08', '08:00', '16:00'),
(1, '2024-01-09', '08:00', '16:00'),
(1, '2024-01-10', '08:00', '16:00'),
(1, '2024-01-12', '08:00', '16:00'),
(1, '2024-01-13', '08:00', '16:00'),

-- Week for Employee 2
(2, '2024-01-08', '09:00', '17:00'),
(2, '2024-01-09', '09:00', '17:00'),
(2, '2024-01-10', '09:00', '17:00'),
(2, '2024-01-14', '09:00', '17:00'),
(2, '2024-01-15', '09:00', '17:00'),

-- Week for Employee 3
(3, '2024-01-08', '10:00', '18:00'),
(3, '2024-01-09', '10:00', '18:00'),
(3, '2024-01-12', '10:00', '18:00'),
(3, '2024-01-13', '10:00', '18:00'),
(3, '2024-01-15', '10:00', '18:00'),

-- Week for Employee 4
(4, '2024-01-08', '07:00', '15:00'),
(4, '2024-01-12', '07:00', '15:00'),
(4, '2024-01-10', '07:00', '15:00'),
(4, '2024-01-11', '07:00', '15:00'),
(4, '2024-01-15', '07:00', '15:00'),

-- Week for Employee 5
(5, '2024-01-13', '11:00', '19:00'),
(5, '2024-01-09', '11:00', '19:00'),
(5, '2024-01-10', '11:00', '19:00'),
(5, '2024-01-11', '11:00', '19:00'),
(5, '2024-01-14', '11:00', '19:00'),

-- Week for Employee 1
(6, '2024-01-08', '08:00', '16:00'),
(6, '2024-01-09', '08:00', '16:00'),
(6, '2024-01-12', '08:00', '16:00'),
(6, '2024-01-13', '08:00', '16:00'),

-- Week for Employee 2
(7, '2024-01-08', '09:00', '17:00'),
(7, '2024-01-09', '09:00', '17:00'),
(7, '2024-01-10', '09:00', '17:00'),
(7, '2024-01-14', '09:00', '17:00'),

-- Week for Employee 3
(8, '2024-01-08', '10:00', '18:00'),
(8, '2024-01-12', '10:00', '18:00'),
(8, '2024-01-13', '10:00', '18:00'),
(8, '2024-01-15', '10:00', '18:00'),

-- Week for Employee 4
(9, '2024-01-08', '07:00', '15:00'),
(9, '2024-01-12', '07:00', '15:00'),
(9, '2024-01-10', '07:00', '15:00'),
(9, '2024-01-15', '07:00', '15:00'),

-- Week for Employee 5
(10, '2024-01-08', '11:00', '19:00'),
(10, '2024-01-10', '11:00', '19:00'),
(10, '2024-01-11', '11:00', '19:00'),
(10, '2024-01-14', '11:00', '19:00'),

-- Week for Employee 5
(11, '2024-01-08', '11:00', '19:00'),
(11, '2024-01-10', '11:00', '19:00'),
(11, '2024-01-11', '11:00', '19:00'),

-- Week for Employee 5
(12, '2024-01-08', '11:00', '19:00'),
(12, '2024-01-10', '11:00', '19:00'),
(12, '2024-01-11', '11:00', '19:00');

