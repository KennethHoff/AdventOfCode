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

let tupleToFormattedString tuple =
    sprintf "(%A, %A)" (fst tuple) (snd tuple)

let prependIndexToString index str = sprintf "%d: %s" index str

let sortTupleElements = fun (first, second) -> (Array.sort first, Array.sort second)

let printTupleAsString tuple =
    tuple |> tupleToFormattedString |> printfn "%s"

let printIndexedTupleAsString index tuple =
    tupleToFormattedString tuple |> prependIndexToString index |> printfn "%s"

let calculateAbsoluteDifference = fun (x: int, y: int) -> System.Math.Abs(x - y)

let buildFrequencyMap arr =
    arr
    |> Array.fold
        (fun acc n ->
            acc
            |> Map.change n (function
                | Some count -> Some(count + 1)
                | None -> Some 1))
        Map.empty
