Imports System
Imports System.Xml
Imports System.Xml.XPath

Public Class loadTheaterDetails
    Inherits System.Web.UI.Page  'needed for "Server" object

    Private path As String = "TheaterInfo.xml" 'default value
    Private doc As New XmlDocument()
    Private count As Int32

    Public Property FilePath() As String
        Get
            Return path
        End Get
        Set(ByVal Value As String)
            path = Value
        End Set
    End Property

    Public ReadOnly Property theaterCount() As Int32
        Get
            Return count
        End Get
    End Property

    Public Function loadDetails() As String
        Try
            doc.Load(Server.MapPath(path))
            loadDetails = "success"
            count = doc.SelectNodes("//theater").Count
        Catch e As Exception
            loadDetails = "An error occured: " + e.Message
        End Try

    End Function

   Public Function getTextNode(ByVal id As Int32, ByVal nodename As String) As String
      Dim xpath As String = "//theater[ @id='" & id & "']/" & nodename
      getTextNode = doc.SelectSingleNode(xpath).InnerText
   End Function

   Public Function getTextNodeWithQuery(ByVal XpathQuery As String) As String
      getTextNodeWithQuery = doc.SelectSingleNode(XpathQuery).InnerText
   End Function

End Class







