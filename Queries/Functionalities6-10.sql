--Functionalities 6-10

Use WeManageDB;

USE WeManageDB;

CREATE TABLE Leaves (
    LeaveID INT PRIMARY KEY IDENTITY,
    EmployeeID INT,
    StartDate DATE,
    EndDate DATE,
    TypeOfLeave NVARCHAR(50),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TRIGGER trg_CheckLeaveOverlap 
ON Leaves
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @overlapExists BIT;
    SET @overlapExists = 0;

    -- Check for overlap in new or updated records
    SELECT @overlapExists = 1
    FROM inserted i
    INNER JOIN Leaves l ON i.EmployeeID = l.EmployeeID
    WHERE (i.StartDate BETWEEN l.StartDate AND l.EndDate 
           OR i.EndDate BETWEEN l.StartDate AND l.EndDate
           OR l.StartDate BETWEEN i.StartDate AND i.EndDate 
           OR l.EndDate BETWEEN i.StartDate AND i.EndDate)
    AND NOT (i.StartDate = l.StartDate AND i.EndDate = l.EndDate); -- Excludes the same record

    IF @overlapExists = 1
    BEGIN
        RAISERROR ('An employee cannot be on two different leaves at the same time.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

INSERT INTO Leaves (EmployeeID, StartDate, EndDate, TypeOfLeave) VALUES
(1, '2024-02-01', '2024-02-10', 'Annual'),
(2, '2024-03-15', '2024-03-20', 'Sick'),
(3, '2024-04-05', '2024-04-15', 'Annual'),
(4, '2024-05-01', '2024-05-10', 'Parental'),
(5, '2024-06-20', '2024-07-01', 'Annual'),
(6, '2024-07-15', '2024-07-20', 'Sick'),
(7, '2024-08-03', '2024-08-13', 'Annual'),
(8, '2024-09-01', '2024-09-11', 'Parental'),
(9, '2024-10-15', '2024-10-25', 'Annual'),
(10, '2024-11-04', '2024-11-14', 'Sick'),
(11, '2024-12-01', '2024-12-10', 'Annual'),
(1, '2024-12-20', '2025-01-05', 'Holiday'),
(2, '2024-01-15', '2024-01-25', 'Annual'),
(3, '2024-02-10', '2024-02-20', 'Sick'),
(4, '2024-03-01', '2024-03-11', 'Annual'),
(5, '2024-04-15', '2024-04-25', 'Parental'),
(6, '2024-05-05', '2024-05-15', 'Annual'),
(7, '2024-06-01', '2024-06-11', 'Sick'),
(8, '2024-07-10', '2024-07-20', 'Annual'),
(9, '2024-08-15', '2024-08-25', 'Parental');

CREATE TABLE Recruits (
    RecruitID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    DateOfBirth DATE,
    Gender CHAR(1),
    Address NVARCHAR(255)
);

CREATE TABLE Recruitments (
    RecruitmentID INT IDENTITY(1,1) PRIMARY KEY,
    RecruitID INT,
    PositionName NVARCHAR(100),
    ApplicationDate DATE,
    Status NVARCHAR(50),
    InterviewDate DATE NULL,
    Notes NVARCHAR(MAX),
    FOREIGN KEY (RecruitID) REFERENCES Recruits(RecruitID)
);

CREATE TRIGGER trg_Recruitments_SingleActiveRecruitment
ON Recruitments
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RecruitID INT;
    DECLARE @Status NVARCHAR(50);
    DECLARE @RecruitmentID INT;

    SELECT @RecruitID = i.RecruitID, @Status = i.Status, @RecruitmentID = i.RecruitmentID 
    FROM inserted i;

    IF @Status = 'Active'
    BEGIN
        IF EXISTS (
            SELECT 1 
            FROM Recruitments 
            WHERE RecruitID = @RecruitID 
            AND Status = 'Active' 
            AND RecruitmentID != @RecruitmentID
        )
        BEGIN
            RAISERROR ('A recruit cannot have multiple active recruitments.', 16, 1);
            ROLLBACK;
        END
    END
END;

INSERT INTO Recruits (FirstName, LastName, Email, DateOfBirth, Gender, Address)
VALUES 
('John', 'Doe', 'john.doe@example.com', '1990-05-15', 'M', '123 Main St, Anytown, USA'),
('Jane', 'Smith', 'jane.smith@example.com', '1992-07-22', 'F', '456 Elm St, Othertown, USA'),
('Alice', 'Johnson', 'alice.johnson@example.com', '1988-03-05', 'F', '789 Oak St, Sometown, USA'),
('Bob', 'Williams', 'bob.williams@example.com', '1991-11-19', 'M', '101 Pine St, Newtown, USA'),
('Sarah', 'Brown', 'sarah.brown@example.com', '1993-09-10', 'F', '202 Maple St, Yourtown, USA');

INSERT INTO Recruitments (RecruitID, PositionName, ApplicationDate, Status, InterviewDate, Notes)
VALUES 
(1, 'Software Engineer', '2023-12-01', 'Closed', '2023-12-15', 'Rejected'),
(2, 'Marketing Specialist', '2023-11-20', 'Active', NULL, 'Application under review.'),
(3, 'Data Analyst', '2023-11-25', 'Active', '2023-12-18', 'First round interview scheduled.'),
(4, 'Product Manager', '2023-12-05', 'Active', NULL, 'Application under review.'),
(5, 'HR Coordinator', '2023-11-30', 'Active', '2023-12-20', 'First round interview scheduled.'),
(1, 'Junior Software Engineer', '2023-12-16', 'Active', NULL, 'Application under review.');

CREATE TABLE Incidents (
    IncidentID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    IncidentDate DATE,
    IncidentType NVARCHAR(100),
    Description NVARCHAR(1000),
    SeverityLevel NVARCHAR(50),
    ReportedDate DATE,
    ActionTaken NVARCHAR(1000),
    Status NVARCHAR(100),
    ResolutionDate DATE,
    Notes NVARCHAR(1000),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

INSERT INTO Incidents (EmployeeID, IncidentDate, IncidentType, Description, SeverityLevel, ReportedDate, ActionTaken, Status, ResolutionDate, Notes) 
VALUES
(3, '2024-02-15', 'Accident', 'Slip and fall in the cafeteria', 'Moderate', '2024-02-15', 'First aid administered', 'Under Investigation', NULL, 'Wet floor sign not displayed'),
(5, '2024-03-10', 'Malfunction', 'Computer system crash', 'Minor', '2024-03-10', 'IT support notified', 'Resolved', '2024-03-12', 'System update required'),
(2, '2024-01-22', 'Workplace Incident', 'Conflict between employees', 'Moderate', '2024-01-22', 'HR mediation session scheduled', 'Open', NULL, 'Follow-up meeting planned'),
(7, '2024-04-05', 'Accident', 'Chemical spill in lab', 'Severe', '2024-04-05', 'Area evacuated and spill contained', 'Under Investigation', NULL, 'Safety protocols review needed'),
(1, '2024-05-20', 'Malfunction', 'Elevator stuck between floors', 'Moderate', '2024-05-20', 'Maintenance called, employees rescued', 'Resolved', '2024-05-21', 'Regular maintenance checks advised');

CREATE TABLE EmployeeDevelopments (
    DevelopmentID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    DevelopmentType NVARCHAR(100),
    Title NVARCHAR(200),
    StartDate DATE,
    EndDate DATE,
    Provider NVARCHAR(200),
    Status NVARCHAR(100),
    Result NVARCHAR(200),
    Notes NVARCHAR(1000),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

USE WeManageDB;

CREATE TRIGGER trg_CheckDevelopmentOverlap
ON EmployeeDevelopments
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM EmployeeDevelopments ed
        INNER JOIN inserted i ON ed.EmployeeID = i.EmployeeID
        WHERE 
            (ed.StartDate <= i.EndDate AND i.StartDate <= ed.EndDate)
            AND ed.DevelopmentID != i.DevelopmentID
    )
    BEGIN
        RAISERROR('An employee cannot be enrolled in overlapping development programs.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;



INSERT INTO EmployeeDevelopments (EmployeeID, DevelopmentType, Title, StartDate, EndDate, Provider, Status, Result, Notes) 
VALUES
(1, 'Training', 'Advanced Project Management', '2024-01-10', '2024-01-15', 'PMI Institute', 'Completed', 'Certificate Obtained', 'Enhanced project management skills'),
(2, 'Workshop', 'Effective Communication Skills', '2024-02-20', '2024-02-22', 'SkillPath', 'Completed', 'Participation Certificate', 'Improved communication and presentation skills'),
(3, 'Seminar', 'Latest Trends in AI', '2024-03-05', NULL, 'TechExpo', 'In Progress', '', 'Staying updated with AI advancements'),
(4, 'Certification', 'Certified Data Analyst', '2024-04-01', '2024-08-01', 'DataCamp', 'In Progress', '', 'Pursuing data analysis certification'),
(5, 'Training', 'Leadership for New Managers', '2024-03-15', '2024-03-17', 'Leadership Academy', 'Completed', 'Certificate Obtained', 'Leadership skills for managing teams'),
(6, 'Workshop', 'Creative Problem Solving', '2024-05-10', '2024-05-12', 'Innovate Inc', 'Planned', '', 'Scheduled for next quarter'),
(7, 'Seminar', 'Cybersecurity Essentials', '2024-02-07', NULL, 'CyberTech 2024', 'Completed', 'Attendance Certificate', 'Understanding basic cybersecurity principles'),
(8, 'Certification', 'Certified Java Developer', '2024-01-20', '2024-06-20', 'Oracle University', 'In Progress', '', 'Enhancing Java programming skills'),
(9, 'Training', 'Advanced Excel Techniques', '2024-03-25', '2024-03-27', 'Excel Experts', 'Completed', 'Certificate Obtained', 'Mastered advanced Excel features'),
(10, 'Workshop', 'Team Building Activities', '2024-04-15', '2024-04-16', 'Team Dynamics', 'Completed', 'Participation Certificate', 'Enhanced team cooperation and morale');

CREATE TABLE Profiles (
    ProfileID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    ActivityDate DATE,
    ActivityType NVARCHAR(100),
    ActivityDescription NVARCHAR(255),
    Impact NVARCHAR(100),
    VisibilityLevel NVARCHAR(50),
    Assessment NVARCHAR(10) CHECK (Assessment IN ('Positive', 'Negative')),
    Notes NVARCHAR(255)
);

USE WeManageDB;

INSERT INTO Profiles (EmployeeID, ActivityDate, ActivityType, ActivityDescription, Impact, VisibilityLevel, Assessment, Notes)
VALUES
(1, '2024-01-15', 'Charity Event', 'Participated in local charity run', 'Raised $5000', 'Local', 'Positive', 'Raised funds for local hospital'),
(2, '2024-02-20', 'Public Speaking', 'Spoke at a tech conference', 'Shared industry insights', 'National', 'Positive', 'Engaged with tech community'),
(3, '2024-03-05', 'Social Media Engagement', 'Promoted company values on social media', 'Increased brand awareness', 'International', 'Positive', 'Positive feedback from followers'),
(4, '2024-04-10', 'Charity Event', 'Organized a charity concert', 'Raised $15000', 'Local', 'Positive', 'Successful event with local artists'),
(5, '2024-05-18', 'Public Speaking', 'Guest speaker at university', 'Inspired students', 'Local', 'Positive', 'Discussed career opportunities'),
(6, '2024-06-22', 'Social Media Engagement', 'Negative remarks on social media', 'Damaged personal reputation', 'International', 'Negative', 'Required PR intervention'),
(7, '2024-07-30', 'Charity Event', 'Volunteered at a food bank', 'Helped hundreds of families', 'Local', 'Positive', 'Team building activity'),
(8, '2024-08-15', 'Public Speaking', 'Misrepresented company at a public event', 'Negative media coverage', 'National', 'Negative', 'Public apology issued'),
(9, '2024-09-25', 'Social Media Engagement', 'Social media campaign for environmental awareness', 'Positive environmental impact', 'International', 'Positive', 'Collaboration with NGOs'),
(10, '2024-10-30', 'Charity Event', 'Participated in international fundraising', 'Raised $25000', 'International', 'Positive', 'Supported global cause'),
(11, '2024-11-12', 'Public Speaking', 'Keynote speaker at an industry summit', 'Enhanced company image', 'National', 'Positive', 'Received industry recognition'),
(12, '2024-12-05', 'Social Media Engagement', 'Controversial political statements', 'Public relations issue', 'International', 'Negative', 'Disciplinary action taken'),
(1, '2024-03-10', 'Charity Event', 'Hosted a charity auction', 'Raised $10000', 'Local', 'Positive', 'Engaged with community leaders'),
(2, '2024-05-22', 'Public Speaking', 'Panelist at a business forum', 'Shared business insights', 'National', 'Positive', 'Positive feedback from attendees'),
(3, '2024-07-15', 'Social Media Engagement', 'Promoted diversity and inclusion', 'Positive company image', 'International', 'Positive', 'Aligned with company values'),
(4, '2024-08-28', 'Charity Event', 'Marathon for health awareness', 'Promoted healthy living', 'Local', 'Positive', 'Team participated together'),
(5, '2024-09-18', 'Public Speaking', 'Spoke at a community event', 'Inspired local community', 'Local', 'Positive', 'Focused on community engagement'),
(6, '2024-10-31', 'Social Media Engagement', 'Advocated for mental health awareness', 'Positive impact on community', 'International', 'Positive', 'Partnered with health organizations'),
(7, '2024-11-20', 'Charity Event', 'Environmental cleanup activity', 'Improved local environment', 'Local', 'Positive', 'Company sponsored event'),
(8, '2024-12-15', 'Public Speaking', 'Presentation at a tech meetup', 'Shared technical expertise', 'Local', 'Positive', 'Strengthened professional network');



