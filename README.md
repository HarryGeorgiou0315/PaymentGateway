# Payment Gateway API

###Overview:
- The Payment Gateway API is to be used as a middle layer between a merchant and  an acquiring bank. 
- In this solution, the acquiring bank is a simulator API with mock responses. It is used to test the payment gateway end-to-end. For a production environment, the environment variable used for the acquiring bank API URL will be replaced with that of the real acquiring bank API. 
	- The use of environment variable for the acquiring bank URL makes it easy to use this solution in a production environment, without any code changes
	- As the requirements did not state the exact request/response of a real acquiring bank API, please note that I made assumption of what those might look like 

Payment Gateway example GET request

     GET /api/payments/{Guid::paymentId}

Payment Gateway example POST request (all request body fields are required)

     POST /api/payments/
        
	 Example JSON request body:
			 {
			    "cardType": "Visa",
			    "firstName": "John",
			    "lastName": "Smith",
			    "address": "123 Test Avenue",
			    "postcode": "T1 1TT",
			    "nameOnCard": "MR J Smith",
			    "cardNumber": "1234567890123456",
			    "expiryDate": "10/2020",
			    "amount": 100.0,
			    "currency": "GBP",
			    "cvv": 123
			}

## How to use the Payment Gateway API 

The payment Gateway is set-up to use Docker to build and run the project and run the tests. 

By using Docker, the solution makes use of docker-compose and linked services, in order to run the Payment Gateway API and its dependencies required for testing (Acquiring Bank Simulator API)

* run the tests by running the following command in terminal - `docker-compose build payment-gateway-api-test` followed by `docker-compose run payment-gateway-api-test`. *This will spin up the `payment-gateway-api-test` and `aquiring-bank-simulator` into two separate containers. The latter service is required for end-to-end tests to work.*

* run the solution by running the following command in terminal - `docker-compose up -d payment-gateway-api`. *This will spin up the `payment-gateway-api` and `aquiring-bank-simulator` into two separate containers.*

**Note: It is required to use Docker to run this solution in order to test it. If the solution is not run via Docker, the required dependency of the Acquiring Bank Simulator API will not be run and the Payment Gateway API will fail as it won't be able to connect to the Acquiring Bank API**

**If you want to run the Payment Gateway API using visual studio you will need to make sure that you set the environmental variable (`AQUIRING_BANK_URL:http://127.0.0.1:3001`) in the project and that you run the Acquiring Bank Simulator container via Docker.**

**Using the Payment Gateway API:**

*Test Payment Ids you can use to test the GET request with (The simulator has been pre-configured with those IDs. Any other IDs would result in the simulator returning HTTP status code of 404:*
	
	cf1f51d5-5cc1-42ab-94f6-a10d0aa25ef3
	92752c4b-3ab4-4069-a2eb-613efda81a66


1. **Process a payment** - make a `POST` request to `http://127.0.0.1:3000/api/payments` : Returns status `201 Created` alongside the ID of the payment processed.

		JSON body:
			 {
			    "cardType": "Visa",
			    "firstName": "John",
			    "lastName": "Smith",
			    "address": "123 Test Avenue",
			    "postcode": "T1 1TT",
			    "name": "MR J Smith",
			    "cardNumber": "1234567890123456",
    			"nameOnCard": "MR J Smith",
			    "expiryDate": "10/2020",
			    "amount": 100.0,
			    "currency": "GBP",
			    "cvv": 123
			} 

2. **Retrieve a payment** - make a `GET` request to `http://127.0.0.1:3000/api/payments/cf1f51d5-5cc1-42ab-94f6-a10d0aa25ef3` : Return status `200 OK`. 


Swagger documentation - `http://127.0.0.1:3000/index.html`

## Further Developer Notes

### Assumptions: 
- This API Request/Responses are based on information I assume it needs to be included based on the task brief provided.
- I assumed that the payment process ID is of type GUID

### Future improvement:
- At the moment the Simulator is simulating mock responses in code. But, as a future improvement, the use of a test database that the simulator interacts with would be preferred.
- Simulator has been structured in a basic way due to time restrictions, however, if this was a real project, a test/staging version of the real Acquiring Bank API will be used, structured in accordance to the SOLID principles and interacting with a real data source to simulate a realistic end-to-end flow. 