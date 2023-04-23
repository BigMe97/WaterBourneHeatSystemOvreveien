using System;

public class TempSensor	
{
	private double temperature;
	private DateTime timestamp;

	public TempSensor()
	{
	}
	
	/// <summary>
	/// Returns the last read temperature
	/// </summary>
	/// <returns></returns>
	public double GetTemp()
	{
		this.ReadTemp();
		return temperature;
	}

	private void ReadTemp()
	{
		this.temperature = Convert.ToDouble(new Random().NextDouble());
		this.timestamp = DateTime.Now;
	}
}
