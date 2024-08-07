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
      Console.WriteLine("2 - Criar arquibo");
      Console.WriteLine("0 - Sair");

      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Criar(); break;
        default: Menu(); break;
      }
    }

    static void Abrir()
    {
      Console.Clear();
      Console.WriteLine("Qual o caminho do arquivo?");
      var path = Console.ReadLine();

      using (var file = new StreamReader(path)) // StreamReader para ler um arquivo
      {
        var text = file.ReadToEnd(); // ReadToEnd para ler o arquivo até o final
        Console.WriteLine(text);
      }

      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    static void Criar()
    {
      Console.Clear();
      Console.WriteLine("Digite o seu texto abaixo (ESC para sair)");
      Console.WriteLine("-----------------------");
      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape); // Enquanto a tecla digitada for diferente de ESC, faça...

      Salvar(text);
    }

    static void Salvar(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      using (var file = new StreamWriter(path)) // using para abrir e fechar o arquivo automaticamente | StreamWriter para escrever um arquivo
      {
        file.Write(text); // Write = Escreva
      }

      Console.WriteLine($"Arquivo {path} salvo com sucesso!");
      Console.ReadLine();
      Menu();
    }
  }
}