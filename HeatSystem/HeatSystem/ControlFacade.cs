using System;
using System.Runtime;

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

	/// <summary>
	/// Alters the configuration
	/// </summary>
	/// <param name="Config"></param>
	/// <returns></returns>
	public bool SetConfig(string Config)
	{
		this.configString = Config;
		return true;
	}

}
