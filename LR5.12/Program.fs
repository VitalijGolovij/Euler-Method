// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.

// Define a function to construct a message to print
open System
[<EntryPoint>]
let main argv =
    let answer language=
        match language with
        |"f#"->"Подлиза"
        |"prolog"->"Подлиза"
        |"1C"->"Россия - священная наша держава!"
        |"PascalABC"->"завтра в школу"
        |"fortran"|"cobol"->"Ловите динозавра!"
        |_->"такого не знаю"

    (Console.ReadLine>>answer>>Console.WriteLine)()

    let user input (output:string->unit) chooser = output (chooser (input ()))
    user Console.ReadLine Console.WriteLine answer
    0 // return an integer exit code
