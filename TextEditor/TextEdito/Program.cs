using System;
using System.IO;
namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("");
            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            //Limpa o console, exibe na tela o texto e recebe um input na variável "path" que será o diretório
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            //Abre o diretório indicado no "path", Lê o arquivo e fecha o diretório
            using(var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            //Limpa o console e exibe na tela o texto
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("");

            //String vazia 
            string text = "";

            //Recebe um texto até que a tecla ESC seja pressionada
            do{
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            //Chama a função "Salvar" e passa a informação do "text"
            Salvar(text);
        }
    
        static void Salvar(string text)
        {
            //Limpa o console, exibe na tela o texto e recebe um input na variável "path" que será o diretório
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            //Abre o diretório indicado no "path", salva o arquivo "text" e fecha o diretório
            using(var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            //Exibe na tela que o arquivo foi salvo, exibe o diretório e retorna para o menu
            Console.WriteLine($"Arquivo {path} foi salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}