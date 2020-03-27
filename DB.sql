CREATE DATABASE LibraryManagementSystem; 
USE LibraryManagementSystem ;

CREATE TABLE PublicationType 
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
NAME NVARCHAR(255)
); 

CREATE TABLE MemberType 
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
NAME NVARCHAR(255)
); 



CREATE TABLE PUBLISHER
(
ID INT IDENTITY(1,1) PRIMARY KEY ,
PublicationTypeId int FOREIGN KEY REFERENCES PublicationType(Id), 
NAME NVARCHAR(255), 
ADDRESS NVARCHAR(255), 
EMAIL NVARCHAR(255), 
CONTACT_NO NVARCHAR(50)
); 

CREATE TABLE MEMBER
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
MemberTypeId int foreign key references MemberType(Id), 
MEMBERSHIP_ID NVARCHAR(50), 
MEMBERSHIP_DATE DATE DEFAULT GETDATE(), 
FIRST_NAME NVARCHAR(255), 
LAST_NAME NVARCHAR(255), 
ADDRESS NVARCHAR(255), 
EMAIL NVARCHAR(255), 
CONTACT_NO NVARCHAR(50), 
EDUCATION NVARCHAR(255), 
REMARKS NVARCHAR(255)
); 


CREATE TABLE BOOK_CATEGORY
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
NAME NVARCHAR(255)
);



CREATE TABLE AUTHOR 
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
FIRST_NAME NVARCHAR(255), 
LAST_NAME NVARCHAR(255), 
ADDRESS NVARCHAR(255), 
EMAIL NVARCHAR(255), 
CONTACT_NO NVARCHAR(50), 
EDUCATION NVARCHAR(255), 
SPECIALIZATION NVARCHAR(255),
REMARKS NVARCHAR(255)
); 

 
CREATE TABLE BOOK 
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
BOOK_CATEGORY_ID INT FOREIGN KEY REFERENCES BOOK_CATEGORY(ID) , 
PUBLISHER_ID INT FOREIGN KEY REFERENCES PUBLISHER(ID), 
BOOK_NAME NVARCHAR(255), 
BOOK_SUBJECT NVARCHAR(255), 
BOOK_DESCRIPTION NVARCHAR(255), 

);
--ALTER TABLE BOOK
--ADD FOREIGN KEY (PUBLISHER_ID) REFERENCES PUBLISHER(ID); 
 
CREATE TABLE BOOK_ISSUE 
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
ISSUE_DATE DATE DEFAULT GETDATE(), 
BOOK_ID INT FOREIGN KEY REFERENCES BOOK(ID), 
MEMBER_ID INT  FOREIGN KEY REFERENCES MEMBER(ID), 
NO_OF_DAYS INT, 
FINE DECIMAL(18,2) DEFAULT 0, 
REMARKS NVARCHAR(255)

);

CREATE TABLE BOOK_RECEIEVED
(
ID INT IDENTITY(1,1) PRIMARY KEY , 
[DATE] DATE DEFAULT GETDATE(), 
BOOK_ID INT FOREIGN KEY REFERENCES BOOK(ID), 
MEMBER_ID INT  FOREIGN KEY REFERENCES MEMBER(ID), 
FINE DECIMAL(18,2) DEFAULT 0, 
REMARKS NVARCHAR(255)

);