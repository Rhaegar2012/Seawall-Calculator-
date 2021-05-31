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
using OxyPlot.Series;
using System.Collections.ObjectModel;


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
        private ICommand m_BeamAnalyzeButton;
        public ICommand BeamAnalyzeButton
        {
            get
            {
                return m_BeamAnalyzeButton;
            }
            set
            {
                m_BeamAnalyzeButton = value;
            }
        }
        //Wall Model View
        //UI Control Properties
        private bool enableReportButton = false;
        public bool EnableReportButton
        {
            get
            {
                return enableReportButton;
            }
            set
            {
                enableReportButton = value;
                OnPropertyChanged("EnableReportButton");
            }
        }
        private bool enableWallDiagramTab = true;
        public bool EnableWallDiagramTab
        {
            get
            {
                return enableWallDiagramTab;
            }
            set
            {
                enableWallDiagramTab = value;
                OnPropertyChanged("EnableWallDiagramTab");
            }
        }
        //Project variable properties
        private string in_ProjectName;
        public string ProjectName
        {
            get
            {
                return in_ProjectName;
            }
            set
            {
                in_ProjectName = value;
            }
        }
        private string in_EngineerName;
        public string EngineerName
        {
            get
            {
                return in_EngineerName;
            }
            set
            {
                in_EngineerName = value;
                
            }
        }
        //Wall diagram variables 
        private const double Origin = 80.0;
        private const double CanvasConversionFactor = 20.0;
        private double in_DiagramGroundWaterElevation;
        public string DiagramGroundWaterElevation
        {
            get
            {
               
                double GroundWaterDepth = double.Parse(this.GroundWaterDepth);
                double in_DiagramGroundWaterElevation =Origin+GroundWaterDepth*CanvasConversionFactor;
                Console.WriteLine("Ground Water depth coordinate: " + in_DiagramGroundWaterElevation.ToString());
                return in_DiagramGroundWaterElevation.ToString();

            }
            set
            {
                in_DiagramGroundWaterElevation = double.Parse(value);
                OnPropertyChanged("DiagramGroundWaterElevation");
            }
        }
        private double in_DiagramOpenWaterElevation;
        public double DiagramOpenWaterElevation
        {
            get
            {
                double OpenWaterDepth = double.Parse(this.OpenWaterLevel);
                double in_DiagramOpenWaterElevation = Origin + OpenWaterDepth * CanvasConversionFactor;
                return in_DiagramOpenWaterElevation;
            }
            set
            {
                in_DiagramOpenWaterElevation = value;
                OnPropertyChanged("DiagramOpenWaterElevation");
            }
        }
        

        //Input constants 
        private const double Initial_Penetration= 1.0;
        
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
        //Plotting Model 
       
       private ObservableCollection <DataPoint> ShearData { get; set; }
        public PlotModel WallPlotModel;

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
        
        public ObservableCollection<DataPoint> WallShearSeries { get; private set; }=new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> WallMomentSeries { get; private set; }=new ObservableCollection<DataPoint>();
      

        private CalculationManager calculationManager=new CalculationManager();
        //Wall Schematic Variables
        private double out_SchemaWallDepth;
        public double SchemaWallDepth
        {
            get
            {
                return out_SchemaWallDepth;
            }
            set
            {
                out_SchemaWallDepth = value;
            }
        }

        //The model view constructor creates the relay command from the button objects and collects the data from the UI 
        public ModelView()
        {
            //Initializes the controls as ICommand objects 
            WallAnalyzeButton = new RelayCommand(new Action<object>(AnalyzeWall));
            WallReportButton = new RelayCommand(new Action<object>(CreateWallReport));
            BeamAnalyzeButton = new RelayCommand(new Action<object>(AnalyzeBeam));

            
            
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
            this.WallShearSeries.Clear();
            this.WallMomentSeries.Clear();
            EnableReportButton = true;
            EnableWallDiagramTab = true;
            
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
                double parse_PilesSpacing = Double.Parse(PilesSpacing);
                double parse_SlopeBatteredPiles = Double.Parse(SlopeBatteredPiles);
                double parse_PilesLateralCapacity = Double.Parse(LateralCapacityKingPiles);
                double parse_SafetyFactor = Double.Parse(SafetyFactor);
                double parse_SaturatedSoilDensity = Double.Parse(SaturatedSoilDensity);
                double parse_SoilDensity = Double.Parse(SoilDensity);
                double parse_SoilToWallFrictionAngle = Double.Parse(SoilToWallFrictionAngle);
                double parse_TopOfPile = Double.Parse(TopOfPile);
                calculationManager.CreateWall(parse_groundElevation,parse_TopOfPile,parse_MudlineDepth,parse_groundWaterDepth,parse_OpenWaterLevel,
                    Initial_Penetration,parse_SoilDensity,parse_SaturatedSoilDensity,parse_ActiveFrictionAngle,parse_PassiveFrictionAngle,parse_SoilToWallFrictionAngle,parse_wallThickness,parse_LandslideSlope,
                    parse_MudlineSlope,parse_LiveSurcharge,parse_PilesSpacing,parse_SlopeBatteredPiles,parse_PilesLateralCapacity,parse_SafetyFactor,isCantilever);
                (this.ShearLoadDistribution, this.MomentLoadDistribution)=calculationManager.CalculateWall();
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

            ReportManager report = new ReportManager(GroundElevation,GroundWaterDepth,OpenWaterLevel,MudlineSlope,
                LandslideSlope,MudlineDepth,TopOfPile,PilesSpacing,LateralCapacityKingPiles,SlopeBatteredPiles,PanelThickness,SafetyFactor,SoilDensity,
                SaturatedSoilDensity,ActiveFrictionAngle,PassiveFrictionAngle,SoilToWallFrictionAngle,LiveSurcharge,LateralForceOnCap,
                MaxWallShear,MaxWallMoment,AxialForceinBatteredPile,AxialForceinKingPile,ActualWallPenetration,ProjectName,EngineerName);
            report.CreateWallReport();
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
          
            this.WallElevations.ForEach(Console.WriteLine);
            this.ShearLoadDistribution.ForEach(Console.WriteLine);
            this.WallPlotModel = new PlotModel { Title = "Wall Load Distribution" };
            ScatterSeries shearLoad=new ScatterSeries();
            for(int i=0; i < this.WallElevations.Count; i++)
            {

               double MaxMoment = Double.Parse(this.MaxWallMoment);
               double MaxShear = Double.Parse(this.MaxWallShear);
               this.WallShearSeries.Add(new DataPoint(this.ShearLoadDistribution[i]/MaxShear,this.WallElevations[i]));
               this.WallMomentSeries.Add(new DataPoint(this.MomentLoadDistribution[i]/MaxMoment, this.WallElevations[i]));
               
            }
       
        }
        //END OF WALL MODEL VIEW 
        //CAP MODEL VIEW 
        //SPAN VISUALIZATION 
        private bool _visibilitySpanTwo;
        public bool VisibilitySpanTwo
        {
            get
            {
                return _visibilitySpanTwo;
            }
            set
            {
                _visibilitySpanTwo = value;
                OnPropertyChanged("VisibilitySpanTwo");
            }
        }
        private bool _visibilitySpanThree;
        public bool VisibilitySpanThree
        {
            get
            {
                return _visibilitySpanThree;
            }
            set
            {
                _visibilitySpanThree = value;
                OnPropertyChanged("VisibilitySpanThree");
            }
        }
        private bool _visibilitySpanFour;
        public bool VisibilitySpanFour
        {
            get
            {
                return _visibilitySpanFour;
            }
            set
            {
                _visibilitySpanFour = value;
                OnPropertyChanged("VisibilitySpanFour");
            }
        }
        private bool _visibilitySpanFive;
        public bool VisibilitySpanFive
        {
            get
            {
                return _visibilitySpanFive;
            }
            set
            {
                _visibilitySpanFive = value;
                OnPropertyChanged("VisibilitySpanFive");
            }
        }
        private string _numberOfSpans;
        public string NumberOfSpans
        {
            get
            {
                return _numberOfSpans;
            }
            set
            {

                _numberOfSpans = value;
                UpdateNumberOfSpans(_numberOfSpans);
                OnPropertyChanged("NumberOfSpans");
            }
        }
        private void UpdateNumberOfSpans(string numberOfSpans)
        {
            
            switch (numberOfSpans[numberOfSpans.Length-1].ToString())
            {
                case "1":
                    this.VisibilitySpanTwo = false;
                    this.VisibilitySpanThree = false;
                    this.VisibilitySpanFour = false;
                    this.VisibilitySpanFive = false;
                    break;

                case "2":
                    this.VisibilitySpanTwo = true;
                    this.VisibilitySpanThree = false;
                    this.VisibilitySpanFour = false;
                    this.VisibilitySpanFive = false;
                    break;
                case "3":
                    this.VisibilitySpanTwo = true;
                    this.VisibilitySpanThree = true;
                    this.VisibilitySpanFour = false;
                    this.VisibilitySpanFive = false;
                    break;
                case "4":
                    this.VisibilitySpanTwo = true;
                    this.VisibilitySpanThree = true;
                    this.VisibilitySpanFour = true;
                    this.VisibilitySpanFive = false;
                    break;
                case "5":
                    this.VisibilitySpanTwo = true;
                    this.VisibilitySpanThree = true;
                    this.VisibilitySpanFour = true;
                    this.VisibilitySpanFive = true;
                    break;
                default:
                    break;
               
            }
           

        }
        //CAP INPUT VARIABLES 
        //SPAN 1 
        private string in_SpanLength1;
        public string SpanLength1 
        {
            get
            {
                return in_SpanLength1;
            }
            set
            {
                in_SpanLength1 = value;
            }
        }
        private string in_BeamWidth1;
        public string BeamWidth1
        {
            get
            {
                return in_BeamWidth1;
            }
            set
            {
                in_BeamWidth1 = value;
            }
        }
        private string in_BeamHeight1;
        public string BeamHeight1
        {
            get
            {
                return in_BeamHeight1;
            }
            set
            {
                in_BeamHeight1 = value;
            }
        }
        private string in_DistLoad1;
        public string DistLoad1
        {
            get
            {
                return in_DistLoad1;
            }
            set
            {
                in_DistLoad1 = value;
            }
        }
        private string in_PointLoad1;
        public string PointLoad1
        {
            get
            {
                return in_PointLoad1;
            }
            set
            {
                in_PointLoad1 = value;
            }
        }
        private string in_PointLoadLocation1;
        public string PointLoadLocation1
        {
            get
            {
                return in_PointLoadLocation1;
            }
            set
            {
                in_PointLoadLocation1 = value;
            }
        }
        // SPAN 2 
        private string in_SpanLength2;
        public string SpanLength2
        {
            get
            {
                return in_SpanLength2;
            }
            set
            {
                in_SpanLength2 = value;
            }
        }
        private string in_BeamWidth2;
        public string BeamWidth2
        {
            get
            {
                return in_BeamWidth2;
            }
            set
            {
                in_BeamWidth2 = value;
            }
        }
        private string in_BeamHeight2;
        public string BeamHeight2
        {
            get
            {
                return in_BeamHeight2;
            }
            set
            {
                in_BeamHeight2 = value;
            }
        }
        private string in_DistLoad2;
        public string DistLoad2
        {
            get
            {
                return in_DistLoad2;
            }
            set
            {
                in_DistLoad2 = value;
            }
        }
        private string in_PointLoad2;
        public string PointLoad2
        {
            get
            {
                return in_PointLoad2;
            }
            set
            {
                in_PointLoad2 = value;
            }
        }
        private string in_PointLoadLocation2;
        public string PointLoadLocation2
        {
            get
            {
                return in_PointLoadLocation2;
            }
            set
            {
                in_PointLoadLocation2 = value;
            }
        }
        //SPAN 3
        private string in_SpanLength3;
        public string SpanLength3
        {
            get
            {
                return in_SpanLength3;
            }
            set
            {
                in_SpanLength3 = value;
            }
        }
        private string in_BeamWidth3;
        public string BeamWidth3
        {
            get
            {
                return in_BeamWidth3;
            }
            set
            {
                in_BeamWidth3 = value;
            }
        }
        private string in_BeamHeight3;
        public string BeamHeight3
        {
            get
            {
                return in_BeamHeight3;
            }
            set
            {
                in_BeamHeight3 = value;
            }
        }
        private string in_DistLoad3;
        public string DistLoad3
        {
            get
            {
                return in_DistLoad3;
            }
            set
            {
                in_DistLoad3 = value;
            }
        }
        private string in_PointLoad3;
        public string PointLoad3
        {
            get
            {
                return in_PointLoad3;
            }
            set
            {
                in_PointLoad3 = value;
            }
        }
        private string in_PointLoadLocation3;
        public string PointLoadLocation3
        {
            get
            {
                return in_PointLoadLocation3;
            }
            set
            {
                in_PointLoadLocation3 = value;
            }
        }
        //SPAN 4
        private string in_SpanLength4;
        public string SpanLength4
        {
            get
            {
                return in_SpanLength4;
            }
            set
            {
                in_SpanLength4 = value;
            }
        }
        private string in_BeamWidth4;
        public string BeamWidth4
        {
            get
            {
                return in_BeamWidth4;
            }
            set
            {
                in_BeamWidth4 = value;
            }
        }
        private string in_BeamHeight4;
        public string BeamHeight4
        {
            get
            {
                return in_BeamHeight4;
            }
            set
            {
                in_BeamHeight4 = value;
            }
        }
        private string in_DistLoad4;
        public string DistLoad4
        {
            get
            {
                return in_DistLoad4;
            }
            set
            {
                in_DistLoad4 = value;
            }
        }
        private string in_PointLoad4;
        public string PointLoad4
        {
            get
            {
                return in_PointLoad4;
            }
            set
            {
                in_PointLoad4 = value;
            }
        }
        private string in_PointLoadLocation4;
        public string PointLoadLocation4
        {
            get
            {
                return in_PointLoadLocation4;
            }
            set
            {
                in_PointLoadLocation4 = value;
            }
        }
        //SPAN 5
        private string in_SpanLength5;
        public string SpanLength5
        {
            get
            {
                return in_SpanLength5;
            }
            set
            {
                in_SpanLength5 = value;
            }
        }
        private string in_BeamWidth5;
        public string BeamWidth5
        {
            get
            {
                return in_BeamWidth5;
            }
            set
            {
                in_BeamWidth5 = value;
            }
        }
        private string in_BeamHeight5;
        public string BeamHeight5
        {
            get
            {
                return in_BeamHeight5;
            }
            set
            {
                in_BeamHeight5 = value;
            }
        }
        private string in_DistLoad5;
        public string DistLoad5
        {
            get
            {
                return in_DistLoad5;
            }
            set
            {
                in_DistLoad5 = value;
            }
        }
        private string in_PointLoad5;
        public string PointLoad5
        {
            get
            {
                return in_PointLoad5;
            }
            set
            {
                in_PointLoad5 = value;
            }
        }
        private string in_PointLoadLocation5;
        public string PointLoadLocation5
        {
            get
            {
                return in_PointLoadLocation5;
            }
            set
            {
                in_PointLoadLocation5 = value;
            }
        }
        //Support Condition 
        private string in_SupportCondition;
        public string SupportCondition
        {
            get
            {
                return in_SupportCondition;
            }
            set
            {
                in_SupportCondition = value;
            }
        }
        //COLLECTIONS FOR BEAM INPUT DATA 
        Dictionary<string, double> BeamSpan1 = new Dictionary<string, double>();
        Dictionary<string, double> BeamSpan2 = new Dictionary<string, double>();
        Dictionary<string, double> BeamSpan3 = new Dictionary<string, double>();
        Dictionary<string, double> BeamSpan4 = new Dictionary<string, double>();
        Dictionary<string, double> BeamSpan5 = new Dictionary<string, double>();
        // ANALYZE METHODS 
        private void ParseBeamData()
        {
            BeamSpan1.Add("Span", Double.Parse(SpanLength1));
            BeamSpan1.Add("Beam Width", Double.Parse(BeamWidth1));
            BeamSpan1.Add("Beam Height", Double.Parse(BeamHeight1));
            BeamSpan1.Add("Distributed Load", Double.Parse(DistLoad1));
            BeamSpan1.Add("Point Load", Double.Parse(PointLoad1));
            BeamSpan1.Add("Point Load Location", Double.Parse(PointLoadLocation1));
            BeamSpan2.Add("Span", Double.Parse(SpanLength2));
            BeamSpan2.Add("Beam Width", Double.Parse(BeamWidth2));
            BeamSpan2.Add("Beam Height", Double.Parse(BeamHeight2));
            BeamSpan2.Add("Distributed Load", Double.Parse(DistLoad2));
            BeamSpan2.Add("Point Load", Double.Parse(PointLoad2));
            BeamSpan2.Add("Point Load Location", Double.Parse(PointLoadLocation2));
            BeamSpan3.Add("Span", Double.Parse(SpanLength3));
            BeamSpan3.Add("Beam Width", Double.Parse(BeamWidth3));
            BeamSpan3.Add("Beam Height", Double.Parse(BeamHeight3));
            BeamSpan3.Add("Distributed Load", Double.Parse(DistLoad3));
            BeamSpan3.Add("Point Load", Double.Parse(PointLoad3));
            BeamSpan3.Add("Point Load Location", Double.Parse(PointLoadLocation3));
            BeamSpan4.Add("Span", Double.Parse(SpanLength4));
            BeamSpan4.Add("Beam Width", Double.Parse(BeamWidth4));
            BeamSpan4.Add("Beam Height", Double.Parse(BeamHeight4));
            BeamSpan4.Add("Distributed Load", Double.Parse(DistLoad4));
            BeamSpan4.Add("Point Load", Double.Parse(PointLoad4));
            BeamSpan4.Add("Point Load Location", Double.Parse(PointLoadLocation4));
            BeamSpan5.Add("Span", Double.Parse(SpanLength5));
            BeamSpan5.Add("Beam Width", Double.Parse(BeamWidth5));
            BeamSpan5.Add("Beam Height", Double.Parse(BeamHeight5));
            BeamSpan5.Add("Distributed Load", Double.Parse(DistLoad5));
            BeamSpan5.Add("Point Load", Double.Parse(PointLoad5));
            BeamSpan5.Add("Point Load Location", Double.Parse(PointLoadLocation5));
        }
        private bool CheckBeamData()
        {
           
            bool Verified = true;
            List<string> DataList = new List<string>();
            switch (NumberOfSpans[NumberOfSpans.Length - 1].ToString())
            {
                case "1":
                    DataList.Add(SpanLength1);
                    DataList.Add(BeamWidth1);
                    DataList.Add(BeamHeight1);
                    DataList.Add(DistLoad1);
                    DataList.Add(PointLoad1);
                    DataList.Add(PointLoadLocation1);
                    break;
                case "2":
                    DataList.Add(SpanLength1);
                    DataList.Add(BeamWidth1);
                    DataList.Add(BeamHeight1);
                    DataList.Add(DistLoad1);
                    DataList.Add(PointLoad1);
                    DataList.Add(PointLoadLocation1);
                    DataList.Add(SpanLength2);
                    DataList.Add(BeamWidth2);
                    DataList.Add(BeamHeight2);
                    DataList.Add(DistLoad2);
                    DataList.Add(PointLoad2);
                    DataList.Add(PointLoadLocation2);
                    break;
                case "3":
                    DataList.Add(SpanLength1);
                    DataList.Add(BeamWidth1);
                    DataList.Add(BeamHeight1);
                    DataList.Add(DistLoad1);
                    DataList.Add(PointLoad1);
                    DataList.Add(PointLoadLocation1);
                    DataList.Add(SpanLength2);
                    DataList.Add(BeamWidth2);
                    DataList.Add(BeamHeight2);
                    DataList.Add(DistLoad2);
                    DataList.Add(PointLoad2);
                    DataList.Add(PointLoadLocation2);
                    DataList.Add(SpanLength3);
                    DataList.Add(BeamWidth3);
                    DataList.Add(BeamHeight3);
                    DataList.Add(DistLoad3);
                    DataList.Add(PointLoad3);
                    DataList.Add(PointLoadLocation3);
                    break;
                case "4":
                    DataList.Add(SpanLength1);
                    DataList.Add(BeamWidth1);
                    DataList.Add(BeamHeight1);
                    DataList.Add(DistLoad1);
                    DataList.Add(PointLoad1);
                    DataList.Add(PointLoadLocation1);
                    DataList.Add(SpanLength2);
                    DataList.Add(BeamWidth2);
                    DataList.Add(BeamHeight2);
                    DataList.Add(DistLoad2);
                    DataList.Add(PointLoad2);
                    DataList.Add(PointLoadLocation2);
                    DataList.Add(SpanLength3);
                    DataList.Add(BeamWidth3);
                    DataList.Add(BeamHeight3);
                    DataList.Add(DistLoad3);
                    DataList.Add(PointLoad3);
                    DataList.Add(PointLoadLocation3);
                    DataList.Add(SpanLength4);
                    DataList.Add(BeamWidth4);
                    DataList.Add(BeamHeight4);
                    DataList.Add(DistLoad4);
                    DataList.Add(PointLoad4);
                    DataList.Add(PointLoadLocation4);
                    break;
                case "5":
                    DataList.Add(SpanLength1);
                    DataList.Add(BeamWidth1);
                    DataList.Add(BeamHeight1);
                    DataList.Add(DistLoad1);
                    DataList.Add(PointLoad1);
                    DataList.Add(PointLoadLocation1);
                    DataList.Add(SpanLength2);
                    DataList.Add(BeamWidth2);
                    DataList.Add(BeamHeight2);
                    DataList.Add(DistLoad2);
                    DataList.Add(PointLoad2);
                    DataList.Add(PointLoadLocation2);
                    DataList.Add(SpanLength3);
                    DataList.Add(BeamWidth3);
                    DataList.Add(BeamHeight3);
                    DataList.Add(DistLoad3);
                    DataList.Add(PointLoad3);
                    DataList.Add(PointLoadLocation3);
                    DataList.Add(SpanLength4);
                    DataList.Add(BeamWidth4);
                    DataList.Add(BeamHeight4);
                    DataList.Add(DistLoad4);
                    DataList.Add(PointLoad4);
                    DataList.Add(PointLoadLocation4);
                    DataList.Add(SpanLength5);
                    DataList.Add(BeamWidth5);
                    DataList.Add(BeamHeight5);
                    DataList.Add(DistLoad5);
                    DataList.Add(PointLoad5);
                    DataList.Add(PointLoadLocation5);
                    break;
                default:
                    break;
            }
            foreach (string data in DataList)
            {
                if (data == null)
                {
                    Verified = false;
                    break;
                }
                   
            }
            return Verified;


        }
        private void AnalyzeBeam(object obj)
        {
            if (CheckBeamData())
            {
                ParseBeamData();
            }
            else
            {
                MessageBox.Show("Check input variables", "Missing Input");
            }
        }



    }
}
