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
                .Response.Write(public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path))
            Else
                If Not Analy(.Request.QueryString("n")) Then
                    .Response.Write("<h1>錯誤信息: 不支援的網站</h1>")
                    .Response.Write(public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path))
                End If
            End If
            .Response.Write("<style>body{background-color: #2a2a2a;color: #C0c0c0;padding: 10%;}a  ,a:hover ,a:visited  ,a:active ,a:link  {text-decoration: none;color: #C0c0c0;}</style></body></html>")
            .Response.End()
        End With
    End Sub
    Function Analy(URL As String) As Boolean
        If Not URL.ToLower.StartsWith("http") Then URL = "http://" + URL
        With Novel
            Dim about As String = public_.about(.Request.Url.Scheme + "://" + .Request.Url.Authority + .Request.Path)
            Try
                If URL.ToLower.StartsWith("http://tw.hjwzw.com/book/read/") Or URL.ToLower.StartsWith("http://t.hjwzw.com/read/") Or URL.ToLower.StartsWith("http://www.hjwzw.com/book/read/") Then
                    Dim a As New hjwzw
                    .Response.Write(a.get_(URL.Substring(URL.LastIndexOf("/") + 1), about))
                    Return True
                ElseIf URL.ToLower.StartsWith("https://hackpad.com/") Or URL.ToLower.StartsWith("http://hackpad.com/") Then
                    Dim a As New hackpad
                    .Response.Write(a.get_(URL.Substring(URL.LastIndexOf("-") + 1), about))
                    Return True
                ElseIf URL.ToLower.StartsWith("http://www.85novel.com/book/") Or URL.ToLower.StartsWith("http://gb.85novel.com/book/") Then
                    Dim b() As String = URL.Split("/")
                    Dim a As New _85novel
                    .Response.Write(a.get_(b(4) + "/" + b(5).Substring(0, b(5).IndexOf(".")), about))
                    Return True
                ElseIf Not String.IsNullOrEmpty(.Request.QueryString("force"))
                    Dim a As New force
                    .Response.Write(a.get_(URL, about))
                    Return True
                End If
            Catch ex As Exception
                .Response.Write("<h1>錯誤信息: 無效的章節</h1>" + about)
                Return True
            End Try
            Return False
        End With
    End Function
    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class