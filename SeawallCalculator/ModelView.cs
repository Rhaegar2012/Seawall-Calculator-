using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;


namespace SeawallCalculator
{
    //ModelView collects and displays information from the UI 
    public class ModelView:ObservableObject
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
        private  bool in_isCantilever;
        public bool isCantilever
        {
            get
            {
                return in_isCantilever;
            }
            set
            {
                in_isCantilever = value;
            }
        }
        //Output variables 
        private string _lateralForceOnCap;
        public string LateralForceOnCap
        {
            get
            {
                return _lateralForceOnCap;
            }
            set
            {
                _lateralForceOnCap = value;
                OnPropertyChanged("LateralForceOnCap");
            }
        }
        private string _maxWallShear;
        public string MaxWallShear {
            get
            {
                return _maxWallShear;
            }
            set
            {
                _maxWallShear = value;
                OnPropertyChanged("MaxWallShear");
            }
        }
        private string _maxWallMoment;
        public string MaxWallMoment 
        {
            get
            {
                return _maxWallMoment;
            }
            set
            {
                _maxWallMoment = value;
                OnPropertyChanged("MaxWallMoment");
            }
        }
        public string _axialForceInBatteredPile;
        public string AxialForceinBatteredPile { 
            get 
            {
                return _axialForceInBatteredPile;
            }
            set 
            {
                _axialForceInBatteredPile = value;
                OnPropertyChanged("AxialForceinBatteredPile");
            }
        }
        private string _axialForceinKingPile;
        public string AxialForceinKingPile {
            get
            {
                return _axialForceinKingPile;
            }
            set
            {
                _axialForceinKingPile = value;
                OnPropertyChanged("AxialForceinKingPile");
            }
        }
        private string _actualWallPenetration;
        public string ActualWallPenetration
        {
            get
            {
                return _actualWallPenetration;
            }
            set
            {
                _actualWallPenetration = value;
                OnPropertyChanged("ActualWallPenetration");
            }
        }
        //Plotting data
        private List<double> _WallElevations;
        public List<double> WallElevations
        {
            get
            {
                return _WallElevations;
            }
            set
            {
                _WallElevations = value;
            }
        }

        private List<double> _ShearLoadDistribution;
        public List<double> ShearLoadDistribution
        {
            get
            {
                return _ShearLoadDistribution;
            }
            set
            {
                _ShearLoadDistribution = value;
            }
        }
        private List<double> _MomentLoadDistribution;
        public List<double> MomentLoadDistribution
        {
            get
            {
                return _MomentLoadDistribution;
            }
            set
            {
                _MomentLoadDistribution = value;
            }
        }
        private List<DataPoint> _WallShearSeries=new List<DataPoint>();
        public List<DataPoint> WallShearSeries
        {
            get
            {
                return _WallShearSeries;
            }
            set
            {
                _WallShearSeries = value;
                OnPropertyChanged("WallShearSeries");
            }
        }
        private List<DataPoint> _WallMomentSeries=new List<DataPoint>();
        public List<DataPoint> WallMomentSeries
        {
            get
            {
                return _WallMomentSeries;
            }
            set
            {
                _WallMomentSeries = value;
                OnPropertyChanged("WallMomentSeries");
            }
        }

        private CalculationManager calculationManager=new CalculationManager();

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
            Console.WriteLine(isCantilever.ToString());
            
            if (CheckWallData())
            {
                double parse_groundElevation = Double.Parse(GroundElevation);
                double parse_groundWaterDepth = Double.Parse(GroundWaterDepth);
                double parse_openWaterLevel = Double.Parse(OpenWaterLevel);
                double parse_MudlineDepth = Double.Parse(MudlineDepth);
                double parse_MudlineSlope = Double.Parse(MudlineSlope);
                double parse_OpenWaterLevel = Double.Parse(OpenWaterLevel);
                double parse_wallThickness = Double.Parse(PanelThickness);
                double parse_PassiveFrictionAngle = Double.Parse(PassiveFrictionAngle);
                double parse_ActiveFrictionAngle = Double.Parse(ActiveFrictionAngle);
                double parse_LandslideSlope = Double.Parse(LandslideSlope);
                double parse_LiveSurcharge = Double.Parse(LiveSurcharge);
                double parse_Penetration = Double.Parse(Penetration);
                double parse_PilesSpacing = Double.Parse(PilesSpacing);
                double parse_SlopeBatteredPiles = Double.Parse(SlopeBatteredPiles);
                double parse_PilesLateralCapacity = Double.Parse(LateralCapacityKingPiles);
                double parse_SafetyFactor = Double.Parse(SafetyFactor);
                double parse_SaturatedSoilDensity = Double.Parse(SaturatedSoilDensity);
                double parse_SoilDensity = Double.Parse(SoilDensity);
                double parse_SoilToWallFrictionAngle = Double.Parse(SoilToWallFrictionAngle);
                double parse_TopOfPile = Double.Parse(TopOfPile);
                calculationManager.CreateWall(parse_groundElevation,parse_TopOfPile,parse_MudlineDepth,parse_groundWaterDepth,parse_OpenWaterLevel,
                    parse_Penetration,parse_SoilDensity,parse_SaturatedSoilDensity,parse_ActiveFrictionAngle,parse_PassiveFrictionAngle,parse_SoilToWallFrictionAngle,parse_wallThickness,parse_LandslideSlope,
                    parse_MudlineSlope,parse_LiveSurcharge,parse_PilesSpacing,parse_SlopeBatteredPiles,parse_PilesLateralCapacity,parse_SafetyFactor,isCantilever);
                (this.MomentLoadDistribution, this.ShearLoadDistribution)=calculationManager.CalculateWall();
                this.WallElevations =calculationManager.CalculateWallDepth();
                UpdateWallForm();
                CreatePlottingSeries();
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
            LateralForceOnCap= calculationManager.LateralForceOnCap;
            MaxWallShear = calculationManager.Maximum_Wall_Shear;
            MaxWallMoment = calculationManager.Maximum_Wall_Moment;
            AxialForceinBatteredPile = calculationManager.Axial_Force_On_Pile;
            AxialForceinKingPile = calculationManager.Axial_Force_On_King_Pile;
            ActualWallPenetration = calculationManager.ActualWallPenetration;
           

        }
        private void CreatePlottingSeries()
        {
            Console.WriteLine("Wall Elevations");
            this.WallElevations.ForEach(Console.WriteLine);
            Console.WriteLine("Shear Distribution");
            this.ShearLoadDistribution.ForEach(Console.WriteLine);
            for(int i=0; i < this.WallElevations.Count; i++)
            {
                
                _WallShearSeries.Add(new DataPoint(this.WallElevations[i], this.ShearLoadDistribution[i]));
                _WallMomentSeries.Add(new DataPoint(this.WallElevations[i], this.MomentLoadDistribution[i]));
            }
        }



    }
}
