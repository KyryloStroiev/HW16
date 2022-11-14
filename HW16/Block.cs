using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW16;

public class Block
{
    public Position Position { get; set; }
    public bool Gameofer { get; set; }
    public Block (Position position, bool gameofer)
    {
        Position = position;
        Gameofer = gameofer;
    }
    public void Render()
    {
        Console.SetCursorPosition(Position.Left, Position.Top);
        Console.WriteLine("■");
        
    }
    

}
public static class BlockExtention
{
    public static Block CreatBlock()
    {
        var rows = 20;
        var columns = 20;  
        var random = new Random();
        var top = random.Next(0, rows + 4);
        var left = random.Next(0, columns + 4);
        return new Block (new Position(top, left), true);
       
    }
}
