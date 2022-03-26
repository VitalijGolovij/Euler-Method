open System

let rec readList n = 
    if n=0 then []
    else
    let Head = float (System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    readList n

let task list =
    let pairsList = List.allPairs list list//все возможеные пары
    let allPairsList = List.map (fun ((x,y),z)->(x,y,z)) (List.allPairs pairsList list)//тройные пары

    let ans = List.filter (fun (x,y,z)->x*x+y*y=z*z) allPairsList// кортежи где выполняется пифагорова тройка
    let sortCortage = List.map (fun (x,y,z)->if (x>y) then (y,x,z) else (x,y,z)) ans//сортирова x и y
    let sortCortage2 = List.map (fun (x,y,z)->if (y>z) then (x,z,y) else (x,y,z)) sortCortage//сортировка у и z 
    
    sortCortage2|>List.distinct|>List.iter (printfn "%O")
    //исключаем повторы - выводим на экран

[<EntryPoint>]
let main argv =
    let list = readData
    task list
    0 // return an integer exit code
