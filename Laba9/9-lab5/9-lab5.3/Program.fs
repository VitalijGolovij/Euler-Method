open System
open System.Windows.Forms
open System.Drawing
open System.IO

//Форма1
let Form1 = new Form(Text = "Дочерняя форма №1",Width =400, Height = 300)
let Edit1 = new TextBox(Top = 10)
let Edit2 = new TextBox(Top = 30)
let button1 = new Button(Text = "+",Top=50,Width=25,Height = 25)
let button2 = new Button(Text = "-",Top=50,Left = 30,Width=25,Height = 25)
let button3 = new Button(Text = "*",Top=50,Left = 60,Width=25,Height = 25)
let button4 = new Button(Text = "/",Top=50,Left=90,Width=25,Height = 25)

Form1.Controls.Add(Edit1)
Form1.Controls.Add(Edit2)
Form1.Controls.Add(button1)
Form1.Controls.Add(button2)
Form1.Controls.Add(button3)
Form1.Controls.Add(button4)

let Summ _ = 
    try
        if (String.IsNullOrWhiteSpace(Edit1.Text)||String.IsNullOrWhiteSpace(Edit2.Text)) then
            MessageBox.Show("Введите значения")|>ignore
        else
            MessageBox.Show(string(double(Edit1.Text)+(double(Edit2.Text))),"Сумма")|>ignore
    with
    | :? FormatException->MessageBox.Show("Введен неверный формат")|>ignore
let Minus _ =
    try
    if (Edit1.Text=""||Edit2.Text="") then
        MessageBox.Show("Введите значения")|>ignore
    else
        MessageBox.Show(string(double(Edit1.Text)-(double(Edit2.Text))),"Разность")|>ignore
    with
    | :? FormatException->MessageBox.Show("Введен неверный формат")|>ignore
let Umnoj _ =
    try
    if (Edit1.Text=""||Edit2.Text="") then
        MessageBox.Show("Введите значения")|>ignore
    else
        MessageBox.Show(string(double(Edit1.Text)*(double(Edit2.Text))),"Умножение")|>ignore
    with
    | :? FormatException->MessageBox.Show("Введен неверный формат")|>ignore
let Del _ = 
    try
    if (Edit1.Text=""||Edit2.Text="") then
        MessageBox.Show("Введите значения")|>ignore
    else
        MessageBox.Show(string(double(Edit1.Text)/(double(Edit2.Text))),"Деление")|>ignore
    with
    | :? FormatException->MessageBox.Show("Введен неверный формат")|>ignore
    | :? DivideByZeroException->MessageBox.Show("Ошибка деления на 0")|>ignore


let _ = button1.Click.Add(Summ)
let _ = button2.Click.Add(Minus)
let _ = button3.Click.Add(Umnoj)
let _ = button4.Click.Add(Del)

Application.Run(Form1)
