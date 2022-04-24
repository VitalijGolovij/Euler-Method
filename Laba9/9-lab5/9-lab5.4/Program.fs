open System
open System.Windows.Forms
open System.Drawing
open System.IO

let form = new Form(Width=400, Height = 300, Text = "F# main form", Menu = new MainMenu())


let image1 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5,Width=10,Height=10)

let button1 = new Button(Text="Хочу другую картинку",Top=120,Width=200,Height=30,Left = 500)

let listImg = ["11.jpg";"22.png";"33.png"]
let mutable n = 3

image1.ImageLocation<-"11.jpg"

form.Controls.Add(image1)
form.Controls.Add(button1)

let ClickButton _ = 
    n<-n+1
    image1.ImageLocation<-List.item (n%listImg.Length) listImg

let _ = button1.Click.Add(ClickButton)


Application.Run(form)
