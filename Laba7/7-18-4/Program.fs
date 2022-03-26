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

let myFilter arr =
    Array.filter (fun x->x%3=0) arr

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов в массиве:"
    let n = Console.ReadLine() |>Int32.Parse
    printfn "Массив:"
    let arr = read_array  n
    
    arr|>myFilter|>Array.iter (printfn "%i")
    
    0 // return an integer exit code
