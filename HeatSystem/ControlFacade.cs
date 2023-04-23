using System;

public class ControlFacade
{
	public string configString;

	public ControlFacade()
	{
		
	}

	/// <summary>
	/// Return configuration string from configuration handler.
	/// </summary>
	/// <returns></returns>
	public string GetConfig()
	{
		return configString;
	}

	public bool SetConfig(string Config)
	{
		this.configString = Config;
		return true;
	}
}
