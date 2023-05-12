using Grpc.Core;
using ICSharpCode.SharpZipLib.Zip;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Task1.Models;
using Task1.Repository;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
           
    {
        private readonly IWebHostEnvironment _host; 
        private readonly IUserRepo _userRepo;
        public TaskController(IUserRepo userRepo, IWebHostEnvironment host)
        {
            _userRepo = userRepo;
            this._host = host;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginRequest User)
        {
            var A = _userRepo.Login(User);

            return Ok(A);

        }


        [HttpPost]
        [Route("AddDoc")]
        public async Task<IActionResult> AddDoc([FromForm] IFormFile file)
        {
            try
            {
                using (FileStream fileStream = System.IO.File.Create(_host.WebRootPath + "\\Documents\\" + file.FileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                DocumentData obj = new DocumentData();
                obj.DocName = file.FileName.Split(".").First();

                obj.DocPath = file.FileName;
                await _userRepo.AddDoc(obj);

                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteDoc")]
        public async Task<IActionResult> DeleteDoc(int DocId)
        {
            var B = await _userRepo.DeleteDoc(DocId);
            return Ok(true);
        }
        /* [HttpPost]
         [Route("AddDoc")]
         public async Task<IActionResult> AddDoc(DocumentData documentData)
         {
             var B = await _userRepo.AddDoc(documentData);
             return Ok(B);
         }*/


        [HttpGet]
  
        [Route("GetDocuments")]
        public IActionResult Display1()
        {
            List<DocumentData> A = _userRepo.GetDocuments();
            return Ok(A);          
        }

        [HttpGet]
        [Route("GetFilePath")]
        public IActionResult GetFilePath(string DocName)
        {
            List<DocumentData> A = _userRepo.GetFilePath(DocName);
            return Ok(A);
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("DocumentsDownload")]
        public async Task<IActionResult> DocumentsDownload([FromQuery] string fileUrl)
        {
            var filePath = Path.Combine(_host.WebRootPath + "\\Documents\\" , fileUrl);
            // using (FileStream fileStream = System.IO.File.Create(_host.WebRootPath + "\\Documents\\" + file.FileName))
            //var filePath = Path.Combine(_host.ContentRootPath + "\\Documents", fileUrl);
            //var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileUrl);
            if (!System.IO.File.Exists(filePath)) return NotFound();
            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(filePath), filePath);
        }
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        // [Route("downloadzip")]
        public string test()
        {
            List<string> files = new List<string>
            {
                "C:/Users/Thomson/source/repos/Task1/wwwroot/Documents/Events.txt",
                "C:/Users/Thomson/source/repos/Task1/wwwroot/Documents/Exam.txt"
            };


            using (var memoryStream = new MemoryStream())
            {
                using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        zipArchive.CreateEntryFromFile(file, Path.GetFileName(file));
                    }
                }

                memoryStream.Position = 0;
                File(memoryStream, "application/zip", "my.zip");
                return "test";

            }
        }

        /*        
        [HttpGet]
        [Route("GetFilePath")]
        public IActionResult GetFilePath(string filename)
        {

            List<DocumentData> A = _userRepo.GetFilePath();
            return Ok(A);
        }        
         public IActionResult GetFile(int DocId)
        {
            var stream = new FileStream(@"C:\Users\Thomson\OneDrive\Desktop\Thomson\Documents\10th_marklist.pdf", FileMode.Open);
            return new FileStreamResult(stream, "pdf");
        }
        */
    }
}
