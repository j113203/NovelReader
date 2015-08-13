Public Class hjwzw
    Dim public_ As New public_
    Function get_(id As String, about As String) As String
        Try
            id = id.Replace("_", ",")
            Dim c As String = ""
            Dim d() As String = id.Split(",")
            Dim current As Integer = d(1)
            Dim a As New Threading.Thread(Sub()
                                              Using b As New Windows.Forms.WebBrowser
                                                  Try
                                                      b.Navigate("http://t.hjwzw.com/Read/" + id)
                                                      Do Until b.ReadyState = Windows.Forms.WebBrowserReadyState.Complete
                                                          Windows.Forms.Application.DoEvents()
                                                      Loop
                                                      c = b.Document.GetElementById("Lab_Contents").InnerHtml
                                                  Catch ex As Exception
                                                      c = ""
                                                  End Try
                                              End Using
                                          End Sub)
            a.SetApartmentState(Threading.ApartmentState.STA)
            a.Start()
            a.Join()
            If String.IsNullOrEmpty(c) Then Return "<h1>錯誤信息: 無效的章節</h1>" + about
            Return c + public_.hotkey("http://t.hjwzw.com/Read/" + d(0).ToString + "," + (current - 1).ToString, "http://t.hjwzw.com/Read/" + d(0).ToString + "," + (current + 1).ToString)
        Catch ex As Exception
            Return "<h1>錯誤信息: 無效的章節</h1>" + about
        End Try
    End Function
End Class
