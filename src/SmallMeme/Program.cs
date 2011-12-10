using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace SmallMeme
{
    class Program
    {
        static string memebasePath = Directory.GetCurrentDirectory() + @"\memes\";
        static string memeOutputName = "meme";
        static string memeFileExtension = ".jpg";
        static string memebase = "yuno";
        static string toptext = "HEY!";
        static string bottomtext = "Y U NO TYPE \"HELP\"?";

        static void Main(string[] args)
        {
            CheckParameters(args);
            GenerateMeme(GetMemeBase());
            WriteStatus();
        }

        static void WriteStatus()
        {
            Console.Write("-> smallmeme created in {0}",
                memebasePath + memeOutputName + memeFileExtension);
            Console.ReadLine();
        }

        static void CheckParameters(string[] args)
        {
            if (args.Count() == 3)
            {
                memebase = args[0];
                toptext = args[1];
                bottomtext = args[2];
            }           
        }

        static Bitmap GetMemeBase()
        {
            return new Bitmap(memebasePath + memebase + memeFileExtension);
        }

        static void GenerateMeme(Image memeBase)
        {
            using (var bitmap = new Bitmap(memeBase.Width, memeBase.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImage(memeBase, 0, 0, memeBase.Width, memeBase.Height);
                    DrawText(graphics);
                }
                bitmap.Save(memebasePath + memeOutputName + memeFileExtension, ImageFormat.Jpeg);
            }
        }

        static void DrawText(Graphics graphics)
        {
            graphics.DrawString(toptext, GetFont(), Brushes.White, new Point(100, 10));
            graphics.DrawString(bottomtext, GetFont(), Brushes.White, new Point(100, 250));
        }

        static Font GetFont()
        {
            return new Font("Verdana", 18, FontStyle.Bold);
        }
    }
}
