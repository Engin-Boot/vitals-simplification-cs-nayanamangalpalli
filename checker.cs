using System;
using System.Diagnostics;

class Checker
{
    static int Main() {
        PatientVitals _patientVitals = new PatientVitals();
        VitalCheck.ExpectTrue( BPMVital.checkBpmVital(100,_patientVitals) 
                            && SPO2Vital.checkSpo2Vital (95,_patientVitals) 
                            && RespRateVital.checkRespRateVital(60,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        VitalCheck.ExpectFalse( BPMVital.checkBpmVital(40,_patientVitals) 
                            && SPO2Vital.checkSpo2Vital (91,_patientVitals) 
                            && RespRateVital.checkRespRateVital(92,_patientVitals));
        _patientVitals.displayAllVitalStatus();
        
        Console.WriteLine("All ok");
        return 0;
    }
}   
   
    
class VitalCheck{

    public static void ExpectTrue(bool expression) {
        if(!expression) {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }

    public static void ExpectFalse(bool expression) {
        if(expression) {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }


}

class PatientVitals{

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

//BPMVital Class
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

    public static bool checkBpmVital(float _bpmValue, PatientVitals _patientVitals){
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

//SPO2Vital class
class SPO2Vital{

    static float _minSpo2 = 90;

    static void setMinSpo2(float _minSpo2Parameter){

        _minSpo2 = _minSpo2Parameter;
    }


    public static float getMinSpo2(){

        return _minSpo2;
    }

    public static bool checkSpo2Vital(float _spo2Value, PatientVitals _patientVitals){
        if (_spo2Value < _minSpo2)
        {
            _patientVitals.setSpo2Status("low");
            return false;
        }
        _patientVitals.setSpo2Status("ok");
        return true;
    }

}

//respRateVital class
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

    public static bool checkRespRateVital(float _respRateValue, PatientVitals _patientVitals){
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
