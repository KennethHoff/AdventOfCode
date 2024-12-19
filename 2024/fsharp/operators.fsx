/// <summary> Apply a function to a tuple pair, the pair being on the left, the function on the right.</summary>
/// <param name="arg">The argument.</param>
/// <param name="func">The function.</param>
let inline (|->) (x, y) func = func x y
