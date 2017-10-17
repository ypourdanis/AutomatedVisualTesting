﻿using System.Drawing;
using static System.Configuration.ConfigurationSettings;

namespace AutomatedVisualTesting.Utilities
{
    public static class ConvertPdf
    {
        /// <summary>
        /// Save pdf pages as images
        /// </summary>
        /// <param name="filename">filename of pdf to save as images</param>
        public static void SavePdfToImage(string filename)
        {
            string testDataDirectory = AppSettings.Get("TestDataDirectory");
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            f.OpenPdf($"{testDataDirectory}{filename}");
            if (f.PageCount > 0)
            {
                f.ImageOptions.Dpi = 300;
                for (int p = 1; p < f.PageCount + 1; p = p + 1)
                {
                    Image img = f.ToDrawingImage(p);
                    img.Save($"{testDataDirectory}{filename}.{p}.png");
                }
            }
        }

        /// <summary>
        /// Return pdf page as image
        /// </summary>
        /// <param name="filename">filename of pdf</param>
        /// <param name="page">page of pdf</param>
        /// <returns>Pdf page as a png image</returns>
        public static Image GetPdfPageAsImage(string filename, int page)
        {
            string testDataDirectory = AppSettings.Get("TestDataDirectory");
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            f.OpenPdf($"{testDataDirectory}{filename}");
            if (f.PageCount > page)
            {
                f.ImageOptions.Dpi = 300;
                return f.ToDrawingImage(page);
            }
            return null;
        }
    }
}