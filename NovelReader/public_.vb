Public Class public_
    Function hotkey(previous As String, nexts As String) As String
        Return "<script>document.onkeydown=function (e){if(e.keyCode === 37){location.replace(""?n=" + previous + """);}else if (e.keyCode === 39){location.replace(""?n=" + nexts + """);}};</script>"
    End Function
    Function about(url As String) As String
        Return "<p><u>使用說明</u><p>" + url + "?n=小說網站網址<p> ← 和 → 方向鍵翻頁<p><br><u>支援的網站</u><p>黃金屋"
    End Function
End Class
