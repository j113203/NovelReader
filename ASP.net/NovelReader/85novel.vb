Public Class _85novel
    Dim public_ As New public_
    Function get_(id As String, about As String) As String
        Try
            id = id.Replace(",", "/")
            Dim d() As String = id.Split("/")
            Dim current As Integer = d(1)
            Dim a As New Net.WebClient
            a.Encoding = System.Text.Encoding.GetEncoding("Big5")
            Dim b As New StringBuilder
            For Each c As Match In Regex.Matches(a.DownloadString("http://www.85novel.com/book/" + id + ".html"), "<p>(.*)</p>")
                b.Append(c.Groups(0).Value)
            Next
            Return b.ToString + public_.hotkey("http://www.85novel.com/book/" + d(0).ToString + "/" + (current - 1).ToString + ".html", "http://www.85novel.com/book/" + d(0).ToString + "/" + (current + 1).ToString + ".html")
        Catch ex As Exception
            Return "<h1>錯誤信息: 無效的章節</h1>" + about
        End Try
    End Function
End Class
