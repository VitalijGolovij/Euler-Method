open System
open System.Text.RegularExpressions
open System.Diagnostics

type Pass(Surname:string, Firstname:string, Lastname:string, Sex:string,Birthday:DateTime, Series:int, Num:int) =
    member this.surname = Surname
    member this.firstname = Firstname
    member this.lastname = Lastname
    member this.sex = Sex
    member this.birthday = Birthday
    member this.series = Series
    member this.num = Num

    member this.Print() =
        printfn "Фамилия: %O" this.surname
        printfn "Имя: %O" this.firstname
        printfn "Отчество: %O" this.lastname 
        printfn "Пол: %O" this.sex
        printfn "Дата рождения: %O" this.birthday 
        printfn "Серия паспорта: %O" this.series 
        printfn "Номер паспорта: %O" this.num

    
       
    interface IComparable with
        member this.CompareTo(obj: obj): int = 
            match obj with
            | :? Pass as pass2 -> if this.series = pass2.series then this.num.CompareTo pass2.num else this.series.CompareTo pass2.series
            | _ -> invalidArg "obj" "Несравнимы" 
    override this.Equals(obj) =
           match obj with
           | :? Pass as pass2 -> (this.series = pass2.series) && (this.num = pass2.num)
           | _ -> false

           //проверка регулярными выражениями
let checkWithRegex regex =
        let myRegex = Regex(regex)
        let str = Console.ReadLine()
        if (myRegex.IsMatch(str)) then str else "Был введен неверный формат"
        
let createPass =
            printfn "Введите имя"
            let Surname = checkWithRegex "^[a-zA-Zа-яА-Я]+$"
            printfn "Введите Фамилию"
            let Firstname = checkWithRegex "^[a-zA-Zа-яА-Я]+$"
            printfn "Введите Отчество"
            let Lastname = checkWithRegex "^[a-zA-Zа-яА-Я]+$"
            printfn "Введите пол"
            let Sex = checkWithRegex "^[a-zA-Zа-яА-Я]+$"
            printfn "Введите дату рождения"
            let Birthday = checkWithRegex "^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$" |> DateTime.Parse
            printfn "Введите серию паспорта"
            let Series = checkWithRegex "^\d{4}$" |> Int32.Parse
            printfn "Введите номер паспорта"
            let Num = checkWithRegex "^\d{6}$" |> Int32.Parse
            
            Pass(Surname,Firstname,Lastname,Sex,Birthday,Series,Num)
            
[<AbstractClass>]
type DocCollection() =
    abstract member searchDoc: Pass->bool

type ArrayDocCollection(list: Pass list) =
    inherit DocCollection()
    member this.DocArray = Array.ofList list
    
    override this.searchDoc(p) =
        Array.exists (fun x -> x.Equals p) this.DocArray


type ListDocCollection(list: Pass list) =
    inherit DocCollection()
    member this.DocList = list

    override this.searchDoc(p) = 
        List.exists (fun x-> x.Equals(p)) this.DocList

type BinListDocCollection(list: Pass list)=
    inherit DocCollection()

    let rec binSearch (l:'DriversLicense list) (p:'DriversLicense) =
        match List.length l with
        | 0 -> false
        | i ->
            let middle = i/2
            match sign <| compare p l.[middle] with
            | 0 -> true
            | 1->binSearch l.[..middle - 1] p
            | _->binSearch l.[middle + 1..] p  

    member this.BinList = List.sortBy (fun (x:Pass) -> (x.series, x.num)) list 

    override this.searchDoc(lic) =
        binSearch this.BinList lic


type SetDocCollection(list: Pass list)=
    inherit DocCollection()
    member this.DocSet = Set.ofList list

    override this.searchDoc(lic) = 
        Set.contains lic this.DocSet


let measureSearchTime (watch:Stopwatch) searchMethod lic =
    watch.Reset()
    watch.Start()
    let isFound = searchMethod lic
    watch.Stop()

    watch.ElapsedMilliseconds

[<EntryPoint>]
let main argv =
    let testPass = createPass

    let passList = [Pass("Головий","Виталий","Александрович","муж",Convert.ToDateTime("29.05.2001"),1234,567890);
                    Pass("Пупкин","Александр","Владимирович","муж",Convert.ToDateTime("15.02.2002"),4974,698354);
                    Pass("Попов","Кирилл","Александрович","муж",Convert.ToDateTime("10.06.2002"),6321,854879);
                    Pass("Лолов","Петр","Николаевич","муж",Convert.ToDateTime("10.05.2002"),9987,776767);
                    Pass("Рогозов","Роман","Николаевич","муж",Convert.ToDateTime("22.05.2002"),8876,554561)]
    
    let myDocArray = ArrayDocCollection(passList)
    let myDocList = ListDocCollection(passList)
    let myDocBin = BinListDocCollection(passList)
    let myDocSet = SetDocCollection(passList)

    let myPass = Pass("Рогозов","Роман","Николаевич","муж",Convert.ToDateTime("22.05.2002"),8876,554561)

    let watch = new Stopwatch()

    
    watch.Reset()
    watch.Start()
    myDocArray.searchDoc(myPass)
    watch.Stop()

    printfn "Array time: %O" watch.ElapsedMilliseconds

    watch.Reset()
    watch.Start()
    myDocList.searchDoc(myPass)
    watch.Stop()

    printfn "List time: %O" watch.ElapsedMilliseconds

    watch.Reset()
    watch.Start()
    myDocBin.searchDoc(myPass)
    watch.Stop()

    printfn "Bin time: %O" watch.ElapsedMilliseconds

    watch.Reset()
    watch.Start()
    myDocSet.searchDoc(myPass)
    watch.Stop()

    printfn "Set time: %O" watch.ElapsedMilliseconds


    watch.Reset()

    0