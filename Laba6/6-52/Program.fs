// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System

let rec writeList = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        writeList tail

//простое число?
let isProst x =
    let rec rec_isProst x count=
        if count=x then true 
        else
            if x%count=0 then false else rec_isProst x (count+1)
    rec_isProst x 2

//сколько раз заданное простое число явл делителем
let rec addDif x n list=
    if x%n=0 then 
        let newList=list@[n]
        addDif (x/n) n newList
    else
        let newList=list@[]
        newList
                
let task x =
    let rec rec_task x count curlist=
        if count=x then curlist else
            let newCurlist = if (x%count=0)&&(isProst count) then (addDif x count curlist) else curlist
            rec_task x (count+1) newCurlist
    rec_task x 2 []

[<EntryPoint>]
let main argv =
    let x = int(Console.ReadLine())
    let list=task x
    writeList list
    0 // return an integer exit code
