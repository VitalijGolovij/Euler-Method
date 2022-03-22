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

    let repeats = List.countBy id list //список кортежей (число, кол-во повторений)
    let ans = List.where (fun (x:int,y:int)->  y>3 ) repeats // список где повт > 3
    
    Console.WriteLine("ans:")
    ans|>List.map (fun (x,y)->x)|>List.iter (printfn "%i")
    0 // return an integer exit code
