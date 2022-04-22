open System
open System.Windows.Forms
open System.Drawing
open System.IO

let form = new Form(Width=400, Height = 300, Text = "F# main form", Menu = new MainMenu())

//Меню бар
let myFile = form.Menu.MenuItems.Add("&Файл")
let myForms = form.Menu.MenuItems.Add("&Формы")
let myHelp = form.Menu.MenuItems.Add("&Помощь")

//Подменю
let myMessage = new MenuItem("&Пример сообщения")
let mySeparator = new MenuItem("-")
let myExit = new MenuItem("&Выход")
let myAbout = new MenuItem("&О программе")
let myForm1 = new MenuItem("&Форма_1")
let myForm2 = new MenuItem("&Форма_2")
let myForm3 = new MenuItem("&Форма_3")

//Добавление подменю в пункты меню
myFile.MenuItems.Add(myMessage)
myFile.MenuItems.Add(mySeparator)
myFile.MenuItems.Add(myExit)
myHelp.MenuItems.Add(myAbout)
myForms.MenuItems.Add(myForm1)
myForms.MenuItems.Add(myForm2)
myForms.MenuItems.Add(myForm3)

let image1 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5)
let image2 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5, Left = 133)
let image3 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5, Left = 266)

//image1.ImageLocation<-"1.png"
//image2.ImageLocation<-"2.png"
//image3.ImageLocation<-"3.png"

form.Controls.Add(image1)
form.Controls.Add(image2)
form.Controls.Add(image3)

let Label1 = new Label(Text = "Пример лабел1",Top = 150)
Label1.Width<-form.Width
Label1.Left<-80
form.Controls.Add(Label1)

//создание сообщения
let Msg _ = MessageBox.Show("Пример сообщения в f#","Сообщение от Msg_")|>ignore
let _ = myMessage.Click.Add(Msg)

//Закрытие приложения
let Exit _ = form.Close()
let _ = myExit.Click.Add(Exit)

//Форма1
let Form1 = new Form(Text = "Дочерняя форма №1",Width =400, Height = 300)
let Edit1 = new TextBox(Top = 10)
let Edit2 = new TextBox(Top=20,Text="5")
let button1 = new Button(Text = "+",Top=50,Width=25,Height = 25)
let button2 = new Button(Text = "-",Top=50,Left = 30,Width=25,Height = 25)
let button3 = new Button(Text = "*",Top=50,Left = 90,Width=25,Height = 25)
let button4 = new Button(Text = "/",Top=50,Left=90,Width=25,Height = 25)
Form1.Controls.Add(Edit1)
Form1.Controls.Add(Edit2)
Form1.Controls.Add(button1)
Form1.Controls.Add(button2)
Form1.Controls.Add(button3)
Form1.Controls.Add(button4)
let Summ _ = MessageBox.Show(string(int(Edit1.Text)+(int(Edit2.Text))),"Сумма")|>ignore
let Minus _ = MessageBox.Show(string(int(Edit1.Text)-(int(Edit2.Text))),"Разность")|>ignore
let Umnoj _ = MessageBox.Show(string(int(Edit1.Text)*(int(Edit2.Text))),"Умножение")|>ignore
let Del _ = MessageBox.Show(string(int(Edit1.Text)/(int(Edit2.Text))),"Деление")|>ignore

let _ = button1.Click.Add(Summ)
let _ = button2.Click.Add(Minus)
let _ = button3.Click.Add(Umnoj)
let _ = button4.Click.Add(Del)

//Форма 2
let Form2 = new Form(Width= 400, Height = 300, Text = "Дочерняя форма №2")
let ProgressBar1 = new ProgressBar(Dock=DockStyle.Top)
let ScrollBar1 = new TrackBar(Top=50,Maximum = 100, Width = 400)
let Button1 = new Button(Dock=DockStyle.Bottom,Text = "Перейти на форму 3")
Form2.Controls.Add(ProgressBar1)
Form2.Controls.Add(ScrollBar1)
Form2.Controls.Add(Button1)
let Change _ = ProgressBar1.Value<-ScrollBar1.Value
let _ = ScrollBar1.ValueChanged.Add(Change)

//Форма 3
let Form3 = new Form(Text ="Дочерняя форма №3" ,Width = 400, Height =300)
let Cal = new MonthCalendar()
let Button2 = new Button(Dock=DockStyle.Bottom, Text="Нажми меня")
Form3.Controls.Add(Cal)
Form3.Controls.Add(Button2)
let MsgDay _ = MessageBox.Show ("Сегодня *тут должна быть дата* ","Дата") |>ignore
let _ = Button2.Click.Add(MsgDay)

//Вызов форм
let opForm1 _ = do Form1.ShowDialog()
let opForm2 _ = do Form2.ShowDialog()
let opForm3 _ = do Form3.ShowDialog()

let _ = myForm1.Click.Add(opForm1)
let _ = myForm2.Click.Add(opForm2)
let _ = myForm3.Click.Add(opForm3)
let _ = Button1.Click.Add(opForm3)

Application.Run(form)


(*let form = new Form(Text = "F# Program")
let button = new Button(Text = "Button Click")
button.Location <- new Point( 100, 100)
form.Controls.Add(button)

button.Click.Add(fun evArgs -> MessageBox.Show("Click me") |> ignore)

Application.Run(form)*)