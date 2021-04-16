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
        public CalculationManager()
        {
               
        }
        public void CreateWall(int groundElevation, int topOfPile, int mudlineDepth, int groundWaterDepth, int openWaterLevel, int penetration,
         int saturatedSoilDensity, int activeFrictionAngle, int passiveFrictionAngle, int soiltoWallFrictionAngle, int landslideSlope, int mudlineSlope,
         int liveSurcharge, int pilesSpacing, int pilesLateralCapacity, double inputSafetyFactor, bool isCantilever)
        {
            Wall = new WallModel(groundElevation, topOfPile, mudlineDepth, groundWaterDepth, openWaterLevel, penetration,
                    saturatedSoilDensity, activeFrictionAngle, passiveFrictionAngle, soiltoWallFrictionAngle, landslideSlope,
                    mudlineSlope, liveSurcharge, pilesSpacing, pilesLateralCapacity, inputSafetyFactor, isCantilever);
        }
        public void CalculateWall()
        {
            //TODO
        }
    }
 
}
