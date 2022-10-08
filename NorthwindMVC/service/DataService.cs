using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace NorthwindMVC.service
{
    public static class DataService
    {
        

        public static byte[] convertToByteArray(int[] intArray){
            byte[] byteArray = new byte[intArray.Length];
            for(int i=0; i< intArray.Length; i++){
                byteArray[i] =(byte) intArray[i];
            }
            return byteArray;
        }

        public static int[] randomNotRepeat(int size,int min,int max){
            int[] pinedPosition = new int[size];
            int[] collection = new int[size];
            int getter;
            Random random = new Random();
            for(byte i=0; i<size; i++){
                again:
                getter = random.Next(min,max);
                if(DataService.isRepeat(pinedPosition,getter)){
                    goto again;
                }
                collection[i] = getter;
                pinedPosition[i] = getter;
            }
            return collection;
        }

        public static bool isRepeat (int[] collection, int number){
            foreach(int i in collection){
                if(i == number){
                    return true;
                }
            }
            return false;
        }

    }
}