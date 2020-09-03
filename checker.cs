    
using System;
using System.Diagnostics;

class Checker
{
    static int Main() {
        
        PatientVitalsStatus _patientVitals = new PatientVitalsStatus();
        
//         float _normalBpmValue=100;
//         float _lowBpmValue=40;
//         float _highBpmValue=160;
        
//         float _normalSpo2Value=95;
//         float _lowSpo2Value=80;
        
//         float _normalRespRateValue=60;
//         float _lowRespRateValue=20;
//         float _highRespRateValue=100;
        
        //All normal values test-condition
        VitalCheck.ExpectTrue(VitalCheck.checkAllVitals(100,95,60,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //====================================[One abnormal vital test cases]==============================
        
        //low Bpm test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(40,91,92,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //high Bpm test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(151,91,92,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //low Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(100,88,92,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
         //low RespRate test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(100,91,20,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
         //high RespRate test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(100,91,97,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //=========================[Combination of Two abnormal vitals test cases]==========================

         //low Bpm and low Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(40,88,92,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //high bpm and low Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(151,88,92,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //low RespRate and low Spo2 test-condition 
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(100,87,20,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //high RespRate and low Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(100,87,97,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //low Bpm and low Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(40,95,20,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        
        //high Bpm and high Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(151,95,97,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //low Bpm and high Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(40,95,97,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //high Bpm and low Spo2 test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(151,95,20,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //=========================[Combination of Three abnormal vitals test cases]=========================
        
        //low Bpm, low Spo2 and low RespRate test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(40,87,20,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //high Bpm, low Spo2 and low RespRate test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(151,87,20,_patientVitals));
        _patientVitals.displayAllVitalStatus();
  
        //low Bpm, low Spo2 and high RespRate test-condition
         VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(40,87,97,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        //high Bpm, low Spo2 and high RespRate test-condition
        VitalCheck.ExpectFalse(VitalCheck.checkAllVitals(151,87,97,_patientVitals));
        _patientVitals.displayAllVitalStatus();

        Console.WriteLine("All ok");
        return 0;
    }
    
}   
    
class VitalCheck{
    
    // [Test-condition for good vital condition]
    public static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    
    //[Test-condition for abnormal vital condition]
    public static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    
    // check for all vital values 
    public static bool checkAllVitals(float _bmpValue,float _spo2Value, float _respRateValue, PatientVitalsStatus _patientVitals){

        return BPMVital.checkBpmVital(_bmpValue,_patientVitals) 
            && SPO2Vital.checkSpo2Vital (_spo2Value,_patientVitals) 
            && RespRateVital.checkRespRateVital(_respRateValue,_patientVitals);

    }



}

// [Stores patient's vital and the breach ]
class PatientVitalsStatus{

    string _bpmStatus;
    string _spo2Status;
    string _respRateStatus;

    internal void setBpmStatus(string _bpmStatus){
        this._bpmStatus = _bpmStatus;
    }
    public string getBpmStatus(){
        return _bpmStatus;
    }

    internal void setSpo2Status(string _spo2Status){
        this._spo2Status = _spo2Status;
    }

    public string getSpo2Status(){
        return _spo2Status;
    }

    internal void setRespRateStatus(string _respRateStatus){
        this._respRateStatus = _respRateStatus;
    }

    public string getRespRateStatus(){
        return _respRateStatus;
    }

    public void displayAllVitalStatus(){

        Console.WriteLine($"Bpm : {_bpmStatus}, Spo2 : {_spo2Status}, RespRate : {_respRateStatus}");
    } 
}

//[Class of BPM vital]
class BPMVital{

    static float _minBpm = 70;
    static float _maxBpm = 100;

    static void setMinBpm(float _minBpmParameter){

        _minBpm = _minBpmParameter;
    }

    static void setMaxBpm(float _maxBpmParameter){

        _maxBpm = _maxBpmParameter;
    }

    public static float getMinBpm(){

        return _minBpm;
    }

    public static float getMaxBpm(){

        return _maxBpm;
    }
    
    //[Checks Bpm vital conditions]
    public static bool checkBpmVital(float _bpmValue, PatientVitalsStatus _patientVitals){
        if (_bpmValue < _minBpm)
        {
            _patientVitals.setBpmStatus("low");
            return false;
        }
        else if(_bpmValue > _maxBpm){
            _patientVitals.setBpmStatus("high");
            return false; 
        }
        _patientVitals.setBpmStatus("ok");
        return true;
    }
}

//[Class of SPO2 vital]
class SPO2Vital{

    static float _minSpo2 = 90;

    static void setMinSpo2(float _minSpo2Parameter){

        _minSpo2 = _minSpo2Parameter;
    }


    public static float getMinSpo2(){

        return _minSpo2;
    }
    
    //[Checks Spo2 vital conditions]
    public static bool checkSpo2Vital(float _spo2Value, PatientVitalsStatus _patientVitals){
        if (_spo2Value < _minSpo2)
        {
            _patientVitals.setSpo2Status("low");
            return false;
        }
        _patientVitals.setSpo2Status("ok");
        return true;
    }

}

//[Class of RespRate vital]
class RespRateVital{

    static float _minRespRate = 30;
    static float _maxRespRate = 95;

    static void setMinRespRate(float _minRespRateParameter){

        _minRespRate = _minRespRateParameter;
    }

    static void setMaxRespRate(float _maxRespRateParameter){

        _maxRespRate = _maxRespRateParameter;
    }

    public static float getMinRespRate(){

        return _minRespRate;
    }

    public static float getMaxRespRate(){

        return _maxRespRate;
    }

    
    //[Checks RespRate vital conditions]
    public static bool checkRespRateVital(float _respRateValue, PatientVitalsStatus _patientVitals){
        if (_respRateValue < _minRespRate)
        {
            _patientVitals.setRespRateStatus("low");
            return false;
        }
        else if(_respRateValue > _maxRespRate){
            _patientVitals.setRespRateStatus("high");
            return false; 
        }
        _patientVitals.setRespRateStatus("ok");
        return true;
    }
}
