#load "utils.fsx"
open Operators

let allLines = System.IO.File.ReadAllLines("day1.txt")

allLines
|> Array.map Utils.splitStringIntoPair
|> Array.map Utils.convertStringPairToIntPair
|> Array.unzip
|> Utils.sortTupleElements
|-> Array.zip
|> Array.map Utils.calculateAbsoluteDifference
|> Array.sum
|> Taps.logAndContinue "Part 1: %d"

allLines
|> Array.map Utils.splitStringIntoPair
|> Array.map Utils.convertStringPairToIntPair
|> Array.unzip
|> fun (left, right) -> (left, Utils.buildFrequencyMap right)
|> fun (left, freqMap) ->
    left
    |> Array.choose (fun key ->
        match Map.tryFind key freqMap with
        | Some freq -> Some(key, freq)
        | None -> None)
    |> Array.sumBy (fun (key, freq) -> key * freq)
    |> Taps.logAndContinue "Part 2: %d"
