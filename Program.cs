namespace DeserializeJson
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            MyDb db = new MyDb();   
            string mydata=db.MyData;
            var myDataObjects=mydata.Split(",");
            Dictionary<string,string> myDataDictionary=new Dictionary<string,string>();
           System.Console.WriteLine(myDataObjects[0]);
           
        }
    }
}