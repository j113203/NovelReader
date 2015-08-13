Imports System.Web
Imports System.Web.Services

Public Class index
    Implements System.Web.IHttpHandler
    Dim Novel As HttpContext
    Dim public_ As New public_
    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Novel = context
        With Novel
            .Response.Write("<html><head><meta charset=""UTF-8""><title>Novel</title></head><body>")
            .Response.Flush()
            If String.IsNullOrEmpty(.Request.QueryString("n")) Then
                public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path)
            Else
                If Not Analy(.Request.QueryString("n")) Then
                    .Response.Write("<h1>錯誤信息: 不支援的網站</h1>")
                    public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path)
                End If
            End If
            .Response.Write("<style>body{background-color: #2a2a2a;color: #C0c0c0;padding: 10%;}</style></body></html>")
            .Response.End()
        End With
    End Sub
    Function Analy(URL As String) As Boolean
        With Novel
            If URL.ToLower.StartsWith("http://tw.hjwzw.com/book/read/") Then
                Dim a As New hjwzw
                .Response.Write(a.get_(URL.Substring("http://tw.hjwzw.com/book/read/".Length), public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path)))
                Return True
            ElseIf URL.ToLower.StartsWith("http://t.hjwzw.com/read/") Then
                Dim a As New hjwzw
                .Response.Write(a.get_(URL.Substring("http://t.hjwzw.com/Read/".Length), public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path)))
                Return True
            End If
            Return False
        End With
    End Function
    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class