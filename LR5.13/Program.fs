// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System

let rec mult1 x=
    if x=0 then 1 else
        (x%10)*(mult1 (x/10))

let mult2 x=
    let rec rec_mult x cur=
        if x=0 then cur else
            let newCur = cur*(x%10)
            rec_mult (x/10) newCur
    rec_mult x 1

                         
let rec maxDigit1 x=
    if x<10 then x else
        max (x%10) (maxDigit1 (x/10))

let maxDigit2 x=
    let rec rec_max x cur=
        if x=0 then cur else
            let newCur = 
                if ((x%10)>cur) then (x%10) else cur
            rec_max (x/10) newCur
    rec_max x 0
            
let rec minDigit1 x=
    if x<10 then x else
        min (x%10) (minDigit1 (x/10))

let minDigit2 x=
    let rec rec_min x cur=
        if x=0 then cur else
            let newCur = 
                if ((x%10)<cur) then (x%10) else cur
            rec_min (x/10) newCur
    rec_min x 9       


[<EntryPoint>]
let main argv =
    Console.WriteLine(minDigit2 243)
    0 // return an integer exit code
