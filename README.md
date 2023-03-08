Main


GET
/Main/Queue
return player id
PUT
/Main/QueueProto

GET
/Main/GetGame
require player id check if game? return board
PUT
/Main/Put
make turn return board
PUT
/Main/PutProto

GET
/Main/GetGameProto

Schemas
GameModel{
id	integer($int32)
}
TurnModel{
id	integer($int32)
turnCell	integer($int32)
}
