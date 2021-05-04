# Currency Converter #

This service handles currency conversion. It is mainly a wrapper on a 3rd party service that gives us currency conversion rates. We like the 3rd party service. It is reliable and gives us accurate data. However, their API is limited, as it always returns all of the conversion rates and it only shows the rates from USD to any particular denomination. We would like to be able to convert from any denomination to any denomiation.

## Requested Changes ##

* Create a new class with a function that can take any arbitrary amount from a particular currency and return the converted amount. For example, the function should be able to answer the question of "How many BTC is 10 CAD worth?"
* Imagine that the existing `CurrencyConverterRepository` does a real call to our 3rd party service. You just happen to not have to worry about deserializing the repsonse and creating POCOs. In a real-world scenario, there would be at least 50 currencies returned.
* How can you verify that your code is correct? Testing the code can be difficult, as currency rates change all of the time.

## Submitting Code ##
* Fork this repository and make your changes
* If you have a Github account, create a pull request to your own repository with your changes
* Do not create a pull request against this repository
* If you do not have a Github account, send an e-mail patch
