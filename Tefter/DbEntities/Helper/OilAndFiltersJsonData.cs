namespace Tefter.DbEntities.Helper
{
    using System;

    public class OilAndFiltersJsonData
    {
        public OilAndFiltersJsonData()
        {
        }

        public OilAndFiltersJsonData(DateTime date, string kilometers, string oil, string nextChange, string oilFilter, string fuelFilter, string airFilter, string coupeFilter)
        {
            Date = date;
            Kilometers = kilometers;
            Oil = oil;
            NextChange = nextChange;
            OilFilter = oilFilter;
            FuelFilter = fuelFilter;
            AirFilter = airFilter;
            CoupeFilter = coupeFilter;
        }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Километри
        /// </summary>
        public string Kilometers { get; set; }

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
