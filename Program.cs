﻿using System;
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
        case 2: Editar(); break;
        default: Menu(); break;
      }
    }

    static void Abrir()
    {
      Console.Clear();
      Console.WriteLine("Qual o caminho do arquivo?");
      var path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        var text = file.ReadToEnd();
        Console.WriteLine(text);
      }

      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    static void Editar()
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
      while (Console.ReadKey().Key != ConsoleKey.Escape);

      Salvar(text);
    }

    static void Salvar(string text)
    {
      Console.Clear();
      Console.WriteLine("Qual caminho para salvar o arquivo?");
      var path = Console.ReadLine();

      using (var file = new StreamWriter(path)) // using para abrir e fechar o arquivo automaticamente
      {
        file.Write(text);
      }

      Console.WriteLine($"Arquivo {path} salvo com sucesso!");
      Console.ReadLine();
      Menu();
    }

  }
}