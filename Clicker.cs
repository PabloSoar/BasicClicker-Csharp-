class Game
{
    // variables
    public long PointsCount { get; private set; }
    public int AutoPointsLevel { get; private set; }
    public long AutoPointsCost { get; private set; }
    private bool isRunning;

    public Game()
    {
        PointsCount = 0;
        AutoPointsLevel = 0;
        AutoPointsCost = 10; // initial cost
        isRunning = true;
    }

    // game loop
    public async Task Run()
    {
        Console.WriteLine("Bem vindo a meu clicker");
        Console.WriteLine("Pressione [Spacebar] para ganhar pontos");
        if (AutoPointsLevel == 0)
        {
            Console.WriteLine("Pressione [U] para comprar um gerador.");
        }
        else
        {
            Console.WriteLine("Pressione [U] para melhorar seu gerador.");
        }
        Console.WriteLine("Pressione [Esc] para sair.");

        // starts the generator
        _ = AutoPointsGeneratorAsync();

        // player input
        while (isRunning)
        {
            var keysPressedThisCycle = new HashSet<ConsoleKey>();

            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (keysPressedThisCycle.Add(key))
                {
                    switch (key)
                    {
                        case ConsoleKey.Spacebar:
                            ManualClick();
                            break;
                        case ConsoleKey.U:
                            TryBuyAutoPoints();
                            break;
                        case ConsoleKey.Escape:
                            isRunning = false;
                            break;
                    }
                }
            }
            UpdateDisplay();
            await Task.Delay(100);
        }
        Console.WriteLine("\nGame over. Sua pontuação: " + PointsCount);
    }

    private void ManualClick()
    {
        PointsCount++;
    }

    private void TryBuyAutoPoints()
    {
        if (PointsCount >= AutoPointsCost)
        {
            PointsCount -= AutoPointsCost;
            AutoPointsLevel++;
            AutoPointsCost = (long)(AutoPointsCost * 1.5);
        }
    }

    // auto generator
    private async Task AutoPointsGeneratorAsync()
    {
        while (isRunning)
        {
            if (AutoPointsLevel > 0)
            {
                PointsCount += AutoPointsLevel;
            }
            await Task.Delay(1000);
        }
    }

    private void UpdateDisplay()
    {
        Console.Write($"\rPontos: {PointsCount} | Nivel do gerador: {AutoPointsLevel} | Custo do upgrade: {AutoPointsCost}  ");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var game = new Game();
        await game.Run();
    }
}
