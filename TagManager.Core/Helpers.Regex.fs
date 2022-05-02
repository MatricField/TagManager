module TagManager.Helpers.Regex

open System.Text.RegularExpressions
let getMatchedGroups pattern str =
    let ``match`` = Regex.Match(pattern, str)
    if ``match``.Success then
        ``match``.Groups
        |> Seq.skip 1
        |> Seq.map (fun group -> group.Value)
        |>Some
    else
        None

let (|Match|_|) = getMatchedGroups