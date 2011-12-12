using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public static class ImageGenerator
{
    public static void DrawImage(Graphics graphics, Bitmap memeBase)
    {
        graphics.DrawImage(memeBase, 0, 0, memeBase.Width, memeBase.Height);
    }

    public static void DrawText(Graphics graphics, Bitmap memeBase, string text, int topPosition)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

        var path = new GraphicsPath();
        path.AddString(text, new FontFamily("Verdana"),
            (int)FontStyle.Regular, 20.0f,
            new Point(GetTextLeftPosition(text, memeBase.Width), topPosition),
            new StringFormat());

        for (int i = 1; i < 8; ++i)
        {
            var pen = new Pen(Color.FromArgb(32, 0, 128, 192), i);
            pen.LineJoin = LineJoin.Round;
            graphics.DrawPath(pen, path);
            pen.Dispose();
        }

        var brush = new SolidBrush(Color.FromArgb(255, 255, 255));
        graphics.FillPath(brush, path);
    }

    public static void Save(Bitmap bitmap, string path)
    {
        bitmap.Save(path, ImageFormat.Jpeg);
    }

    private static int GetTextLeftPosition(string text, int width)
    {
        int imageWidth = width / 2;
        int textWidth = (text.Length * 12) / 2;
        int diff = imageWidth - textWidth;

        return diff;
    }    
}
