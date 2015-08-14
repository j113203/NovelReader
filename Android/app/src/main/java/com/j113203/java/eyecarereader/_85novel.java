package com.j113203.java.eyecarereader;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class _85novel {
    public_ public_= new public_();
    public String get_( String id,MainActivity MainActivity){
        id=id.replace(",", "/");
        String[] d = id.split("/");
        Integer current= Integer.parseInt(d[1]);
        String net = public_.DownloadString("http://www.85novel.com/book/" + id + ".html");
        Matcher m = Pattern.compile("<p>(.*)</p>").matcher(net);
        StringBuilder a= new StringBuilder();
        while (m.find()) {
            a.append( m.group(0).toString());
        }
        MainActivity.prev="http://www.85novel.com/book/" + d[0] + "/" +  String.valueOf(current - 1) + ".html";
        MainActivity.nexts="http://www.85novel.com/book/" + d[0] + "/" +  String.valueOf(current + 1) + ".html";
        return a.toString();
    }
}
