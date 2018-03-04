using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Ellegia.Domain.Services.PdfFileReader
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
                    return _pdfReader;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _pdfReader.Close();
            }
        }
    }
}