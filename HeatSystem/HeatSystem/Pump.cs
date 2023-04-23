using System;

public class Pump
{
	private bool on = false;

	public Pump()
	{
		
	}

	/// <summary>
	/// Turn the circulation pump on
	/// </summary>
	/// <returns></returns>
	public bool TurnOn()
	{
		this.on = true;
		return this.on;
	}

	/// <summary>
	/// Turn the circulation pump off
	/// </summary>
	/// <returns></returns>
	public bool TurnOff()
	{
		this.on = false;
		return !this.on;
	}
}
