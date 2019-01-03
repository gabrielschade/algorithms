open System

let (^) char string = sprintf "%c%s" char string

let longestCommonSubsequenceSolve original edited =
    let rec solve (original:string) (edited:string) indexOriginal indexEdited =
        let solve' = solve original edited

        let solveWhenDifferentChars indexOriginal indexEdited=
            let resultA : string = solve' (indexOriginal+1) indexEdited
            let resultB : string = solve' indexOriginal (indexEdited+1)
            if resultA.Length > resultB.Length
                then resultA
                else resultB

        match original, edited with
        | original', edited' 
            when indexOriginal = original'.Length || indexEdited = edited'.Length -> 
            String.Empty

        | original', edited' 
            when original'.Chars(indexOriginal) = edited'.Chars(indexEdited) -> 
            original'.Chars(indexOriginal) ^ (solve' (indexOriginal+1) (indexEdited+1) )

        | _ -> solveWhenDifferentChars indexOriginal indexEdited
    
    solve original edited 0 0


let longestCommonSubsequenceSolveWithCache (original:string) (edited:string) =
    let rec solveWithCache 
        (original:string) (edited:string) (cache:string[,]) 
        indexOriginal indexEdited =
        
        let solveWithCache' = solveWithCache original edited cache
        
        let cacheResult indexOriginal indexEdited value =
            cache.[indexOriginal,indexEdited] <- value
            value
        
        let cacheResult' = cacheResult indexOriginal indexEdited

        let solveWhenDifferentCharsWithCache indexOriginal indexEdited=
            let resultA : string = solveWithCache' (indexOriginal+1) indexEdited
            let resultB : string = solveWithCache' indexOriginal (indexEdited+1)
            if resultA.ToString().Length >= resultB.ToString().Length
                then resultA
                else resultB

        match original, edited with
        | original', edited' 
            when indexOriginal = original'.Length || indexEdited = edited'.Length -> 
            String.Empty
        
        | original', edited' 
            when cache.[indexOriginal, indexEdited] <> String.Empty ->
            cache.[indexOriginal, indexEdited]

        | original', edited' 
            when original'.Chars(indexOriginal) = edited'.Chars(indexEdited) -> 
            cacheResult' 
                (original'.Chars(indexOriginal) 
                ^ (solveWithCache' (indexOriginal+1) (indexEdited+1)) )
            
        | _ -> 
            cacheResult' (solveWhenDifferentCharsWithCache indexOriginal indexEdited)
    
    let mutable cache = 
        Array2D.init original.Length edited.Length 
            (fun linha coluna -> String.Empty)

    solveWithCache original edited cache 0 0


[<EntryPoint>]
let main argv =
    longestCommonSubsequenceSolveWithCache "BMOAL" "BLOA"
    |> Console.WriteLine

    longestCommonSubsequenceSolveWithCache "let inicio = 10" "let inicio = 125"
    |> Console.WriteLine

    longestCommonSubsequenceSolveWithCache 
        """let solveWhenDifferentChars indexOriginal indexEdited=
    let resultA : string = solve' (indexOriginal+1) indexEdited
    let resultB : string = solve' indexOriginal (indexEdited+1)
    if resultA.Length > resultB.Length
        then resultA
        else resultB""" 

        """let solveWhenDifferentChars indexOriginal indexEdited=
    let resultA = solve' (indexOriginal+1) indexEdited
    let resultB = solve' indexOriginal (indexEdited+1)
    if resultA.ToString().Length > resultB.ToString().Length
        then resultA
        else resultB"""

        |> Console.WriteLine

    Console.ReadKey() |> ignore
    0
