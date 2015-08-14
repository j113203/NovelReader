package com.j113203.java.eyecarereader;


import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class hjwzw {
    public_ public_= new public_();
    public String get_(String id,MainActivity MainActivity){
        id=id.replace("_", ",");
        String[] d = id.split(",");
        Integer current = Integer.parseInt(d[1]);
        String net = public_.DownloadString("http://t.hjwzw.com/Read/" + id);
        Matcher m = Pattern.compile("<p>(.*)</p>").matcher(net);
        StringBuilder a= new StringBuilder();
        while (m.find()) {
            a.append(m.group(0).toString());
        }
        MainActivity.prev="http://t.hjwzw.com/Read/" + d[0] + "," + String.valueOf(current - 1);
        MainActivity.nexts="http://t.hjwzw.com/Read/" + d[0] + "," + String.valueOf(current + 1);
        return a.toString();
    }
}
