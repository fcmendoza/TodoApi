## Search/Listing API

### Search Vehicles

* Retrieves available vehicles based on searching criteria or empty if nonthing is found.
* Sample Request Uri:

```sh
GET /api/vehicles?lat=58.50&lng=22.77&start-20200129T18:00:00Z&end=20200201T18:00:00Z&min_price=10&max_price=250
```

Search criteria

```sh
&min_rate=4
&max_rate=5
&child_seat=true
&type=car
&make=Tesla
&year_min=2016
&year_max=2020
&color=red
,...
```

Response:

```sh
HTTP/1.1 200 OK
Content-Type: application/json

[{
    "rank" : 1
    "id": "1234",
    "name": "Tesla Model S 2019",
    "trips_count": 15,
    "hasDelivery": true,
    "make": "Tesla",
    "year": 2019,
    "hourlyRate": 100,
    "rating": 5,
    "numberOfSeats": 4,
    "features": null,  ...
},{
    "rank": 2
    "id": "5678",
    "name": "Tesla Model X 2018",
    "trips_count" : 29,
    "hasDelivery": false,
    "make": "Tesla",
    "year": 2018,
    "hourlyRate": 200,
    "rating": 4.5,
    "numberOfSeats": 5,
    "features": null,  ...,
}, ...]
```