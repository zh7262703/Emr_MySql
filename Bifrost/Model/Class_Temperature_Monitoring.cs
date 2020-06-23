using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class Class_Temperature_Monitoring
    {

        private double temperatureMax;

        /// <summary>
        /// 监测值MAX1 体温
        /// </summary>
        public double TemperatureMax
        {
            get { return temperatureMax; }
            set { temperatureMax = value; }
        }

        private double temperatureMin;

        /// <summary>
        /// 监测值MIN1 体温
        /// </summary>
        public double TemperatureMin
        {
            get { return temperatureMin; }
            set { temperatureMin = value; }
        }

        //--------------------------2

        private double pulseMax;

        /// <summary>
        /// 监测值MAX2 脉博
        /// </summary>
        public double PulseMax
        {
            get { return pulseMax; }
            set { pulseMax = value; }
        }

        private double pulseMin;

        /// <summary>
        /// 监测值MIN2 脉博
        /// </summary>
        public double PulseMin
        {
            get { return pulseMin; }
            set { pulseMin = value; }
        }

        //--------------------------3


        private double breathMax; 

        /// <summary>
        /// 监测值MAX3 呼吸
        /// </summary>
        public double BreathMax
        {
            get { return breathMax; }
            set { breathMax = value; }
        }

        private double breathMin;

        /// <summary>
        /// 监测值MIN3 呼吸
        /// </summary>
        public double BreathMin
        {
            get { return breathMin; }
            set { breathMin = value; }
        }

        //--------------------------4
     

        private double sBPMax;

        /// <summary>
        /// 监测值MAX4 收缩压
        /// </summary>
        public double SBPMax
        {
            get { return sBPMax; }
            set { sBPMax = value; }
        }

        private double sBPMin;

        /// <summary>
        /// 监测值MIN4 收缩压
        /// </summary>
        public double SBPMin
        {
            get { return sBPMin; }
            set { sBPMin = value; }
        }

        //--------------------------5


        private double dBPMax;

        /// <summary>
        /// 监测值MIN5 舒张压
        /// </summary>
        public double DBPMax
        {
            get { return dBPMax; }
            set { dBPMax = value; }
        }

        private double dBPMin;

        /// <summary>
        /// 监测值MAX5 舒张压
        /// </summary>
        public double DBPMin
        {
            get { return dBPMin; }
            set { dBPMin = value; }
        }

       

        //--------------------------6
      

        private double stoolMax;

        /// <summary>
        /// 监测值MAX6 大便
        /// </summary>
        public double StoolMax
        {
            get { return stoolMax; }
            set { stoolMax = value; }
        }

        private double stoolMin;

        /// <summary>
        /// 监测值MIN6 大便
        /// </summary>
        public double StoolMin 
        {
            get { return stoolMin; }
            set { stoolMin = value; }
        }

    }
}
