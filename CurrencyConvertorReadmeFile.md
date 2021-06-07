# Currency Calculator

## Description
We were requeired to create a service which can be used as a wrapper to a third party service and can give us conversion rates, and based on that, user is able to do the currency conversions. 


# Implementation



## Pattern: Hybrid Repository Pattern

I would call it a hybrid repository pattern implementation because the data access of currency rates is encapsulated with CurrencyConversionRepository and is being consumed by the Conversion service.
The business logic is completely hidden from the consuming application which is in our case the Http triggerd Azure function *CurrencyConverter*

## The Startup.cs file

The startup class with Azure Function is meant for setup and registration of services. In our case, we inject our dependencies like 

 - **CurrencyConversionRepository** as singleton because request for thrid party service will always remain the same.
 -  **ConversionService** as scoped because every request will be different hence we can use same object within the request but different across different requests.

## Repository and services

ConversionService calls the CurrencyConversionRepository returns the required output to the caller. Constructor injection is used here to make our dependencies available. This helps us avoiding the use static class for injected services or for function class.

## Helpers

In this case, we needed only one helper i.e. request validator.
This validator finds if the conversion request is malformatted or incomplete. Based on the validation rules, the application throws the exceptions.
Sample valid request - 

    {
	    "Amount":70,
	    "FromCurrency":"inr",
	    "ToCurrency":"usd"
    }

## The driver: Http Azure Function

The driver of the wrapper is the Http triggered Azure function. Again, the constructor injection is used to make the dependencies available. In our code, we are not using config, but I just put it for our the sake of future use as a placeholder.

 - The try-catch block - In our case, we know all kinds of scenarios where our application might throw an error and hence we want to handle all the errors gracefully. 
 - Logging - The strongest part of any application is the logging. Good logging mechanism helps track the errors in the application and hence makes developer efficient. Here, each execution will have a unique guid and that can be used to trace a particular execution. Although function host invocation id is able to do that but in complex applications, the tracking id should start from the GUI and must be cascaded to the end of the application making a complete roundtrip. Just to illustrate that, I have used a reference guid.

Sample error response - 

    {
    	"Message": "Specified argument was out of the range of valid values. (Parameter 'Requested Currency is not valid.'), TrackingId=ec28bb91-e049-4427-ace9-44bc37f41e96"
    }

That was all about the implementation, now let's have a look to test cases.

# Unit Tests

For covering all the scenarios, unit tests are written to check whether conversion works correctly, entered denomination is valid or the currency which user has entered is valid. 

Also, negative tests like user enters some invalid inputs, whether the method is throwing expected exception, are also covered.
Sample requests are added into json files (e.g.**Sample_Valid_Request**) in the form of list of requests. The *CurrencyDataRequest.cs* helps providing the static methods which are consumed in the unit cases for the sample requests.

I chose this approach because we can even make our tests look less clumsy and this json file can be further extended to add more test cases and hence increase the reusablity.
