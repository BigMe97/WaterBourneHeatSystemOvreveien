using System;

public class OnOffValve
{
	public bool open = false;
	public string room;

	public OnOffValve(string roomName)
	{
		this.open = false;
		this.room = roomName;
	}

	/// <summary>
	/// Open this valve
	/// </summary>
	/// <returns></returns>
	public bool Open() 
	{ 
		this.open = true;
		return this.open; 
	}

	/// <summary>
	/// Close this valve
	/// </summary>
	/// <returns></returns>
	public bool Close()
	{
		this.open = false;
		return !this.open;
	}

}
