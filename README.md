# Introduction: PersonsAPI 
Proof of concept for IMemory cache 

Demo of an API with commonly used behaviors like pagination and memory cache.

We need an API that provides the removal of dependency of a database on DB2 because the actual BD is too slow on the Clients table because is full of a lot of context that create too much columns only used by each context. 

Example: 
RRHH
Add fields like provider status (active, disabled)

MKT:
Add fields like lead status ( firstCall, Meeting, OnActionFromClient, etc)
Add field of type for types like (Client, Prospect or lead, blackList,etc)

Payments area:
add fields like payment status (ActiveBill, LatePayment,etc)

The arquitecture solution is to cut the dependencies on microservices with single responsability meaner and all the shared data that is base of a person must be on a single microservice.

# Persons API

Documentation:
In process
