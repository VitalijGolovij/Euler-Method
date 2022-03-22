// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n
    
[<EntryPoint>]
let main argv =
    let list = readData
    
    Console.WriteLine("Ввод а и b:")
    let a = Console.ReadLine()|>Convert.ToInt32
    let b = Console.ReadLine()|>Convert.ToInt32

    let ans = List.where (fun x-> a<=x&&x<=b) list //новый лист где выполняются условия
    Console.WriteLine("ответ:")
    ans|>List.iter (printfn "%i")
    0 // return an integer exit code
