using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeawallCalculator
{
    class WallModel
    {
        //Input Variables 
        private int Ground_Elevation;
        private int Top_of_Pile;
        private int Mudline_Depth;
        private int Ground_Water_Depth;
        private int Open_Water_Level;
        private int Penetration;
        private int Soil_Density;
        private int Saturated_Soil_Density;
        private double Active_Friction_Angle;
        private double Passive_Friction_Angle;
        private double Soil_to_Wall_Friction_Angle;
        private int Landslide_Slope;
        private int Mudline_Slope;
        private int Live_Surcharge;
        private int PilesSpacing;
        private int LateralCapacityPiles;
        private double TargetSafetyFactor;

        //Model Variables
        private int TieBack_Elevation {
            get
            {
                return this.Ground_Elevation - this.Top_of_Pile;
            }
        }
        private int Mudline_Elevation
        {
            get
            {
                return this.Mudline_Depth - this.Ground_Elevation;
            }
        }
        private int GroundWater_Elevation {
            get
            {
                return this.Ground_Elevation - this.Ground_Water_Depth;
            }
            
        }
        private int SeaWater_Elevation 
        {
            get
            {
                return this.Ground_Elevation - this.Open_Water_Level;
            }
        }
        private int Panel_Height
        {
            get
            {
                return this.Mudline_Depth + this.Penetration;
            }
        }
        private double Submerged_Density 
        {
            get
            {
                return this.Saturated_Soil_Density - 62.5;
            }
        }
        private double Landslide_Angle {
            get 
            {
                return Math.Atan(this.Landslide_Slope);
            } 
        }
        private double Mudline_Angle
        {
            get
            {
                return Math.Atan(this.Mudline_Slope);
            }
        }
        private double  Active_Pressure_Coefficient
        {
            get
            {
                return (Math.Pow(Math.Cos(this.Active_Friction_Angle),2)/(Math.Cos(this.Soil_to_Wall_Friction_Angle)*
                    Math.Pow((1+Math.Sqrt((Math.Sin(this.Active_Friction_Angle+this.Soil_to_Wall_Friction_Angle)*Math.Sin(this.Active_Friction_Angle-this.Landslide_Angle))/
                    (Math.Cos(this.Soil_to_Wall_Friction_Angle)*Math.Cos(this.Landslide_Angle)))),2)));
            }
        }
        private double Passive_Pressure_Coefficient 
        {
            get
            {
                return (Math.Pow(Math.Cos(this.Passive_Friction_Angle), 2) / (Math.Cos(this.Soil_to_Wall_Friction_Angle) *
                    Math.Pow((1 - Math.Sqrt((Math.Sin(this.Passive_Friction_Angle + this.Soil_to_Wall_Friction_Angle) * Math.Sin(this.Passive_Friction_Angle - this.Mudline_Angle)) /
                    (Math.Cos(this.Soil_to_Wall_Friction_Angle) * Math.Cos(this.Mudline_Angle)))), 2)));
            }
        }
        //Lateral Loads 
        private double Surcharge_Resultant_Force
        {
            get
            {
                return this.Live_Surcharge * this.Active_Pressure_Coefficient * this.Panel_Height;
            }
        }

        private double Soil_Above_GroundWater_Resultant_Force 
        {
            get
            {
                return 0.5 * this.Active_Pressure_Coefficient * this.Soil_Density*Math.Pow(this.Ground_Water_Depth,2);
            }
        }
        private double Active_Saturated_Soil_Uniform_Resultant_Force
        {
            get
            {
                return this.Active_Pressure_Coefficient * this.Ground_Water_Depth * this.Soil_Density * (this.Panel_Height - this.Ground_Water_Depth);
            }
        }
        private double Active_Saturated_Soil_Gradient_Resultant_Force
        {
            get
            {
                return 0.5 * this.Active_Pressure_Coefficient * this.Submerged_Density * Math.Pow(this.Panel_Height - this.Ground_Water_Depth, 2);
            }
        }
        private double Hydrostatic_Groundwater_Resultant_Force 
        {
            get
            {
                return (62.5 * Math.Pow(this.Panel_Height - this.Ground_Water_Depth, 2)) / 2;
            }
        }
        private double Hydrostatic_Open_Water_Resultant_Force
        {
            get
            {
                return (62.5 * Math.Pow(this.Panel_Height - this.Open_Water_Level, 2)) / 2;
            }
        }
        private double King_Pile_Resultant_Force
        {
            get
            {
                return (this.LateralCapacityPiles * 1000 / this.PilesSpacing);
            }
        }
        private double Passive_Saturated_Soil_Resultant_Force 
        {
            get
            {
                return (Math.Pow(this.Penetration, 2) * this.Passive_Pressure_Coefficient * this.Submerged_Density);
            }
        }
     

        //AT stands for "Above Toe"
        private double Surcharge_Resultant_AT
        {
            get
            {
                return this.Panel_Height / 2;
            }
        }
        private double Soil_Above_GroundWater_Resultant_AT
        {
            get
            {
                return this.Panel_Height - (2 / 3) * this.Ground_Water_Depth;
            }
        }
        private double Active_Saturated_Soil_Uniform_AT
        {
            get
            {
                return (this.Panel_Height - this.Ground_Water_Depth) / 2;
            }
        }
        private double Active_Saturated_Soil_Gradient_AF
        {
            get
            {
                return (this.Panel_Height - this.Ground_Water_Depth) / 2;
            }
        }
        private double Hydrostatic_Ground_Water_AT
        {
            get
            {
                return (this.Panel_Height - this.Ground_Water_Depth) / 3;
            }
        }
        private double Hydrostatic_Open_Water_AT
        {
            get
            {
                return (this.Panel_Height - this.Open_Water_Level) / 3;
            }
        }
        private double King_Pile_AT
        {
            get
            {
                return (this.Panel_Height - this.Top_of_Pile);
            }
        }
        private double PassiveSaturatedSoil_AT
        {
            get
            {
                return (this.Penetration / 3);
            }
        }
        
        //Collections, public collections can be sent to the frontend layer
        private List<double> Moment_At_Toe = new List<double>();
        public List<double> WallElevation = new List<double>();
        private List<double> WallHeight = new List<double>();
        private List<double> WallDepth = new List<double>();
        public List<double> WallShear = new List<double>();
        public List<double> WallMoment = new List<double>();
        

        //Output Variables
        public double Safety_Factor;
        //Constructor
        public WallModel(int GroundElevation, int TopOfPile,int MudlineDepth,
            int GroundWaterDepth,int OpenWaterLevel,int Penetration,int SaturatedSoilDensity,
            int ActiveFrictionAngle, int PassiveFrictionAngle,int SoilToWallFrictionAngle,
            int LandslideSlope, int MudlineSlope,int LiveSurcharge, int PilesSpacing, int PilesLateralCapacity,double InputSafetyFactor)
        {
            this.Ground_Elevation = GroundElevation;
            this.Top_of_Pile = TopOfPile;
            this.Mudline_Depth = MudlineDepth;
            this.Ground_Water_Depth = GroundWaterDepth;
            this.Open_Water_Level = OpenWaterLevel;
            this.Penetration = Penetration;
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
        }
        private void Calculate_Moment_At_Toe()
        {
            Moment_At_Toe.Add(this.Surcharge_Resultant_Force * this.Surcharge_Resultant_AT);
            Moment_At_Toe.Add(this.Soil_Above_GroundWater_Resultant_Force * this.Soil_Above_GroundWater_Resultant_AT);
            Moment_At_Toe.Add(this.Active_Saturated_Soil_Uniform_Resultant_Force * this.Active_Saturated_Soil_Uniform_AT);
            Moment_At_Toe.Add(this.Active_Saturated_Soil_Gradient_Resultant_Force * this.Active_Saturated_Soil_Gradient_AF);
            Moment_At_Toe.Add(this.Hydrostatic_Groundwater_Resultant_Force * this.Hydrostatic_Ground_Water_AT);
            Moment_At_Toe.Add(this.Hydrostatic_Open_Water_Resultant_Force * this.Hydrostatic_Open_Water_AT);
            Moment_At_Toe.Add(Moment_At_Toe[3] - Moment_At_Toe[4]);
            Moment_At_Toe.Add(this.King_Pile_Resultant_Force * this.King_Pile_AT);
            Moment_At_Toe.Add(this.Passive_Saturated_Soil_Resultant_Force * this.PassiveSaturatedSoil_AT);
        }
        public void Calculate_Safety_Factor()
        {
            double Resultant_Overturning_Force = Surcharge_Resultant_Force + Soil_Above_GroundWater_Resultant_Force + Active_Saturated_Soil_Uniform_Resultant_Force +
               Active_Saturated_Soil_Uniform_Resultant_Force + (Hydrostatic_Groundwater_Resultant_Force - Hydrostatic_Open_Water_Resultant_Force);
            double Factored_Passive_Saturated_Soil_Resultant_Force = this.Passive_Saturated_Soil_Resultant_Force / this.TargetSafetyFactor;
            double Restoring_Forces = this.King_Pile_Resultant_Force + Factored_Passive_Saturated_Soil_Resultant_Force;
            double Overturning_Moment = 0;
            for (int i=0; i < Moment_At_Toe.Count - 5; i++)
            {
                Overturning_Moment += Moment_At_Toe[i];
            }
            Overturning_Moment += Moment_At_Toe[6];
            double Factored_Passive_Saturated_Soil_Moment = Moment_At_Toe[Moment_At_Toe.Count] / this.TargetSafetyFactor;
            double Battered_Pile_Moment = Factored_Passive_Saturated_Soil_Moment - Overturning_Moment;
            double Battered_Pile_Resultant_AT = this.Panel_Height - this.Top_of_Pile;
            double Battered_Pile_Resultant_Force = Battered_Pile_Moment / Battered_Pile_Resultant_AT;
            double Resisting_Forces = Restoring_Forces + Battered_Pile_Resultant_Force;
            this.Safety_Factor = Resisting_Forces / Resultant_Overturning_Force;

        }
        //Wall Geometry is the base wall elevation progression across its entire height
        private void Generate_Wall_Geometry()
        {
            //TODO
        }
        //Generate_Wall_Elevations is load specific, returs the wall elevations used to calculate a specific load distribution
        private List<double> Generate_Wall_Elevations(string Case)
        {
            //TODO: Needs to return both the depth and the moment lever 
            List<double> Depth = new List<double>();
            List<double> Moment_Arm = new List<double>();
            switch (Case)
            {
                case "Surcharge":
                    Depth = this.WallDepth;
                    break;
                case "Soil":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Min(depth, this.Ground_Water_Depth));
                    break;
                case "Uniform Soil":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                    break;
                case "Gradient Soil":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                    break;
                case "Hydrostatic Ground Water":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                    break;
                case "Hydrostatic Open Water":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Max(0, depth - this.Open_Water_Level));
                    break;
                case "Factored Passive Pressure":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Max(0, depth - this.Open_Water_Level));
                    break;
                case "King and Battered Piles":
                    foreach (double depth in this.WallDepth)
                        Depth.Add(Math.Max(0, depth - this.Top_of_Pile));
                    break;
            }
            return Depth;
        }
            
        private void Calculate_Surcharge_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_Surcharge_Soil_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_Uniform_Soil_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_Gradient_Soil_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_Hydrostatic_Ground_Water_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_Hydrostatic_Open_Water_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_Passive_Pressure_Load_Distribution()
        {
            //TODO
        }
        private void Calculate_King_Battered_Pile()
        {
            //TODO 
        }
        public void Calculate_Wall_Load_Distributions()
        {
            Generate_Wall_Geometry();
            Calculate_Surcharge_Load_Distribution();
            Calculate_Surcharge_Soil_Load_Distribution();
            Calculate_Uniform_Soil_Load_Distribution();
            Calculate_Gradient_Soil_Load_Distribution();
            Calculate_Hydrostatic_Ground_Water_Load_Distribution();
            Calculate_Hydrostatic_Open_Water_Load_Distribution();
            Calculate_Passive_Pressure_Load_Distribution();
            Calculate_King_Battered_Pile();
        }


    }
}
