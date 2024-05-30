# Flight Microservice

This microservice is designed to fetch flight information from a provided API, parse the XML data, and expose a RESTful API endpoint to retrieve specific flight details.

## Requirements
- .NET 7 SDK
- Docker (optional)

## Installation
1. Clone this repository to your local machine:
```
git clone https://github.com/RandikaSilva/FlightMicroservice
```
2. Navigate to the project directory:

cd FlightMicroservice


## Running the Microservice
1. Navigate to the project directory:
`cd FlightMicroservice
`
2. Build the .NET solution:
`dotnet build
`
3. Run the microservice:
`dotnet run --project FlightMicroservice.API
`
This will start the microservice locally. It will be accessible.

## Testing the Microservice
### Unit Tests:
Unit tests are located in the FlightMicroservice.Tests project. You can run them using the following command:

This command will run all the unit tests and display the results.
`dotnet test FlightMicroservice.Tests
`
### Manual Testing:
You can manually test the microservice by sending HTTP requests to the exposed endpoints. Here are some sample requests:
- Get all flights & flights by destination:
`GET https://localhost:58223/api/Flights?destination=Miami
`
If we pass the destination param as empty, it will return all the data.

## Dockerization (Optional)
You can also run the microservice in a Docker container. Make sure you have Docker installed on your machine.
1. Build the Docker image:
`docker build -t FlightMicroservice 
`
2. Run the Docker container:
`docker run -d -p 8080:80 --FlightMicroservice:v1
`
The microservice will now be accessible at http://localhost:8080.
