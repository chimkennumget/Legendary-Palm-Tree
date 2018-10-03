/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package webscraper;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;

public class Webscraper {
    
    public static String Name;
    public static String Weight;
    public static String HomeTown;

    private final static String url1 = "http://www.cornellrams.com/roster/17/11";

    private static ArrayList<String> getNames() throws IOException {
        URL NewURL = new URL(url1);
        URLConnection conn = NewURL.openConnection();

        // open the stream and put it into BufferedReader
        BufferedReader br = new BufferedReader(
                new InputStreamReader(conn.getInputStream()));

        String inputLine;

        //save to this filename
        ArrayList<String> list = new ArrayList();
        ArrayList<String> list0 = new ArrayList();

        while ((inputLine = br.readLine()) != null) {
            list.add(inputLine);

        }
        br.close();
        for (int i = 0; i < list.size(); i++) {
//            System.out.println(list.get(i));
            if (list.get(i).contains("<a href=\"/roster/17/11/")){
                Name = list.get(i);
                Name = Name.split("href=\"")[1].split("\">")[0];
                System.out.println(Name);
                list0.add(Name + "\n");
            }
        }
        return(list0);
    }
            
    

    private static void webscraper(String Url2, BufferedWriter bw) {
        try {

            // get URL content
//            url2 = "https://fortnitestats.net/stats/twitch-luuu90";
            URL url = new URL(Url2);
            URLConnection conn = url.openConnection();

            // open the stream and put it into BufferedReader
            BufferedReader br = new BufferedReader(
                    new InputStreamReader(conn.getInputStream()));

            String inputLine;

            //save to this filename
            ArrayList<String> list = new ArrayList();
            ArrayList<String> list0 = new ArrayList();

            while ((inputLine = br.readLine()) != null) {
                list.add(inputLine);

            }

            br.close();

            for (int i = 0; i < list.size(); i++) {
                if(list.get(i).contains("href=\"/roster/17/11/")){
                    Name = list.get(i);
                    Name = Name.split(".php\">")[1].split("</a>")[0];
//                    list0.add(Name + ",");
//                    list0.add("\n");
                    System.out.println(Name);
                   }
                else if ( list.get(i).contains("\"rosterWeight\">")){
                   Weight = list.get(i);
                   Weight = Weight.split("\"rosterWeight\">")[1].split("</td>")[0];
                   }
                else if ( list.get(i).contains("\"rosterTown\">")){
                    HomeTown = list.get(i);
                    HomeTown = HomeTown.split("\"rosterTown\">")[1].split("</td>")[0];
                    list0.add(Name + "," + Weight + "," + HomeTown + "\n");
                }
            }
            for (int z = 0; z < list0.size(); z++) {
                bw.write(list0.get(z));
            }

            bw.write("Cornell's 2018-2019 Wrestling Bad Asses");

        } catch (MalformedURLException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    public static void main(String[] args) throws IOException {
        String fileName = "CornellRoster.csv";
        File file = new File(fileName);

        if (!file.exists()) {
            file.createNewFile();
        }

        //use FileWriter to write file
        FileWriter fw = new FileWriter(file.getAbsoluteFile());
        BufferedWriter bw = new BufferedWriter(fw);
        bw.write("Name " + "," + "Weight " + "," + "Hometown " + "\n");
        String url = "http://www.cornellrams.com/roster/17/11";
        webscraper(url,bw);
        
//        webscraper(AllNames, bw);
//        webscraper("https://fortnitestats.net/stats/twitch-orcas", bw);
        bw.close();

    }
}
