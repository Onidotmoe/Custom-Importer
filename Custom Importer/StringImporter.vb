Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Content.Pipeline
Imports Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
Imports System.IO

<ContentImporter(".txt", DefaultProcessor:=NameOf(StringProcessor), DisplayName:="String Importer - Custom Importer")>
Public Class StringImporter
    Inherits ContentImporter(Of String)

    Public Overrides Function Import(FileName As String, Context As ContentImporterContext) As String
        Context.Logger.LogMessage("Importing String : {0}", FileName)

        Return File.ReadAllText(FileName)
    End Function
End Class

<ContentProcessor(DisplayName:="String Processor - Custom Importer")>
Public Class StringProcessor
    Inherits ContentProcessor(Of String, String)

    Public Overrides Function Process(Input As String, Context As ContentProcessorContext) As String
        Try
            Context.Logger.LogMessage("Processing Strings")

            Return Input
        Catch ex As Exception
            Context.Logger.LogMessage("Error {0}", ex)
            Throw
        End Try
    End Function
End Class

<ContentTypeWriter>
Public Class StringWriter
    Inherits ContentTypeWriter(Of Char())

    ''' <remarks>We have to use a Char array instead of a String otherwise we'll get a "Key already added" error in the pipeline tool.</remarks>
    Protected Overrides Sub Write(Output As ContentWriter, Value As Char())
        Output.Write(Value)
    End Sub

    Public Overrides Function GetRuntimeType(TargetPlatform As TargetPlatform) As String
        Return GetType(String).AssemblyQualifiedName
    End Function

    Public Overrides Function GetRuntimeReader(TargetPlatform As TargetPlatform) As String
        Return "CustomImporter.StringReader, Custom Importer"
    End Function
End Class
Public Class StringReader
    Inherits ContentTypeReader(Of String)

    Protected Overrides Function Read(Input As ContentReader, ExistingInstance As String) As String
        Return Input.ReadString
    End Function
End Class