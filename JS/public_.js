function hotkey(previous,nexts){
	return "<script>document.onkeydown=function (e){if(e.keyCode === 37){location.replace('?n=" + previous + "');}else if (e.keyCode === 39){location.replace('?n=" + nexts + "');}};</script>";
}
function about(){
	return "<p><u>使用說明</u><p>" + location.protocol + '//' + location.host + location.pathname + "?n=小說網站網址<p> ← 和 → 方向鍵翻頁<p><br><u>支援的網站</u><p>黃金屋";
}