// Learn more about F# at http://fsharp.org

open System

let rec readStrings n strings=
    match n with 
    |0 -> strings
    |_ -> 
        let s = Console.ReadLine()
        let newStrings = strings @ [s]
        let n1 = n - 1
        readStrings n1 newStrings

let rec writeStringList = function
    |[] -> let z = System.Console.ReadKey()
           0
    | (head : string)::tail -> 
                      System.Console.WriteLine(head)
                      writeStringList tail

//перевод в аски код
let inline charToInt c = int c - int '0'

//средний вес кода
let getAverageAsciiWeight string = 
    let AverageAscii = List.average (List.map (fun x-> Convert.ToDouble (charToInt x)) (Seq.toList string))
    AverageAscii

let firstTask (strings:'string list) =
    let firstStringWeight = getAverageAsciiWeight strings.Head
    Console.WriteLine strings.Head
    let sortedS = List.sortBy (fun x-> pown ((getAverageAsciiWeight x) - firstStringWeight) 2) strings.Tail
    writeStringList (sortedS)

let IsGlasn c =
    if (c='e'||c='y'||c='u'||c='i'||c='o'||c='a') then true else false

let IsSoglasn c =
    if (c='q'||c='w'||c='r'||c='t'||c='p'||c='s'||c='d'||c='f'||c='g'||c='h'||c='j'||c='k'||c='l'||c='z'||c='x'||c='c'||c='v'||c='b'||c='n'||c='m') then true else false

    //количество сочетаний гласная-согласная
let FreqGlSogl (list:'char list) =
    let rec recFreqGlSogl list count =
        match list with
        |[]->count
        |h::t->
            if t=[] then recFreqGlSogl t count
            else
                let newCount = if (IsGlasn h)&&(IsSoglasn t.Head) then (count+1) else count
                recFreqGlSogl t newCount
    recFreqGlSogl list 0

    //количество сочетаний согласная-гласная
let FreqSoglGl (list:'char list) =
    let rec recFreqSoglGl list count =
        match list with
        |[]->count
        |h::t->
            if t=[] then recFreqSoglGl t count
            else
                let newCount = if (IsSoglasn h)&&(IsGlasn t.Head) then (count+1) else count
                recFreqSoglGl t newCount
    recFreqSoglGl list 0
            
let secondTask (strings:'string list) =
    let sortedS = List.sortBy (fun str-> abs( (FreqGlSogl (Seq.toList str)) - (FreqSoglGl (Seq.toList str)) )) strings
    writeStringList sortedS



[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let strings = readStrings n []
    firstTask strings
    Console.WriteLine " "
    secondTask strings
    
    0 // return an integer exit code