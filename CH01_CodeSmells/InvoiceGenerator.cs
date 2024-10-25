using iTextSharp.text.pdf;

namespace CodeSmells
{
    public class InvoiceGenerator
    {
        public void GenerateInvoice()
        {
            int invoiceNumber = 12345;
            using (PdfWriter pdfWriter = new PdfWriter($"Invoice_{invoiceNumber}.pdf"))
            {
                pdfWriter.Write("Invoice Content");
            }
        }

        public void OtherMethod()
        {
            Console.WriteLine("Doing something...");
        }
    }
}
