# README

How to run the app:

docker-compose up

Use e.g postman and send request on localhost:5044/api/path with e.g. JSON body:

{
  "start": {
    "x": 0,
    "y": 0
  },
  "commands": [
    {
      "direction": "West",
      "steps": 2
    },
    {
        "direction": "North",
        "steps": 5
    }
  ]
}

Result is stored in postgres database as well as printed in console.