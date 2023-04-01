/*API Test with MongoDB
This is a sample project that demonstrates how to create a RESTful API using ASP.NET Core with MongoDB as the database.
Setup
To run this project, you will need the following:
•	.NET Core SDK
•	MongoDB


Project Structure
The project structure is as follows:
TrainingCenterAPI/
├── data/
│   ├── CodeForMongoOpr.cs
│   ├── MongoDbAPIManager.cs
│   ├── MongoOprService.cs
│   └── MongodbConfigSetting.cs
├── Models/
│   └── TrainingCenter.cs
├── appsettings.json
├── Program.cs
└── Startup.cs


The data folder contains the CodeForMongoOpr, MongoDbAPIManager, MongoOprService, and MongodbConfigSetting classes. These classes are responsible for managing the MongoDB database and performing CRUD operations on the training center documents.
The Models folder contains the TrainingCenter class, which represents a training center document in the database.
appsettings.json contains the configuration settings for the MongoDB database.
Program.cs contains the Main method, which creates the WebApplication using the WebApplication.CreateBuilder method.
Startup.cs contains the ConfigureServices method, which configures the dependency injection container and registers the MongoDbAPIManager class. It also contains the Configure method, which sets up the routes for the API endpoints.

Endpoints
GET /
Returns a welcome message.
GET /api/training_center_get_all
Returns a list of all training centers.
POST /api/training_center_add
Adds a new training center. The request body should contain a JSON representation of the training center:
*/
