# InventoryManager
Inventory Manager for code test

1. Run the application

To run the aplication just need to run the project. To authenticate just need to add user and password. The valid values are Raul - 1234. 

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

For testing I've used NUnit, Moq and FluentValidations.
