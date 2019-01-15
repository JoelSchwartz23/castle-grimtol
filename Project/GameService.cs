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
    public bool Playing = true;



    public void Setup()

    {
      Room start = new Room("Start", "You wake up in a strange dark room, a little dazed..... You see a very feint light to the east and it appears you have nowhere else to go but towards it.", false);
      Room keyroom = new Room("KeyRoom", "You find yourself in another very dark room but now the light to the east has grown much brighter. You kicked something on the floor when you walked in, but it is too dark and you cannot find the item.", false);
      Room keyroom2 = new Room("KeyRoom2", "Now that you have a source of light you are able to see the item that you kicked when you initially came into the room and it's a key!", false);
      Room crossroads = new Room("CrossRoads", "You have found your way to the lit room and now it seems you must choose a path. To the south there's a door, to the north there's another room that is seemingly brighter than the one you are currently in and to the east it seems that theres another dark room.", false);
      Room axeroom = new Room("AxeRoom", "You open the locked door and once you enter the room you feel the floor move beneath your feet, suddenly an Axe comes down from the ceiling and you fail to avoid it. You have fallen.", true);
      Room darkroom = new Room("DarkRoom", "You have entered another dark room and there's not currently enough light to be able to tell if there's anything useful to you.", false);
      Room darkroom2 = new Room("DarkRoom2", "You now have a source of light and you notice that there's a door in the room. You check the door and it appears to be locked. Do you have the key?", false);
      Room roperoom = new Room("RopeRoom", "You open the door and when you walk in there's a rope in the corner of the room. The rope might be useful for later.", true);
      Room torchroom = new Room("TorchRoom", "You enter a room that is significantly lighter than the previous room and it appears that there's a torch on the wall that you can take.", false);
      Room closingroom = new Room("ClosingRoom", "You enter a room that has a lever on the far wall, but the walls start closing in on you the moment you come into the room. Hurry and leave the room, or use the correct item in your inventory to stop the walls.", false);
      Room bananadoor = new Room("BananaDoor", "You enter a room and you see two different doors, one to the north with a cresent shape in the middle that appears to be locked and the other to the east is just a solid yellow door.", true);
      Room bananaroom = new Room("BananaRoom", "You step into the room after opening the brightly colored door and you see a ton of bananas, you're hungry, but getting out of the dungeon takes precedence.", false);
      Room maceroom = new Room("MaceRoom", "The door swings open and instantly a mace flies down from the ceiling striking you in the head. You have fallen.", true);
      Room bananadoor2 = new Room("BananaDoor2", "You enter a room and see another door with a crescent shape in it.", true);
      Room coloreddoors = new Room("ColoredDoors", "You enter a room and see two doors, one red and one black, both with a crescent shape on them. It appears you need to place an item in the doors to continue.", true);
      Room reddoor = new Room("RedDoor", "You chose to go through the red doorand you have gained your freedom from the dungeon. Congatulations, You Won!", false);
      Room blackdoor = new Room("BlackDoor", "You chose to go through the black door and the moment you stepped in spikes came up through the floor. You have fallen.", false);

      start.Exits.Add("east", keyroom);
      keyroom.Exits.Add("east", crossroads);
      crossroads.Exits.Add("east", darkroom);
      crossroads.Exits.Add("north", torchroom);
      crossroads.Exits.Add("south", axeroom);
      crossroads.Exits.Add("west", keyroom);
      darkroom.Exits.Add("east", roperoom);
      darkroom.Exits.Add("west", crossroads);
      roperoom.Exits.Add("west", darkroom);
      torchroom.Exits.Add("north", closingroom);
      torchroom.Exits.Add("south", crossroads);
      closingroom.Exits.Add("east", bananadoor);
      closingroom.Exits.Add("west", coloreddoors);
      closingroom.Exits.Add("south", torchroom);
      bananadoor.Exits.Add("east", bananaroom);
      bananadoor.Exits.Add("north", maceroom);
      bananaroom.Exits.Add("west", bananadoor);
      coloreddoors.Exits.Add("north", reddoor);
      coloreddoors.Exits.Add("west", blackdoor);




      Item torch = new Item("torch", "Probably helpful for illuminating dark rooms");
      Item banana = new Item("banana", "Looks like it could be inserted into the cresecent shape on the door.");
      Item rope = new Item("rope", "This could be helpful for lassoing levers.");
      // keyroom2.Items.Add(key);
      torchroom.Items.Add(torch);
      bananaroom.Items.Add(banana);
      roperoom.Items.Add(rope);

      CurrentRoom = start;
      System.Console.WriteLine("What is your name?");
      CurrentPlayer = new Player(Console.ReadLine());


    }

    public enum gameInputs
    {
      goNorth,
      goEast,
      goSouth,
      goWest,
      useKey,
      takeKey,
      useTorch,
      takeTorch,
      useBanana,
      takeBanana,
      useRope,
      takeRope,
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
      else if (input.Contains("go") && input.Contains("east"))
      {
        return gameInputs.goEast;
      }
      else if (input.Contains("go") && input.Contains("south"))
      {
        return gameInputs.goSouth;
      }
      else if (input.Contains("go") && input.Contains("west"))
      {
        return gameInputs.goWest;
      }
      else if (input.Contains("use") && input.Contains("key"))
      {
        return gameInputs.useKey;
      }
      else if (input.Contains("take") && input.Contains("key"))
      {
        return gameInputs.takeKey;
      }
      else if (input.Contains("use") && input.Contains("torch"))
      {
        return gameInputs.useTorch;
      }
      else if (input.Contains("take") && input.Contains("torch"))
      {
        return gameInputs.takeTorch;
      }
      else if (input.Contains("use") && input.Contains("banana"))
      {
        return gameInputs.useBanana;
      }
      else if (input.Contains("take") && input.Contains("banana"))
      {
        return gameInputs.takeBanana;
      }
      else if (input.Contains("use") && input.Contains("rope"))
      {
        return gameInputs.useRope;
      }
      else if (input.Contains("take") && input.Contains("rope"))
      {
        return gameInputs.takeRope;
      }
      else if (input.Contains("inventory"))
      {
        return gameInputs.inventory;
      }
      else if (input.Contains("look"))
      {
        return gameInputs.look;
      }
      else if (input.Contains("quit"))
      {
        return gameInputs.quit;
      }
      else if (input.Contains("help"))
      {
        return gameInputs.help;
      }
      else if (input.Contains("reset"))
      {
        return gameInputs.reset;
      }
      else
      {
        return gameInputs.end;
      }
    }
    public void GetUserInput()
    {
      // while (true)
      // {
      string userInput = Console.ReadLine().ToLower();
      gameInputs input = Parse(userInput);

      if (input == gameInputs.goNorth)
      {
        Go("north");
      }
      else if (input == gameInputs.goEast)
      {
        Go("east");
      }
      else if (input == gameInputs.goSouth)
      {
        Go("south");
      }
      else if (input == gameInputs.goWest)
      {
        Go("west");
      }
      else if (input == gameInputs.useKey)
      {
        UseItem("Key");
      }
      else if (input == gameInputs.takeKey)
      {
        TakeItem("Key");
      }
      else if (input == gameInputs.useTorch)
      {
        UseItem("Torch");
      }
      else if (input == gameInputs.takeTorch)
      {
        TakeItem("Torch");
      }
      else if (input == gameInputs.useBanana)
      {
        UseItem("Banana");
      }
      else if (input == gameInputs.takeBanana)
      {
        TakeItem("Banana");
      }
      else if (input == gameInputs.useRope)
      {
        UseItem("Rope");
      }
      else if (input == gameInputs.takeRope)
      {
        TakeItem("Rope");
      }
      else if (input == gameInputs.inventory)
      {
        Inventory();
      }
      else if (input == gameInputs.look)
      {
        Look();
      }
      else if (input == gameInputs.quit)
      {
        Quit();
        // break;
      }
      else if (input == gameInputs.help)
      {
        Help();
      }
      else if (input == gameInputs.reset)
      {
        Reset();
      }
      // }
    }
    public void Help()
    {
      System.Console.WriteLine("Game Intructions:\n");
      System.Console.WriteLine("Submit 'help' at anytime to bring these instructions back\n");
      System.Console.WriteLine("Submit 'go' + north,east,south or west to navigate the dungeon. Example: goeast \n");
      System.Console.WriteLine("Submit 'inventory' to display the items you have picked up, if any.\n");
      System.Console.WriteLine("Submit 'use' + the name of items in you inventory to use them. \n");
      System.Console.WriteLine("Submit 'take' + the name of an item in the room to take that item. \n");
      System.Console.WriteLine("Submit 'look' to receive a description of the room that you are in again \n");
      System.Console.WriteLine("Submit 'quit' at any time to exit the game. \n");
      System.Console.WriteLine("Submit 'reset' to restart the game at any point. \n");
    }

    public void Inventory()
    {
      System.Console.WriteLine("you have these items in your inventory: ");
      foreach (Item Item in CurrentPlayer.Inventory)
      {
        System.Console.WriteLine(Item.Name);
      }
    }

    public void Look()
    {
      // Console.Clear();
      System.Console.WriteLine(CurrentRoom.Description);
      System.Console.Write("\nHow Will you proceed " + CurrentPlayer.PlayerName + "?");

    }

    public void Quit()
    {
      Playing = false;
    }
    public void Reset()
    {
      Console.Clear();
      StartGame();
    }

    public void StartGame()
    {
      System.Console.WriteLine("Welcome to Death Dungeon...");
      Setup();
      Help();
      System.Console.WriteLine("Game Introduction:\n");
      Look();
      while (Playing)
      {
        if (CurrentRoom.Name == "AxeRoom")
        {
          return;
        }
        if (CurrentRoom.Name == "BlackDoor")
        {
          return;
        }
        if (CurrentRoom.Name == "MaceRoom")
        {
          return;
        }
        GetUserInput();
      }
    }

    public void TakeItem(string itemName)
    {
      Item gameItem = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
      if (gameItem != null)
      {
        CurrentRoom.Items.Remove(gameItem);
        CurrentPlayer.Inventory.Add(gameItem);
        Console.WriteLine("Item added to inventory");
        Inventory();

      }
      else
      {
        System.Console.WriteLine("There are no items in this room to take.");
      }
    }

    public void UseItem(string itemName)
    {
      Item gameItem = CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName.ToLower());
      // foreach (Item Item in CurrentPlayer.Inventory)
      if (CurrentRoom.Name == "KeyRoom" && gameItem.Name == "torch")
      {
        Item key = new Item("key", "Probably helpful for opening locked doors.");
        CurrentRoom.Items.Add(key);
        CurrentRoom.Description = "Now that you have a source of light you are able to see the item that you kicked when you initially came into the room and it's a key!";
        Look();
      }
      if (CurrentRoom.Name == "DarkRoom" && gameItem.Name == "torch")
      {
        CurrentRoom.Description = "You now have a source of light and you notice that there's a door in the room. You check the door and it appears to be locked. Do you have the key?";
        Look();
      }
      if (CurrentRoom.Name == "CrossRoads" && gameItem.Name == "key")
      {
        CurrentRoom.Exits["south"].Locked = false;
        Console.WriteLine("You have unlocked the southern exit.");
      }
      if (CurrentRoom.Name == "DarkRoom" && gameItem.Name == "key")
      {
        CurrentRoom.Exits["east"].Locked = false;
        Console.WriteLine("You have unlocked the eastern exit.");
      }
      if (CurrentRoom.Name == "ClosingRoom" && gameItem.Name == "rope")
      {
        CurrentRoom.Exits["east"].Locked = false;
        CurrentRoom.Exits["west"].Locked = false;
        Console.WriteLine("You successfully lassoed the lever. The walls push back and reveal a door to the east and a door to the west.");
      }
      if (CurrentRoom.Name == "BananaDoor" && gameItem.Name == "banana")
      {
        CurrentRoom.Exits["north"].Locked = false;
        Console.WriteLine("You put the banana in the crescent shape on the wall and the door retracts. You can now enter the room to the north.");
      }
    }


    public void Go(string direction)
    {
      if (!CurrentRoom.Exits.ContainsKey(direction))
      {
        System.Console.WriteLine("You ran into the wall. Nice one.");
        return;
      };
      if (!CurrentRoom.Exits[direction].Locked == false)
      {
        System.Console.WriteLine("That door is locked");
        return;
      }
      CurrentRoom = CurrentRoom.Exits[direction];
      Console.Clear();
      Look();
      // System.Console.Write("\nHow Will you proceed?");
    }
  }
}



