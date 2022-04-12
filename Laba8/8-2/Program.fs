open System

type Maybe<'a> =
    | Just of 'a
    | Nothing

let fmapMaybe f p =
    match p with
    | Just a -> Just (f a)
    | Nothing -> Nothing


let applyMaybe If p =
    match If,p with
    | Just f, Just a -> Just (f a)
    | _ -> Nothing




[<EntryPoint>]
let main argv =

    //закон 1 функтор 
    //вернул тождественное значение
    let id x = x
    let a1 = Just 3
    let b1 = fmapMaybe id a1
    Console.WriteLine(b1)

    //закон 2 функтор
    //Для двух функций f и g композиция их подъемов эквивалентна подъему композиции.
    let f1 x = x+1
    let g1 x = x*2
    let a2 = Just 3
    let b2 = fmapMaybe (f1>>g1) a2
    Console.WriteLine(b2)

    //закон 1 аппликативный функтор
    //Применение поднятой функции id к поднятому значению эквивалентно
    //применению неподнятой функции id к неподнятому значению.
    let a3 = Just 3
    let b3 = applyMaybe (Just id) a3
    Console.WriteLine(b3)

    //закон 2 аппликативный функтор
    //Если y=f(x), то подъем функции f и значения х и применение к ним
    //функции apply приведет к такому же результату, что и подъем y.
    let x = 5
    let y = id x 
    let test1 = applyMaybe (Just id) (Just x)
    let test2 = Just y
    Console.WriteLine((test1,test2))

    //закон 3 и 4 в f# проверить нельзя Поскольку в F# нет встроенной функции <*> (apply),


    0