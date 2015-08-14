Public Class hackpad
    Dim public_ As New public_
    Function get_(id As String, about As String) As String
        Try
            Dim a As New Net.WebClient
            a.Encoding = System.Text.Encoding.UTF8
            Return "<script>" + a.DownloadString("https://hackpad.com/" + id + ".js?format=html") + "</script>"
        Catch ex As Exception
            Return "<h1>錯誤信息: 無效的章節</h1>" + about
        End Try
    End Function
End Class
