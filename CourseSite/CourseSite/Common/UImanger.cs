using CourseSite.Models.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CourseSite.Common
{
    public static class UImanger
    {
        public static string CurrentLang
        {
            get { return Thread.CurrentThread.CurrentCulture.Name; }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static SelectList GenderDll()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                return (new SelectList(db.Gender.ToList(), "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Gender_EngName" : "Gender_AraName"));
            }
        }
    }

}