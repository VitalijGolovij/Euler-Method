open System

let IsPalindrom (str:string) =
    let revStr = Seq.rev str
    if (Seq.forall2 (fun x y -> x = y) str revStr)=false then Console.WriteLine("Не является") else Console.WriteLine("Является")

let getCountSpace (str:string) =
    let arrChar = str.ToCharArray()
    let rec recGetCountSpace arr idx count=
        if idx+1>(Array.length arr) then count
        else
            let newCount = if (Array.get arr idx)=' ' then (count+1) else count
            recGetCountSpace arr (idx+1) newCount
    Console.WriteLine(recGetCountSpace arrChar 0 0)

let countDefFigure (str:string) =
    let x = Convert.ToInt32(str)
    let figureArr = Array.empty
    let rec recCountDefFigure x (arr:int array) =
        if x=0 then arr.Length
        else
            let cur = x%10
            let newArr= if (Array.tryFind (fun x->x=cur) arr)<>None then arr else Array.append arr [|cur|]
            let newX=x/10
            recCountDefFigure newX newArr
    Console.WriteLine(recCountDefFigure x figureArr)

[<EntryPoint>]
let main argv =
    printfn "Введите строку:"
    let str = Console.ReadLine()
    printfn "Какую задачу решить?"
    printfn "1. Проверка слова на палиндром"
    printfn "2. Посчитать количество пробелов"
    printfn "3. Количество уникальных цифр в числе"
    let choose = Convert.ToInt32(Console.ReadLine())
    printf "Ответ:"
    match choose with
    |1->IsPalindrom str
    |2->getCountSpace str
    |_->countDefFigure str
    0
