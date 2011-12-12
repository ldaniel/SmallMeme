using System.Drawing;
using System.IO;

public class Meme
{
    public string BasePath { get; private set; }
    public string FileExtension { get; private set; }
    public string OutputName { get; private set; }
    public string BaseMeme { get; private set; }
    public string TopText { get; private set; }
    public string BottomText { get; private set; }
    public string Status { get; private set; }
    private int Height { get; set; }
    private int Width { get; set; }

    public Meme()
    {
        BasePath = Directory.GetCurrentDirectory() + @"\memes\";
        FileExtension = ".jpg";
        OutputName = "meme";
        BaseMeme = "yuno";
        TopText = "HEY!";
        BottomText = "Y U NO TYPE \"HELP\"?";
        Status = string.Empty;
    }

    public Bitmap GetMemeBaseImage()
    {
        var meme = new Bitmap(BasePath + BaseMeme + FileExtension);
        Width = meme.Width;
        Height = meme.Height;

        return meme;
    }

    public string GetStatus()
    {
        return Status;
    }

    public void Generate(string[] args)
    {
        CheckParameters(args);
        CreateMemeImage();        
    }
    
    private void CheckParameters(string[] args)
    {
        if (MemeValidator.IsValidParameters(args))
        {
            BaseMeme = args[0];
            TopText = args[1];
            BottomText = args[2];
            UpdateStatus("small meme created -> " + BasePath + BaseMeme + FileExtension);
        }
        else
        {
            UpdateStatus(MemeValidator.GetHelpText());
        }
    }

    private void CreateMemeImage()
    {
        var memeBase = GetMemeBaseImage();

        using (var bitmap = new Bitmap(memeBase.Width, memeBase.Height))
        {
            using (var graphics = Graphics.FromImage(bitmap))
            {
                ImageGenerator.DrawImage(graphics, memeBase);
                ImageGenerator.DrawText(graphics, memeBase, TopText, 5);
                ImageGenerator.DrawText(graphics, memeBase, BottomText, Height - 30);
            }
            ImageGenerator.Save(bitmap, BasePath + OutputName + FileExtension);
        }
    }   

    private void UpdateStatus(string text)
    {
        Status = text;
    }
}