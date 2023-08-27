# National Parks API

### Pier Rodriguez

#### An API that allows users to get and post info about National Parks

## Technologies Used

* _C#/.Net_
* _Sql Workbench_
* _mvc_
*_EF_
_Swagger_

## Description

An API that allows users to GET, POST, EDIT and DELETE info about National Parks.

* GET gives you a list of all available parks
* POST allows any user to beable to create or add a new park.
* GET ID - gives info about a specific park
* PUT allow any user to update info about the park.
* DELETE ID - allows any user to delete a park by its id.
* GET / PAGINATION - allows me to retrieve info from a large dataset.

## SetUp/Installation Reqs

1. Run the following command 

    'git clone https://github.com/pierknows1/NationalParkAPI/'

2. cd NationalParks

3. Add your own appsettings.json inside the root folder.

*use this command 

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=national_parks;uid=[USERNAME];pwd=[PASSWORD];"
  } 
}

4. Run the command

- dotnet ef database update in NationalParks Folder.

5. Run the command 

- dotnet watch run and add the following url to your browser 

    'https://localhost:5001/swagger/index.html'

#### HTTP Request Structure

GET https://localhost:5001/api/Parks
GET https://localhost:5001/api/Parks/{id}
POST https://localhost:5001/api/Parks
PUT https://localhost:5001/api/Parks/{id}
DELETE https://localhost:5001/api/Parks/{id}

## Known Bugs 

* _Cant test CORS_ ? added it cause it was simple to add to program.cs

## License

MIT License

_Copyright_ _2023_ _Pier Rodriguez_


