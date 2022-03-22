
open System
let rec readlist1 n =
    if n = 0 then []
    else
    let Head = Console.ReadLine()|>Convert.ToDouble
    let Tail = readlist1 (n-1)
    Head::Tail

let check (list:float list)=
    let rec c1 list b=
        match list with
        | a::t-> 
            if ((a%1.0=0.0 && b%1.0=0.0) ||(a%1.0<>0.0 && b%1.0<>0.0)) then false
            else c1 t a
        | []-> true
    c1 list.Tail list.Head

[<EntryPoint>]
let main argv =
   let n = Console.ReadLine()|> Int32.Parse
   let list = readlist1 n
   Console.WriteLine(check list)
   0 // return an integer exit code