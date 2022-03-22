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


let task list =
    let indexList = List.indexed list//каждому эелемнту поставим индекс (0,2) (1,8)
    let sortListByValue = List.rev (List.sortBy (fun (x,y)->y) indexList)//сортирует список по значению
    List.map (fun (x,y)->x) sortListByValue//возвращает список только из индексов
        
    
[<EntryPoint>]
let main argv =
    let list = readData
    let ans = task list
    Console.WriteLine("ans:")
    ans|>List.iter (printfn "%i")
    0 // return an integer exit code
