
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

    let max1:int = List.max list//первый макс элемнет
    let idxMax1:int = List.findIndex (fun x-> x = max1) list //найти индекс макс1
    let listWithoutMax1 = List.removeAt idxMax1 list//удаление макс1 из списка
    let max2 = List.max listWithoutMax1//найти макс2
    
    Console.WriteLine("ответ:")
    Console.WriteLine(max1)
    Console.WriteLine(max2)
    0 // return an integer exit code
