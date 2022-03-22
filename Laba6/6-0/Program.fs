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

let task list f=
    let rec rec_task list curlist = 
        match list with
        |[]->curlist
        |h::t->
            let arg1 = h
            let arg2 = if t<>[] then t.Head else 1
            let arg3 = if t<>[] then (if t.Tail<>[] then t.Tail.Head else 1) else 1
            let newCurlist = curlist @ [f arg1 arg2 arg3]
            let newList = if t<>[] then (if t.Tail<>[] then t.Tail.Tail else []) else []//сдвиг
            rec_task newList newCurlist
    rec_task list []


[<EntryPoint>]
let main argv =
    let list = readData
    Console.WriteLine("ans:")
    writeList (task list (fun x y z->x+y+z))
    0 // return an integer exit code
