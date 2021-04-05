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
        //Collections
        private List<double> Moment_At_Toe = new List<double>();
        //Constructor
        public WallModel(int GroundElevation, int TopOfPile,int MudlineDepth,
            int GroundWaterDepth,int OpenWaterLevel,int Penetration,int SaturatedSoilDensity,
            int ActiveFrictionAngle, int PassiveFrictionAngle,int SoilToWallFrictionAngle,
            int LandslideSlope, int MudlineSlope,int LiveSurcharge)
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
        }

    }
}
