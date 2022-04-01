open System

let IsPalindrom =
    let str = Console.ReadLine()
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

let getCountSpace =
    let str = Console.ReadLine()
    let arrChar = str.ToCharArray()
    let rec recGetCountSpace arr idx count=
        if idx+1>(Array.length arr) then count
        else
            let newCount = if (Array.get arr idx)=' ' then (count+1) else count
            recGetCountSpace arr (idx+1) newCount
    Console.WriteLine(recGetCountSpace arrChar 0 0)

let countDefFigure =
    let x = int (Console.ReadLine())
    let figureArr = Array.empty
    let rec recCountDefFigure x (arr:int array) =
        if x=0 then arr.Length
        else
            let cur = x%10
            let newArr= if (Array.tryFind (fun x->x=cur) arr)<>None then arr else Array.append arr [|cur|]
            let newX=x/10
            recCountDefFigure newX newArr
    Console.WriteLine(recCountDefFigure x figureArr)

let choose = function
    | 1 -> IsPalindrom
    | 2 -> getCountSpace
    | _ -> countDefFigure

[<EntryPoint>]
let main argv =
    printfn "Какую задачу решить?"
    printfn "1. Проверка слова на палиндром"
    printfn "2. Посчитать количество пробелов"
    printfn "2. Количество уникальных цифр в числе"

    Console.ReadLine() |> Int32.Parse |> choose
    0
