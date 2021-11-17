using System;
using System.IO;
namespace Alpaca
{
    class Program
    {
        static void Main(string[] args)
        {
            string inPath = @"..\..\..\woerterbuch_E-D-E.csv";
            string text = File.ReadAllText(inPath);
            string[] lines = text.Split("\n");
            int words = lines.Length;
            string[] englisch = new string[words];
            string[] german = new string[words];
            for (int line = 0; line < lines.Length; line++)
            {
                try
                {
                    string[] items = lines[line].Split(',');
                    englisch[line] = items[0].Replace("\"", string.Empty);
                    german[line] = items[1].Replace("\"", string.Empty);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Die Linie {lines[line]} wurde falsch formartiert.");
                }

            }

            string outText = "";


            Random rnd = new Random();

            int tries = 0;
            int allowedTries = 3;
            int points = 0;

            string outPath = @"..\..\..\woerterbuch_E-D-E";
            File.WriteAllText(outPath, outText);
         
            Console.WriteLine("In welcher Sprache wollen Sie abgefragt werden? [1.De|2.En]");
            Console.WriteLine("Um das System zu verlassen schreiben Sie 'exit' Sie sehen auch, dann ihren exit.");
            string userLanguage = Console.ReadLine();        
            if (userLanguage == "De")
            {
                while (true)
                {
                    try
                    {

                        for (int i = 0; i < german.Length; i++)
                        {

                            outText += $"{i},{german[i]},{rnd.Next()}\r\n";
                            Console.WriteLine(german[i]);
                            string userGuess = Console.ReadLine();
                       
                            bool isGameover;
                            int point = 0;
                            int bestTry = 0;
                            string again = "";
                            bool isLoop = true; 
                            if (userGuess == "Ghost")
                            {
                                Console.WriteLine("Geisterspiel");
                                bool isCorrect = true;
                                while (isCorrect)
                                {
                                    isGameover = false;
                                    isLoop = true;
                                    point = 0; 
                                    Random random = new Random();
                                    while (isGameover == false)
                                    {
                                        Console.WriteLine("Hinter einer Tür verbirgt sich ein Geist.\nWelche Tür wählst du? 1, 2 oder 3?");
                                        int door = Convert.ToInt32(Console.ReadLine());
                                        int ghostDoor = random.Next(1, 4);
                                        if (door == ghostDoor)
                                        {
                                            Console.WriteLine("Game over! Hier ist ein Geist!");
                                            Console.WriteLine("Deine Punkte: {0}", point); 
                                            if (point > bestTry)
                                            {
                                                bestTry = point;
                                                Console.WriteLine("Ihr neuer Highscore ist " + bestTry);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Schade kein neuer Highscore.");
                                                Console.WriteLine("Ihr Highscore ist " + bestTry);
                                            }
                                            isGameover = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Kein Geist gefunden!");
                                            point++;
                                        }
                                    }
                                    while (isLoop)
                                    {
                                        Console.WriteLine("Wollen sie nochmal spielen? [j|n]");
                                        again = Console.ReadLine(); 
                                        if (again == "n")
                                        {
                                            isCorrect = false;
                                            isLoop = false;
                                        }
                                        if (again == "j")
                                        { 
                                            isLoop = false; 
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ungültige eingabe.");
                                        }
                                    }
                                }
                            }


                            if (userGuess == "exit")
                            {

                                int highScore = 0;
                                highScore = point;

                                if (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    if (point > highScore) { highScore = point; }
                                    else if (point < highScore && point > 0) { Console.WriteLine("Schade kein neuer High Score."); }
                                    else if (point <= 0) { Console.WriteLine("Schade keine Punkte."); }
                                    Console.WriteLine("Ihr High Score ist " + highScore);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    return;
                                }

                            }

                            if (userGuess == englisch[i])
                            {
                                point++;
                                continue;
                            }
                             if (userGuess != englisch[i])
                            {
                                tries++;
                                continue;
                            }
                             if (tries == allowedTries)
                            {
                                Console.WriteLine($"Das Wort war {englisch[i]}.");
                                continue;
                            }
                          

                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ungültige Eingabe.");
                        return;
                    }

                }
            }
            else if (userLanguage == "En")
                while (true)
                {
                    try
                    {
                        for (int i = 0; i < englisch.Length; i++)
                        {

                            outText += $"{i},{englisch[i]},{rnd.Next()}\r\n";
                            Console.WriteLine(englisch[i]);
                            string userAnswer = Console.ReadLine();
                            if (userAnswer == "exit")
                            {

                                int highScore = 0;
                                highScore = points;

                                if (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    if (points > highScore) { highScore = points; }
                                    else if (points < highScore && points > 0) { Console.WriteLine("Schade kein neuer High Score."); }
                                    else if (points <= 0) { Console.WriteLine("Schade keine Punkte."); }
                                    Console.WriteLine("Ihr High Score ist " + highScore);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    return;
                                }

                            }
                            if (userAnswer == german[i])
                            {
                                points++;
                                continue;
                            }
                            else if (userAnswer != german[i])
                            {
                                tries++;
                                continue;
                            }
                            else if (tries == allowedTries)
                            {
                                Console.WriteLine($"Das Wort war {german[i]}.");
                                continue;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ungültige Eingabe.");
                        break;
                    }
                }
            {
            }
        }
    }
}
