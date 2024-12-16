#load "taps.fsx"
open System


let splitStringIntoPair (a: string) =
    a.Split ' '
    |> Array.filter (not << String.IsNullOrWhiteSpace)
    |> function
        | [| x; y |] -> (x, y)
        | _ -> failwith "Invalid input: Expected expectly two non-empty strings"

let convertStringPairToIntPair (a: string * string) =
    let (str1, str2) = a

    try
        (int str1, int str2)
    with :? FormatException ->
        failwith "One or both of the strings cannot be parsed as integers"

let tupleToFormattedString tuple : string =
    sprintf "(%A, %A)" (fst tuple) (snd tuple)

let prependIndexToString index str = sprintf "%d: %s" index str

let sortTupleElements = fun (first, second) -> (Array.sort first, Array.sort second)

let printTupleAsString tuple =
    tuple |> tupleToFormattedString |> printfn "%s"

let printIndexedTupleAsString index tuple =
    tupleToFormattedString tuple |> prependIndexToString index |> printfn "%s"

// TODO: Figure out how if it's possible to remove the type annotations.
let calculateAbsoluteDifference = (fun (x: int, y: int) -> System.Math.Abs(x - y))
