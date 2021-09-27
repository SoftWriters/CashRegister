# Prerequisites

1. [Download .NET 5.0.102 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- The MVC project was created using the `dotnet new mvc` cli command.
- The test project was created using the `dotnet new nunit` cli command

## Running the Application
Using the `dotnet` command line interface, navigate to [the CashRegister project folder](./CashRegister) and run the following command:

```
dotnet run
```

### Swagger UI
After running this command, you can navigate to the port specified in the output of the above command. To navigate to the Swagger UI, 
simply append `/swagger` to your localhost port e.g: `https://localhost:5001/swagger`

## Testing the Application

### Unit Testing
From the root of the project run the following command to run the unit tests:

```
dotnet test
```

### Manual Testing
The application can be manually tested by navigating to the [Swagger link.](#swagger-ui) This provides a physical and easy way to 
verify the code. 

# Technologies

1. .NET 5 - MVC Framework
2. [SwashBuckle](https://www.nuget.org/packages/Swashbuckle) - API Documentation Generation
3. [CsvHelper](https://www.nuget.org/packages/CsvHelper) - Library for parsing CSV related data