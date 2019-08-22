using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


public class Hacker : MonoBehaviour
{

    //Game states
    int Level=0;
    enum screen {MainMenu,Guessing,Win };
    screen CurrentScreen = screen.MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenuScreen("Hello all mighty hacker");
    }

    void ShowMainMenuScreen (string Greeting)
    {
        CurrentScreen = screen.MainMenu;

        Terminal.ClearScreen();
        Terminal.WriteLine(Greeting + "\nChoose a place where to hack:");
        Terminal.WriteLine("Press 1 for McDonalds");
        Terminal.WriteLine("Press 2 for Sony");
        Terminal.WriteLine("Press 3 for White house office");
        Terminal.WriteLine("Enter your selection:");
    }

    void ShowGuessingScreen()
    {
        CurrentScreen = screen.Guessing;

        Terminal.ClearScreen();
        Terminal.WriteLine("You selected level " + Level);
        Terminal.WriteLine("Enter password:");

    }
    void ShowWinScreen()
    {
        CurrentScreen = screen.Win;

        Terminal.ClearScreen();
        Terminal.WriteLine("Access granted");
    }

    void OnUserInput(string input)
    {
        print("The user typed " + input);
        switch (CurrentScreen)
        {
            case screen.MainMenu:
                MainMenuInputHandler(input);
                break;
            case screen.Guessing:
                GuessingInputHandler(input);
                break;
            case screen.Win:
                WinInputHandler(input);
                break;
        }
        
            
        

    }

     void WinInputHandler(string InputInWin)
    {
        if (Regex.IsMatch(InputInWin, "menu", RegexOptions.IgnoreCase)) ShowMainMenuScreen("Welcome back");
    }

     void GuessingInputHandler(string InputInGuessing)
    {
        
        if (Regex.IsMatch(InputInGuessing, "menu", RegexOptions.IgnoreCase)) ShowMainMenuScreen("Welcome back");
        else
        {
            switch (Level)
            {
                case 1:
                    if (InputInGuessing == "Burger") ShowWinScreen();

                    else Terminal.WriteLine("Access denied");
                    
                    break;
                case 2:
                    if (InputInGuessing == "Technology") ShowWinScreen();

                    else Terminal.WriteLine("Access denied");

                    break;
            }
        }
    }

     void MainMenuInputHandler(string InputInMainMenu)
    {
       switch (InputInMainMenu)
        {
            case "1":
            case "2":
            case "3":
                Int32.TryParse(InputInMainMenu, out Level);
                ShowGuessingScreen();
                break;
            case "007":
                ShowMainMenuScreen("Welcome back Mr. Bond");
                break;
            case "666":
                Terminal.WriteLine("Too hot");
                break;
            case "3.3.":
                Terminal.WriteLine("Happy Birthday");
                break;
            case "69":
                Terminal.WriteLine("Enjoy");
                break;
            default:
                break;                
       }
    }
}
