// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System

let read_array n =
    let rec read_array_r n arr = 
        if n = 0 then
            arr
        else
            let tail = System.Console.ReadLine() |> Int32.Parse
            let new_arr = Array.append arr [|tail|]
            let n1 = n - 1
            read_array_r n1 new_arr

    read_array_r n Array.empty

let write_array arr =
    printfn "%A" arr
    
[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов в массиве:"
    let n = Console.ReadLine() |>Int32.Parse
    printfn "Массив:"
    let arr = read_array  n

    let list = Array.toList arr
    
    Console.WriteLine("Ввод а и b:")
    let a = Console.ReadLine()|>Convert.ToInt32
    let b = Console.ReadLine()|>Convert.ToInt32

    let ans = List.where (fun x-> a<=x&&x<=b) list //новый лист где выполняются условия
    Console.WriteLine("ответ:")
    Console.WriteLine(ans.Length)
    0 // return an integer exit code
