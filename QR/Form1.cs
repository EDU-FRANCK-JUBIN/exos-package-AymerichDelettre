using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using iText;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace QR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://www.youtube.com/watch?v=EhjC25OoVKE",
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(5);
            this.pictureBox1.Image = qrCodeImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dest = "C:/Users/aymer/Desktop/sample.pdf";
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdfDoc = new PdfDocument(writer);
            pdfDoc.AddNewPage();
            Document document = new Document(pdfDoc);
            Paragraph para = new Paragraph(richTextBox1.Text);
            document.Add(para);
            document.Close();
            System.Diagnostics.Process.Start(dest);
        }
    }
}
