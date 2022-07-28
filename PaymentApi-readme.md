
# Intro
Readme for PaymentApi sample project. 
Brief discussion of the api endpoint "one-time-payment", and then short notes on how to run the application and the associated unit tests.

# Sample call
The one-time-payment api call can be hit at a url like: 
https://localhost:5001/payments/one-time-payment?amount=40
(Here, assuming running on local machine, port 5001. Change if needed.) 
With that call, also need to pass in a userId on header field "userId".

With the example call as above, the endpoint would return sample output: 

> {
    "beginningBalance": 100,
    "paymentAmount": 40,
    "adjustments": 1.2,
    "balanceRemaining": 58.8,
    "nextPaymentDate": "2022-08-12T00:00:00-05:00"
}

Note on api endpoint structure. For the input, since we are only passing in a single parameter, opted for just a query parameter and not form content in a json body. 


# Running the application
Application can be run from the command line as follows: 
Navigate to folder src/PaymentsApiSample
Execute the command: 

    dotnet run --project PaymentsApi\PaymentsApi.csproj

# Notes towards test automation
Here, supporting two basic types of tests: unit tests and integration tests. 
Unit tests are using dotnet testrunner. Integration tests using Postman. 
## Unit tests
To run the unit tests, 
Navigate to src/PaymentsApiSample/UnitTests 
Execute the command: 

    dotnet test -v normal UnitTests.csproj

## Integration tests
Postman collection is located in the /postman folder. Should be importable from the file. 
