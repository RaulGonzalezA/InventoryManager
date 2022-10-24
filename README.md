# InventoryManager
Inventory Manager for code test

1. Run the application

To run the aplication just need to run the project. To authenticate just need to add user and password. The valid values are Raul - 1234. 

I've declare 4 endpoints. 

- GetItems -> Get all the items
- PostItem -> Add new Item
- DeleteItem -> Deletes a Item
- UpdateItem -> Updates a item.

The documentation of the API is done with Swashbuckle.AspNetCore

2. Desing and Code structure

I use DDD design pattern as sugested into the prove. I've divided the solution in 4 projects and tests.
 - Host
 - Application
 - Domain
 - Infrastructure
 
For the security I've used basic auth and just need to use a user and pasword.
I use inmemory database and is seeded with two users and two items each time that the app starts.

The design patterns that I use for develop the test are:
- Mediator
- Decorator
- Repository
- CQRS

The nuget pakages I've used are the next:
- FluentAssertions - to do the validations of the objects
- MediatorR - to develope the CQRS pattern and separate into commands and queries. And manage the handles.
- EntityFrameworkCode - to manage the database
- Nwtonsoft - to serialize json
- IdentityModels.Tokens.Jwt - to authentication

For testing I've used NUnit, Moq and FluentValidations. I've done a test of one of each files, is needed to complete the tests.

3 - Improvements

Use token bearer and IS for authentication.
Could use dapper for querys
Need to add pagination and somefilters for GetItems()
For the events could send the event by email, by serviceBus or other services
