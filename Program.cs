using api_test_with_mongo.data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Configure the MongoDB settings from the configuration file
builder.Services.Configure<MongodbConfigSetting>(builder.Configuration.GetSection("MongoDbSettings"));

// Register the MongoDbAPIManager to the dependency injection container
builder.Services.AddSingleton<MongoDbAPIManager>();

var app = builder.Build();

// Route for the root endpoint
app.MapGet("/", () => "Welcome to Training Center");

// Route for getting all training centers
app.MapGet("/api/training_center_get_all", 
    async (MongoDbAPIManager mongooprservice) =>
{
    var trainingCenters = await mongooprservice.GetAll();
    return Results.Ok(trainingCenters);
});

// Route for adding a new training center
app.MapPost("/api/training_center_add", 
    async (MongoDbAPIManager mongooprservice, CodeForMongoOpr codeformongoopr) =>
{
    // Validate the model state before proceeding
    var validationResults = new List<ValidationResult>();
    var validationContext = new ValidationContext(codeformongoopr, null, null);
    if (!Validator.TryValidateObject(codeformongoopr, validationContext, validationResults, true))
    {
        return Results.BadRequest(validationResults);
    }

    // CreateDocument the new training center and return an OK result
    await mongooprservice.CreateDocument(codeformongoopr);
    return Results.Ok();
});

app.Run();
