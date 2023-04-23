using System;

public class MixingValve
{
    private double position = 0;

    public MixingValve()
    {
        
    }

    /// <summary>
    /// Set the position of the mixing valve
    /// </summary>
    /// <param name="pos"></param>
    public void SetPosition(double pos)
    {
        this.position = pos;
    }

    /// <summary>
    /// Get the position of the mixing valve
    /// </summary>
    /// <returns></returns>
    public double GetPosition()
    { 
        return this.position;
    }

}
