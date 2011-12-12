using System;

class Program
{
    static void Main(string[] args)
    {
        GenerateMeme(args);
    }

    static void GenerateMeme(string[] args)
    {
        var meme = new Meme();
        meme.Generate(args);
        WriteStatus(meme.Status);
    }

    static void WriteStatus(string msg)
    {
        Console.Write(msg);
        Console.ReadLine();
    }
}

