using System;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SwinAdventure!");

            Console.Write("Tell me your name, weary traveler (Enter your Name) - ");
            string playerName = Console.ReadLine();
            Console.Write("What... exactly are you (Enter your Description) - ");
            string playerDescription = Console.ReadLine();

            Player player = new Player(playerName, playerDescription, 300, 5);
            Enemy wolf = new Enemy(new string[] { "wolf" }, "Wolf", "Savage Beast", 150, 10);

            Location swinburne = new Location(new string[] { "swin", "start" }, "Swinburne University", "The place where it all started", null, null);
            Item gem = new Item(new string[] { "gem", "cleargem" }, "Clear Gem", "Item of Potential");
            Weapon sword = new Weapon(new string[] { "sword", "ironsword" }, "Sword", "Basic iron sword", 140);
            HealingItem goldenapple = new HealingItem(new string[] { "goldenapple" }, "Golden Apple", "Magic Apple", 50);
            HealingItem steak = new HealingItem(new string[] { "steak" }, "Steak", "Juicy Piece of Steak", 50);
            UpgradeItem strengthpotion = new UpgradeItem(new string[] { "strengthpotion" }, "Strength Potion", "'Increase your strength 10 fold!' is written on the label", 100, 20);
            Weapon bladewolf = new Weapon(new string[] { "bladewolf" }, "Blade Wolf", "A blade blessed by the blood of a wolf", 100);

            player.Inventory.Put(gem);
            player.Inventory.Put(sword);
            player.Inventory.Put(steak);
            wolf.Inventory.Put(goldenapple);
            wolf.Inventory.Put(strengthpotion);
            wolf.Inventory.Put(bladewolf);

            Bag backpack = new Bag(new string[] { "backpack", "smallbag" }, "Backpack", "A school bag with adequate space");

            player.Inventory.Put(backpack);

            Item amulet = new Item(new string[] { "amulet", "heirloom" }, "Amulet", "Family heirloom passed on for generations");

            backpack.Inventory.Put(amulet);

            Path staircaseN = new Path(new string[] { "staircaseN", "north" }, swinburne, new Direction[] { Direction.North });
            Location castle = new Location(new string[] { "castle", "right" }, "The Castle", "Dark Structure", staircaseN, null);
            Path staircaseS = new Path(new string[] { "staircaseS", "south" }, castle, new Direction[] { Direction.South});
            swinburne.Path = staircaseS;
            player.Location = castle;


            Item ring = new Item(new string[] { "ring" }, "Ring", "Golden Ring with a diamond");
            Item lightsaber = new Item(new string[] { "lightsaber" }, "Lightsaber", "Plasma Sword");
            swinburne.Inventory.Put(ring);
            swinburne.Inventory.Put(lightsaber);
            swinburne.AddEnemy(wolf);

            while (true)
            {
                Console.Write("Enter a command: ");
                string input = Console.ReadLine();
                string[] command = input.Split(' ');
                MoveCommand moveCommand = new MoveCommand();
                LookCommand lookCommand = new LookCommand();
                TakeCommand takeCommand = new TakeCommand();
                DropCommand dropCommand = new DropCommand();
                AttackCommand attackCommand = new AttackCommand();
                UseCommand useCommand = new UseCommand();
                CommandProcessor commandProcessor = new CommandProcessor(new string[] { }, new Command[] { moveCommand, lookCommand, takeCommand, dropCommand, attackCommand, useCommand });
                string result = commandProcessor.Execute(player, command);
                Console.WriteLine(result);

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine($"Good bye {playerName}, may we meet again");
                    break;
                } else if (player.Health == 0)
                {
                    Console.WriteLine("Game Over! You died...");
                    break;
                }
            }

        }
    }
}