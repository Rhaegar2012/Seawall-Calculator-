﻿using System;
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
        
        ReportManager(string groundElevation, string groundwaterdepth, string openWaterLevel, string mudlineSlope, string landslideSlope , string mudlineDepth,
            string topOfPile , string pilesSpacing, string lateralCapacityofKingPiles,string slopeBatteredPiles, string panelThickness, string safetyFactor, string soilDensity, 
            string saturatedSoilDensity, string activeFrictionAngle, string  passiveFrictionAngle,string soilWallFrictionAngle, string liveSurcharge,
            string lateralForceOnCap, string maxWallShear, string maxWallMoment,string axialForceBatteredPile, string axialForceKingPile, string actualWallPenetration)
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
                Paragraph subtitle = new Paragraph("Project: XXXX \n Engineer: XXXX");
                LineSeparator titleUnderline = new LineSeparator();
                document.Add(title);
                document.Close();
            }
          
        }
    }
}
