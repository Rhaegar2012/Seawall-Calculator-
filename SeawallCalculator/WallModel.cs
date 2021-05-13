using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeawallCalculator
{
    class WallModel:ListFunctions
    {
        //Input Variables 
        private double Ground_Elevation;
        private double Top_of_Pile;
        private double Mudline_Depth;
        private double Ground_Water_Depth;
        private double Open_Water_Level;
        private double Penetration;
        private double Soil_Density;
        private double Saturated_Soil_Density;
        private double Panel_Thickness;
        private double Active_Friction_Angle;
        private double Passive_Friction_Angle;
        private double Soil_to_Wall_Friction_Angle;
        private double Landslide_Slope;
        private double Mudline_Slope;
        private double Live_Surcharge;
        private double PilesSpacing;
        private double SlopeOfBatteredPiles;
        private double LateralCapacityPiles;
        private double TargetSafetyFactor;
        private bool Cantilever;

        //Model Variables
        private double _tieBack_Elevation;
        private double TieBack_Elevation {
            get
            {
                return _tieBack_Elevation=this.Ground_Elevation - this.Top_of_Pile;
            }
            set
            {
                _tieBack_Elevation = value;
            }
        }
        private double _mudline_Elevation;
        private double Mudline_Elevation
        {
            get
            {
                return _mudline_Elevation= this.Mudline_Depth - this.Ground_Elevation;
            }
            set
            {
                _mudline_Elevation = value;
            }
        }
        private double _groundWater_Elevation;
        private double GroundWater_Elevation {
            get
            {
                return _groundWater_Elevation= this.Ground_Elevation - this.Ground_Water_Depth;
            }
            set
            {
                _groundWater_Elevation = value;
            }
            
        }
        private double _seaWater_Elevation;
        private double SeaWater_Elevation 
        {
            get
            {
                return _seaWater_Elevation=this.Ground_Elevation - this.Open_Water_Level;
            }
            set
            {
                _seaWater_Elevation = value;
            }
        }
        private double _panel_Height;
        private double Panel_Height
        {
            get
            {
                return this.Mudline_Depth + this.Penetration;
            }
            set
            {
                _panel_Height = value;
            }
        }
        private double _submerged_Density;
        private double Submerged_Density 
        {
            get
            {
                return _submerged_Density=this.Saturated_Soil_Density - 62.5;
            }
            set
            {
                _submerged_Density = value;
            }
        }
        private double _landslide_Angle;
        private double Landslide_Angle {
            get 
            {
                return _landslide_Angle=Math.Atan(this.Landslide_Slope);
            }
            set
            {
                _landslide_Angle = value;
            }
        }
        private double _mudline_Angle;
        private double Mudline_Angle
        {
            get
            {
                return _mudline_Angle=Math.Atan(this.Mudline_Slope);
            }
            set
            {
                _mudline_Angle = value;
            }
        }
        private double _active_Pressure_Coefficient;
        private double  Active_Pressure_Coefficient
        {
            get
            {
                return _active_Pressure_Coefficient=(Math.Pow(Math.Cos(this.Active_Friction_Angle),2)/(Math.Cos(this.Soil_to_Wall_Friction_Angle)*
                    Math.Pow((1+Math.Sqrt((Math.Sin(this.Active_Friction_Angle+this.Soil_to_Wall_Friction_Angle)*Math.Sin(this.Active_Friction_Angle-this.Landslide_Angle))/
                    (Math.Cos(this.Soil_to_Wall_Friction_Angle)*Math.Cos(this.Landslide_Angle)))),2)));
            }
            set
            {
                _active_Pressure_Coefficient = value;
            }
        }
        private double _passive_Pressure_Coefficient;
        private double Passive_Pressure_Coefficient 
        {
            get
            {
                return (Math.Pow(Math.Cos(this.Passive_Friction_Angle), 2) / (Math.Cos(this.Soil_to_Wall_Friction_Angle) *
                    Math.Pow((1 - Math.Sqrt((Math.Sin(this.Passive_Friction_Angle + this.Soil_to_Wall_Friction_Angle) * Math.Sin(this.Passive_Friction_Angle - this.Mudline_Angle)) /
                    (Math.Cos(this.Soil_to_Wall_Friction_Angle) * Math.Cos(this.Mudline_Angle)))), 2)));
            }
            set
            {
                _passive_Pressure_Coefficient = value;
            }
        }
        //Lateral Loads 
        private double _surcharge_Resultant_Force;
        private double Surcharge_Resultant_Force
        {
            get
            {
                return _surcharge_Resultant_Force=this.Live_Surcharge * this.Active_Pressure_Coefficient * this.Panel_Height;
            }
            set
            {
                _surcharge_Resultant_Force = value;
            }
        }
        private double _soil_Above_Groundwater_Resultant_Force;
        private double Soil_Above_GroundWater_Resultant_Force 
        {
            get
            {
                return _soil_Above_Groundwater_Resultant_Force=0.5 * this.Active_Pressure_Coefficient * this.Soil_Density*Math.Pow(this.Ground_Water_Depth,2);
            }
            set
            {
                _soil_Above_Groundwater_Resultant_Force = value;
            }
        }
        private double _active_Saturated_Soul_Uniform_Resultant_Force;
        private double Active_Saturated_Soil_Uniform_Resultant_Force
        {
            get
            {
                return _active_Saturated_Soul_Uniform_Resultant_Force=this.Active_Pressure_Coefficient * this.Ground_Water_Depth * this.Soil_Density * (this.Panel_Height - this.Ground_Water_Depth);
            }
            set
            {
                _active_Saturated_Soul_Uniform_Resultant_Force = value;
            }
        }
        private double _active_Saturated_Soil_Gradient_Resultant_Force;
        private double Active_Saturated_Soil_Gradient_Resultant_Force
        {
            get
            {
                return 0.5 * this.Active_Pressure_Coefficient * this.Submerged_Density * Math.Pow(this.Panel_Height - this.Ground_Water_Depth, 2);
            }
            set
            {
                _active_Saturated_Soil_Gradient_Resultant_Force = value;
            }
        }
        private double _hydrostatic_Groundwater_Resultant_Force;
        private double Hydrostatic_Groundwater_Resultant_Force 
        {
            get
            {
                return (62.5 * Math.Pow(this.Panel_Height - this.Ground_Water_Depth, 2)) / 2;
            }
            set
            {
                _hydrostatic_Groundwater_Resultant_Force = value;
            }
        }
        private double _hydrostatic_Open_Water_Resultant_Force;
        private double Hydrostatic_Open_Water_Resultant_Force
        {
            get
            {
                return _hydrostatic_Open_Water_Resultant_Force= (62.5 * Math.Pow(this.Panel_Height - this.Open_Water_Level, 2)) / 2;
            }
            set
            {
                _hydrostatic_Open_Water_Resultant_Force = value;
            }
        }
        private double _total_Hydrostatic_Resultant_Force;
        private double Total_Hydrostatic_Resultant_Force
        {
            get
            {
                return _total_Hydrostatic_Resultant_Force = this.Hydrostatic_Groundwater_Resultant_Force -
                    this.Hydrostatic_Open_Water_Resultant_Force;
            }
            set
            {
                _total_Hydrostatic_Resultant_Force = value;
            }
        }
        private double _king_Pile_Resultant_Force;
        private double King_Pile_Resultant_Force
        {
            get
            {
                return _king_Pile_Resultant_Force=(this.LateralCapacityPiles * 1000 / this.PilesSpacing);
            }
            set
            {
                _king_Pile_Resultant_Force = value;
            }
        }
        private double _passive_Saturated_Soil_Resultant_Force;
        private double Passive_Saturated_Soil_Resultant_Force 
        {
            get
            {
                return _passive_Saturated_Soil_Resultant_Force=0.5*(Math.Pow(this.Penetration, 2) * this.Passive_Pressure_Coefficient * this.Submerged_Density);
            }
            set
            {
                _passive_Saturated_Soil_Resultant_Force=value;
            }
        }
        private double _battered_Pile_Resultant_Force;
        private double Battered_Pile_Resultant_Force {
            get
            {
                return _battered_Pile_Resultant_Force;
            }
            set
            {
                _battered_Pile_Resultant_Force = value;
            }
        }

        //AT stands for "Above Toe"
        private double _surcharge_Resultant_AT;
        private double Surcharge_Resultant_AT
        {
            get
            {
                return _surcharge_Resultant_AT=this.Panel_Height / 2;
            }
            set
            {
                _surcharge_Resultant_AT = value;
            }
        }
        private double _soil_Above_Groundwater_Resultant_AT;
        private double Soil_Above_GroundWater_Resultant_AT
        {
            get
            {
                double result = this.Panel_Height - (0.67 * this.Ground_Water_Depth);
                return _soil_Above_Groundwater_Resultant_AT=result;
            }
            set
            {
                _soil_Above_Groundwater_Resultant_AT = value;
            }
        }
        private double _active_Saturated_Soil_Uniform_AT;
        private double Active_Saturated_Soil_Uniform_AT
        {
            get
            {
                return _active_Saturated_Soil_Uniform_AT=(this.Panel_Height - this.Ground_Water_Depth) / 2;
            }
            set
            {
                _active_Saturated_Soil_Uniform_AT = value;
            }
        }
        private double _active_Saturated_Soil_Gradient_AF;
        private double Active_Saturated_Soil_Gradient_AF
        {
            get
            {
                return _active_Saturated_Soil_Gradient_AF=(this.Panel_Height - this.Ground_Water_Depth) / 3;
            }
            set
            {
                _active_Saturated_Soil_Gradient_AF = value;
            }
        }
        private double _hydrostatic_Ground_Water_AT;
        private double Hydrostatic_Ground_Water_AT
        {
            get
            {
                return _hydrostatic_Ground_Water_AT=(this.Panel_Height - this.Ground_Water_Depth) / 3;
            }
            set
            {
                _hydrostatic_Ground_Water_AT = value;
            }
        }
        private double _hydrostatic_Open_Water_AT;
        private double Hydrostatic_Open_Water_AT
        {
            get
            {
                return _hydrostatic_Open_Water_AT= (this.Panel_Height - this.Open_Water_Level) / 3;
            }
            set
            {
                _hydrostatic_Open_Water_AT = value;
            }
        }
        private double _king_Pile_AT;
        private double King_Pile_AT
        {
            get
            {
                return _king_Pile_AT=(this.Panel_Height - this.Top_of_Pile);
            }
            set
            {
                _king_Pile_AT = value;
            }
        }
        private double _passiveSaturatedSoil_AT;
        private double PassiveSaturatedSoil_AT
        {
            get
            {
                return _passiveSaturatedSoil_AT=(this.Penetration / 3);
            }
            set
            {
                _passiveSaturatedSoil_AT = value;
            }
        }

        //Resultant Vertical Forces
        private double Panels_Weight
        {
            get
            {
                return this.Panel_Thickness / 12 * 150 * this.Panel_Height;
            }
        }
        private double Friction_Force
        {
            get
            {
                double value = (Surcharge_Resultant_Force + Soil_Above_GroundWater_Resultant_Force + Active_Saturated_Soil_Uniform_Resultant_Force +
                    Active_Saturated_Soil_Gradient_Resultant_Force + Passive_Saturated_Soil_Resultant_Force) * Math.Tan(this.Soil_to_Wall_Friction_Angle);
                return value;
            }
        }
        private double Vertical_Force
        {
            get
            {
                double value = 0.6 * this.Panels_Weight + this.Friction_Force;
                return value;
            }
        }
        //Collections, public collections can be sent to the frontend layer
        private Dictionary<string, double> Moment_At_Toe = new Dictionary<string,double>();
        public List<double> WallElevation = new List<double>();
        private List<double> WallHeight = new List<double>();
        private List<double> WallDepth = new List<double>();
        private List<double> ReversedDepth = new List<double>();
        public List<double> WallShear = new List<double>();
        public List<double> WallMoment = new List<double>();

        //Output Variables to be displayed on the View
        private double _LateralForceOnCap;
        public double LateralForceonCap 
        {
            get 
            {
                return this.Battered_Pile_Resultant_Force;
            }
            set
            {
                _LateralForceOnCap = value;
            }
        }
        public double Max_Shear 
        {
            get
            {
                double max_value = this.FindMaxValue(this.WallShear);
                return max_value;
            }
        }
        public double Max_Moment
        {
            get
            {
                double max_value = this.FindMaxValue(this.WallMoment);
                return max_value;
            }
        }
        public double Axial_Force_in_Battered_Pile 
        {
            get
            {
                double value = (Math.Sqrt(Math.Pow(12, 2) + Math.Pow(this.SlopeOfBatteredPiles, 2))) / (this.SlopeOfBatteredPiles) * (this.LateralForceonCap) * (this.PilesSpacing)/1000 ;
                return value;
            }
            
        }
        public double Axial_Force_in_King_Pile
        {
            get
            {
                double value =Math.Abs( this.Axial_Force_in_Battered_Pile * 12 / (Math.Sqrt(Math.Pow(12, 2) + Math.Pow(this.SlopeOfBatteredPiles, 2))) - (this.PilesSpacing * this.Vertical_Force) / 1000);
                return value;
            }
        }
        public double Output_Penetration
        {
            get
            {
                return this.Penetration;
            }
        }
      
        //Output Variables
        public double Safety_Factor;
        //Constructor
        public WallModel(double GroundElevation, double TopOfPile,double MudlineDepth,
            double GroundWaterDepth,double OpenWaterLevel,double Penetration,double SoilDensity,double SaturatedSoilDensity,
            double ActiveFrictionAngle, double PassiveFrictionAngle,double SoilToWallFrictionAngle,double panelThickness,
            double LandslideSlope, double MudlineSlope,double LiveSurcharge, 
            double PilesSpacing, double SlopeOfBattered, double PilesLateralCapacity,double InputSafetyFactor,bool isCantilever)
        {
            this.Ground_Elevation = GroundElevation;
            this.Top_of_Pile = TopOfPile;
            this.Mudline_Depth = MudlineDepth;
            this.Ground_Water_Depth = GroundWaterDepth;
            this.Open_Water_Level = OpenWaterLevel;
            this.Panel_Thickness = panelThickness;
            this.Penetration = Penetration;
            this.Soil_Density = SoilDensity;
            this.Saturated_Soil_Density = SaturatedSoilDensity;
            this.Active_Friction_Angle = ActiveFrictionAngle*Math.PI/180;
            this.Passive_Friction_Angle = PassiveFrictionAngle*Math.PI/180;
            this.Soil_to_Wall_Friction_Angle = SoilToWallFrictionAngle * Math.PI / 180;
            this.Landslide_Slope = LandslideSlope;
            this.Mudline_Slope = MudlineSlope;
            this.Live_Surcharge = LiveSurcharge;
            this.PilesSpacing = PilesSpacing;
            this.LateralCapacityPiles = PilesLateralCapacity;
            this.TargetSafetyFactor = InputSafetyFactor;
            this.Cantilever = isCantilever;
            this.SlopeOfBatteredPiles = SlopeOfBattered;
        }
        private void Calculate_Moment_At_Toe()
        {
            Moment_At_Toe.Add("Surcharge Moment",this.Surcharge_Resultant_Force * this.Surcharge_Resultant_AT);
            Moment_At_Toe.Add("Soil above Groundwater Moment",this.Soil_Above_GroundWater_Resultant_Force * this.Soil_Above_GroundWater_Resultant_AT);
            Moment_At_Toe.Add("Active Saturated Soil Uniform Moment",this.Active_Saturated_Soil_Uniform_Resultant_Force * this.Active_Saturated_Soil_Uniform_AT);
            Moment_At_Toe.Add("Active Saturated Soil Gradient Moment",this.Active_Saturated_Soil_Gradient_Resultant_Force * this.Active_Saturated_Soil_Gradient_AF);
            Moment_At_Toe.Add("Hydrostatic Groundwater Moment",this.Hydrostatic_Groundwater_Resultant_Force * this.Hydrostatic_Ground_Water_AT);
            Moment_At_Toe.Add("Hydrostatic Open Water Moment",this.Hydrostatic_Open_Water_Resultant_Force * this.Hydrostatic_Open_Water_AT);
            Moment_At_Toe.Add("Total Hydrostatic Moment",Moment_At_Toe["Hydrostatic Groundwater Moment"] - Moment_At_Toe["Hydrostatic Open Water Moment"]);
            Moment_At_Toe.Add("King Pile Moment",this.King_Pile_Resultant_Force * this.King_Pile_AT);
            Moment_At_Toe.Add("Passive Saturated Soil Moment", this.Passive_Saturated_Soil_Resultant_Force * this.PassiveSaturatedSoil_AT);
        }
       
        //Penetration Calculation
        private void UpdatePanelHeight(double penetration)
        {
            this.Panel_Height = penetration + this.Mudline_Depth;
        }
        private void UpdateLateralForces(double penetration)
        {
            UpdatePanelHeight(penetration);
            this.Surcharge_Resultant_Force = this.Active_Pressure_Coefficient * this.Panel_Height * this.Live_Surcharge;
            this.Soil_Above_GroundWater_Resultant_Force = 0.5 * Math.Pow(this.Ground_Water_Depth, 2) * this.Soil_Density*this.Active_Pressure_Coefficient;
            this.Active_Saturated_Soil_Uniform_Resultant_Force = this.Active_Pressure_Coefficient * this.Ground_Water_Depth * (this.Panel_Height - this.Ground_Water_Depth);
            this.Active_Saturated_Soil_Gradient_Resultant_Force = 0.5 * this.Active_Pressure_Coefficient * this.Submerged_Density * Math.Pow((this.Panel_Height - this.Ground_Water_Depth), 2);
            this.Hydrostatic_Groundwater_Resultant_Force = this.Submerged_Density * Math.Pow((this.Panel_Height - this.Ground_Water_Depth), 2) / 2;
            this.Hydrostatic_Open_Water_Resultant_Force = this.Submerged_Density * Math.Pow((this.Panel_Height - this.Open_Water_Level), 2) / 2;
            this.Total_Hydrostatic_Resultant_Force = this.Hydrostatic_Groundwater_Resultant_Force - this.Hydrostatic_Open_Water_Resultant_Force;
            this.Passive_Saturated_Soil_Resultant_Force = 0.5 * this.Passive_Pressure_Coefficient * this.Submerged_Density * Math.Pow(this.Penetration, 2);
            
        }
        private void UpdateResultantAboveToe(double penetration)
        {
            UpdatePanelHeight(penetration);
            this.Surcharge_Resultant_AT = this.Panel_Height / 2;
            this.Soil_Above_GroundWater_Resultant_AT = this.Panel_Height - (2 / 3) * this.Ground_Water_Depth;
            this.Active_Saturated_Soil_Uniform_AT = (this.Panel_Height - this.Ground_Water_Depth) / 2;
            this.Active_Saturated_Soil_Gradient_AF = (this.Panel_Height - this.Ground_Water_Depth) / 3;
            this.Hydrostatic_Ground_Water_AT = (this.Panel_Height - this.Ground_Water_Depth) / 3;
            this.Hydrostatic_Open_Water_AT = (this.Panel_Height - this.Open_Water_Level) / 3;
            this.King_Pile_AT = this.Panel_Height - this.Top_of_Pile;
            this.PassiveSaturatedSoil_AT = this.Penetration / 3;
        }
        private double CalculateOverturningLoads()
        {
            double Surcharge_Moment = Moment_At_Toe["Surcharge Moment"];
            double Soil_GroundWater_Moment = Moment_At_Toe["Soil above Groundwater Moment"];
            double Active_Saturated_Soil_Uniform_Moment = Moment_At_Toe["Active Saturated Soil Uniform Moment"];
            double Active_Saturated_Soil_Gradient_Moment = Moment_At_Toe["Active Saturated Soil Gradient Moment"];
            double Total_Hydrostatic_Moment = Moment_At_Toe["Total Hydrostatic Moment"];
            double OverturningLoad = Moment_At_Toe["Surcharge Moment"] +
                Moment_At_Toe["Soil above Groundwater Moment"] +
                Moment_At_Toe["Active Saturated Soil Uniform Moment"] +
                Moment_At_Toe["Active Saturated Soil Gradient Moment"] +
                Moment_At_Toe["Total Hydrostatic Moment"];
            return OverturningLoad;
        }
        private double CalculateRestoringForce()
        {
            double RestoringForce = Moment_At_Toe["King Pile Moment"] +
                Moment_At_Toe["Passive Saturated Soil Moment"] / this.TargetSafetyFactor;
            return RestoringForce;
        }
        private double CalculateTiedOverturningForces()
        {
            double OverturningForce = this.Surcharge_Resultant_Force + this.Soil_Above_GroundWater_Resultant_Force +
                this.Active_Saturated_Soil_Gradient_Resultant_Force + this.Active_Saturated_Soil_Uniform_Resultant_Force + this.Total_Hydrostatic_Resultant_Force;
            return OverturningForce;

        }
        private double CalculateTiedRestoringForce()
        {
            double RestoringForce = (this.Passive_Saturated_Soil_Resultant_Force / this.TargetSafetyFactor)+this.King_Pile_Resultant_Force+
                (CalculateOverturningLoads()-CalculateRestoringForce())/(this.Panel_Height-this.Top_of_Pile);
            return RestoringForce;
            
        }
   
        public void CantileverWallPenetration()
        {
            double tolerance = 0.0001;
            Calculate_Moment_At_Toe();
            double ForceOnCap =(CalculateOverturningLoads()- CalculateRestoringForce())/(this.Panel_Height-this.Top_of_Pile);
            if (ForceOnCap > tolerance)
            {
                
                this.Penetration = this.Penetration + 0.01;
                UpdateLateralForces(this.Penetration);
                UpdateResultantAboveToe(this.Penetration);
                Moment_At_Toe.Clear();
                CantileverWallPenetration();
            }

        }
        private void SupportedWallPenetration()
        {
           
            Calculate_Moment_At_Toe();
            double RestoringForce = CalculateTiedRestoringForce();
            double OverturningForce = CalculateTiedOverturningForces();
            this.Safety_Factor = (RestoringForce / OverturningForce);
            double BatteredPileMoment = OverturningForce - RestoringForce;
            double ForceOnCap = BatteredPileMoment / (this.Panel_Height - this.Top_of_Pile);
            this.LateralForceonCap = ForceOnCap;
            this.Battered_Pile_Resultant_Force = ForceOnCap;
            if (this.Safety_Factor <1)
            {
                this.Penetration = this.Penetration + 0.01;
                UpdateLateralForces(this.Penetration);
                UpdateResultantAboveToe(this.Penetration);
                Moment_At_Toe.Clear();
                SupportedWallPenetration();
            }
        }

        //Wall Geometry is the base wall elevation progression across its entire height
        private void Generate_Wall_Geometry()
        {
            double index = this.Panel_Height;
            this.WallHeight.Add(index);
            while (index > 0.01)
            {
                index = index - this.Panel_Height / 20;
                this.WallHeight.Add(index);
            }
            for(int i=0; i < this.WallHeight.Count; i++)
            {
                double currentHeight = this.WallHeight[i];
                double wallDepth = this.Panel_Height - currentHeight;
                this.WallDepth.Add(wallDepth);
            }

        }
        //Generate_Wall_Elevations is load specific, returs the wall elevations used to calculate a specific load distribution
        private (List<double>,List<double>) Generate_Wall_Elevations(string Case  )
        {
           
            List<double> Depth = new List<double>();
            List<double> Moment_Arm = new List<double>();
            switch (Case)
            {
                case "Surcharge":
                    Depth = this.WallDepth;
                    foreach (double depth in Depth)
                        Moment_Arm.Add(depth / 2);
                    break;
                case "Soil":
                    foreach (double depth in this.WallDepth)
                    {
                        Depth.Add(Math.Min(depth, this.Ground_Water_Depth));
                        Moment_Arm.Add((2 / 3) * (Math.Max(0, depth - this.Ground_Water_Depth)));
                    }
                    break;
                case "Uniform Soil":
                    foreach (double depth in this.WallDepth)
                    {
                        double DeltaDepth = depth - this.Ground_Water_Depth;
                        double EffectiveDepth = Math.Max(0, DeltaDepth);
                        double momentArm = EffectiveDepth / 2;
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                        Moment_Arm.Add(momentArm);
                    }
                    
                    break;
                case "Gradient Soil":
                    foreach (double depth in this.WallDepth)
                    {
                        double DeltaDepth = depth - this.Ground_Water_Depth;
                        double EffectiveDepth = Math.Max(0, DeltaDepth);
                        double momentArm = EffectiveDepth / 3;
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                        Moment_Arm.Add(momentArm);
                    }
                    break;
                case "Hydrostatic Ground Water":
                    foreach (double depth in this.WallDepth)
                    {
                        double DeltaDepth = depth - this.Ground_Water_Depth;
                        double EffectiveDepth = Math.Max(0, DeltaDepth);
                        double momentArm = EffectiveDepth / 3;
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                        Moment_Arm.Add(momentArm);
                    }

                    break;
                case "Hydrostatic Open Water":
                    foreach (double depth in this.WallDepth)
                    {
                        double DeltaDepth = depth - this.Open_Water_Level;
                        double EffectiveDepth = Math.Max(0, DeltaDepth);
                        double momentArm = EffectiveDepth / 3;
                        Depth.Add(Math.Max(0, depth - this.Open_Water_Level));
                        Moment_Arm.Add(momentArm);
                    }
                    break;
                case "Factored Passive Pressure":
                    foreach (double depth in this.WallDepth)
                    {
                        double DeltaDepth = depth - this.Mudline_Depth;
                        double EffectiveDepth = Math.Max(0, DeltaDepth);
                        double momentArm = EffectiveDepth / 3;
                        Depth.Add(Math.Max(0, depth - this.Mudline_Depth));
                        Moment_Arm.Add(momentArm);
                    }
                    break;
                case "King and Battered Piles":
                    foreach (double depth in this.WallDepth)
                    {
                        Depth.Add(Math.Max(0, depth - this.Top_of_Pile));
                    }
                    break;
            }

            return (Depth, Moment_Arm);

        }
            
        private (List<double>,List<double>) Calculate_Surcharge_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Surcharge");
            for(int i=0;i<Depth.Count;i++)
            {

                double Force = Depth[i] * this.Active_Pressure_Coefficient * this.Live_Surcharge;
                ShearForce.Add(Force);
                Moment.Add(Force * MomentArm[i]);
            }
  
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_Soil_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Soil");
            for (int i = 0; i < Depth.Count; i++)
            {

                double Force = (Math.Pow(Depth[i],2) * this.Active_Pressure_Coefficient * this.Soil_Density)/2;
                ShearForce.Add(Force);
                Moment.Add(Force * (this.WallDepth[i]-MomentArm[i]));
            }
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_Uniform_Soil_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Uniform Soil");
            for (int i = 0; i < Depth.Count; i++)
            {
                if (Depth[i] + this.Ground_Water_Depth < this.Mudline_Depth)
                {
                    double Force = (Depth[i] * this.Active_Pressure_Coefficient * this.Submerged_Density);
                    ShearForce.Add(Force);
                    Moment.Add(Force * MomentArm[i]);
                }
                else
                {
                    double Force = (this.Active_Pressure_Coefficient * this.Soil_Density *
                        this.Ground_Water_Depth * Depth[i]);
                    ShearForce.Add(Force);
                    Moment.Add(Force * MomentArm[i]);
                }
                
            }
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_Gradient_Soil_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Gradient Soil");
            for (int i = 0; i < Depth.Count; i++)
            {

                double Force = (Math.Pow(Depth[i], 2) * this.Active_Pressure_Coefficient * this.Submerged_Density)/2;
                ShearForce.Add(Force);
                Moment.Add(Force * MomentArm[i]);
            }
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_Hydrostatic_Ground_Water_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Hydrostatic Ground Water");
            for (int i = 0; i < Depth.Count; i++)
            {

                double Force = (Math.Pow(Depth[i], 2) * 62.5) / 2;
                ShearForce.Add(Force);
                Moment.Add(Force * MomentArm[i]);
            }
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_Hydrostatic_Open_Water_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Hydrostatic Open Water");
            for (int i = 0; i < Depth.Count; i++)
            {

                double Force = (Math.Pow(Depth[i], 2) * 62.5) / 2;
                ShearForce.Add(Force);
                Moment.Add(Force * MomentArm[i]);
            }
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_Passive_Pressure_Load_Distribution()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("Factored Passive Pressure");
            for (int i = 0; i < Depth.Count; i++)
            {
                
                double Force = (Math.Pow(Depth[i], 2) * this.Passive_Pressure_Coefficient*this.Submerged_Density) / (2*TargetSafetyFactor);
                ShearForce.Add(Force);
                Moment.Add(Force * MomentArm[i]);
            }
            return (ShearForce, Moment);
        }
        private (List<double>,List<double>) Calculate_King_Battered_Pile()
        {
            List<double> ShearForce = new List<double>();
            List<double> Moment = new List<double>();
            (List<double> Depth, List<double> MomentArm) = Generate_Wall_Elevations("King and Battered Piles");
            double Force;
            for (int i = 0; i < Depth.Count; i++)
            {
                if (Depth[i] == 0)
                {
                    Force = 0;    
                }
                else
                {
                    Force = (this.King_Pile_Resultant_Force+this.Battered_Pile_Resultant_Force);  
                }
                ShearForce.Add(Force);
                Moment.Add(Force * Depth[i]);

            }
            return (ShearForce, Moment);
        }
        public (List<double>,List<double>) Calculate_Wall_Load_Distributions()
        {
            if (Cantilever)
            {
                CantileverWallPenetration();
            }
            else
            {
                SupportedWallPenetration();
            }
            
            Generate_Wall_Geometry();
            List<double> TotalWallShear = new List<double>();
            List<double> TotalWallMoment = new List<double>();
            (List<double> SurchargeShear,List<double> SurchargeMoment)=Calculate_Surcharge_Load_Distribution();
            (List<double>SoilShear,List<double>SoilMoment)=Calculate_Soil_Load_Distribution();
            (List<double>UniformSoilShear,List<double>UniformSoilMoment)=Calculate_Uniform_Soil_Load_Distribution();
            (List<double>GradientSoilShear,List<double>GradientSoilMoment)=Calculate_Gradient_Soil_Load_Distribution();
            (List<double>HydrostaticGroundWaterShear,List<double>HydrostaticGroundWaterMoment)=Calculate_Hydrostatic_Ground_Water_Load_Distribution();
            (List<double>HydrostaticOpenWaterShear,List<double>HydrostaticOpenWaterMoment)=Calculate_Hydrostatic_Open_Water_Load_Distribution();
            (List<double>PassivePressureShear,List<double>PassivePressureMoment)=Calculate_Passive_Pressure_Load_Distribution();
            (List<double>KingBatteredShearForce,List<double>KingBatteredMoment)=Calculate_King_Battered_Pile();
            for (int i=0; i < this.WallDepth.Count; i++)
            {
                
                TotalWallShear.Add(SurchargeShear[i] +
                    SoilShear[i] +
                    UniformSoilShear[i] +
                    GradientSoilShear[i] +
                    HydrostaticGroundWaterShear[i] -
                    HydrostaticOpenWaterShear[i] -
                    PassivePressureShear[i] -
                    KingBatteredShearForce[i]);
                TotalWallMoment.Add(SurchargeMoment[i] +
                    SoilMoment[i] +
                    UniformSoilMoment[i] +
                    GradientSoilMoment[i] +
                    HydrostaticGroundWaterMoment[i] -
                    HydrostaticOpenWaterMoment[i] -
                    PassivePressureMoment[i] -
                    KingBatteredMoment[i]);
            }

            Debugging_function(SurchargeShear, SurchargeMoment, SoilShear, SoilMoment, UniformSoilShear, UniformSoilMoment, GradientSoilShear, GradientSoilMoment,
                HydrostaticGroundWaterShear, HydrostaticGroundWaterMoment, HydrostaticOpenWaterShear, HydrostaticOpenWaterMoment, PassivePressureShear, PassivePressureMoment,
                KingBatteredShearForce, KingBatteredMoment);
            this.WallShear = TotalWallShear;
            this.WallMoment = TotalWallMoment;
            
            return (TotalWallShear, TotalWallMoment);
        }
        public List<double> Calculate_Wall_Elevation()
        {
            List<double> WallElevation = new List<double>();
            WallElevation.Add(this.Ground_Elevation);
            for (int i=1; i < this.WallHeight.Count; i++)
            {
                WallElevation.Add(WallElevation[i - 1] - this.WallHeight[0] / 20);
            }
            return WallElevation;
        }
        private void Debugging_function(List<double> SurchargeShear,List<double> SurchargeMoment, List<double> SoilShear,List<double> SoilMoment,
            List<double> UniformSoilShear,List<double>UniformSoilMoment,List<double>GradientSoilShear,List<double>GradientSoilMoment,
            List<double> HydrostaticGroundWaterShear,List<double> HydrostaticGroundWaterMoment,
            List<double> HydrostaticOpenWaterShear,List<double> HydrostaticOpenWaterMoment,
            List<double> PassivePressureShear,List<double> PassivePressureMoment,List<double> KingPilesShear, List<double> KingPilesMoment)
        {
            Console.WriteLine("Wall total Height");
            Console.WriteLine(this.Panel_Height);
            Console.WriteLine("Wall Height");
            this.WallHeight.ForEach(Console.WriteLine);
            Console.WriteLine("Surcharge load Shear");
            SurchargeShear.ForEach(Console.WriteLine);
            Console.WriteLine("Surcharge load Moment");
            SurchargeMoment.ForEach(Console.WriteLine);
            Console.WriteLine("Soil shear");
            SoilShear.ForEach(Console.WriteLine);
            Console.WriteLine("Soil Moment");
            SoilMoment.ForEach(Console.WriteLine);
            Console.WriteLine("Uniform Soil Shear");
            UniformSoilShear.ForEach(Console.WriteLine);
            Console.WriteLine("Uniform Soil Moment");
            UniformSoilMoment.ForEach(Console.WriteLine);
            Console.WriteLine("Gradient Soil Shear");
            GradientSoilShear.ForEach(Console.WriteLine);
            Console.WriteLine("Gradient Soil Moment");
            GradientSoilMoment.ForEach(Console.WriteLine);
            Console.WriteLine("Hydrostatic Ground Water Shear ");
            HydrostaticGroundWaterShear.ForEach(Console.WriteLine);
            Console.WriteLine("Hydrostatic GroundWater Moment");
            HydrostaticGroundWaterMoment.ForEach(Console.WriteLine);
            Console.WriteLine("Hydrostatic Open Water Shear");
            HydrostaticOpenWaterShear.ForEach(Console.WriteLine);
            Console.WriteLine("Hydrostatic Open Water Moment");
            HydrostaticOpenWaterMoment.ForEach(Console.WriteLine);
            Console.WriteLine("Passive Pressure Shear");
            PassivePressureShear.ForEach(Console.WriteLine);
            Console.WriteLine("Passive Pressure Moment");
            PassivePressureMoment.ForEach(Console.WriteLine);
            Console.WriteLine("King Pile Shear");
            KingPilesShear.ForEach(Console.WriteLine);
            Console.WriteLine("King Pile Moment");
            KingPilesMoment.ForEach(Console.WriteLine);


        }



    }
}
