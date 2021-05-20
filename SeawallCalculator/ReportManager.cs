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
        ReportManager(string groundElevation)
        {

        }
        public void CreateReport()
        {
            SaveFileDialog reportFileDialog = new SaveFileDialog();
            reportFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            reportFileDialog.Filter = "Your extension here (*.EXT)|*.ext|All Files (*.*)|*.*";
            reportFileDialog.FilterIndex = 1;
            if ((bool) reportFileDialog.ShowDialog())
            {
                string filepath =reportFileDialog.FileName;
                PdfWriter writer = new PdfWriter(filepath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph paragraph = new Paragraph("Hello World");
                Console.WriteLine(paragraph.ToString());
                document.Add(paragraph);
                document.Close();

            }
          
            
            
        }
    }
}
