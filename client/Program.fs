// Learn more about F# at http://fsharp.org

open System
open Sample.Data
open Sample.Models

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    use ctx = new Context()

    let h = Person(Name="bork")

    ctx.Persons.Add(h)
    ctx.SaveChanges()
    0 // return an integer exit code
