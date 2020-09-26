Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Content.Pipeline
Imports Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
Imports System.IO

<ContentImporter(".*", DefaultProcessor:=NameOf(ByteArrayProcessor), DisplayName:="Byte Importer - Custom Importer")>
Public Class ByteImporter
    Inherits ContentImporter(Of Byte())

    Public Overrides Function Import(FileName As String, Context As ContentImporterContext) As Byte()
        Context.Logger.LogMessage("Importing Bytes : {0}", FileName)

        Return File.ReadAllBytes(FileName)
    End Function
End Class

<ContentProcessor(DisplayName:="Byte Array Processor - Custom Importer")>
Public Class ByteArrayProcessor
    Inherits ContentProcessor(Of Byte(), Byte())

    Public Overrides Function Process(Input As Byte(), Context As ContentProcessorContext) As Byte()
        Try
            Context.Logger.LogMessage("Processing Bytes")

            Return Input
        Catch ex As Exception
            Context.Logger.LogMessage("Error {0}", ex)
            Throw
        End Try
    End Function
End Class

<ContentTypeWriter>
Public Class ByteArrayWriter
    Inherits ContentTypeWriter(Of Byte())

    Protected Overrides Sub Write(Output As ContentWriter, Value As Byte())
        Output.Write(Value)
    End Sub

    Public Overrides Function GetRuntimeType(TargetPlatform As TargetPlatform) As String
        Return GetType(Byte()).AssemblyQualifiedName
    End Function

    Public Overrides Function GetRuntimeReader(TargetPlatform As TargetPlatform) As String
        Return "CustomImporter.ByteArrayReader, Custom Importer"
    End Function
End Class
Public Class ByteArrayReader
    Inherits ContentTypeReader(Of Byte())
    Protected Overrides Function Read(Input As ContentReader, ExistingInstance As Byte()) As Byte()
        Return Input.ReadBytes(Input.ReadInt32)
    End Function
End Class