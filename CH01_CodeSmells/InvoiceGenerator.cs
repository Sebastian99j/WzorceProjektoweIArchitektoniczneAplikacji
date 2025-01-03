using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CodeSmells
{
    public class InvoiceGenerator
    {
        public void GenerateInvoice()
        {
            int invoiceNumber = 12345;
            string fileName = $"Invoice_{invoiceNumber}.pdf";

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                Document document = new Document();

                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);

                document.Open();

                document.Add(new Paragraph("Invoice Content"));

                document.Close();
            }

            Console.WriteLine($"Invoice saved as {fileName}");
        }

        public void OtherMethod()
        {
            Console.WriteLine("Doing something...");
        }
    }
}