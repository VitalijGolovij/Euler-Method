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

        //найти макс в списке
let findMax list =
    let rec rec_findMax list cur =
        match list with
        |[]->cur
        |h::t->
            let newCur = if (h>cur) then h else cur
            let newList = if t<>[] then t else []
            rec_findMax newList newCur
    rec_findMax list list.Head

    //достать значение по индексу
let item list idx =
    let rec rec_item list idx count =
        match list with
        |[]->0
        |h::t->
            if idx=count then h
            else
                rec_item t idx (count+1)
    rec_item list idx 0

    //находит индекс первого значения равного заданному
let findFirstIndex list x =
    let rec recFindFirstIndex list x count =
        match list with
        |[]->0
        |h::t->
            if h=x then count 
            else
                recFindFirstIndex t x (count+1)
    recFindFirstIndex list x 0

    //перевернуть список
let revList list =
    let rec recRevList list curlist =
        match list with 
        |[]->curlist
        |h::t->
            let newCurlist = [h] @ curlist
            let newList = if t<> [] then t else []
            recRevList newList newCurlist
    recRevList list []

    //вовзращает новый список со значениями интервала
let intervalList list a b =
    let rec recIntervalList list a b curlist =
        match list with
        |[]->curlist
        |h::t->
            let newCurlist = if (h>=a&&h<=b) then curlist @ [h] else curlist
            let newList = if t<>[] then t else []
            recIntervalList newList a b newCurlist
    recIntervalList list a b []

    //список со значениями между заданными индексами
let intervalIndexList list a b =
    let rec recIntervaIndexlList list a b curlist count=
        match list with
        |[]->curlist
        |h::t->
            let newCurlist = if (count>a && count<b) then curlist @ [h] else curlist
            recIntervaIndexlList t a b newCurlist (count+1)
    recIntervaIndexlList list a b [] 0

[<EntryPoint>]
let main argv =
    let list = readData

    let idxMax1 = list|>findMax|>item list

    let idxMax2 = (list.Length-1) - (list|>revList|>findMax|>item (revList list)) 
    Console.WriteLine("ответ")

    let ans = intervalIndexList list idxMax1 idxMax2
    writeList ans    

    0 // return an integer exit code
