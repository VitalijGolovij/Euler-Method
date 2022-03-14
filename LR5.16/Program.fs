// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System

let rec nod (a:int) (b:int) =
    if ((a % b) = 0) then 
        b
    else
        nod a (a%b)

let components x f init =
    let rec rec_components x f counter cur=
        if counter = 0 then cur 
        else
            let newCur = if (nod x counter)=1 then f counter cur else cur
            rec_components x f (counter-1) newCur
    rec_components x f (x-1) init

let Euler x =
    let rec rec_Euler x counter cur=
        if counter = 0 then cur 
        else
            let newCur = if (nod x counter)=1 then cur+1 else cur
            rec_Euler x (counter-1) newCur
    rec_Euler x (x-1) 0

[<EntryPoint>]
let main argv =
    Console.WriteLine(Euler 5)

    0 // return an integer exit code
    //5 4 3 2 1 =