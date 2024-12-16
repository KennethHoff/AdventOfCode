#load "utils.fsx"

let allLines = System.IO.File.ReadAllLines("day1.txt")

allLines
|> Array.map Utils.splitStringIntoPair
|> Array.map Utils.convertStringPairToIntPair
|> Array.unzip
|> Utils.sortTupleElements
|> fun (x, y) -> Array.zip x y
|> Array.map Utils.calculateAbsoluteDifference
|> Array.sum
|> Taps.logAndContinue "Part 1: %d"

