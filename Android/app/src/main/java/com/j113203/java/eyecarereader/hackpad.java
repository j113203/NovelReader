package com.j113203.java.eyecarereader;
public class hackpad {
    public_ public_= new public_();
    public String get_( String id){
        String a  = public_.DownloadString("https://hackpad.com/" + id + ".js?format=html");
        return a.substring(16,a.length()-19);
    }
}
