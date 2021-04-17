namespace Tefter.DbEntities.Helper
{
    using System;

    public class JsonData
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Километри
        /// </summary>
        public int Kilometers { get; set; }

        /// <summary>
        /// Масло
        /// </summary>
        public string Oil { get; set; }

        /// <summary>
        /// Следваща смяна
        /// </summary>
        public string NextChange { get; set; }

        /// <summary>
        /// Маслен филтър
        /// </summary>
        public string OilFilter { get; set; }

        /// <summary>
        /// Горивен филтър
        /// </summary>
        public string FuelFilter { get; set; }

        /// <summary>
        /// Въздушен филтър
        /// </summary>
        public string AirFilter { get; set; }

        /// <summary>
        /// Филтър купе
        /// </summary>
        public string CoupeFilter { get; set; }
    }
}
