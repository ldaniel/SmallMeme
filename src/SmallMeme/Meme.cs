using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

public class Meme
{
    public string BasePath { get; private set; }
    public string FileExtension { get; private set; }
    public string OutputName { get; private set; }
    public string BaseMeme { get; private set; }
    public string TopText { get; private set; }
    public string BottomText { get; private set; }
    public string Status { get; private set; }

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
        return new Bitmap(BasePath + BaseMeme + FileExtension);
    }

    public void Generate(string[] args)
    {
        CheckParameters(args);
        CreateMemeImage();
        UpdateStatus("small meme created -> " + BasePath + BaseMeme + FileExtension);
    }


    public string GetStatus()
    {
        return Status;
    }

    private void CheckParameters(string[] args)
    {
        if (MemeValidator.CheckParameters(args))
        {
            BaseMeme = args[0];
            TopText = args[1];
            BottomText = args[2];
        }
    }

    private void CreateMemeImage()
    {
        var memeBase = GetMemeBaseImage();

        using (var bitmap = new Bitmap(memeBase.Width, memeBase.Height))
        {
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(memeBase, 0, 0, memeBase.Width, memeBase.Height);
                DrawText(graphics);
            }
            bitmap.Save(BasePath + OutputName + FileExtension, ImageFormat.Jpeg);
        }
    }

    private void DrawText(Graphics graphics)
    {
        graphics.DrawString(TopText, GetFont(), Brushes.White, new Point(100, 10));
        graphics.DrawString(BottomText, GetFont(), Brushes.White, new Point(100, 250));
    }

    private void UpdateStatus(string text)
    {
        Status = text;
    }

    private Font GetFont()
    {
        return new Font("Verdana", 18, FontStyle.Bold);
    }
}