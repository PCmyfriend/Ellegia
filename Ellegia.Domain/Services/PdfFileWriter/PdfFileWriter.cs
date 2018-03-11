using System.Collections.Generic;
using System.IO;
using Ellegia.Domain.Enums;
using Ellegia.Domain.Models;
using iTextSharp.text.pdf;

namespace Ellegia.Domain.Services.PdfFileWriter
{
    public class PdfFileWriter : IPdfFileWriter
    {
        private PdfStamper _pdfStamper;
        private readonly ContactPrintingVersion _contactPrintingVersion;
        private readonly Dictionary<string, FieldKeyTypeEnum> _formFieldsDictionary;

        public PdfFileWriter()
        {
            _contactPrintingVersion = new ContactPrintingVersion();
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

                var contactsByContactTypeDictionary = _contactPrintingVersion.GetContactsPrintingVersion(order.Customer);

                foreach (string fieldKey in fieldKeys)
                {
                    try
                    {
                        switch (_formFieldsDictionary[fieldKey])
                        {
                            case FieldKeyTypeEnum.PhoneNumber:
                                var phoneNumberPrintingVersion =
                                    _contactPrintingVersion.GetContactPrintingVersionByContactType(
                                        contactsByContactTypeDictionary, FieldKeyTypeEnum.PhoneNumber);
                                form.SetField(fieldKey, phoneNumberPrintingVersion);
                                break;
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                    }
                }
                _pdfStamper.Close();
                return memoryStream.ToArray();
            }
        }
    }    
}
