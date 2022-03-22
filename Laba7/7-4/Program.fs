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


let task list =
    let indexList = List.indexed list//каждому эелемнту поставим индекс (0,2) (1,8)
    let sortListByValue = List.rev (List.sortBy (fun (x,y)->y) indexList)//сортирует список по значению
    List.map (fun (x,y)->x) sortListByValue//возвращает список только из индексов
        
    
[<EntryPoint>]
let main argv =
    //let list = readData
    printfn "Кол-во элементов в массиве:"
    let n = Console.ReadLine() |>Int32.Parse
    printfn "Массив:"
    let arr = read_array  n

    let list = Array.toList arr

    let ans = task list
    Console.WriteLine("ans:")
    ans|>List.iter (printfn "%i")
    0 // return an integer exit code
