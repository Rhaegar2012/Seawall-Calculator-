using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeawallCalculator
{
    class CalculationManager
    {
        private  WallModel Wall;
        public string LateralForceOnCap
        {
            get
            {
                return (Wall.LateralForceonCap.ToString());
            }
        }
        public string Maximum_Wall_Shear
        {
            get
            {
                
                return (Wall.Max_Shear.ToString());
            }
        }
        public string Maximum_Wall_Moment
        {
            get
            {
                return (Wall.Max_Moment.ToString());
            }
        }
        public string Axial_Force_On_Pile
        {
            get
            {
                return (Wall.Axial_Force_in_Battered_Pile.ToString());
            }
        }
        public string Axial_Force_On_King_Pile
        {
            get
            {
                return (Wall.Axial_Force_in_King_Pile.ToString());
            }
        }
        public CalculationManager()
        {
           //Placeholder 
        }
        public void CreateWall(double groundElevation, double topOfPile, double mudlineDepth, double groundWaterDepth, double openWaterLevel, double penetration,
         double saturatedSoilDensity, double activeFrictionAngle, double passiveFrictionAngle, double soiltoWallFrictionAngle,double panelThickness, double landslideSlope, double mudlineSlope,
         double liveSurcharge, double pilesSpacing,double slopeOfBattered, double pilesLateralCapacity, double inputSafetyFactor, bool isCantilever)
        {
            Wall = new WallModel(groundElevation, topOfPile, mudlineDepth, groundWaterDepth, openWaterLevel, penetration,
                    saturatedSoilDensity, activeFrictionAngle, passiveFrictionAngle, soiltoWallFrictionAngle,panelThickness, landslideSlope,
                    mudlineSlope, liveSurcharge, pilesSpacing,slopeOfBattered, pilesLateralCapacity, inputSafetyFactor, isCantilever);
        }
        public (List<double>,List<double>) CalculateWall()
        {
            return (Wall.Calculate_Wall_Load_Distributions());
        }
        
    }
 
}
