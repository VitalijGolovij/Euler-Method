open System
open FParsec

let test p str =
    match run p str with
    | Success(result, _, _) -> printfn "%O" result
    | Failure(errorMsg, _, _) -> printfn "%O" errorMsg

let parseFloatBrackets =
    pstring "(" >>. pfloat .>> pstring ")"

let betweenStrings s1 s2 p =
    pstring s1 >>. pfloat .>> pstring s2

let parseFloatBrackets2 =
    pfloat |> betweenStrings "(" ")"

let a_or_b = many (pstring "a" <|> pstring  "b")

let pstring_ws s = 
    spaces >>. pstring s .>> spaces

let float_ws = 
    spaces >>. pfloat .>> spaces

let parseFloatBracketswithSpaces =
    pstring_ws "(" >>. float_ws .>> pstring_ws ")"

let a_plus_b = pipe5
                    (pstring_ws "(")
                    (float_ws)
                    (pstring_ws "+")
                    (float_ws)
                    (pstring_ws ")")
                    (fun _ x _ y _ ->x+y)

let a_plus_b2 = pipe2
                    (pstring_ws "(" >>. float_ws .>> pstring_ws "+")
                    (float_ws .>> pstring_ws ")")
                    (fun x y -> x+y)

let a_plus_b2_tuple = tuple2
                        (pstring_ws "(" >>. float_ws .>> pstring_ws "+")
                        (float_ws .>> pstring_ws ")")


type Expr =
    | Num of float
    | Plus of Expr * Expr
    | Minus of Expr * Expr

//опережающие значения парсера. Implementation - ссылочное значение(ref), изменяется через := 
let parseExpression, implementation = createParserForwardedToRef<Expr, unit>() //выражение, значение - создает парсер to ref
let parsePlus = tuple2 (parseExpression .>> pstring_ws "+") parseExpression |>> Plus // вернуть пару, кинуть в плюс
let parseMinus = tuple2 (parseExpression .>> pstring_ws "-")parseExpression |>> Minus// вернуть пару, кинуть в минус
let parseOp = between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus)//attempt - для двух парсеров
let parseNum = float_ws |>> Num //поиск до значения
implementation := parseNum <|> parseOp // изменение значения по ссылке

//Обработка распакованного выражения
let rec EvalExpr(e:Expr):float =
    match e with
    | Num(num) -> num //число
    | Plus(a,b) -> //плюс. два аргумента
        let left = //первый аргумент(левый)
            match a with
            | Num(num) -> num//число 
            | _ -> EvalExpr(a)//или другое выражение
        let right =
            match b with
            | Num(num) -> num 
            | _ -> EvalExpr(b)
        let res1 = left + right //собственно, сумма
        printfn "%f + %f = %f" left right res1 //вывод на экран для простоты контроля
        res1
    | Minus(a,b) -> //минус
        let left =
            match a with
            | Num(num) -> num
            | _ -> EvalExpr(a)
        let right =
            match b with
            | Num(num) -> num
            | _ -> EvalExpr(b)
        let res2 = left - right
        printfn "%f - %f = %f" left right res2
        res2

[<EntryPoint>]
let main argv =
    test pfloat "32.23"
    printfn "----------"
    printfn "%A" (run pfloat "231.32")
    printfn "%A" (run parseFloatBrackets "(321)")
    printfn "%A" (run parseFloatBrackets2 "(777)")
    printfn "%A" (run (many parseFloatBrackets) "(111)(222)(3333)")
    printfn "%A" (run a_or_b "babbbabba")
    printfn "-------------------"
    printfn "%A" (run parseFloatBracketswithSpaces "  (   8   )   ")
    printfn "%A" (run a_plus_b "   (  2  + 3  )  ")
    printfn "%A" (run a_plus_b2 "   (   1  +   1   )")
    printfn "%A" (run a_plus_b2_tuple "  (  9  +  0  ) ")

    Console.WriteLine("Введите выражение: ")
    let (input:string) = Console.ReadLine() 
    let expr1 = run parseExpression input 
    Console.WriteLine(expr1)
    match expr1 with
    | Success(result, _, _) ->
        let eval1 = EvalExpr(result)
        printfn "Результат вычислений: %f" eval1
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg



    



    0