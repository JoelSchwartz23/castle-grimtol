using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {

      GameService game = new GameService();
      game.Playing = true;

      Console.Clear();
      System.Console.WriteLine("Welcome to Death Dungeon...");
      System.Console.WriteLine("Begin? (Y/N)");
      if (Console.ReadLine().ToLower().Contains("n"))
      {
        return;
      }
      else if (Console.ReadLine().ToLower().Contains("y"))
      {
        game.Setup();
      }

    }
  }
}

