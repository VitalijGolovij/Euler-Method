open System

let IsPalindrom (str:string) =
    let arrChar = str.ToCharArray()//массив символов
    let revArrChar = Array.rev arrChar//развернутый массив символов
    let rec recIsPolindrom arr1 arr2 idx =
        if idx+1>(Array.length arr1) then true
        else
            if (Array.get arr1 idx)<>(Array.get arr2 idx) then false
            else
                recIsPolindrom arr1 arr2 (idx+1)
    if (recIsPolindrom arrChar revArrChar 0) then 
        Console.WriteLine("Является")
        else
        Console.WriteLine("Не является")

let getCountSpace (str:string) =
    let arrChar = str.ToCharArray()
    let rec recGetCountSpace arr idx count=
        if idx+1>(Array.length arr) then count
        else
            let newCount = if (Array.get arr idx)=' ' then (count+1) else count
            recGetCountSpace arr (idx+1) newCount
    Console.WriteLine(recGetCountSpace arrChar 0 0)


[<EntryPoint>]
let main argv =
    
    let str = Console.ReadLine()
    getCountSpace str
    0
