using System.Text;

namespace SimpleWeb{

    public static class Calculator{


        public static string getTimeTable(){

            StringBuilder str = new();

            for (byte i=1; i <= 24; i++){
                for (byte u=1; u<12; u++){
                    str.Append(string.Format("{0} x {1} = {2}\n",i,u,i*u));
                }
            }
            return str.ToString();
        }


    }


}