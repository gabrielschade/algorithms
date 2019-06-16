// Learn more about F# at http://fsharp.org

open System
open Microsoft.FSharp.Linq
open XPlot.GoogleCharts
open System.IO
open System.Diagnostics

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

let valueOrNull value =
    match value with
    | n when n > 100.0 -> Nullable()
    | _ -> Nullable(value)

let generateBigOGraph =
    let baseList = [for number in 1..1000 do yield (float)number]
    let o1 = baseList |> List.map(fun n -> n.ToString(), 1.0)
    let oLogN = baseList |> List.map( fun n -> n.ToString(), Math.Log(n,2.0))
    let oSquareRootN = baseList |> List.map (fun n -> n.ToString(), Math.Sqrt(n))
    let oN = baseList |> List.map(fun n -> n.ToString(), n)
    let oNLogN = baseList |> List.map(fun n -> n.ToString(), n * (Math.Log(n,2.0)))
    let oSquared = baseList |> List.map( fun n -> n.ToString(), n * n)
    let o2PoweredN = baseList |> List.map( fun n -> n.ToString(), Math.Pow(2.0, n))
    let options = Options ( 
                            title = "Big-O", 
                            curveType = "function", 
                            legend = Legend(position = "bottom"),
                            vAxis = Axis ( 
                                maxValue = 50
                            )
    )
    

    let chart = 
        [oLogN; ]//oLogN;oSquareRootN; oN; ]//oNLogN; ]//oSquared;]// o2PoweredN]
        |> Chart.Line
        |> Chart.WithOptions options
        |> Chart.WithHeight 400
        |> Chart.WithYTitle "Number of Interactions"
        |> Chart.WithLabels ["O(log n)";]// "O(log n)"; "O(√n)";"O(n)"]//;"O(n log n)"]//;"O(n^2)"]//;"O(2^n)"]
    
    let html = chart.GetHtml()
    File.AppendAllLines ("metrics.html",[html])
    
    Process.Start (@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", 
                    "file:\\" + Directory.GetCurrentDirectory() + "\\metrics.html")
    |> ignore  
    0

[<EntryPoint>]
let main argv =
    let list = [for number in 1..100 do yield number]
    list
    |> binarySearch 40
    |> Console.WriteLine


    generateBigOGraph |> ignore
    

    0 // return an integer exit code
