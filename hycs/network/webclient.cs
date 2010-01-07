using System; 
using System.Net; 
using System.IO; 
 
class MainClass {  
  public static void Main() { 
    WebClient user = new WebClient(); 
    string uri = "http://www.java2s.com"; 
    string fname = "data.txt"; 
     
    try { 
      Console.WriteLine("Downloading data from " + uri + " to " + fname); 
      user.DownloadFile(uri, fname); 
    } catch (WebException exc) { 
      Console.WriteLine(exc); 
    } 
 
    Console.WriteLine("Download complete."); 
  } 
}
