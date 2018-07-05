using iTextSharp.text.pdf;

namespace Ellegia.Domain.Services.PdfFileIO.PdfFileReader
{
    public interface IPdfFileReader
    {
        PdfReader ReadFile();      
    }
}   