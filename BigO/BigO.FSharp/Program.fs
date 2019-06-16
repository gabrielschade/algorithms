open System

let isEvenAt index (list : int list) =
    list.[index] % 2 = 0

let rec containsValue value (list:int list)=
    match list with
    | [] -> false
    | head::tail when head = value -> true
    | _::tail -> containsValue value tail

let rec containsDuplicatedValues (list:int list) =
    let rec compareToList number position (innerList:int list) =
        match innerList with
        | [] -> false
        | head::tail when head = number && tail.Length <> position -> true
        | _::tail -> compareToList number position tail

    match list with
    | [] -> false
    | head::tail -> compareToList head tail.Length list

let rec exponential number = 
    if number <= 1
        then number
        else exponential (number-1) + exponential (number-1)


let binarySearch value (list:int list)=
    let rec containsValueAt innerValue (innerList: int list) first last  =
        let index = (first + last) / 2
        match innerList with
        | _ when first > last -> false
        | innerList when innerValue > innerList.[index] -> containsValueAt innerValue innerList (index+1) last
        | innerList when innerValue < innerList.[index] -> containsValueAt innerValue innerList first (index-1)
        | _ -> true

    containsValueAt value list 0 list.Length

[<EntryPoint>]
let main argv =
    let list = [for number in 1..100 do yield number]
    list
    |> binarySearch 40
    |> Console.WriteLine 

    0
