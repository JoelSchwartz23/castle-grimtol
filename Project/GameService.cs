using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public IRoom CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Playing { get; set; }


    public void Setup()

    {
      Playing = true;
      Room start = new Room("Start", "You wake up in a strange dark room, a little dazed..... You see a very feint light to the east and it appears you have nowhere else to go but towards it.", false);
      Room keyroom = new Room("KeyRoom", "You find yourself in another very dark room but now the light to the east has grown much brighter. You kicked something on the floor when you walked in, but it is too dark and you cannot find the item.", false);
      Room keyroom2 = new Room("KeyRoom2", "Now that you have a source of light you are able to see the item that you kicked when you initially came into the room and it's a key!", false);
      Room crossroads = new Room("CrossRoads", "You have found your way to the lit room and now it seems you must choose a path. To the south there's a door, to the north there's another room that is seemingly brighter than the one you are currently in and to the east it seems that theres another dark room.", false);
      Room axeroom = new Room("AxeRoom", "You open the locked door and once you enter the room you feel the floor move beneath your feet, suddenly an Axe comes down from the ceiling and you fail to avoid it. You have fallen.", true);
      Room darkroom = new Room("DarkRoom", "You have entered another dark room and there's not currently enough light to be able to tell if there's anything useful to you.", false);
      Room darkroom2 = new Room("DarkRoom2", "You now have a source of light and you notice that there's a door in the room. You check the door and it appears to be locked. Do you have the key?", false);
      Room roperoom = new Room("RopeRoom", "You open the door and when you walk in there's a rope in the corner of the room. The rope might be useful for later.", true);
      Room torchroom = new Room("TorchRoom", "You enter a room that is significantly lighter than the previous room and it appears that there's a torch on the wall that you can take.", false);
      Room closingroom = new Room("ClosingRoom", "You enter a room that has a lever on the far side, but the instant you step in the door slams shut behind you and the walls start closing in quickly. It appears you don't have enough time to run to the lever what will you do?", false);
      Room bananadoor = new Room("BananaDoor", "You enter a room and you see two different doors, one with a cresent shape in the middle that appears to be locked and the other is just a solid yellow door.", true);
      Room bananaroom = new Room("BananaRoom", "You step into the room after opening the brightly colored door and you see a ton of bananas, you're hungry, but getting out of the dungeon takes precedence.", false);
      Room maceroom = new Room("MaceRoom", "The door swings open and instantly a mace flies down from the ceiling striking you in the head. You have fallen.", false);
      Room bananadoor2 = new Room("BananaDoor2", "You enter a room and see another door with a crescent shape in it.", true);
      Room coloreddoors = new Room("ColoredDoors", "You enter a room and see two doors, one red and one black. Which will you choose?", false);
      Room reddoor = new Room("RedDoor", "You chose to go through the red doorand you have gained your freedom from the dungeon. Congatulations, You Won!", false);
      Room blackdoor = new Room("BlackDoor", "You chose to go through the black door and the moment you stepped in spikes came up through the floor. You have fallen.", false);

      start.Exits.Add("east", keyroom);
      keyroom.Exits.Add("east", crossroads);
      crossroads.Exits.Add("east", darkroom);
      crossroads.Exits.Add("north", torchroom);
      crossroads.Exits.Add("south", axeroom);
      crossroads.Exits.Add("west", keyroom);
      darkroom.Exits.Add("east", roperoom);
      torchroom.Exits.Add("north", closingroom);
      closingroom.Exits.Add("east", bananadoor);
      closingroom.Exits.Add("west", coloreddoors);
      bananadoor.Exits.Add("east", bananaroom);
      bananadoor.Exits.Add("north", maceroom);
      coloreddoors.Exits.Add("north", reddoor);
      coloreddoors.Exits.Add("west", blackdoor);



      var key = new Item("Key", "Probably helpful for opening locked doors.");
      keyroom.Items.Add(key);
      var torch = new Item("Torch", "Probably helpful for illuminating dark rooms");
      torchroom.Items.Add(torch);
      var banana = new Item("Banana", "Looks like it could be inserted into the cresecent shape on the door.");
      bananaroom.Items.Add(banana);

      CurrentRoom = start;

    }

    public enum gameInputs
    {
      goNorth,
      goEast,
      goSouth,
      goWest,
      useKey,
      useTorch,
      useBanana,
      inventory,
      look,
      quit,
      help,
      reset,
      end
    }
    public gameInputs Parse(string text)
    {
      string input = text.ToLower();
      if (input.Contains("go") && input.Contains("north"))
      {
        return gameInputs.goNorth;
      }
      if (input.Contains("go") && input.Contains("east"))
      {
        return gameInputs.goEast;
      }
      if (input.Contains("go") && input.Contains("south"))
      {
        return gameInputs.goSouth;
      }
      if (input.Contains("go") && input.Contains("west"))
      {
        return gameInputs.goWest;
      }
      if (input.Contains("use") && input.Contains("key"))
      {
        return gameInputs.useKey;
      }
      if (input.Contains("use") && input.Contains("torch"))
      {
        return gameInputs.useTorch;
      }
      if (input.Contains("use") && input.Contains("banana"))
      {
        return gameInputs.useBanana;
      }
      if (input.Contains("inventory"))
      {
        return gameInputs.inventory;
      }
      if (input.Contains("look"))
      {
        return gameInputs.look;
      }
      if (input.Contains("quit"))
      {
        return gameInputs.quit;
      }
      if (input.Contains("help"))
      {
        return gameInputs.help;
      }
      if (input.Contains("reset"))
      {
        return gameInputs.reset;
      }
      return gameInputs.end;
    }
    public void GetUserInput()
    {

    }
    public void Help()
    {
      Console.Clear();
      System.Console.WriteLine("Game Intructions\n");
      System.Console.WriteLine("Submit 'Help' at anytime to bring these instructions back\n");
      System.Console.WriteLine("Submit 'Go' + north,east,south or west to navigate the dungeon.\n");
      System.Console.WriteLine("Submit 'Inventory' to display the items you have picked up, if any.\n");
      System.Console.WriteLine("Submit 'Use' + the name of items in you inventory to use them. \n");
      System.Console.WriteLine("Submit 'Look' to receive a description of the room that you are in again \n");
      System.Console.WriteLine("Submit 'Quit' at any time to exit the game. \n");
      System.Console.WriteLine("Submit 'Reset' to restart the game at any point. \n");

    }

    public void Inventory()
    {
      Console.Clear();
      foreach (var item in CurrentPlayer.Inventory)
      {
        System.Console.WriteLine($"{item.Name}:{item.Description} \n");
      }
    }

    public void Look()
    {
      Console.Clear();
      System.Console.WriteLine($"{CurrentRoom.Description}");

    }

    public void Quit(bool Playing)
    {
      System.Console.WriteLine("Are you sure you would like to quit the game?  Type: y/n \n");
      string input = Console.ReadLine().ToLower();
      if (input == "y")
      {
        Playing = false;
        return;
      }
      else if (input == "n")
      {
        Playing = true;
      }

    }

    public void Reset()
    {
      Playing = true;
      Setup();

    }


    public void StartGame()
    {
      throw new System.NotImplementedException();
    }

    public void TakeItem(string itemName)
    {
      // var founditem = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
      // if CurrentRoom
    }

    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public void Go(string direction)
    {
      // if (!CurrentRoom.Exits.ContainsKey(direction))
      // {
      //   System.Console.Writeline("You cannot go that way."){
      //     return;
    }
  }
}



