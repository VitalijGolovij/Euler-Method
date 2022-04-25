open System
open System.Windows.Forms
open System.Drawing

Application.EnableVisualStyles()
// Создание формы с заголовком "Работа с массивом"
let form = new Form(Text="Работа с массивом")

let textBox1 = new TextBox(Width=150)
let textBox2 = new TextBox(Width=150,Top=100)
let label1 = new Label(Text="Входной массив",Top = 20)
let label2 = new Label(Text="Ответ",Top =120)
let button1 = new Button(Text="Сумма",Top=50)

form.Controls.Add(textBox1)
form.Controls.Add(textBox2)
form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(button1)

textBox1.Text<-"1,2,3,4,5,6,7,8,9,10"

let myFoo (str:string) =
    let strArr= (str.Split(','))
    let intArr = Array.map (fun x-> int(x)) strArr
    let sum=0
    (sum,intArr)||>Array.fold(fun a x->a+x)

let f _ =
    let inptStr=textBox1.Text
    let ans=myFoo inptStr
    textBox2.Text<-string(ans)

let _ = button1.Click.Add(f)

// запуск формы
Application.Run(form)
