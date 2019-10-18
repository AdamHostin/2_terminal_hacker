
using UnityEngine;
using System.Text.RegularExpressions;


public class Hacker : MonoBehaviour
{

    //Game states
    int Level = 0;
    enum screen { MainMenu, Guessing, Win };
    screen CurrentScreen = screen.MainMenu;
    string Password = "";

    //Game passwords
    string[,] LevelPasswords = {{"Burger", "Cheese", "Beef", "Nugets", "Wrap"},
    {"Playstation", "Ratchet", "Spider-man", "Dualshock", "Entertainment"},
    {"President", "Independence", "Weapon", "Government", "Diplomacy"} };
    const int RowDimension = 1;
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
        Terminal.WriteLine("You can get back to menu any time\nby tiping: menu");
        Terminal.WriteLine("Your hint is: " + Password.Anagram());
        Terminal.WriteLine("Enter Password:");

    }

    void ShowWinScreen()
    {
        CurrentScreen = screen.Win;

        Terminal.ClearScreen();
        switch (Level)
        {
            case 1:
                Terminal.WriteLine("Access granted! Good job fat boy!");
                //Ascii art from external sorce: http://www.qqpr.com/ascii-art-food-2.html

                Terminal.WriteLine(@"                       \\|\|//||///
        _..----.._      |\/\||//||||
     .'     o    '.     |||\\|/\\ ||
    /   o       o  \    | './\_/.' |
   |o        o     o|   | .:.  .:. |
   /'-.._o     __.-'\   | :  ::  : |
   \      `````     /   | :  ''  : |
   |``--........--'`|    '.______.'
    \              /
    `'----------'`");
                break;
            case 2:
                //Ascii art from external sorce: http://ascii.co.uk/art/playstation
                Terminal.WriteLine(@"Access granted! Enjoy your game ;)
               _____________________
              |      |,`    `.|     | 
              |     /   SONY  \     |
              | O _ \   />    /   _ |   ______
              |   _(_)'.____.'(_)_  |  (°)__(°)
              [_____ |[=]__[=] | ___]  //    \\");
                break;
            case 3:
                Terminal.WriteLine("Access granted! Wanna build that wall?");
                //Ascii art from external sorce: https://www.oocities.org/spunk1111/july4.htm
                Terminal.WriteLine(@"
9::::=======
|::::=======
|===========
|===========
|
                ");
                break;
            default:
                Debug.LogError("Something went wrong in ShowWinScreen() ");
                break;
        }

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
            default:
                Debug.LogError("Invalid Screen in function OnUserInput");
                break;
        }
        
            
        

    }

    void WinInputHandler(string InputInWin)
    {
        if (Regex.IsMatch(InputInWin, "^menu$", RegexOptions.IgnoreCase)) ShowMainMenuScreen("Welcome back");
    }

    void GuessingInputHandler(string InputInGuessing)
    {

        if (Regex.IsMatch(InputInGuessing, "^menu$", RegexOptions.IgnoreCase)) ShowMainMenuScreen("Welcome back");

        else if (InputInGuessing == Password) ShowWinScreen();

        else PrepareGuessingScreen();
    }

    void MainMenuInputHandler(string InputInMainMenu)
    {
        print("Length of an array" + LevelPasswords.Length);
        switch (InputInMainMenu)
        {
            case "1":
            case "2":
            case "3":
                //Int32.TryParse(InputInMainMenu, out Level);
                Level = int.Parse(InputInMainMenu);
                PrepareGuessingScreen();
                break;
            case "exit":
            case "EXIT":
            case "Exit":
            case "Quit":
            case "quit":
            case "QUIT":
                Terminal.WriteLine("If on a browser close the tab");
                Application.Quit();
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
            default:
                Terminal.WriteLine("Please enter valid level number (1-3)");
                break;                
       }
    }

    void PrepareGuessingScreen()
    {
        Password = LevelPasswords[Level - 1, Random.Range(0, Random.Range(0, LevelPasswords.GetLength(RowDimension)))];
        ShowGuessingScreen();
    }
}
