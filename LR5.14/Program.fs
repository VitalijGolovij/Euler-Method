// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System
let operation x f init=
    let rec rec_operation x f cur counter=
        if counter=0 then cur 
        else
            let newCur=if (x%counter=0) then (f cur counter) else cur
            rec_operation x f newCur (counter-1)

    rec_operation x f init (x-1)

[<EntryPoint>]
let main argv =
    Console.WriteLine(operation 6 (fun x y->x*y) 1)
    Console.WriteLine(operation 6 (fun x y->x+y) 0)
    Console.WriteLine(operation 6 (fun x y->max x y) 1)
    Console.WriteLine(operation 6 (fun x y->min x y) 1)
    0 // return an integer exit code
