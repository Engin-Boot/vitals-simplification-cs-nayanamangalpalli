using System;
using System.Diagnostics;
class VitalsChecker{


    static bool vitalsAreOk(float bpm, float spo2, float respRate)
        {
            if(checkSPO2(spo2) && checkBpmAndrespRate(bpm,respRate)){
                return true;
            }
            return false;
        }
    
        static bool checkBpmAndrespRate(float bpm, float respRate){
            if(checkBPM(bpm) && checkRespRate(respRate)){
                return true;
            }
            return false;
        }
        
        static bool checkBPM(float bpm){
            if (bpm < 70 || bpm > 150)
            {
                return false;
            }
            return true;
        }
        static bool checkSPO2(float spo2){
            if (spo2 < 90)
            {
                return false;
            }
            return true;
        }
        
        static bool checkRespRate(float respRate){
            if (respRate < 30 || respRate > 95)
            {
                return false;
            }
            return true;
        }
   
    static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
}
