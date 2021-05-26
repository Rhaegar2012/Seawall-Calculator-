using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using System.IO;
using Microsoft.Win32;

namespace SeawallCalculator
{
    class ReportManager
    {
        //Project Variables 
        private string ProjectName;
        private string EngineerName;
        //Wall Input variables 
        private string GroundElevation;
        private string GroundWaterDepth;
        private string OpenWaterLevel;
        private string MudlineLevel;
        private string LandslideSlope;
        private string MudlineSlope;
        private string MudlineDepth;
        private string TopOfPile;
        private string PilesSpacing;
        private string LateralCapacityofKingPiles;
        private string SlopeBatteredPiles;
        private string PanelThickness;
        private string SafetyFactor;
        private string SoilDensity;
        private string SaturatedSoilDensity;
        private string ActiveFrictionAngle;
        private string PassiveFrictionAngle;
        private string SoilToWallFrictionAngle;
        private string LiveSurcharge;
        //Wall Output Variables 
        private string LateralForceonCap;
        private string MaxWallShear;
        private string MaxWallMoment;
        private string AxialForceBatteredPile;
        private string AxialForceKingPile;
        private string ActualWallPenetration;
        
       public ReportManager(string groundElevation, string groundwaterdepth, string openWaterLevel, string mudlineSlope, string landslideSlope , string mudlineDepth,
            string topOfPile , string pilesSpacing, string lateralCapacityofKingPiles,string slopeBatteredPiles, string panelThickness, string safetyFactor, string soilDensity, 
            string saturatedSoilDensity, string activeFrictionAngle, string  passiveFrictionAngle,string soilWallFrictionAngle, string liveSurcharge,
            string lateralForceOnCap, string maxWallShear, string maxWallMoment,string axialForceBatteredPile, string axialForceKingPile, string actualWallPenetration,
            string projectName, string engineerName)
        {
            GroundElevation = groundElevation;
            GroundWaterDepth = groundwaterdepth;
            OpenWaterLevel = openWaterLevel;
            LandslideSlope = landslideSlope;
            MudlineSlope = mudlineSlope;
            MudlineDepth = mudlineDepth;
            TopOfPile = topOfPile;
            PilesSpacing = pilesSpacing;
            LateralCapacityofKingPiles = lateralCapacityofKingPiles;
            SlopeBatteredPiles = slopeBatteredPiles;
            PanelThickness = panelThickness;
            SafetyFactor = safetyFactor;
            SoilDensity = soilDensity;
            SaturatedSoilDensity = saturatedSoilDensity;
            ActiveFrictionAngle = activeFrictionAngle;
            PassiveFrictionAngle = passiveFrictionAngle;
            SoilToWallFrictionAngle = soilWallFrictionAngle;
            LiveSurcharge = liveSurcharge;
            LateralForceonCap = lateralForceOnCap;
            MaxWallShear = maxWallShear;
            MaxWallMoment = maxWallMoment;
            AxialForceBatteredPile = axialForceBatteredPile;
            AxialForceKingPile = axialForceKingPile;
            ActualWallPenetration = actualWallPenetration;
            ProjectName = projectName;
            EngineerName = engineerName;
        }
        public void CreateWallReport()
        {
            SaveFileDialog reportFileDialog = new SaveFileDialog();
            reportFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            reportFileDialog.DefaultExt = ".pdf";
            reportFileDialog.Filter = "pdf files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            reportFileDialog.FilterIndex = 1;
            if ((bool) reportFileDialog.ShowDialog())
            {
                string filepath =reportFileDialog.FileName;
                PdfWriter writer = new PdfWriter(filepath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph title = new Paragraph("Green Coastal Engineering - Seawall Calculation Report");
                title.SetTextAlignment(TextAlignment.JUSTIFIED);
                title.SetFontSize(20);
                Paragraph subtitle = new Paragraph("Project: "+ProjectName+"\n"+
                    "Engineer: "+EngineerName+"\n"+
                    "Date:xxxxx");
                LineSeparator titleUnderline = new LineSeparator( new SolidLine(1f));
                Paragraph input_title = new Paragraph("Input Variables");
                input_title.SetTextAlignment(TextAlignment.JUSTIFIED);
                input_title.SetFontSize(16);
                Paragraph input_Variables = new Paragraph("Ground Elevation: " + GroundElevation + " ft\n" +
                    "Ground Water Depth: " + GroundWaterDepth + " ft below ground\n"+
                    "Open Water Level: " +OpenWaterLevel +" ft below ground\n"+
                    "Mudline Slope: "+MudlineSlope +" Downward +\n"+
                    "Landslide Slope: "+LandslideSlope+" Upward+\n"+
                    "Mudline Depth: "+MudlineDepth+" ft below Ground \n"+ 
                    "Top of Pile: "+TopOfPile+" ft below Ground \n"+
                    "Piles Spacing: "+PilesSpacing+" ft\n"+
                    "Lateral Capacity of King Piles: "+LateralCapacityofKingPiles+" kip\n"+
                    "Slope of Battered Piles: "+SlopeBatteredPiles+" in/ft\n"+
                    "Wall Panel Thickness: "+PanelThickness+" in\n"+
                    "Safety Factor: "+SafetyFactor+" in\n"+
                    "Soil Density: "+SoilDensity+" pcf\n"+
                    "Saturated Soil Density: "+SaturatedSoilDensity+" pcf\n"+
                    "Active Friction Angle: "+ActiveFrictionAngle+" Deg\n"+
                    "Passive Friction Angle: "+PassiveFrictionAngle+" Deg\n"+
                    "Soil to Wall Friction Angle: "+SoilToWallFrictionAngle+" Deg\n"+
                    "Live Surcharge Load: "+LiveSurcharge+" psf\n");
                input_Variables.SetTextAlignment(TextAlignment.JUSTIFIED);
                Paragraph output_title = new Paragraph("Output Variables");
                output_title.SetTextAlignment(TextAlignment.JUSTIFIED);
                output_title.SetFontSize(16);
                Paragraph output_Variables = new Paragraph("Lateral Force on Cap: " + LateralForceonCap + " lb/ft\n" +
                    "Max Wall Shear: " + MaxWallShear + " lb*ft/ft\n" +
                    "Max Wall Moment: " + MaxWallMoment + " lb*ft/ft\n" +
                    "Axial Force on Battered Pile: " + AxialForceBatteredPile + " kip\n" +
                    "Axial Force on King Pile: " + AxialForceKingPile + " kip");
                output_Variables.SetTextAlignment(TextAlignment.JUSTIFIED);
                document.Add(title);
                document.Add(subtitle);
                document.Add(titleUnderline);
                document.Add(input_title);
                document.Add(input_Variables);
                document.Add(output_title);
                document.Add(output_Variables);
                document.Close();
            }
          
        }
    }
}
