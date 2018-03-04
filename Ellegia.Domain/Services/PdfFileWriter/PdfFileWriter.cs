using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;
using iTextSharp.text.pdf;

namespace Ellegia.Domain.Services.PdfFileWriter
{
    public class PdfFileWriter : IPdfFileWriter
    {
        private PdfStamper _pdfStamper;
        private readonly Dictionary<string, FieldKeyTypeEnum> _formFieldsDictionary;

        public PdfFileWriter()
        {
            _formFieldsDictionary = new Dictionary<string, FieldKeyTypeEnum> {
                { "PhoneNumber", FieldKeyTypeEnum.PhoneNumber }
            };
        }

        public byte[] FillPfdTemplate(PdfReader pdfReader, Order order)
        {
            using (var memoryStream = new MemoryStream())
            {
                 _pdfStamper = new PdfStamper(pdfReader, memoryStream);

                var form = _pdfStamper.AcroFields;
                var fieldKeys = form.Fields.Keys;

                foreach (string fieldKey in fieldKeys)
                {
                    try
                    {
                        switch (_formFieldsDictionary[fieldKey])
                        {
                            case FieldKeyTypeEnum.PhoneNumber:
                                //form.SetField(fieldKey, order.Customer.Contacts.Where(c=>c) ));
                                break;
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                    }
                    finally
                    {
                        _pdfStamper.Close();
                    }
                }
                return memoryStream.ToArray();
            }
        }
    }
}
