# SQL-TableValued-CLR

![screenshot](https://httpsimage.com/v2/3f554f60-e5f2-40e8-b04f-126f45273fd4.png)

This is an example of a Table Valued CLR Function for SQL server that demonstrates how SQL server
can call an API directly, without a webserver involved. The API called returns JSON, and this function
converts the JSON into a table, with two columns, Property, and TextValue

The Json is retrieved from the URL https://www.regcheck.org.uk/api/json.aspx/Check/SK08KPT, and is returned as follows;
```json
{
  "ABICode": "52077701",
  "Description": "2008 Vauxhall Corsa Club, 1364CC Petrol, 3DR, Manual",
  "RegistrationYear": "2008",
  "CarMake": {
    "CurrentTextValue": "Vauxhall"
  },
  "CarModel": {
    "CurrentTextValue": "Corsa"
  },
  "EngineSize": {
    "CurrentTextValue": "1364CC"
  },
  "FuelType": {
    "CurrentTextValue": "Petrol"
  },
  "MakeDescription": "Vauxhall",
  "ModelDescription": "Corsa",
  "Immobiliser": {
    "CurrentTextValue": ""
  },
  "NumberOfSeats": {
    "CurrentTextValue": 5
  },
  "IndicativeValue": {
    "CurrentTextValue": ""
  },
  "DriverSide": {
    "CurrentTextValue": "RHD"
  },
  "ImageUrl": "\/image\/vehicleimage\/none"
}
```

Which becomes

| Property  | TextValue |
| ------------- | ------------- |
| ABICode | 52077701 |
| Description | 2008 Vauxhall Corsa Club, 1364CC Petrol, 3DR, Manual |
| RegistrationYear | 2008 |
| CarMake | Vauxhall |
| CarModel | Corsa |
| EngineSize | 1364CC |
| FuelType | Petrol |
| MakeDescription | Vauxhall |
| ModelDescription | Corsa |
| Immobiliser |  |
| NumberOfSeats | 5 |
| IndicativeValue |  |	
| DriverSide | RHD |
| ImageUrl | /image/vehicleimage/none |

