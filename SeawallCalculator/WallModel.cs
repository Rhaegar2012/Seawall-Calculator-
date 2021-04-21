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
        private double TieBack_Elevation {
            get
            {
                return this.Ground_Elevation - this.Top_of_Pile;
            }
        }
        private double Mudline_Elevation
        {
            get
            {
                return this.Mudline_Depth - this.Ground_Elevation;
            }
        }
        private double GroundWater_Elevation {
            get
            {
                return this.Ground_Elevation - this.Ground_Water_Depth;
            }
            
        }
        private double SeaWater_Elevation 
        {
            get
            {
                return this.Ground_Elevation - this.Open_Water_Level;
            }
        }
        private double Panel_Height
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
        private double Battered_Pile_Resultant_Force { get; set; }

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
        private List<double> Moment_At_Toe = new List<double>();
        public List<double> WallElevation = new List<double>();
        private List<double> WallHeight = new List<double>();
        private List<double> WallDepth = new List<double>();
        public List<double> WallShear = new List<double>();
        public List<double> WallMoment = new List<double>();

        //Output Variables to be displayed on the View
        public double LateralForceonCap 
        {
            get 
            {
                return this.Battered_Pile_Resultant_Force;
            }
        }
        public double Max_Shear 
        {
            get
            {
                double max_value = this.FindMaxValue(WallShear);
                return max_value;
            }
        }
        public double Max_Moment
        {
            get
            {
                double max_value = this.FindMaxValue(WallMoment);
                return max_value;
            }
        }
        public double Axial_Force_in_Battered_Pile 
        {
            get
            {
                double value = Math.Sqrt(Math.Pow(12, 2) + Math.Pow(this.PilesSpacing, 2)) / (this.SlopeOfBatteredPiles) * (this.LateralForceonCap) * (this.PilesSpacing / 1000);
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
      
        //Output Variables
        public double Safety_Factor;
        //Constructor
        public WallModel(double GroundElevation, double TopOfPile,double MudlineDepth,
            double GroundWaterDepth,double OpenWaterLevel,double Penetration,double SaturatedSoilDensity,
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
            this.Battered_Pile_Resultant_Force = Battered_Pile_Moment / Battered_Pile_Resultant_AT;
            double Resisting_Forces = Restoring_Forces + Battered_Pile_Resultant_Force;
            this.Safety_Factor = Resisting_Forces / Resultant_Overturning_Force;

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
                this.WallDepth.Add(this.Panel_Height-this.WallHeight[i]);
            }

        }
        //Generate_Wall_Elevations is load specific, returs the wall elevations used to calculate a specific load distribution
        private (List<double>,List<double>) Generate_Wall_Elevations(string Case  )
        {
            //TODO: Needs to return both the depth and the moment lever 
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
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                        Moment_Arm.Add((1 / 2) * (Math.Max(0, depth - this.Ground_Water_Depth)));
                    }
                    break;
                case "Gradient Soil":
                    foreach (double depth in this.WallDepth)
                    {
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                        Moment_Arm.Add((1 / 3) * (Math.Max(0, depth - this.Ground_Water_Depth)));
                    }
                    break;
                case "Hydrostatic Ground Water":
                    foreach (double depth in this.WallDepth)
                    {
                        Depth.Add(Math.Max(0, depth - this.Ground_Water_Depth));
                        Moment_Arm.Add((1 / 3) * (Math.Max(0, depth - this.Ground_Water_Depth)));
                    }

                    break;
                case "Hydrostatic Open Water":
                    foreach (double depth in this.WallDepth)
                    {
                        Depth.Add(Math.Max(0, depth - this.Open_Water_Level));
                        Moment_Arm.Add((1 / 3) * (Math.Max(0, depth - this.Open_Water_Level)));
                    }
                    break;
                case "Factored Passive Pressure":
                    foreach (double depth in this.WallDepth)
                    {
                        Depth.Add(Math.Max(0, depth - this.Mudline_Depth));
                        Moment_Arm.Add((1 / 3) * Math.Max(0, depth - this.Mudline_Depth));
                    }
                    Depth.ForEach(Console.WriteLine);
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

                double Force = (Depth[i] * this.Active_Pressure_Coefficient * this.Submerged_Density);
                ShearForce.Add(Force);
                Moment.Add(Force * MomentArm[i]);
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
            this.WallDepth.ForEach(Console.WriteLine);
            this.WallHeight.ForEach(Console.WriteLine);
            this.WallElevation.ForEach(Console.WriteLine);
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
            
            TotalWallShear.ForEach(Console.WriteLine);
            this.WallShear = TotalWallShear;
            this.WallMoment = TotalWallMoment;
            return (TotalWallShear, TotalWallMoment);
        }



    }
}
