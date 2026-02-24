namespace WordOfTheDay
{
    internal class Program
    {
        static void Main()
        {
            int choice = Menu();
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        // Will create if it doesn't exist or add to existing file
                        AppendToFile();
                        break;
                    case 2:
                        ReadFile();
                        break;
                    case 3:
                        ReadToArray();
                        break;
                    case 4:
                        try
                        {
                            string path = "Word.txt";
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                                Console.WriteLine("File deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("File does not exist.");
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                        break;
                }
                choice = Menu();
            }

        }


        static int Menu()
        {
            Console.WriteLine("Enter your choice:\n1. Add Word\n2. Read All\n" +
                "3. Read Current Word\n4. Delete File\n5. Exit\n");
            int choice = 0;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
            return choice;
        }

        static void AppendToFile()
        {

            bool end = false;
            List<string> defList = new List<string>();
            string word = string.Empty;
            string define = "";
            Console.WriteLine("Word?");
            while (string.IsNullOrEmpty(word))
            {
                word = Console.ReadLine();
                Console.WriteLine("Enter a word");
            }
            word = $"{word}: ";
            while (!end)
            {
                Console.WriteLine("Definition of word?");
                string defWord = Console.ReadLine();
                defList.Add(defWord);

                Console.WriteLine("Add another Definition? [N] to finish");
                if (Console.ReadLine() == "N" || Console.ReadLine() == "n")
                {

                    string newWord = $"\nWord: {word}";
                    for (int i = 0; i < defList.Count; i++)
                    {
                        define = $"{define} " + $"{i + 1}. {defList[i]}";
                    }
                    end = true;
                }
            }

            string path = "Word.txt";
            string newText = $"\n{word}" + $"{define}";


            try
            {
                File.AppendAllText(path, newText);
                Console.WriteLine("Text appended successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return;
        }
        static void ReadFile()
        {
            string path = "Word.txt";
            try
            {
                if (File.Exists(path))
                {
                    string content = File.ReadAllText(path);
                    Console.WriteLine("File Content:\n" + content);
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return;

        }
        static void ReadToArray()
        {
            string path = "Word.txt";
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    string currentWord = lines[lines.Length - 1];
                    Console.WriteLine($"Current word: {currentWord}");

                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}