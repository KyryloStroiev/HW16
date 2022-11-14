
using HW16;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
var rate = TimeSpan.FromMilliseconds(150);
var game = new Game();

using (var token = new CancellationTokenSource())
{
    var check = CheckKeyPresses(token);
    do
    {
        game.OnTick();
        game.Render();
        await Task.Delay(rate);
    } while (!game.IsGameOver);
    token.Cancel();
    await check;
}

async Task CheckKeyPresses(CancellationTokenSource cts)
{
    while(!cts.Token.IsCancellationRequested)
    {
        if(Console.KeyAvailable)
            game.OnKeyPress(Console.ReadKey(true).Key);
        await Task.Delay(10);
    }
}