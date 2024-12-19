#r "nuget: FSharpx.Extras"
#load "taps.fsx"
#load "operators.fsx"

open System
open FSharpx

let splitStringIntoArray = String.splitChar [| ' ' |]

let splitStringIntoPair =
    splitStringIntoArray
    >> function
        | [| x; y |] -> (x, y)
        | _ -> failwith "Invalid input: Expected exactly two non-empty strings"

let convertStringPairToIntPair (a: string * string) =
    let (str1, str2) = a

    try
        (int str1, int str2)
    with :? FormatException ->
        failwith "One or both of the strings cannot be parsed as integers"

let sortTupleElements = fun (first, second) -> (Array.sort first, Array.sort second)

let abs = fun (x: int, y: int) -> abs x - y

let buildFrequencyMap arr =
    arr
    |> Array.fold
        (fun acc n ->
            acc
            |> Map.change n (function
                | Some count -> Some(count + 1)
                | None -> Some 1))
        Map.empty
