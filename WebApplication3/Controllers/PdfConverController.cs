using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Framework;
using WebApp.Service;
using Framework.ViewModel;

namespace WebApp.Controllers
{
    /// <summary>
    /// pdfConvert
    /// </summary>
    [RoutePrefix("pdfConvert")]
    public class PdfConverController : BaseController
    {
        private PdfConvertService _pdfConvert = null;
        public PdfConverController()
        {
            _pdfConvert = new PdfConvertService();
        }
        /// <summary>
        /// 上传并添加水印
        /// </summary>
        /// <param name="watermark">水印文字</param>
        /// <returns></returns>
        [HttpPost, Route("trans/{watermark}")]
        public async Task<string> Upload(string watermark)
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                var file = HttpContext.Request.Files[0];
                var result = await Task.Run(() => _pdfConvert.Upload(file, watermark));
                return base.Result(result);
            }
            return base.Result(new UrlResultModel() { HasError = true, ErrorMessage = "文件上传失败" });
        }

        [HttpGet, Route("delete")]
        public async Task<bool> Delete(string filepath)
        {
            return await Task.Run(() => _pdfConvert.Delete(filepath));
        }
    }
}