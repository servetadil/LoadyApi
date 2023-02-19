# LoadyApi
 This REST API retrieves a list of available truck drivers and filters by location (City).

 The Truck Driver List API is a REST API that returns a list of available truck drivers. This API allows you to filter the results by city name.

## Technologies
* .Net 6
* Azure CosmosDB/MongoDB
* Azure Devops
* Terraform
* XUnit
* Docker


## API Endpoint

`GET Driver/GetByCity`

### Request
    curl -i -H 'Accept: application/json' -d 'cityname=köln' http://localhost:44326/Driver/GetByCity

### Response

    HTTP/1.1 200 OK
    Date: Mon, 20 Feb 2023 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 36

    [{"name":"Tom","surname":"Cruise","city":"Köln","country":"Germany"}]


### Azure Infrastructure with Terraform
This project uses Terraform to create infrastructure on Microsoft Azure. This README provides an overview of the project and instructions on how to use it.

#### Project Structure
The project has the following structure:

.
├── main.tf
├── terraform.tfstate

main.tf: This file contains the Terraform code to create the infrastructure on Azure.<br />
terraform.tfstate: This file contains the state of the infrastructure created by Terraform.<br />

#### Prerequisites<br />
Before you can use this project, you need to install the following tools:

- Terraform <br/>
- Azure CLI <br/>

You also need to have an active Azure subscription and an Azure service principal with contributor access to the subscription.


### Libraries

**MongoDB Driver**: It has been used for connect to MongoDB

Documentation: [https://www.mongodb.com/docs/drivers/csharp/current/](https://www.mongodb.com/docs/drivers/csharp/current/)

**FluentValidation:** It has been used for validation of commands and queries.

Documentation: [https://github.com/FluentValidation/FluentValidation](https://github.com/FluentValidation/FluentValidation)

**AutoMapper**: It has been used for object-to-object mapping from entity to Dto or ViewModels.

Documentation: [https://docs.automapper.org/en/stable/](https://docs.automapper.org/en/stable/)

**Newtonsoft:** It has been used for json convert from enum.

Documentation: [https://www.newtonsoft.com/json/help/html/Introduction.htm](https://www.newtonsoft.com/json/help/html/Introduction.htm)

**Swagger:** It has been used for api documentation and structure.

Documentation: [https://swagger.io/docs/](https://swagger.io/docs/)

**FluentValidation:** It has been used for improve testing readability.

Documentation: [https://fluentassertions.com/introduction](https://github.com/fluentassertions/fluentassertions)**

**xUnit:** It has been used for unit tests.

Documentation: [https://xunit.net/docs/getting-started/netcore/cmdline](https://xunit.net/docs/getting-started/netcore/cmdline)**

**Moq**: It has been used to create mock objects.

Documentation: [https://documentation.help/Moq/](https://documentation.help/Moq/)
