module Oware

type StartingPosition =
    | South
    | North

 //Layout of the whole board game consisting of all the houses, the scores and position situated on the board
type Board = {
    a:int
    b:int
    c:int
    d:int
    e:int
    f:int
    a':int
    b':int
    c':int
    d':int
    e':int
    f':int
    northScore:int
    southScore:int
    position:StartingPosition}
//board
    
//Returns the number of seeds in each house 
let getSeeds n board = 
    match n with
    |1 -> board.a
    |2 -> board.b
    |3 -> board.c
    |4 -> board.d
    |5 -> board.e
    |6 -> board.f
    |7 -> board.a'
    |8 -> board.b'
    |9 -> board.c'
    |10 -> board.d'
    |11 -> board.e'
    |12 -> board.f'
    |_ -> failwith "Out of range"
//getSeeds

let useHouse n board = failwith "Not implemented"

//Initializes the default start values of the game
let start position ={a = 4; b = 4; c = 4; d = 4; e =  4; f = 4; a' = 4; b' = 4; c' = 4; d' = 4; e' = 4; f' = 4; northScore = 0; southScore = 0; position = position}

//Keeps track of the score of the North and South positions in the game
let score board = (board.northScore,board.southScore)
//score

//Keeps track of the games' current state
let gameState board = 
    match (board.northScore < 24 && board.position = North), (board.northScore < 24 && board.position = South) , (board.northScore >= 24 || board.southScore >= 24) with
    |true,_,_ -> "South's turn"
    |_,true,_ -> "North's turn"
    |_ -> 
        match (board.northScore >= 24 && board.southScore < 24), (board.southScore >= 24 && board.northScore < 24), (board.northScore >= 24 && board.southScore >= 24) with
        |true,_,_ -> "North won"
        |_,true,_ -> "South won"
        |_ -> "Game ended in a draw"
//gameState

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    printfn "Planning to merge with Sihle97"
    0 // return an integer exit code