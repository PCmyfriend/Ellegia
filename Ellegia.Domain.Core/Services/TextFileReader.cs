using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text.pdf;

namespace Ellegia.Domain.Core.Services
{
    public class TextFileReader : ITextFileReader
    {
        private readonly string _webRootPath;
        

        public TextFileReader(string webRootPath)
        {
            _webRootPath = webRootPath;
        }

        public IEnumerable<string> ReadFile()
        {

            try
            {
                using (var existingFileStream = new FileStream(Directory.GetCurrentDirectory() + "\\wwwroot\\orderTemplate.pdf", FileMode.Open))
                {
                    TimeSpan tmp = new TimeSpan();
                    var a = tmp.ToString();
                    using (var newFileStream = new FileStream(string.Format(Directory.GetCurrentDirectory() + "TmpPdfFiles\\{0}.pdf", tmp.ToString()), FileMode.Create))
                    {
                        var pdfReader = new PdfReader(existingFileStream);

                        var stamper = new PdfStamper(pdfReader, newFileStream);

                        var form = stamper.AcroFields;
                        var fieldKeys = form.Fields.Keys;

                        foreach (string fieldKey in fieldKeys)
                        {
                            form.SetField(fieldKey, "0705606262");
                        }

                        stamper.Close();
                        pdfReader.Close();
                    }
                }


                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}