﻿using Ellegia.Domain.Models;
using iTextSharp.text.pdf;

namespace Ellegia.Domain.Services.PdfFileIO.PdfFileWriter
{
    public interface IPdfFileWriter 
    {
        byte[] FillPfdTemplate(PdfReader pdfReader, Order order);
    }
}
