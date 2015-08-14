package com.j113203.java.eyecarereader;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;

public class public_ {
    public String about(){
        return "<br><p><u>操作說明</u><p>左右空白位置 翻頁<p><br><u>支援的網站</u><p>黃金屋<p>hackpad<p>85novel";
    }
    public String DownloadString(String url_){
        try
        {
            URL url = new URL(url_);
            BufferedReader a = new BufferedReader(new InputStreamReader(url.openStream()));
            String result;
            StringBuilder b = new StringBuilder();
            while ((result = a.readLine()) != null)
            {
                b.append(result);
            }
            a.close();
            return b.toString();
        } catch (MalformedURLException e) {
        } catch (IOException e) {
        }
        return "";
    }
}
