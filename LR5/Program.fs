// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System
let answer language=
    match language with
    |"f#"->"Подлиза"
    |"prolog"->"Подлиза"
    |"1C"->"Россия - священная наша держава!"
    |"PascalABC"->"завтра в школу"
    |"fortran"|"cobol"->"Ловите динозавра!"
    |_->"такого не знаю"

[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый язык?" 
    let x:string = Console.ReadLine()
    Console.WriteLine(answer x)
    0 // return an integer exit code
