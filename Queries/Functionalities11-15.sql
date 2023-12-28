--functionalities 11-15

Use WeManageDB;

CREATE TABLE Ratings (
	RatingID INT PRIMARY KEY IDENTITY,
    EmployeeID INT,
    Date DATE,
    PerformanceRating INT NULL,
    CONSTRAINT FK_Ratings_EmployeeID FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
);


INSERT INTO Ratings (EmployeeID, Date, PerformanceRating) VALUES
(1, '2024-01-03', RAND()*(10-1)+1),
(1, '2024-01-04', RAND()*(10-1)+1),
(1, '2024-01-05', NULL), -- Example of an absence
(2, '2024-01-03', RAND()*(10-1)+1),
(2, '2024-01-04', NULL),
(2, '2024-01-05', RAND()*(10-1)+1),
(3, '2024-01-03', RAND()*(10-1)+1),
(3, '2024-01-04', RAND()*(10-1)+1),
(3, '2024-01-05', RAND()*(10-1)+1),
(4, '2024-01-03', RAND()*(10-1)+1),
(4, '2024-01-04', RAND()*(10-1)+1),
(4, '2024-01-05', NULL),
(5, '2024-01-03', RAND()*(10-1)+1),
(5, '2024-01-04', NULL),
(5, '2024-01-05', RAND()*(10-1)+1),
(6, '2024-01-03', RAND()*(10-1)+1),
(6, '2024-01-04', RAND()*(10-1)+1),
(6, '2024-01-05', RAND()*(10-1)+1),
(7, '2024-01-03', NULL),
(7, '2024-01-04', RAND()*(10-1)+1),
(7, '2024-01-05', RAND()*(10-1)+1),
(8, '2024-01-03', RAND()*(10-1)+1),
(8, '2024-01-04', NULL),
(8, '2024-01-05', RAND()*(10-1)+1),
(9, '2024-01-03', RAND()*(10-1)+1),
(9, '2024-01-04', RAND()*(10-1)+1),
(9, '2024-01-05', RAND()*(10-1)+1),
(10, '2024-01-03', RAND()*(10-1)+1),
(10, '2024-01-04', NULL),
(10, '2024-01-05', RAND()*(10-1)+1),
(11, '2024-01-03', RAND()*(10-1)+1),
(11, '2024-01-04', RAND()*(10-1)+1),
(11, '2024-01-05', RAND()*(10-1)+1),
(12, '2024-01-03', RAND()*(10-1)+1),
(12, '2024-01-04', RAND()*(10-1)+1),
(12, '2024-01-05', RAND()*(10-1)+1);

CREATE TABLE Schedules (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    EventName NVARCHAR(100),
    StartDate DATETIME,
    EndDate DATETIME,
    RoomID NVARCHAR(10),  -- Short string identifier for the room
    Description NVARCHAR(255),
    HostEmployeeID INT,
    EventType NVARCHAR(50),
    IsMandatory BIT,
    CONSTRAINT FK_Schedule_Employees FOREIGN KEY (HostEmployeeID) REFERENCES Employees(EmployeeID)
);

USE WeManageDB;

INSERT INTO Schedules (EventName, StartDate, EndDate, RoomID, Description, HostEmployeeID, EventType, IsMandatory)
VALUES
('Team Meeting', '2024-01-03 09:00:00', '2024-01-03 10:00:00', 'A101', 'Weekly team meeting to discuss project progress', 1, 'Meeting', 1),
('Training Session', '2024-01-04 13:00:00', '2024-01-04 15:00:00', 'B302', 'Training on new software tools', 2, 'Training', 0),
('Client Presentation', '2024-01-05 11:00:00', '2024-01-05 12:30:00', 'C204', 'Presentation for potential clients', 3, 'Presentation', 1),
('Health & Safety Briefing', '2024-01-06 10:00:00', '2024-01-06 11:00:00', 'D501', 'Monthly safety briefing for all staff', 4, 'Briefing', 1),
('Department Meeting', '2024-01-07 14:00:00', '2024-01-07 15:30:00', 'A101', 'Monthly departmental meeting', 5, 'Meeting', 1),
('Project Kickoff', '2024-01-08 09:30:00', '2024-01-08 11:00:00', 'E303', 'Kickoff meeting for new project', 6, 'Meeting', 1),
('Team Building Activity', '2024-01-09 13:00:00', '2024-01-09 17:00:00', 'Outdoor', 'Outdoor team building activities', 7, 'Team Building', 0),
('Tech Talk', '2024-01-10 15:00:00', '2024-01-10 16:30:00', 'B302', 'Talk on latest technology trends', 8, 'Talk', 0),
('HR Workshop', '2024-01-11 10:00:00', '2024-01-11 12:00:00', 'C204', 'Workshop on HR policies', 9, 'Workshop', 0),
('Board Meeting', '2024-01-12 09:00:00', '2024-01-12 11:00:00', 'D501', 'Quarterly board meeting', 10, 'Meeting', 1),
('Product Review', '2024-01-13 14:00:00', '2024-01-13 16:00:00', 'A101', 'Review of product development cycle', 11, 'Review', 0),
('Marketing Strategy Session', '2024-01-14 11:00:00', '2024-01-14 13:00:00', 'E303', 'Planning session for new marketing strategy', 12, 'Strategy Session', 0),
('Customer Feedback Analysis', '2024-01-15 10:00:00', '2024-01-15 12:00:00', 'B302', 'Analyzing recent customer feedback', 1, 'Analysis', 0),
('Employee Engagement Survey', '2024-01-16 13:00:00', '2024-01-16 14:00:00', 'C204', 'Discussing the results of the employee engagement survey', 2, 'Survey', 0),
('Innovation Brainstorming', '2024-01-17 15:00:00', '2024-01-17 17:00:00', 'Outdoor', 'Brainstorming session for new ideas', 3, 'Brainstorming', 0);

CREATE TABLE Notifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    SenderEmployeeID INT,
    NotificationContent NVARCHAR(500),
    Timestamp DATETIME,
    FOREIGN KEY (SenderEmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Notifications (SenderEmployeeID, NotificationContent, Timestamp)
VALUES
(1, 'Reminder: Company-wide meeting on January 10th at 10:00 AM.', '2024-01-03 08:00:00'),
(2, 'Health and Safety training scheduled for January 15th.', '2024-01-04 09:15:00'),
(3, 'Deadline for project proposals extended to January 20th.', '2024-01-05 10:30:00'),
(4, 'New cafeteria menu available next week.', '2024-01-06 11:45:00'),
(5, 'IT system maintenance on January 12th, expect downtimes.', '2024-01-07 12:00:00'),
(6, 'Annual employee satisfaction survey is now open. Please participate.', '2024-01-08 13:20:00'),
(7, 'Reminder: Submit your leave applications for Q1.', '2024-01-09 14:35:00'),
(8, 'Office charity event happening on January 25th.', '2024-01-10 15:50:00'),
(9, 'Update on remote working policies.', '2024-01-11 16:05:00'),
(10, 'Parking area will be under maintenance next week.', '2024-01-12 17:30:00');

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName NVARCHAR(100),
    ProjectDescription NVARCHAR(255),
    StartDate DATE,
    EndDate DATE,
    Budget DECIMAL(18, 2),
    Status NVARCHAR(50),
    ManagerEmployeeID INT,
    CONSTRAINT FK_Projects_Employees FOREIGN KEY (ManagerEmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Projects (ProjectName, ProjectDescription, StartDate, EndDate, Budget, Status, ManagerEmployeeID)
VALUES
('Project Orion', 'Development of a new client management system', '2024-01-10', '2024-07-10', 50000.00, 'In Progress', 1),
('Green Initiative', 'Company-wide sustainability and green energy project', '2024-02-15', '2024-12-15', 75000.00, 'Planning', 2),
('Market Expansion', 'Expansion into new international markets', '2024-03-01', NULL, 100000.00, 'In Progress', 3);

CREATE TABLE ProjectDetails (
    ProjectDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT,
    EmployeeID INT,
    Role NVARCHAR(100),
    JoinDate DATE,
    LeaveDate DATE NULL, -- NULL if still involved in the project
    AdditionalInfo NVARCHAR(MAX),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO ProjectDetails (ProjectID, EmployeeID, Role, JoinDate, LeaveDate, AdditionalInfo)
VALUES
(1, 1, 'Project Manager', '2023-01-10', NULL, 'Leading the project team'),
(1, 2, 'Software Developer', '2023-01-10', NULL, 'Development of core modules'),
(1, 3, 'Quality Assurance', '2023-01-15', NULL, 'Ensuring product quality and reliability'),

(2, 4, 'Project Coordinator', '2023-02-01', NULL, 'Coordinating project tasks and team'),
(2, 5, 'UI/UX Designer', '2023-02-05', NULL, 'Designing user interfaces and experiences'),
(2, 6, 'Software Developer', '2023-02-01', NULL, 'Development of user interfaces'),

(3, 7, 'Data Analyst', '2023-03-01', NULL, 'Analyzing project data and metrics'),
(3, 8, 'Marketing Specialist', '2023-03-05', NULL, 'Marketing and outreach for the project'),
(3, 9, 'Finance Manager', '2023-03-01', NULL, 'Managing project budget and finances');

CREATE TABLE Logins (
    EmployeeID INT PRIMARY KEY,
    Login NVARCHAR(50),
    Password NVARCHAR(50),
    AccessLevel NVARCHAR(50) CHECK (AccessLevel IN ('Basic', 'Moderator', 'Admin')),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Logins (EmployeeID, Login, Password, AccessLevel)
VALUES 
(1, 'user1', 'password1', 'Admin'),
(2, 'user2', 'password2', 'Moderator'),
(3, 'user3', 'password3', 'Basic'),
(4, 'user4', 'password4', 'Basic'),
(5, 'user5', 'password5', 'Basic'),
(6, 'user6', 'password6', 'Basic'),
(7, 'user7', 'password7', 'Moderator'),
(8, 'user8', 'password8', 'Basic'),
(9, 'user9', 'password9', 'Basic'),
(10, 'user10', 'password10', 'Moderator'),
(11, 'user11', 'password11', 'Basic'),
(12, 'user12', 'password12', 'Basic');









