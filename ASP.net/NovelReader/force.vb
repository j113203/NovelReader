Public Class force
    Function get_(URL As String, about As String) As String
        Try
            Dim a As New Net.WebClient
            Dim b As New StringBuilder
            For Each c As Match In Regex.Matches(a.DownloadString(URL), "<p>(.*)</p>")
                b.Append(c.Groups(0).Value)
            Next
            Return b.ToString
        Catch ex As Exception
            Return "<h1>錯誤信息: 無效的章節</h1>" + about
        End Try
    End Function
End Class
