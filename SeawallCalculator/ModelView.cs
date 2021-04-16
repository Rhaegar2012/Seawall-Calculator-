using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Reflection;

namespace SeawallCalculator
{
    //ModelView collects and displays information from the UI 
    public class ModelView
    {
        //Control Properties
        //ICommand objects that bind the controls in the UI, instead of having them bound directly to their click events
        //WallControl Properties
        private ICommand m_WallAnalyzeCommand;
        public ICommand WallAnalyzeButton
        {
            get
            {
                return m_WallAnalyzeCommand;
            }
            set
            {
                m_WallAnalyzeCommand = value;
            }
        }
        private ICommand m_WallReportCommand;
        public ICommand WallReportButton
        {
            get
            {
                return m_WallReportCommand;
            }
            set
            {
                m_WallReportCommand = value;
            }
        }
        //Wall input Data Properties 
        private string in_GroundElevation;
        public string GroundElevation {
            get
            {
                return in_GroundElevation;
            }
            set
            {
                in_GroundElevation = value;
            }
        }
        private string in_GroundWaterDepth;
        public string GroundWaterDepth
        {
            get
            {
                return in_GroundWaterDepth;
            }
            set
            {
                in_GroundWaterDepth = value;
            }
        }
        private string in_OpenWaterLevel;
        public string OpenWaterLevel
        {
            get
            {
                return in_OpenWaterLevel;
            }
            set
            {
                in_OpenWaterLevel = value;
            }
        }
        private string in_MudlineSlope;
        private string in_MudlineDepth;
        public string MudlineDepth
        {
            get
            {
                return in_MudlineDepth;
            }
            set
            {
                in_MudlineDepth = value;
            }
        }
        public string MudlineSlope
        {
            get
            {
                return in_MudlineSlope;
            }
            set
            {
                in_MudlineSlope = value;
            }
        }
        private string in_LandslideSlope;
        public string LandslideSlope
        {
            get
            {
                return in_LandslideSlope;
            }
            set
            {
                in_LandslideSlope = value;
            }
        }
        private string in_TopOfPile;
        public string TopOfPile
        {
            get
            {
                return in_TopOfPile;
            }
            set
            {
                in_TopOfPile = value;
            }
        }
        private string in_PilesSpacing;
        public string PilesSpacing
        {
            get
            {
                return in_PilesSpacing;
            }
            set
            {
                in_PilesSpacing = value;
            }
        }
        private string in_LateralCapacityKingPiles;
        public string LateralCapacityKingPiles
        {
            get
            {
                return in_LateralCapacityKingPiles;
            }
            set
            {
                in_LateralCapacityKingPiles = value;
            }
        }
        private string in_SlopeBatteredPiles;
        public string SlopeBatteredPiles
        {
            get
            {
                return in_SlopeBatteredPiles;
            }
            set
            {
                in_SlopeBatteredPiles = value;
            }
        }
        private string in_PanelThickness;
        public string PanelThickness
        {
            get
            {
                return in_PanelThickness;
            }
            set
            {
                in_PanelThickness = value;
            }
        }
        private string in_Penetration;
        public string Penetration
        {
            get
            {
                return in_Penetration;
            }
            set
            {
                in_Penetration = value;
            }
        }
        private string in_SafetyFactor;
        public string SafetyFactor
        {
            get
            {
                return in_SafetyFactor;
            }
            set
            {
                in_SafetyFactor = value;
            }
        }
        private string in_SoilDensity;
        public string SoilDensity
        {
            get
            {
                return in_SoilDensity;
            }
            set
            {
                in_SoilDensity = value;
            }
        }
        private string in_SaturatedSoilDensity;
        public string SaturatedSoilDensity
        {
            get
            {
                return in_SaturatedSoilDensity;
            }
            set
            {
                in_SaturatedSoilDensity = value;
            }
        }
        private string in_ActiveFrictionAngle;
        public string ActiveFrictionAngle
        {
            get
            {
                return in_ActiveFrictionAngle;
            }
            set
            {
                in_ActiveFrictionAngle = value;
            }
        }
        private string in_PassiveFrictionAngle;
        public string PassiveFrictionAngle
        {
            get
            {
                return in_PassiveFrictionAngle;
            }
            set
            {
                in_PassiveFrictionAngle = value;
            }
        }
        private string in_SoilToWallFrictionAngle;
        public string SoilToWallFrictionAngle
        {
            get
            {
                return in_SoilToWallFrictionAngle;
            }
            set
            {
                in_SoilToWallFrictionAngle = value;
            }
        }
        private string in_LiveSurcharge;
        public string LiveSurcharge
        {
            get
            {
                return in_LiveSurcharge;
            }
            set
            {
                in_LiveSurcharge = value;
            }
        }
        //TODO:Bind cantilever bool variable to checkbox in the view  
        public bool isCantilever=true;
        //Wall property list for verification


        private CalculationManager calculationManager;

        //The model view constructor creates the relay command from the button objects and collects the data from the UI 
        public ModelView()
        {
            //Initializes the controls as ICommand objects 
            WallAnalyzeButton = new RelayCommand(new Action<object>(AnalyzeWall));
            WallReportButton = new RelayCommand(new Action<object>(CreateWallReport));
            
        }
        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
        private bool CheckWallData()
        {
            bool Verified = true;
            string[] DataArray = {in_GroundElevation,
                                  in_GroundWaterDepth,
                                  in_LandslideSlope,
                                  in_LateralCapacityKingPiles,
                                  in_LiveSurcharge,
                                  in_MudlineSlope,
                                  in_MudlineDepth, 
                                  in_OpenWaterLevel,
                                  in_PanelThickness,
                                  in_PassiveFrictionAngle,
                                  in_Penetration,
                                  in_PilesSpacing,
                                  in_SafetyFactor,
                                  in_SaturatedSoilDensity,
                                  in_SlopeBatteredPiles,
                                  in_SoilDensity,
                                  in_SoilToWallFrictionAngle,
                                  in_TopOfPile};
            for(int i=0; i < DataArray.Length; i++)
            {
                if (DataArray[i] == null)
                    Verified = false;
            }
            return Verified;
        }
        private void AnalyzeWall(object obj)
        {
            
            if (CheckWallData())
            {
                int parse_groundElevation = Int32.Parse(GroundElevation);
                int parse_groundWaterDepth = Int32.Parse(GroundWaterDepth);
                int parse_openWaterLevel = Int32.Parse(OpenWaterLevel);
                int parse_MudlineDepth = Int32.Parse(MudlineDepth);
                int parse_MudlineSlope = Int32.Parse(MudlineSlope);
                int parse_OpenWaterLevel = Int32.Parse(OpenWaterLevel);
                int parse_wallThickness = Int32.Parse(PanelThickness);
                int parse_PassiveFrictionAngle = Int32.Parse(PassiveFrictionAngle);
                int parse_ActiveFrictionAngle = Int32.Parse(ActiveFrictionAngle);
                int parse_LandslideSlope = Int32.Parse(LandslideSlope);
                int parse_LiveSurcharge = Int32.Parse(LiveSurcharge);
                int parse_Penetration = Int32.Parse(Penetration);
                int parse_PilesSpacing = Int32.Parse(PilesSpacing);
                int parse_PilesLateralCapacity = Int32.Parse(LateralCapacityKingPiles);
                double parse_SafetyFactor = Double.Parse(SafetyFactor);
                int parse_SaturatedSoilDensity = Int32.Parse(SaturatedSoilDensity);
                int parse_SlopeBatteredPiles = Int32.Parse(SlopeBatteredPiles);
                int parse_SoilDensity = Int32.Parse(SoilDensity);
                int parse_SoilToWallFrictionAngle = Int32.Parse(SoilToWallFrictionAngle);
                int parse_TopOfPile = Int32.Parse(TopOfPile);
                calculationManager.CreateWall(parse_groundElevation, parse_TopOfPile, parse_MudlineDepth, parse_groundWaterDepth, parse_OpenWaterLevel,
                    parse_Penetration, parse_SaturatedSoilDensity, parse_ActiveFrictionAngle, parse_PassiveFrictionAngle, parse_SoilToWallFrictionAngle,
                    parse_LandslideSlope, parse_MudlineSlope, parse_LiveSurcharge, parse_PilesSpacing, parse_PilesLateralCapacity, parse_SoilToWallFrictionAngle,
                    isCantilever);
                calculationManager.CalculateWall();
                UpdateWallForm();

            }
            else
            {
                MessageBox.Show("Check input variables", "Warning Message");
            }
        }
        private void CreateWallReport(object obj)
        {
            throw new  NotImplementedException();
        }
        private void UpdateWallForm()
        {

        }



    }
}
