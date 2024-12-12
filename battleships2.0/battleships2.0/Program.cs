using battleships2._0;
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
        int x, y;
        static int bomb = 2, wideShot = 2, longShot = 2, airStrike = 2;
        static List<string> usedShipsP = new List<string>();
        static List<int> usedShipsC = new List<int>();
        static void SetArrayToDefault(int[,] array2D)
        {

            for (int i = 1; i < array2D.GetLength(0) + 1; i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i - 1, j] = 0;
                }

            }


        }//**
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
        }//
        static int[] GetCoordinates(string coordinates)
        {
            int[] output = new int[2];
            int x;
            int y;
            coordinates = coordinates.ToUpper();
            char columnLetter = coordinates[0];
            char rowNumber = coordinates[1];
            while (true)
            {
                
                if (coordinates.Length != 2 || columnLetter < 'A' || columnLetter > 'J' || rowNumber < '1' || rowNumber > '9')
                { 
                    if(coordinates.Length == 3 && (columnLetter < 'A' || columnLetter > 'J'))
                    {
                        rowNumber = coordinates[1];
                        char secondRowNumber = coordinates[2];
                        if (secondRowNumber == 0 && rowNumber == 1)
                        {
                            x = columnLetter - 'A' + 1;
                            y = 10;
                            output[0] = x - 1;
                            output[1] = y - 1;
                            return output;
                        }
                        else { }
                        
                    }
                    Console.WriteLine("brooo what, repeat input\n");
                    coordinates = Console.ReadLine().ToUpper();
                    columnLetter = coordinates[0];
                    rowNumber = coordinates[1];
                }
                else
                {
                    break;
                }
            }
            x = columnLetter - 'A' + 1;
            y = int.Parse(rowNumber.ToString());
            output[0] = x - 1;
            output[1] = y - 1;
            return output;
        }//**
        static void Print2DArray(int[,] arrayToPrint)
        {
            Console.Write("  1 2 3 4 5 6 7 8 9 10\n");
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                Console.Write((char)(i+65) + " ");



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
        }//**
        static void Print2DArrayWithoutShips(int[,] arrayToPrint)
        {
            Console.Write("  1 2 3 4 5 6 7 8 9 10\n");
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
        }//**

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
                if(CheckShipPlacementAvailability(arraytochange, coordinates, userInput, GetShipLenght(userInput2)) == true)
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

        }//
        static int[,] ComputerShipPlacement(int[,] Arraytochange, int n)
        {
            Random rng = new Random();
            int x, y;
            int shipChoice;



            while (true)
            {
                shipChoice = rng.Next(1, 6);
                
                if (usedShipsC.Contains(shipChoice))
                {
                    Console.WriteLine("Ship has been already placed");
                }
                else
                {
                    Console.WriteLine("computer is choosing...");
                    int verticalOrHorizontal = rng.Next(0, 2);
                    if (verticalOrHorizontal == 0)
                    {
                        usedShipsC.Add(shipChoice);
                        x = rng.Next(0, 10 - shipChoice);
                        y = rng.Next(0, 10);
                        for (int j = 0; j < shipChoice; j++)
                        {
                            Arraytochange[x + j, y] = 1;
                        }
                        return Arraytochange;
                    }
                    else
                    {
                        usedShipsC.Add(shipChoice);
                        x = rng.Next(0, 10);
                        y = rng.Next(0, 10 - shipChoice);
                        for (int j = 0; j < shipChoice; j++)
                        {
                            Arraytochange[x, y + j] = 1;
                        }
                        
                    }
                    break;
                }
            }
            return Arraytochange;
        }
        static bool CheckShipPlacementAvailability(int[,] battleField, int[] coordinates, string vh, int l)
        {
            bool available = true;
            for (int i = 0; i < l; i++)
            {
                switch (vh)
                {
                    case "v":
                        if (battleField[coordinates[0] + i, coordinates[1]] == 0 && (coordinates[0] + l) < 11)
                        {
                            available = true;
                        }
                        else { return false; }
                        break;
                    case "h":
                        if (battleField[coordinates[0], coordinates[1] + i] == 0 && (coordinates[1] + l) < 11)
                        {
                            available = true;
                        }
                        else { return false; }
                        break;
                    default:
                        return false;
                }
            }
            return available;
        }//**
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
        }//**
        static int GetBattleFieldTargetState(int[,] arrayRN, int targetX, int targetY)
        {
            switch(arrayRN[targetX, targetY])
            {
                case 1: return 3;
                case 2: return 2;
                case 3: return 3;
                default: return 2;
            }
        }//**
        static int[,] ComputerMove(int[,] arrayToChange)
        {  
                Random rng = new Random();
            int x = rng.Next(0, 10);
            int y = rng.Next(0, 10);
            int computerChoice = rng.Next(1, 2);
            switch (computerChoice)
            {
                case 1:
                    arrayToChange[x, y] = GetBattleFieldTargetState(arrayToChange, x, y);
                    return arrayToChange;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            arrayToChange[x + i - 1, y + j - 1] = GetBattleFieldTargetState(arrayToChange, x + i - 1, y + j - 1);
                        }
                    }
                    return arrayToChange;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        arrayToChange[x + i - 1, y] = GetBattleFieldTargetState(arrayToChange, x + i - 1, y);
                    }
                    return arrayToChange;
                case 4:
                    for (int j = 0; j < 3; j++)
                    {
                        arrayToChange[x, y + j - 1] = GetBattleFieldTargetState(arrayToChange, x, y + j - 1);
                    }
                    return arrayToChange;
                default:
                    for (int i = 0; i < 5; i++)
                    {
                        arrayToChange[x, y] = GetBattleFieldTargetState(arrayToChange, x, y);
                        x = rng.Next(0, 10);
                        y = rng.Next(0, 10);
                    }
                    return arrayToChange;
            }
                



                
                   
                    
                    
            


        }//*
        static int[,] PlayerMove(int[,] arrayToChange)
        {
            string userInput2;
            while (true)
            {
                if(userInput == "n"
            }
            Console.WriteLine("Choose with which ammo will you shoot \n\nn for normal\nb for bomb\nw for wideshot\nl for longshot\na for airstrike");
            string userInput = Console.ReadLine();
            int[] coordinates = new int[2];
            while (true)
            {
                if (userInput == "n" || userInput == "b" || userInput == "w" || userInput == "l")
                {
                    
                    
                    while (true)
                    {
                        Console.WriteLine("now choose where do you want to shoot");
                        userInput2 = Console.ReadLine();
                        coordinates = GetCoordinates(userInput2);
                        if (arrayToChange[coordinates[0], coordinates[1]] == 3 || arrayToChange[coordinates[0], coordinates[1]] == 2)
                        {
                            Console.WriteLine("you have already shot at this place, choose different location");
                            userInput2 = Console.ReadLine();
                            coordinates = GetCoordinates(userInput2);
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



                else if (userInput == "a")
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
                else { Console.WriteLine("Wrong user input"); }
            }       
        } //**
        
        static void Main(string[] args)
        {

            /*Battleship battleShip1 = new Battleship();
            battleShip1.shipType = "Aircraft Carrier";
            battleShip1.shipLenght = 5;
            Battleship battleShip2 = new Battleship();
            battleShip1.shipType = "Cruiser";
            battleShip1.shipLenght = 5;
            Battleship battleShip3 = new Battleship();
            battleShip1.shipType = "Battleship";
            battleShip1.shipLenght = 5;
            Battleship battleShip4 = new Battleship();
            battleShip1.shipType = "Submarine";
            battleShip1.shipLenght = 5;
            Battleship battleShip5 = new Battleship();
            battleShip1.shipType = "Destroyer";
            battleShip1.shipLenght = 5;*/
            int[,] playerBattlefield = new int[10, 10];
            int[,] computerBattlefield = new int[10, 10];
            SetArrayToDefault(computerBattlefield);
            SetArrayToDefault(playerBattlefield);

            
            Console.WriteLine("!!Welcome Player!!\n\n\nTime to place your ships");
            for(int i = 0; i < 5; i++)
            {
                Print2DArray(playerBattlefield);
                playerBattlefield = PlayerShipPlacement(playerBattlefield, i);
                
                Console.Clear();
            }
            Print2DArray(playerBattlefield);
            Console.ReadKey();
            Console.WriteLine("now its time for computer to place it's ship");
            for (int i = 0; i < 5; i++)
            {
                computerBattlefield = ComputerShipPlacement(computerBattlefield, i);
                Print2DArray(computerBattlefield);
                Console.ReadKey();
                Console.Clear();

                
            }
            Print2DArray(computerBattlefield);
            Console.ReadKey();
            Console.WriteLine("now it is time to fight");
            while (true/*CheckIfThereAreShipsRemaining(computerBattlefield) == true && CheckIfThereAreShipsRemaining(playerBattlefield) == true*/)
            {
                Console.Clear();
                PlayerMove(computerBattlefield);
                Print2DArrayWithoutShips(computerBattlefield);
                ComputerMove(playerBattlefield);
                Console.WriteLine("\n\n\n");
                Print2DArrayWithoutShips(playerBattlefield);
                Console.ReadKey();
                
            }
            if(CheckIfThereAreShipsRemaining(computerBattlefield) == false)
            {
                Console.WriteLine("VAMOOS");
            }
            else
            {
                Console.WriteLine("GG WP, better luck next time");
            }


            /*int water = 0;
            int ship = 1;
            int miss = 2;
            int hit = 3;
            bool repeat = true;
            string userInput;
            string[] coordinates;
            int x = 0;
            int y = 0;*/



            Console.ReadKey();
            
        }

            


        /*static void Main(string[] args)
        {
            
            
           

            
            //Console.WriteLine("Choose your difficulty\n1) easy\n2) medium\n3) impossible");
            //while (repeat == true)
            //{
               // string difficulty = Console.ReadLine();
               // switch (difficulty)
                //{
                    //case "easy":
                       // Console.WriteLine("Great choice, now place your ships");
                        Console.WriteLine("Which ship do you want to place?");
                        userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "carrier":
                                
                                

                                    break;
                        }

                        Print2DArray(playerBattlefield);
                        /*break;
                    case "medium":
                        Print2DArray(playerBattlefield);
                        break;
                    case "impossible":
                        Print2DArray(playerBattlefield);
                        break;
                    default:
                        Console.Write("wrong user input");
                        break;
                }
                

            }


            Console.ReadKey();



        }*/
    }
}
