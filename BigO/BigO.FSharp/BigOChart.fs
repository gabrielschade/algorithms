module BigOChart

open System
open XPlot.GoogleCharts
open System.IO
open System.Diagnostics

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
        [o1;oLogN;oSquareRootN; oN; oNLogN; oSquared; o2PoweredN]
        |> Chart.Line
        |> Chart.WithOptions options
        |> Chart.WithHeight 400
        |> Chart.WithYTitle "Number of Interactions"
        |> Chart.WithLabels ["O(1)";"O(log n)"; "O(√n)";"O(n)";"O(n log n)";"O(n^2)";"O(2^n)"]
    
    let html = chart.GetHtml()
    File.AppendAllLines ("metrics.html",[html])
    
    Process.Start (@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", 
                    "file:\\" + Directory.GetCurrentDirectory() + "\\bigO.html")
    |> ignore  