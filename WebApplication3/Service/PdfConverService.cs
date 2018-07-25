using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Framework.ViewModel;

namespace WebApp.Service
{
    public class PdfConvertService
    {
        public PdfConvertService()
        {

        }

        public UrlResultModel Upload(HttpPostedFileBase file, string watermark)
        {
            UrlResultModel result = new UrlResultModel();
            result.HasError = false;
            string path = AppDomain.CurrentDomain.BaseDirectory + "uploads\\";
            var sourcePath = Path.Combine(path, file.FileName);
            file.SaveAs(sourcePath);
            try
            {
                Guid id = Guid.NewGuid();
                var filename = System.IO.Path.GetFileNameWithoutExtension(sourcePath);
                var extension = System.IO.Path.GetExtension(sourcePath);
                string tempPath = path + "_" + Guid.NewGuid() + ".pdf";
                string targetPath = path + $"{id}_{filename}.pdf";
                if (new List<string>() { ".ppt", ".pptx" }.Contains(extension.Trim().ToLower()))
                {
                    AsposeTransPdf.AsposePPTToPDF(sourcePath, tempPath);
                }
                if (new List<string>() { ".doc", ".docx" }.Contains(extension.Trim().ToLower()))
                {
                    AsposeTransPdf.AsposeWordToPDF(sourcePath, tempPath);
                }
                if (new List<string>() { ".xls", ".xlsx" }.Contains(extension.Trim().ToLower()))
                {
                    AsposeTransPdf.AsposeExcelToPDF(sourcePath, tempPath);
                }
                //WordToPDF(tempPath, targetPath);
                ITextSharpUtils.setWatermark(tempPath, targetPath, String.IsNullOrWhiteSpace(watermark) ? "金 风 科 技" : watermark);
                System.IO.File.Delete(tempPath);
                result.Url = $"uploads\\{id}_{filename}.pdf";
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.ErrorMessage = e.Message;
            }
            finally
            {
                System.IO.File.Delete(sourcePath);
            }
            return result;
        }

        public bool Delete(string fileName)
        {
            try
            {
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + fileName);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}