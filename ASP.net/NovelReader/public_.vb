Public Class public_
    Function hotkey(previous As String, nexts As String) As String
        Return "<div style=""left:0px;position:fixed;width:10%;height:100%;top:0px;"" onclick=""location.replace('?n=" + previous + "');""></div><div style=""right:0px;position:fixed;width:10%;height:100%;top:0px;"" onclick=""location.replace('?n=" + nexts + "');""></div><script>document.onkeydown=function (e){if(e.keyCode === 37){location.replace(""?n=" + previous + """);}else if (e.keyCode === 39){location.replace(""?n=" + nexts + """);}};</script>"
    End Function
    Function about(url As String) As String
        Return "<p><u>使用說明</u><p>" + url + "?n=小說章節網址<p> ← 和 → 方向鍵 及 左右空白位置 翻頁<p><br><u>支援的網站</u><p>黃金屋<p>hackpad<p>85novel"
    End Function
End Class
