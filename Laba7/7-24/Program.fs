
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
    let max1:int = List.max list//первый макс элемнет
    let idxMax1:int = List.findIndex (fun x-> x = max1) list //найти индекс макс1
    let listWithoutMax1 = List.removeAt idxMax1 list//удаление макс1 из списка
    let max2 = List.max listWithoutMax1//найти макс2
    
    Console.WriteLine("ответ:")
    Console.WriteLine(max1)
    Console.WriteLine(max2)
    0 // return an integer exit code
