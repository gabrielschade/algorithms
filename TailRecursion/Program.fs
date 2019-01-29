open System

let helloFunction() =
    printf "Hello"

let rec sum list =
    match list with 
    | [] -> 0 
    | head::tail -> head + sum tail

let tailRecursionSum list =
    let rec _internalSum list acc =
        match list with
        | [] -> acc
        | head::tail -> _internalSum tail (acc+head)

    _internalSum list 0

[<EntryPoint>]
let main argv =  
    List.init 100000 (fun index -> index)
    |> tailRecursionSum
    |> Console.WriteLine

    Console.ReadKey()
    |> ignore

    0
