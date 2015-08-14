package com.j113203.java.eyecarereader;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Window;
import android.widget.EditText;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Button;
import android.text.Html;
import android.view.View;
import java.util.jar.JarEntry;
public class MainActivity extends AppCompatActivity  {
    public_ public_= new public_();
    public String nexts ="" , prev ="";
    boolean bottom = false;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        write(public_.about());
    }
    public void Button_OnClick(View view) {
        EditText input_url = (EditText) findViewById(R.id.editText);
        if (!Analysis(input_url.getText().toString())){
            findViewById(R.id.editText).setVisibility(View.VISIBLE);
            findViewById(R.id.send).setVisibility(View.VISIBLE);
            write("<h1>錯誤信息: 不支援的網站</h1>" + public_.about());
        }
    }
    @Override
    public void onBackPressed() {
        findViewById(R.id.editText).setVisibility(View.VISIBLE);
        findViewById(R.id.send).setVisibility(View.VISIBLE);
        write(public_.about());
    }
    void write(String text){
        TextView main = (TextView) findViewById(R.id.main);
        main.setText(Html.fromHtml(text));
    }
    public void go_next(View view){
       if (!nexts.equals("")){
           Analysis(nexts);
       }
    }
    public  void go_prev(View view){
        if (!prev.equals("")){
            Analysis(prev);
        }
    }
    Boolean Analysis(String URL){
        nexts="";
        prev="";
        findViewById(R.id.editText).setVisibility(View.GONE);
        findViewById(R.id.send).setVisibility(View.GONE);
        if (! URL.toLowerCase().startsWith("http")){URL = "http://"+URL;}
        try{
            if (URL.toLowerCase().startsWith("http://tw.hjwzw.com/book/read/") || URL.toLowerCase().startsWith("http://t.hjwzw.com/read/") || URL.toLowerCase().startsWith("http://www.hjwzw.com/book/read/")){
                hjwzw hjwzw = new hjwzw();
                write(hjwzw.get_(URL.substring(URL.lastIndexOf("/") + 1),MainActivity.this));
                return true;
            }else if(URL.toLowerCase().startsWith("https://hackpad.com/") ||URL.toLowerCase().startsWith("http://hackpad.com/")){
                hackpad hackpad = new hackpad();
                write(hackpad.get_(URL.substring(URL.lastIndexOf("-") + 1)));
                return true;
            }else if(URL.toLowerCase().startsWith("http://www.85novel.com/book/") || URL.toLowerCase().startsWith("http://gb.85novel.com/book/")){
                _85novel _85novel = new _85novel();
                String[] a = URL.split("/");
                write(_85novel.get_(a[4]+ "/"+a[5].substring(0,a[5].indexOf(".")),MainActivity.this));
                return true;
            }

        } catch (Exception e) {
            findViewById(R.id.editText).setVisibility(View.VISIBLE);
            findViewById(R.id.send).setVisibility(View.VISIBLE);
            write("<h1>錯誤信息: 無效的章節</h1>");
            return true;
        }
        return false;
    }
}
