// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System

let rec nod (a:int) (b:int) =
    if ((a % b) = 0) then 
        b
    else
        nod a (a%b)

let Metod_1 x =
    let rec rec_Metod_1 x counter cur=
        if counter = 0 then cur 
        else
            let newCur = if (nod x counter)<>1 && counter%2=0 then cur+1 else cur
            rec_Metod_1 x (counter-1) newCur
    rec_Metod_1 x (x-1) 0

let Metod_2 x =
    let rec rec_Metod_2 x cur=
        if x = 0 then cur 
        else
            let newCur = if (x%10%3<>0)&&(x%10>cur) then x%10 else cur
            let newX= x/10
            rec_Metod_2 newX newCur
    rec_Metod_2 x (-1)

let nd x =
    let rec rec_nd x counter =
        if (x=counter) then 1
        else
            if (x%counter=0) then counter
            else
                rec_nd x (counter+1)
    rec_nd x 2

let sumCifr5 x=
    let rec rec_sumCifr5 x cur=
        if x=0 then cur
        else
            let newCur=if x%10<5 then cur+(x%10) else cur
            let newX=x/10
            rec_sumCifr5 newX newCur
    rec_sumCifr5 x 0

let Metod_3 x =
    let n = nd x
    let rec rec_Metod_3 x counter= 
        if counter = 0 then 0
        else
            if (nod x counter)<>1 && counter%n<>0 then counter*(sumCifr5 counter)
            else
                rec_Metod_3 x (counter-1)
    rec_Metod_3 x (x-1)

let select_f = function
    | 1 -> Metod_1
    | 2 -> Metod_2
    | _ -> Metod_3

[<EntryPoint>]
let main argv =
    let x =(Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()))
    let otv = select_f (fst x) (snd x)
    Console.WriteLine(otv)
    0 // return an integer exit code
