using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace SeawallCalculator
{
    [Serializable]
    class CalculationManager
    {
        private  WallModel Wall;
        public  WallModel ExistingWall;
        private DataSerializer serializer;
        public string LateralForceOnCap
        {
            get
            {
                double value = Math.Round(Wall.LateralForceonCap, 0);
                return (value.ToString());
            }
        }
        public string Maximum_Wall_Shear
        {
            get
            {
                double value = Math.Round(Wall.Max_Shear, 0);
                return (value.ToString());
            }
        }
        public string Maximum_Wall_Moment
        {
            get
            {
                double value = Math.Round(Wall.Max_Moment, 0);
                return (value.ToString());
            }
        }
        public string Axial_Force_On_Pile
        {
            get
            {
                double value = Math.Round(Wall.Axial_Force_in_Battered_Pile, 0);
                return (value.ToString());
            }
        }
        public string Axial_Force_On_King_Pile
        {
            get
            {
                double value = Math.Round(Wall.Axial_Force_in_King_Pile, 0);
                return (value.ToString());
            }
        }
        public string ActualWallPenetration
        {
            get
            {
                double value = Math.Round(Wall.Output_Penetration, 0);
                return (value.ToString());
            }
        }
        private List<double> _wallElevations;
        public List<double> WallElevations
        {
            get
            {
                return _wallElevations;
            }
            set
            {
                _wallElevations = value;
            }
        }
         
        public CalculationManager()
        {
            //Initializes data Serializer 
            serializer = new DataSerializer();
        }
        public void CreateWall(double groundElevation, double topOfPile, double mudlineDepth, double groundWaterDepth, double openWaterLevel, double penetration,double soilDensity,
         double saturatedSoilDensity, double activeFrictionAngle, double passiveFrictionAngle, double soiltoWallFrictionAngle,double panelThickness, double landslideSlope, double mudlineSlope,
         double liveSurcharge, double pilesSpacing,double slopeOfBattered, double pilesLateralCapacity, double inputSafetyFactor, bool isCantilever)
        {
            Wall = new WallModel(groundElevation, topOfPile, mudlineDepth, groundWaterDepth, openWaterLevel, penetration,soilDensity,
                    saturatedSoilDensity, activeFrictionAngle, passiveFrictionAngle, soiltoWallFrictionAngle,panelThickness, landslideSlope,
                    mudlineSlope, liveSurcharge, pilesSpacing,slopeOfBattered, pilesLateralCapacity, inputSafetyFactor, isCantilever);
        }
        public (List<double>,List<double>) CalculateWall()
        {
            return (Wall.Calculate_Wall_Load_Distributions());
        }
        public List<double> CalculateWallDepth()
        {
            return Wall.Calculate_Wall_Elevation();
        }
        public void save_file()
        {
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == true)
            {
                string path = saveFileDialog1.FileName;
                serializer.BinarySerialize(Wall, path);
            }
        }
        public void open_file()
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                this.ExistingWall = (WallModel)serializer.BinaryDeserialize(openFileDialog1.FileName);
            }
         
        }
        
    }
 
}
