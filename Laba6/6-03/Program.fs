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

let rec writeList = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        writeList tail

let findMax list =
    let rec rec_findMax list cur =
        match list with
        |[]->cur
        |h::t->
            let newCur = if (h>cur) then h else cur
            let newList = if t<>[] then t else []
            rec_findMax newList newCur
    rec_findMax list list.Head

let item list idx =
    let rec rec_item list idx count =
        match list with
        |[]->0
        |h::t->
            if idx=count then h
            else
                rec_item t idx (count+1)
    rec_item list idx 0

[<EntryPoint>]
let main argv =
    let list = readData
    Console.WriteLine("Ввод индекса:")
    let idx = int (Console.ReadLine())
    
    if (item list idx = findMax list) then Console.WriteLine("является")
    else Console.WriteLine("не является")

    0 // return an integer exit code
