using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16;

public class Game
{
    public Position StartPosition = new(8, 8);
    public Direction CurrentDirection;
    public Direction NextDirection;
    

    public Snake _snake;
    public Apple _apple;
    public Block _block;
    public int _rate = 120;

    public Game()
    {
        _snake = new Snake(StartPosition, 5);
        _apple = AppleExtentions.CreatApple();
        _block = BlockExtention.CreatBlock();
        CurrentDirection = Direction.Right;
        NextDirection = Direction.Right;
    }

    public bool IsGameOver => !_snake.IsAlive;
    public void OnKeyPress(ConsoleKey key)
    {
        Direction newDirection;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                newDirection = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                newDirection = Direction.Down;
                break;
            case ConsoleKey.LeftArrow:
                newDirection = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                newDirection = Direction.Right;
                break;
            default: return;
        }
        if (newDirection == CurrentDirection.OppositeDirection())
            return;
        NextDirection = newDirection;

    }
   
    public void Render()
    {
        Console.Clear();
        _snake.Render(this);
        _apple.Render();
        _block.Render();
        Console.SetCursorPosition(0, 0);
    }
    public void OnTick()
    {
        if (IsGameOver) throw new Exception();
        CurrentDirection = NextDirection;
        _snake.Move(CurrentDirection);
        if (_snake.Head.Equals(_apple.Position))
        {
            _snake.Grow();
            
            _rate = _rate > 10 ? _rate - 10 : _rate;
            _apple = AppleExtentions.CreatApple();
            do
            {
                _block = BlockExtention.CreatBlock();
            } while (IsGameOver);

        }
        if (_snake.Head.Equals(_block.Position))
        {
            Console.WriteLine("-----GAME OVER----- \n" +
                " Дя продовження нажмiть Enter");
            Console.ReadKey();
        }
    }
    
}
public static class GameExtension
{
    public static void RotateShakeIfBouns(this Game game)
    {
        if (game._snake.Head.Left == Console.WindowWidth - 6 || game._snake.Head.Left == 0 ||
                game._snake.Head.Top == Console.WindowWidth - 6 || game._snake.Head.Top == 0)
            game.NextDirection = game.CurrentDirection.OppositeDirection();
    }
}
