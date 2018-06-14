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
        private readonly OrderPrintingVersion _orderPrintingVersion;

        public PdfFileWriter()
        {
            _orderPrintingVersion = new OrderPrintingVersion();
        }   

        public byte[] FillPfdTemplate(PdfReader pdfReader, Order order)
        {           
            var contactsPrintingVersion = _orderPrintingVersion.GetContactsPrintingVersion(order.Customer);
            var standartSizePrintingVersion =
                _orderPrintingVersion.GetStandardSizePrintingVersion(order.ProductType.StandardSize);
            var productTypePrintingVersion = _orderPrintingVersion.GetProductTypePrintingVersion(order.ProductType);
            var quantityInKg = _orderPrintingVersion.GetGeneralInfoPrintingVersion(order);


            using (var memoryStream = new MemoryStream())
            {
                _pdfStamper = new PdfStamper(pdfReader, memoryStream);

                var form = _pdfStamper.AcroFields;
                var fieldKeys = form.Fields.Keys;   

                foreach (string fieldKey in fieldKeys)
                {
                    try
                    {   
                        switch (fieldKey)
                        {
                            case "CustomerName":
                                form.SetField(fieldKey, order.Customer.Name);
                                break;
                            case "PhoneNumber":
                                form.SetField(fieldKey, contactsPrintingVersion.phoneNumber);
                                break;
                            case "WidthInMm":
                                form.SetField(fieldKey, standartSizePrintingVersion.widthInMm);
                                break;
                            case "LengthInMm":
                                form.SetField(fieldKey, standartSizePrintingVersion.lengthInMm);
                                break;
                            case "ThicknessInMicron":
                                form.SetField(fieldKey, productTypePrintingVersion.thicknessInMicron);
                                break;
                            case "HasCorona":
                                form.SetField(fieldKey, productTypePrintingVersion.hasCorona);
                                break;
                            case "QuantityInKg":
                                form.SetField(fieldKey, quantityInKg);
                                break;
                            default:
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
