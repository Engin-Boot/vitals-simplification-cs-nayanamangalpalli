using System;
using System.Diagnostics;

class Checker
{
    static int Main() {
        VitalsChecker.ExpectTrue(VitalsChecker.vitalsAreOk(100, 95, 60));
        VitalsChecker.ExpectFalse(VitalsChecker.vitalsAreOk(40, 91, 92));
        Console.WriteLine("All ok");
        return 0;
    }
}
