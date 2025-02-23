using System;
using System.Collections.Generic;
using System.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int numeroAleatorio=0;
        // 1. Crear conjunto ficticio de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // 2. Crear conjuntos ficticios de vacunados
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
         // Asignar 75 ciudadanos vacunados con Pfizer
        while (vacunadosPfizer.Count < 75)
        {
            numeroAleatorio = random.Next(1, 501);
            vacunadosPfizer.Add($"Ciudadano {numeroAleatorio}");
        }

        // Asignar 75 ciudadanos vacunados con Astrazeneca
        while (vacunadosAstrazeneca.Count < 75)
        {
            numeroAleatorio = random.Next(1, 501);
            vacunadosAstrazeneca.Add($"Ciudadano {numeroAleatorio}");
        }

        // 3. Operaciones de conjuntos
        HashSet<string> dosVacunas = new HashSet<string>(vacunadosPfizer);
        dosVacunas.IntersectWith(vacunadosAstrazeneca);
        
        //Ciudadanos solo con Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(dosVacunas);

        //Ciudadanos solo con AstraZeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(dosVacunas);

        //Ciudadanos no Vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        //Generar reporte en PDF
        GenerarReportePDF(noVacunados, dosVacunas, soloPfizer, soloAstrazeneca);

        Console.WriteLine("Reporte generado exitosamente.");
    }

    static void GenerarReportePDF(HashSet<string> noVacunados, HashSet<string> dosVacunas, HashSet<string> soloPfizer, HashSet<string> soloAstrazeneca)
    {
        // Crear un nuevo documento PDF
        PdfDocument document = new PdfDocument();
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Arial", 12);

        int yPosition = 50; // Posición vertical inicial

        // Escribir los resultados en el PDF

        double textWidth = gfx.MeasureString("Reporte de Vacunación COVID-19", font).Width;
        double pageWidth = 595; // Ancho típico de A4 en puntos (ajústalo si es diferente)
        double xCenter = (pageWidth - textWidth) / 2;
        gfx.DrawString("Reporte de Vacunación COVID-19", font, XBrushes.Black, new XPoint(xCenter, yPosition));
        yPosition += 30;

        gfx.DrawString($"Ciudadanos no vacunados: {noVacunados.Count}", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 20;

        gfx.DrawString($"Ciudadanos con dos vacunas: {dosVacunas.Count}", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 20;

        gfx.DrawString($"Ciudadanos solo con Pfizer: {soloPfizer.Count}", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 20;

        gfx.DrawString($"Ciudadanos solo con Astrazeneca: {soloAstrazeneca.Count}", font, XBrushes.Black, new XPoint(50, yPosition));
        yPosition += 20;

        // Guardar el documento
        string filename = "ReporteVacunacion.pdf";
        document.Save(filename);
    }
}
