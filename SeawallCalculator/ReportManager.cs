using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using Microsoft.Win32;

namespace SeawallCalculator
{
    class ReportManager
    {
        public void CreateReport()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Your extension here (*.EXT)|*.ext|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if ((bool) saveFileDialog1.ShowDialog())
            {
                string filepath = saveFileDialog1.FileName;
                PdfWriter writer = new PdfWriter(filepath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph header = new Paragraph("HEADER")
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20);
                document.Add(header);
                document.Close();
            }
            
        }
    }
}
