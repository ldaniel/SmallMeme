using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MemeValidator
{
    public static bool CheckParameters(string[] args)
    {
        bool result = false;

        if (args.Count() == 3)
        {
            bool isFirstParameterValid = CheckFirstParameter(args[0]);
            bool isSecondParameterValid = CheckSecondParameter(args[1]);
            bool isThirdParameterValid = CheckThirdParameter(args[2]);

            result = isFirstParameterValid && isSecondParameterValid && isThirdParameterValid;
        }

        return result;
    }

    private static bool CheckFirstParameter(string firstParameter)
    {
        return CheckMemeType(firstParameter);
    }

    private static bool CheckSecondParameter(string secondParameter)
    {
        return secondParameter.Length > 0;
    }

    private static bool CheckThirdParameter(string thirdParameter)
    {
        return thirdParameter.Length > 0;
    }
    
    private static bool CheckMemeType(string meme)
    {
        return GetMemesFromMemeDirectory().Contains(meme);
    }

    private static List<string> GetMemesFromMemeDirectory()
    {
        var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory() + @"\memes\");
        var memePossibleValues = new List<string>();
        foreach (var file in files)
        {
            memePossibleValues.Add(Path.GetFileName(file).Replace(".jpg", ""));
        }

        return memePossibleValues;
    }
}
