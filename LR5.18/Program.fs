// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System

let rec nod (a:int) (b:int) =
    if ((a % b) = 0) then 
        b
    else
        nod a (a%b)

let Metod_1 x =
    let rec rec_Metod_1 x counter cur=
        if counter = 0 then cur 
        else
            let newCur = if (nod x counter)<>1 && counter%2=0 then cur+1 else cur
            rec_Metod_1 x (counter-1) newCur
    rec_Metod_1 x (x-1) 0

let Metod_2 x =
    let rec rec_Metod_2 x cur=
        if x = 0 then cur 
        else
            let newCur = if (x%10%3<>0)&&(x%10>cur) then x%10 else cur
            let newX= x/10
            rec_Metod_2 newX newCur
    rec_Metod_2 x (-1)


[<EntryPoint>]
let main argv =
    Console.WriteLine(Metod_1 6)
    Console.WriteLine(Metod_2 3686)
    0 // return an integer exit code
