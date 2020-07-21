# GenePlanet Backend API task

The purpose of the challenge is to build a smart-cacheservice that holds a list of breached emails. Example of similar application can be found in here: https://haveibeenpwned.com/. It includes:

- GET requests
- POST requests
- DELETE requests
- MySQL
- Unit tests

# Prerequisites
 - MySQL server(connection string available in settings.json)
 - asp.net core 3.1

# Usage
- Download package
- Set up mysql connection string in settings.json
- Run GenePlanet.exe
- Connect to http://localhost:5000/swagger/v1/swagger.json to explore api endpoints
- Have fun

# Example:
- Create GET request on http://localhost:5000/BreachedEmails/marko.skace@gmail.com
- then create POST request on http://localhost:5000/BreachedEmails with JSON in body { "email" : "marko.skace@gmail.com" }
- repeat previous GET request to see the difference 

# Solution
GenePlanet solution includes 2 projects, Tests and Main application. Main application uses migrations in combination of EF Core. It checks on startup if migrations have been ran, otherwise it does it itself, so no additional steps are required to set it up and get it running. Smart-caching is a bit of a lie, as it only acts as an in-memory repository(mirrored database). It gets populated from the databas on the startup also(clones by keys) and it mirrors actions(create/delete). In case application crashes/restarts, data persists in database and fills memory cache when it starts back up. Implementation has its flaws and advantages, which of course can be discussed.