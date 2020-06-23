using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Model
{
    /// <summary>
    /// 监控值
    /// </summary>
    public class TemperatureMonitoring
    {
        /// <summary>
        /// 体温 最大值
        /// </summary>
        public double TEMPERATUREMAX { get; set; }

        /// <summary>
        /// 体温 最小值
        /// </summary>
        public double TEMPERATUREMIN { get; set; }

        /// <summary>
        /// 脉搏 最大值
        /// </summary>
        public double PULSEMAX { get; set; }

        /// <summary>
        /// 脉搏 最小值
        /// </summary>
        public double PULSEMIN { get; set; }

        /// <summary>
        /// 呼吸 最大值
        /// </summary>
        public double BREATHMAX { get; set; }

        /// <summary>
        /// 呼吸 最下值
        /// </summary>
        public double BREATHMIN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double SBPMAX { get; set; }
        public double SBPMIN { get; set; }
        public double DBPMAX { get; set; }
        public double DBPMIN { get; set; }
        public double STOOLMAX { get; set; }
        public double STOOLMIN { get; set; }
    }
}
