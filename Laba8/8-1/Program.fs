open System

type IPrint = interface
    abstract member Print: unit->unit
    end

[<AbstractClass>]
type GeometryFigure()=
    abstract S: unit->float

type Rectangle(width:float,height:float)=
    inherit GeometryFigure()

    let mutable PropertyWidth=width
    let mutable PropertyHeight=height

    override this.S()=PropertyWidth*PropertyHeight
    override this.ToString()=
        sprintf "Rectangle: w=%f, h=%f, S=%f" PropertyWidth PropertyHeight (this.S())

    interface IPrint with
        member this.Print()=this.ToString()|>Console.WriteLine

type Square(a:float)=
    inherit Rectangle(a,a)
    override this.ToString()=
        sprintf "Square: a=%f, S=%f" a (this.S())

    interface IPrint with
        member this.Print()=this.ToString()|>Console.WriteLine

type Circle(r:float)=
    inherit GeometryFigure()

    let mutable PropertyR=r
    
    override this.S()=3.14*PropertyR*PropertyR
    override this.ToString()=
        sprintf "Circle: r=%f, S=%f" PropertyR (this.S())

    interface IPrint with
        member this.Print()=this.ToString()|>Console.WriteLine

//////////////part 2

type GeometryFigure2 = 
    | Rect of float * float
    | Sqr of float
    | Circ of float

let calc_area (fig: GeometryFigure2) =
    match fig with
    | Rect(w,h) -> w * h
    | Sqr(a) -> a*a
    | Circ(r) -> Math.PI * r * r

[<EntryPoint>]
let main argv =
    let rect = Rectangle(2.0, 4.5)
    printfn "Rect area: %f" (rect.S())
    let rectInterface = rect:>IPrint
    rectInterface.Print()

    let circle = Circle(2.0)
    printfn "Circle area: %f" (circle.S())
    
    let fig_sqr = Sqr(1.1)
    printfn "Sqr area: %f" (calc_area fig_sqr)

    
    0