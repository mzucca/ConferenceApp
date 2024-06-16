# ReHub API Documentation
In this document we'll see all the technical details about implementation of the API of the ReHub project.

## Authentication
The authentication uses the Microsoft.AspNetCore.Authentication.JwtBearer package

# Working environment
host 92.48.105.144
root:thrusters.16I
postgres:
PG_USER=rihubit_main
PG_PASS=RnJSx7gYwukbBDUnOQc24y


# Tests
Sample users: 
Administrator admin@example.com
Doctor morenosimone12@gmail.com
Customer client1@example.com

1. Flusso iniziale delle API
    1. /login
    2. /me
    3. /my-appointments
    4. /my-notifications
2. For administrators:
    1. Admin Panel: /referrer/all
    2. Patients: /client/with_details
3. For Doctors:
    1. Patients: /client/with_details