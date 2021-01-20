## .Net Core + MongoDb (NoSql) Backend Test
* This Solution Built Using N-Tier Architecture and CQRS Design Pattern

## CQRS Design Pattern
* Command Query Responsibility Segregation Design Pattern (CQRS) To Separate
  Commands and Queries
  
## CompanyContact.Api
* Contain Controllers and Configs Of the Project (Startup)
  
## CompanyContact.Appilication
* This is Business Logic Layaer..That contain Handling the requests from the Controllers and processing it

## CompanyContact.DAL
* This Data Access Layaer..That contain database Conffigs and Repositories.. and its responsible to send Command and Queries to Database

## CompanyContact.Core
* This is Domain Layaer..That contain Entities , Interfaces , Models , Enums .. etc

<br/>

## Technologies

* .NET Core 3.1
* MongoDb
* MediatR
* FluentValidation
* Swagger

Test APIs From: http://localhost:51979/swagger/index.html
Using Robo 3T 
"DatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "CompanyContacts"
  }
