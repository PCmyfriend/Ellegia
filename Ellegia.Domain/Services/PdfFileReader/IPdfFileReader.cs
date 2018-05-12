using iTextSharp.text.pdf;

namespace Ellegia.Domain.Services.PdfFileReader
{
    public interface IPdfFileReader
    {
        PdfReader ReadFile();      
    }
}   