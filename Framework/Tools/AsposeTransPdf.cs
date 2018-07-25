using Aspose.Words;
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Framework
{
    public class AsposeTransPdf
    {
        public static bool AsposePPTToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Presentation ppt = new Presentation(sourcePath);
            try
            {
                ppt.Save(targetPath, Aspose.Slides.Export.SaveFormat.Pdf);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public static bool AsposeWordToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Document doc = new Document(sourcePath);
            try
            {
                doc.Save(targetPath, Aspose.Words.SaveFormat.Pdf);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public static bool AsposeExcelToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Workbook excel = new Workbook(sourcePath);
            try
            {
                excel.Save(targetPath, Aspose.Cells.SaveFormat.Pdf);
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

    }
}
