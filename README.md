# Mambu connector
![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.1-blue)

## Overview
This NuGet package is designed to simplify the configuration and management of a Mambu instance. By encapsulating HTTP requests, this package eases interaction with the Mambu API, allowing for quick and efficient integration.

## Package Installation

`MambuConnector` requires the installation of certain NuGet packages. You can install them using the `dotnet add package` command in the terminal or through the NuGet package manager in your IDE.

Execute the following commands to install the necessary packages:

```bash
dotnet add package MambuConnector
```

## Usage
`MambuConnector` offers a modular and extensible approach to configure the management of your Mambu instance.

### Configuration
First, you need to add `MambuConnector` to your service container using the `AddMambuConnector` extension method.

```csharp
using MambuConnector.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// MambuConnector Configuration
builder.Services.AddMambuConnector(mambuConfig =>
{
    mambuConfig.Url = "https://your_mambu_instance.com";
    mambuConfig.User = "your_username";
    mambuConfig.Password = "your_password";
});

var app = builder.Build();
```

Make sure to replace “https://your_mambu_instance.com”, “your_username”, and “your_password” with the corresponding values for your Mambu environment. With this setup, you will be ready to leverage the capabilities of MambuConnector to perform operations against the Mambu API.


## Examples

### Create a Loan account
This example shows how to create a loan account in Mambu
```csharp
// This service enables the creation and management of loan accounts within Mambu.
public class LoanAccountsService
{
    // Mambu connector injected to interact with the API.
    private readonly IMambuConnector _mambuConnector;

    // The constructor receives the Mambu connector.
    public GroupService(IMambuConnector mambuConnector)
    {
        _mambuConnector = mambuConnector;
    }

    // Creates a new loan account in Mambu using the provided data.
    public async Task CreateLoanAccountAsync(LoanAccount loanAccount)
    {
        // The CreateAsync method sends a request to the Mambu API to create the loan account.
        await _mambuConnector.LoanAccounts.Create(loanAccount);

    }
}
```

### Retrieve Client Information by ID
This example demonstrates how to retrieve detailed information of a client using their ID

```csharp
// This service facilitates the retrieval and management of client information.
public class ClientService
{
    // Mambu connector injected to interact with the API.
    private readonly IMambuConnector _mambuConnector;

    // The constructor receives the Mambu connector.
    public ClientService(IMambuConnector mambuConnector)
    {
        _mambuConnector = mambuConnector;
    }

    // Retrieves detailed information of a client by their unique ID.
    public async Task<Client> GetClientByIdAsync(string clientId)
    {
        // The GetByIdAsync method queries the API to obtain the client's data.
        var client = await _mambuConnector.Clients.GetById(clientId);

        return client;
    }
}

```

### Search criteria builder
The `SearchCriteriaBuilder` is a tool of the Builder design pattern that simplifies the creation of `SearchCriteria` objects, allowing step-by-step configuration of search and sorting criteria in a clear and readable manner.

This example illustrates the use of `SearchCriteriaBuilder` for performing a search for clients.

```csharp
// Create and configure the search criteria fluently.
var searchCriteria = new SearchCriteriaBuilder()
    .AddFilterCriteria("status", FilterOperator.EQUALS, "Active") // Filter by active clients.
    .AddBetweenFilter("creationDate", "2022-01-01", "2022-12-31") // Filter by date range.
    .AddInFilter("clientId", new List<string> { "123", "456", "789" }) // Filter by multiple identifiers.
    .SetSorting("clientName", SortingOrder.ASC) // Sort by client name in ascending order.
    .Build(); // Build the search criteria.

// Use MambuConnector to perform a search operation with the built criteria.
var clients = await _mambuConnector.Clients.Search(searchCriteria);

```


