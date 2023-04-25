

using HeatSystem;

bool run = true;
DataAccess data = new DataAccess();
Controller HeatController = new Controller(data);
Facade ControllerFacade = new Facade(HeatController);
UserInterface UiController = new UserInterface(ControllerFacade);



// Thread t1 = new Thread(new ThreadStart(CF.Run));
// t1.Start();

while (run)
{
    DateTime begin = DateTime.Now;
    Console.SetCursorPosition(0, 0);
    Console.Write("Running... ");

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo exitKey = Console.ReadKey(true);
        if (exitKey.Key == ConsoleKey.X)
        {
            run = false;
            Console.WriteLine("Exiting...");
        }
    }
    run = UiController.Run(run);
    
}

// t1.Join();
