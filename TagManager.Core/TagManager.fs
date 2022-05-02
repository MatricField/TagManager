module TagManager.Core

open TagManager.Helpers

let parseTags dir =
    let tagStringPattern = """^(【.+】)+"""
    let pattern = """【(?:\d+-)?(.+?)】"""

    match dir with
    |Regex.Match tagStringPattern groups ->
        groups
        |>Seq.choose (Regex.getMatchedGroups pattern)
        |>Seq.collect id
        |>Seq.distinct
    |_ -> Seq.empty