using System;
using System.Text;

namespace EditorHtml
{
    public class Editor
    {
        // Método que exibe o editor e inicia a edição de texto
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("EDITOR MODE");
            Console.WriteLine("----------------------------------------");
            Start();
        }

        // Método que inicia a captura do texto digitado pelo usuário
        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Do you want to save this file? [Y/N]");
            Viewer.Show(file.ToString()); // Mostra o texto capturado no visualizador

            // Verifica se o usuário deseja salvar o arquivo
            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                SaveFile(file.ToString());
            }
            else
            {
                Menu.Show();
            }
        }

        // Método que salva o texto digitado em um arquivo
        public static async Task SaveFile(string text)
        {
            Console.WriteLine("Enter the file path to save:");
            string path = Console.ReadLine();

    try
    {
        await File.WriteAllTextAsync(path, text);
        Console.WriteLine($"File saved successfully at {path}!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving file: {ex.Message}");
    }

    Console.ReadLine();
    Menu.Show();
        }
    }
    
}