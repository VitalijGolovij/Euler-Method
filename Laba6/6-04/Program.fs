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

   //возвращает значение по индексу
let item list idx =
    let rec rec_item list idx count =
        match list with
        |[]->0
        |h::t->
            if idx=count then h
            else
                rec_item t idx (count+1)
    rec_item list idx 0

    //удалить элемент
let DelElem list n =
    let rec DelElem (list:'a list) n (curlist:'a list) curIdx  =
        if n = curIdx then curlist @ list.Tail
        else
            let newCurlist = curlist @ [list.Head]
            DelElem list.Tail n newCurlist (curIdx+1)
    DelElem list n [] 0

    //находит индекс первого значения равного заданному
let findFirstIndex list x =
    let rec recFindFirstIndex list x count =
        match list with
        |[]-> -1
        |h::t->
            if h=x then count 
            else
                recFindFirstIndex t x (count+1)
    recFindFirstIndex list x 0


let findMax list =
    let rec rec_findMax list cur =
        match list with
        |[]->cur
        |h::t->
            let newCur = if (h>cur) then h else cur
            let newList = if t<>[] then t else []
            rec_findMax newList newCur
    rec_findMax list list.Head

let findMin list =
    let rec rec_findMax list cur =
        match list with
        |[]->cur
        |h::t->
            let newCur = if (h<cur) then h else cur
            let newList = if t<>[] then t else []
            rec_findMax newList newCur
    rec_findMax list list.Head

    //имеет лист значение?
let IsHave list x =
    let rec recIsHave list x =
        match list with
        |[]-> false
        |h::t->
            if (h=x) then true else recIsHave t x
    recIsHave list x

    //сортровка + реверз
let revSort list =
    let rec recRevSort list curlist =
        match list with
        |[]->curlist
        |_->
            let max = findMax list
            let idxMax = findFirstIndex list max
            let newList = DelElem list idxMax
            let newCurlist = curlist @ [max]
            recRevSort newList newCurlist
    recRevSort list []

    //прохожу все числа от минимума к максимуму
let rec proc list min max curEl curList =
    if curEl = (max+1) then curList
    else //элемент существует в списке но еще его индекс не записан
        if (IsHave list curEl = true && IsHave curList (findFirstIndex list curEl) = false) then 
            let idxEl = findFirstIndex list curEl
            let newCurlist = [idxEl] @ curList
            
            proc list min max curEl newCurlist
        else
            proc list min max (curEl+1) curList


let proga list =
    proc list (findMin list) (findMax list) (findMin list) []
    

[<EntryPoint>]
let main argv =
    let list = readData
    let ans = proga list
    writeList ans


    0 // return an integer exit code
