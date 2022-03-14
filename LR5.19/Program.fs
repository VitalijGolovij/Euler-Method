// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System

let rec nod (a:int) (b:int) =
    if ((a % b) = 0) then 
        b
    else
        nod a (a%b)

let sumCifr x=
    let rec rec_sumCifr x cur=
        if x=0 then cur
        else
            let newCur= cur+(x%10)
            let newX=x/10
            rec_sumCifr newX newCur
    rec_sumCifr x 0

let Euler x =
    let rec rec_Euler x counter cur=
        if counter = 0 then cur 
        else
            let newCur = if (nod x counter)=1 then cur+1 else cur
            rec_Euler x (counter-1) newCur
    rec_Euler x (x-1) 0


//число сумма цифр от количества четных чисел, не взаимно простых с данным
let Metod_1 x =
    let rec rec_Metod_1 x counter cur=
        if counter = 0 then sumCifr cur 
        else
            let newCur = if (nod x counter)<>1 && counter%2=0 then cur+1 else cur
            rec_Metod_1 x (counter-1) newCur
    rec_Metod_1 x (x-1) 0

//число эйлера от максимальной цифры числа, не деляющуюся на 3
let Metod_2 x =
    let rec rec_Metod_2 x cur=
        if x = 0 then Euler cur 
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

[<EntryPoint>]
let main argv =
    Console.WriteLine(Metod_1 6)
    Console.WriteLine(Metod_2 3686)
    Console.WriteLine(Metod_3 21)
    0 // return an integer exit code
     
    // 21 14 70
