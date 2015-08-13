function hjwzw_get_(id, about){
	try {
		var b = document.createElement("iframe"); 
		b.setAttribute("id", "a");
		b.setAttribute("style", "visibility: hidden");
		b.onload = function(){
								try {
									var innerDoc = b.contentDocument || b.contentWindow.document;
									document.getElementById("main").innerHTML=innerDoc.getElementById("Lab_Contents").innerHTML;
								}
								catch(ex) {
									document.getElementById("main").innerHTML="<h1>錯誤信息: "+ex+"</h1>"+ about;
									
								}	
								
							};
		b.setAttribute("src", "http://t.hjwzw.com/Read/" + id);
		document.body.appendChild(b); 
	}
	catch(ex) {
		document.write("<h1>錯誤信息: 無效的章節</h1>" + about);
	}
}