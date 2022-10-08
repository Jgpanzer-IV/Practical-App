using System.IO;
using System.Diagnostics;
using System.Text;

namespace NorthwindService.Static{


    public static class ToolHelper{

        private static Encoding encoder = Encoding.UTF8;

        public static void FileLogging(string message){
            
            using (FileStream file = File.OpenWrite("loging.txt")){
                using (StreamWriter writer = new StreamWriter(file)){
                    writer.WriteLine(message);
                }            
            }
        }



    }


}