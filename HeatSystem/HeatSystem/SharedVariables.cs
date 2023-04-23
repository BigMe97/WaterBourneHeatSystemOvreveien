using System;
public class SharedVariables
{
    public bool run { get; set; }
    public int samplingtime = 1000;
    public double setpoint;
    public TempSensor outflowTemp;
    public MixingValve MV;
    public TempSensor[] tempSensorList;
    public OnOffValve[] ValveList;
    public Pump pump;


    public SharedVariables()
    {

    }


    public SharedVariables(TempSensor[] tempSensorList, TempSensor outtemp, MixingValve mv, OnOffValve[] valveList, Pump pump)
    {
        this.run = true;
        this.tempSensorList = tempSensorList;
        this.outflowTemp = outtemp;
        this.MV = mv;
        this.ValveList = valveList;
        this.pump = pump;
    }
}

