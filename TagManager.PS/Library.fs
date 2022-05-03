module TagManager.PS

open System.Management.Automation

[<Cmdlet(VerbsCommon.Get, "Tag")>]
type GetTagCommand() =
    inherit PSCmdlet()

    [<Parameter(
        Position=0,
        ValueFromPipeline=true,
        ValueFromPipelineByPropertyName=true)>]
    [<ValidateNotNullOrEmpty>]
    member val Name = "" with get, set

    override this.ProcessRecord() =
        let tags = Core.parseTags this.Name
        this.WriteObject(tags, false)