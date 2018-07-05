using System;
using System.IO;
using iTextSharp.text.pdf;

namespace Ellegia.Domain.Services.PdfFileIO.PdfFileReader
{
    public class PdfFileReader : IPdfFileReader
    {
        private readonly string _filePath;
        private PdfReader _pdfReader;
        
        public PdfFileReader(string filePath)            
        {
            _filePath = filePath;
        }
            
        public PdfReader ReadFile()
        {
            try
            {
                using (var stream = new FileStream(_filePath, FileMode.Open))
                {
                    _pdfReader = new PdfReader(stream);      
                }
            }
            catch (Exception)
            {
                return null;
            }

            _pdfReader.Close();
            return _pdfReader;
        }
    }
}