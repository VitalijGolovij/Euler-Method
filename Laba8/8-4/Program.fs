open System

// Операторы async, let! И return! используются для асинхронного программирования. Но оно не рассмотрено в курсе :(


let timeNow = System.DateTime.Now.ToLongTimeString()

let messageResponder = MailboxProcessor.Start(fun inbox->
    // Цикл обработки сообщений
    let rec messageLoop() = async {
        // Чтение сообщения
        let! (msg:string) = inbox.Receive()

        let response = match msg.ToLower() with
        | "привет" -> "Привет"
        | "сколько время?" -> timeNow
        | _ -> "Пока что не понимаю"

        printfn "%s" response

        return! messageLoop()
    }
    
    // Запуск обработки сообщений
    messageLoop()
)

let rec askUser() =
    let input = Console.ReadLine().Trim()
    if not (String.IsNullOrEmpty input) then
        messageResponder.Post(input)
        askUser()


[<EntryPoint>]
let main argv =
    printfn "Введите сообщение"
    askUser()
    0