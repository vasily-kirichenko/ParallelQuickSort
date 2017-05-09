open Hopac
open Hopac.Infixes
open BenchmarkDotNet.Attributes
open System
open BenchmarkDotNet.Running

let rec quicksort list =
    match list with
    | [] -> []
    | firstElem :: otherElements ->
        let smallerElements =     
            otherElements             
            |> List.filter (fun e -> e < firstElem) 
            |> quicksort          
    
        let largerElements =      
            otherElements 
            |> List.filter (fun e -> e >= firstElem)
            |> quicksort          
        
        List.concat [smallerElements; [firstElem]; largerElements]

let rec hquicksort list =
    job {
        match list with
        | [] -> return []
        | firstElem :: otherElements ->
             let smallerElementsJob =  
                 otherElements             
                 |> List.filter (fun e -> e < firstElem) 
                 |> hquicksort          
             
             let largerElementsJob =      
                 otherElements 
                 |> List.filter (fun e -> e >= firstElem)
                 |> hquicksort          
             
             let! smallerElements, largerElements = smallerElementsJob <*> largerElementsJob
             return List.concat [smallerElements; [firstElem]; largerElements]
    }

type Benchmarks() =
    let rnd = Random()
    let list = List.init 1000 (fun _ -> rnd.Next(Int32.MinValue, Int32.MaxValue))
    
    [<Benchmark>]
    member __.Sequential() = quicksort list

    [<Benchmark>]
    member __.Hopac() = hquicksort list |> run

[<EntryPoint>]
let main _ = 
    BenchmarkRunner.Run<Benchmarks>() |> ignore
    0
