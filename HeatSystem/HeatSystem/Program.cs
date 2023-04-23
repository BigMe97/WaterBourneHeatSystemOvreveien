

SharedVariables Vars = new SharedVariables();
ControlFacade CF = new ControlFacade();

CF.GetConfig();
TempSensor MainOut = new TempSensor();
TempSensor[] roomTemps = new TempSensor[13];
foreach (TempSensor roomTemp in roomTemps)
{
    roomTemp.GetTemp();
    roomTemp.room
}

// Thread t1 = new Thread(new ThreadStart(CF.Run));
// t1.Start();

while (Vars.run)
{
    DateTime begin = DateTime.Now;
    Console.SetCursorPosition(0, 0);
    Console.Write("Running... ");

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo exitKey = Console.ReadKey(true);
        if (exitKey.Key == ConsoleKey.X)
        {
            Vars.run = false;
            Console.WriteLine("Exiting...");
        }
    }

    

    // Alter Vars

    CF.SetConfig("MV10");




    int dt = DateTime.Now.Subtract(begin).Milliseconds;
    Console.Write(dt.ToString());
    Console.WriteLine("ms");
    Thread.Sleep(1000 - dt);
}

// t1.Join();
