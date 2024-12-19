#load "utils.fsx"

open Operators
open FSharpx

let input = System.IO.File.ReadAllLines("day2.txt")

let answer =
    input
    |> Array.map Utils.splitStringIntoArray
    |> Array.map (Array.map int)
    |> Array.map (function
            | [|a;b;|]
            |)
    |> Array.filter (
        Array.pairwise
        >> Array.forall (fun (a, b) -> let diff = abs (a - b) in diff <= 3 && diff >= 1)
    )
    |> Taps.logAndContinue "%A"
