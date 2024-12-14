
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static int x = 0, y = 0;
        static int bomb = 2, wideShot = 2, longShot = 2, airStrike = 2;
        static List<string> usedShipsP = new List<string>();
        static List<int> usedShipsC = new List<int>();
        static int[] computerLastShotCoords = new int[2];
        static List<int[]> preferedTiles = new List<int[]>();
        static int scanner = 1;
        static void Scanner(int[,] arrayBeingScanned, int[] coordinates)
        {
            Console.Write("  1 2 3 4 5 6 7 8 9 10\n");

            for (int i = 0; i < arrayBeingScanned.GetLength(0); i++)
            {
                Console.Write((char)(i + 65) + " ");

                for (int j = 0; j < arrayBeingScanned.GetLength(1); j++)
                {

                    if (i >= coordinates[0] - 1 && i <= coordinates[0] + 1 && j >= coordinates[1] - 1 && j <= coordinates[1] + 1)
                        
                    {
                        if (arrayBeingScanned[i, j] == 1)
                        {
                            Console.Write("l ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    else
                    {
                        switch (arrayBeingScanned[i, j])
                        {
                            case 0:
                                Console.Write("■ ");
                                break;
                            case 1:
                                Console.Write("■ ");
                                break;
                            case 2:
                                Console.Write("M ");
                                break;
                            case 3:
                                Console.Write("X ");
                                break;
                        }
                    }
                }
                Console.Write("\n");
            }
        }

        static void SetArrayToDefault(int[,] array2D)
        {

            for (int i = 1; i < array2D.GetLength(0) + 1; i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i - 1, j] = 0;
                }
            }
        }
        static bool CheckIfThereAreShipsRemaining(int[,] array2D)
        {
            int shipTileCount = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i, j] == 1)
                    {
                        shipTileCount++;
                    }
                }
            }
            if (shipTileCount > 0) { return true; }
            else { return false; }
        }
        static bool ValidCoordinates (string coordinates)
        {
            if (coordinates.Length < 2 && coordinates.Length > 3)
            {
                Console.WriteLine("invalid input, please repeat coordinates");
                return false;
            }
            if (coordinates[0] < 'A' || coordinates[0] > 'J')
            {
                return false;
            }
            for(int i = 1; i < coordinates.Length; i++)
            {
                if (coordinates[i] < '0' && coordinates[i] > '9')
                {
                    return false;
                }    
            }
            return true;
        }
        static int[] GetCoordinates(string coordinates)
        {
            coordinates = coordinates.ToUpper();
            int[] output = new int[2];
            int x = 0, y = 0;
            while (ValidCoordinates(coordinates) == false)
            {
                Console.WriteLine("invalid input, please repeat coordinates");
                coordinates = Console.ReadLine().ToUpper();
            }
            switch (coordinates.Length)
            {
                case 2:
                    x = coordinates[0] - 'A' + 1;
                    y = int.Parse(coordinates[1].ToString());
                    break;
                case 3:
                    x = coordinates[0] - 'A' + 1;
                    y = int.Parse(coordinates[1].ToString() + coordinates[2].ToString());;
                    break;
            }
            
            output[0] = x - 1;
            output[1] = y - 1;
            return output;
        }
        static void Print2DArray(int[,] arrayToPrint)
        {
            Console.Write("  1 2 3 4 5 6 7 8 9 10\n");
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                Console.Write((char)(i + 65) + " ");
                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {
                    switch (arrayToPrint[i, j])
                    {
                        case 0:
                            Console.Write("■ ");
                            break;
                        case 1:
                            Console.Write("L ");
                            break;
                        case 2:
                            Console.Write("M ");
                            break;
                        case 3:
                            Console.Write("X ");
                            break;
                    }

                }

                Console.Write("\n");
            }
        }
        static void Print2DArrayWithoutShips(int[,] arrayToPrint)
        {
            Console.Write("  1 2 3 4 5 6 7 8 9 10\n");
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                Console.Write((char)(i + 65) + " ");



                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {

                    switch (arrayToPrint[i, j])
                    {
                        case 0:
                            Console.Write("■ ");
                            break;
                        case 1:
                            Console.Write("■ ");
                            break;
                        case 2:
                            Console.Write("M ");
                            break;
                        case 3:
                            Console.Write("X ");
                            break;
                    }

                }

                Console.Write("\n");
            }
        }
        static int GetAmmoCount(string ammoType)
        {
            switch (ammoType)
            {
                case "n": return 999999999;
                case "a": return airStrike;
                case "b": return bomb;
                case "l": return longShot;
                case "w": return wideShot;
                default: return 77;
            }
        }
        static int[,] PlayerShipPlacement(int[,] arraytochange, int n)
        {


            string userInput;
            string userInput2;
            while (true)
            {
                Console.WriteLine("Choose which ship do you want to place\nA for Aircraft Carrier\nC for Cruiser\nB for Battleship\nS for submarine\nD for destroyer");
                while (true)
                {

                    userInput2 = Console.ReadLine().ToLower();
                    if (userInput2 == "a" || userInput2 == "c" || userInput2 == "b" || userInput2 == "s" || userInput2 == "d")
                    {
                        if (usedShipsP.Contains(userInput2)) { Console.WriteLine("this ship has been already placed, pick a different ship"); }
                        else { break; }
                    }
                    else
                    {
                        Console.WriteLine("wrong user input");
                    }
                }
                usedShipsP.Add(userInput2);
                Console.WriteLine("Choose your starting coordinates (there will be placed the topleft of your ship) for example B6");
                userInput = Console.ReadLine();
                int[] coordinates = GetCoordinates(userInput);

                Console.WriteLine("now choose wether you would like your ship to be horizontaly or veritaly (v/h)");
                userInput = Console.ReadLine().ToLower();
                if (CheckShipPlacementAvailability(arraytochange, coordinates, userInput, GetShipLenght(userInput2)) == true)
                {
                    if (userInput == "v")
                    {
                        for (int i = 0; i < GetShipLenght(userInput2); i++)
                        {
                            arraytochange[coordinates[0] + i, coordinates[1]] = 1;
                        }
                    }
                    else if (userInput == "h")
                    {
                        for (int j = 0; j < GetShipLenght(userInput2); j++)
                        {
                            arraytochange[coordinates[0], coordinates[1] + j] = 1;
                        }
                    }
                    return arraytochange;
                }
                else { Console.WriteLine("cannot place ship like this, please try again"); }
                usedShipsP.RemoveAt(n);
            }

        }
        static int[,] ComputerShipPlacement(int[,] Arraytochange, int n)
        {
            {
                Random rng = new Random();
                int x, y;
                int shipChoice;
                string vh;
                int[] shipLengths = new int[] { 5, 4, 3, 3, 2 };
                while (true)
                {
                    shipChoice = rng.Next(0, 5);

                    if (usedShipsC.Contains(shipChoice))
                    {
                        Console.WriteLine("Ship has already been placed");
                    }
                    else
                    {
                        Console.WriteLine("Computer is choosing...");
                        vh = rng.Next(0, 2) == 0 ? "v" : "h";

                        bool placementFound = false;
                        while (!placementFound)
                        {
                            if (vh == "v")
                            {
                                x = rng.Next(0, 10 - shipLengths[shipChoice]);
                                y = rng.Next(0, 10);

                                if (CheckShipPlacementAvailability(Arraytochange, new int[] { x, y }, "v", shipLengths[shipChoice]))
                                {
                                    for (int j = 0; j < shipLengths[shipChoice]; j++)
                                    {
                                        Arraytochange[x + j, y] = 1;
                                    }
                                    placementFound = true;
                                }
                            }
                            else
                            {
                                x = rng.Next(0, 10);
                                y = rng.Next(0, 10 - shipLengths[shipChoice]);


                                if (CheckShipPlacementAvailability(Arraytochange, new int[] { x, y }, "h", shipLengths[shipChoice]))
                                {
                                    for (int j = 0; j < shipLengths[shipChoice]; j++)
                                    {
                                        Arraytochange[x, y + j] = 1;
                                    }
                                    placementFound = true;
                                }
                            }
                        }
                        usedShipsC.Add(shipChoice);
                        break; 
                    }
                }
                return Arraytochange;
            }
        }
        static bool CheckShipPlacementAvailability(int[,] battleField, int[] coordinates, string vh, int l)
        {
            bool available = true;
            if (vh == "v")
            {
                if (coordinates[0] + l > 10) return false; 
                for (int i = 0; i < l; i++)
                {
                    if (coordinates[0] + i < 0 || coordinates[0] + i >= 10 || battleField[coordinates[0] + i, coordinates[1]] != 0)
                    {
                        return false;
                    }
                    for (int j = -1; j <= 1; j++)
                    {

                        if (coordinates[0] + i + j >= 0 && coordinates[0] + i + j < 10)
                        {

                            if (coordinates[1] - 1 >= 0 && battleField[coordinates[0] + i + j, coordinates[1] - 1] != 0 ||
                                coordinates[1] + 1 < 10 && battleField[coordinates[0] + i + j, coordinates[1] + 1] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else if (vh == "h")
            {
                if (coordinates[1] + l > 10) return false;
                for (int i = 0; i < l; i++)
                {
                    if (coordinates[1] + i < 0 || coordinates[1] + i >= 10 || battleField[coordinates[0], coordinates[1] + i] != 0)
                    {
                        return false;
                    }
                    for (int j = -1; j <= 1; j++)
                    {
                        if (coordinates[1] + i + j >= 0 && coordinates[1] + i + j < 10)
                        {
                            if (coordinates[0] - 1 >= 0 && battleField[coordinates[0] - 1, coordinates[1] + i + j] != 0 ||
                                coordinates[0] + 1 < 10 && battleField[coordinates[0] + 1, coordinates[1] + i + j] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                return false; 
            }
            return available;
    }
        static int GetShipLenght(string shipName)
        {

            int shipLenght = 0;
            switch (shipName)
            {
                case "a":
                    shipLenght = 5;
                    break;
                case "c":
                    shipLenght = 4;
                    break;
                case "b":
                    shipLenght = 3;
                    break;
                case "s":
                    shipLenght = 3;
                    break;
                case "d":
                    shipLenght = 2;
                    break;
            }
            return shipLenght;
        }
        static int GetBattleFieldTargetState(int[,] arrayRN, int targetX, int targetY)
        {
            switch (arrayRN[targetX, targetY])
            {
                case 1: return 3;
                case 2: return 2;
                case 3: return 3;
                default: return 2;
            }
        }
        static int[,] ComputerMove(int[,] arrayToChange)// computer move
        {
            Random rng = new Random();

            computerLastShotCoords[0] = x; computerLastShotCoords[1] = y;
            if (arrayToChange[computerLastShotCoords[0], computerLastShotCoords[1]] == 3)
            {
                arrayToChange[computerLastShotCoords[0], computerLastShotCoords[1]] = GetBattleFieldTargetState(arrayToChange, computerLastShotCoords[0], computerLastShotCoords[1]);
                return arrayToChange;
            }
            else
            {
                x = rng.Next(0, 10);
                y = rng.Next(0, 10);
                int computerChoice = rng.Next(1, 51);
                switch (computerChoice)
                {
                    default:
                        arrayToChange[x, y] = GetBattleFieldTargetState(arrayToChange, x, y);
                        return arrayToChange;
                    case 1:
                        x = rng.Next(1, 9);
                        y = rng.Next(1, 9);
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                arrayToChange[x + i - 1, y + j - 1] = GetBattleFieldTargetState(arrayToChange, x + i - 1, y + j - 1);
                            }
                        }
                        return arrayToChange;
                    case 2:
                        x = rng.Next(1, 9);
                        for (int i = 0; i < 3; i++)
                        {
                            arrayToChange[x + i - 1, y] = GetBattleFieldTargetState(arrayToChange, x + i - 1, y);
                        }
                        return arrayToChange;
                    case 3:
                        y = rng.Next(1, 9);
                        for (int j = 0; j < 3; j++)
                        {
                            arrayToChange[x, y + j - 1] = GetBattleFieldTargetState(arrayToChange, x, y + j - 1);
                        }
                        return arrayToChange;
                    case 4:
                        for (int i = 0; i < 5; i++)
                        {
                            arrayToChange[x, y] = GetBattleFieldTargetState(arrayToChange, x, y);
                            x = rng.Next(0, 10);
                            y = rng.Next(0, 10);
                        }
                        return arrayToChange;
                }
            }
        }
        static int[,] PlayerMove(int[,] arrayToChange)
        {
            bool validTarget = false;
            string userInput2;
            string userInput = "shoot";

            
            if(scanner > 0)
            {
                Console.WriteLine("player's turn : choose wether you want to user scanner or shoot (scan/shoot)\n");
                userInput = Console.ReadLine().ToLower();
            }         
            while (true)
            {  
                if(userInput == "scan")
                {
                    scanner--;
                    int[] coordinates = new int[2];
                    Console.WriteLine("Choose where do you want to scan");
                    userInput2 = Console.ReadLine();
                    coordinates = GetCoordinates(userInput2);
                    Scanner(arrayToChange, coordinates);
                    Console.ReadKey();
                    return arrayToChange;
                    
                }
                else if (userInput == "shoot")
                {
                    while (true)
                    {
                        Console.WriteLine("Choose with which ammo will you shoot \n\nn for normal (remaining shots: >9999)\nb for bomb (remaining shots :" + bomb + ")\nw for wideshot (remaining shots :" + wideShot + ")\nl for longshot (remaining shots :" + longShot + ")\na for airstrike (remaining shots :" + airStrike + ")");
                        userInput = Console.ReadLine().ToLower();
                        int[] coordinates = new int[2];

                        if ((userInput == "n" || userInput == "b" || userInput == "w" || userInput == "l") && GetAmmoCount(userInput) > 0)
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose where do you want to shoot");
                                userInput2 = Console.ReadLine();
                                coordinates = GetCoordinates(userInput2);
                                switch (userInput)
                                {
                                    case "b": if (coordinates[0] < 9 && coordinates[0] > 1 && coordinates[1] < 9 && coordinates[1] > 0) { validTarget = true; } else { validTarget = false; } break;
                                    case "l": if (coordinates[0] < 9 && coordinates[0] > 1) { validTarget = true; } else { validTarget = false; } break;
                                    case "w": if (coordinates[1] < 9 && coordinates[1] > 1) { validTarget = true; } else { validTarget = false; } break;
                                    default: validTarget = true; break;
                                }
                                if (arrayToChange[coordinates[0], coordinates[1]] == 3 || arrayToChange[coordinates[0], coordinates[1]] == 2 || validTarget == false)
                                {
                                    Console.WriteLine("you either have already shot at this place, or you cannot shoot here with this kind of ammo");
                                }
                                else { break; }

                            }
                            switch (userInput)
                            {
                                case "n":

                                    arrayToChange[coordinates[0], coordinates[1]] = GetBattleFieldTargetState(arrayToChange, coordinates[0], coordinates[1]);
                                    return arrayToChange;
                                case "b":
                                    coordinates = GetCoordinates(userInput2);
                                    for (int i = 0; i < 3; i++)
                                    {
                                        for (int j = 0; j < 3; j++)
                                        {
                                            arrayToChange[coordinates[0] + i - 1, coordinates[1] + j - 1] = GetBattleFieldTargetState(arrayToChange, coordinates[0] + i - 1, coordinates[1] + j - 1);
                                        }
                                    }
                                    bomb--;
                                    return arrayToChange;
                                case "l":
                                    coordinates = GetCoordinates(userInput2);
                                    for (int i = 0; i < 3; i++)
                                    {
                                        arrayToChange[coordinates[0] + i - 1, coordinates[1]] = GetBattleFieldTargetState(arrayToChange, coordinates[0] + i - 1, coordinates[1]);
                                    }
                                    longShot--;
                                    return arrayToChange;
                                case "w":
                                    coordinates = GetCoordinates(userInput2);
                                    for (int j = 0; j < 3; j++)
                                    {
                                        arrayToChange[coordinates[0], coordinates[1] + j - 1] = GetBattleFieldTargetState(arrayToChange, coordinates[0], coordinates[1] + j - 1);
                                    }
                                    wideShot--;
                                    return arrayToChange;
                            }
                        }



                        else if (userInput == "a" && GetAmmoCount(userInput) > 0)
                        {
                            Random rng = new Random();
                            for (int i = 0; i < 5; i++)
                            {
                                int randomX = rng.Next(0, 10);
                                int randomY = rng.Next(0, 10);
                                arrayToChange[randomX, randomY] = GetBattleFieldTargetState(arrayToChange, randomX, randomY);
                            }
                            airStrike--;
                            return arrayToChange;
                        }
                        else
                        {
                            if (userInput != "a" && userInput != "n" && userInput != "b" && userInput != "l" && userInput != "w")
                            {
                                Console.WriteLine("Wrong user input");
                            }
                            else { Console.WriteLine("not enogh ammo"); }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("wrong user Input");
                }
            }
        } 

        static void Main(string[] args)
        {
            bool playAgain = true;
            int turn = 0;
            int[,] playerBattlefield = new int[10, 10];
            int[,] computerBattlefield = new int[10, 10];
            while(playAgain == true)
            {
                SetArrayToDefault(computerBattlefield);
                SetArrayToDefault(playerBattlefield);


                Console.WriteLine("!!Welcome Player!!\n\n\nTime to place your ships");
                for (int i = 0; i < 5; i++)// placing ships for player
                {
                    Print2DArray(playerBattlefield);
                    playerBattlefield = PlayerShipPlacement(playerBattlefield, i);
                    Console.Clear();
                }
                Print2DArray(playerBattlefield);
                Console.ReadKey();
                Console.WriteLine("now its time for computer to place it's ship");
                Console.ReadKey();
                for (int i = 0; i < 5; i++)// placing ships for computer
                {
                    computerBattlefield = ComputerShipPlacement(computerBattlefield, i);
                    Console.Clear();
                }

                Console.WriteLine("now it is time to fight");
                Console.ReadKey();
                while (CheckIfThereAreShipsRemaining(computerBattlefield) == true && CheckIfThereAreShipsRemaining(playerBattlefield) == true)
                {
                    Console.Clear();
                    PlayerMove(computerBattlefield);
                    Console.WriteLine("computer battlefield:\n");
                    Print2DArrayWithoutShips(computerBattlefield);
                    ComputerMove(playerBattlefield);
                    Console.WriteLine("\n\n player battlefield:\n");
                    Print2DArray(playerBattlefield);
                    Console.ReadKey();
                    turn++;
                    if (turn % 30 == 0)// given player the ability to scan every 30 turns
                    {
                        scanner++;
                    }
                }
                if (CheckIfThereAreShipsRemaining(computerBattlefield) == false)
                {
                    while (true)
                    {
                        Console.WriteLine("\n\nVAMOOS, well played, do you want to play again (y/n)");
                        string userInput = Console.ReadLine();
                        if (userInput == "y")
                        {
                            Console.WriteLine("vamos");
                            playAgain = true;
                        }
                        else if (userInput == "n")
                        {
                            Console.WriteLine("see you next time");
                        }
                        else { Console.WriteLine("wrong user input"); }
                    }
                    
                }
                else
                {
                    
                    while (true)
                    {
                        Console.WriteLine("GG WP, better luck next time, do you want to play again (y/n)");
                        string userInput = Console.ReadLine();
                        if (userInput == "y")
                        {
                            Console.WriteLine("vamos");
                            playAgain = true;
                        }
                        else if (userInput == "n")
                        {
                            Console.WriteLine("see you next time");
                        }
                        else { Console.WriteLine("wrong user input"); }
                    }
                }
            }
           
            Console.ReadKey();
        }
    }
}