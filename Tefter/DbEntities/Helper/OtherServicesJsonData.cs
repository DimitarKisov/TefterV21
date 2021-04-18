namespace Tefter.DbEntities.Helper
{
    using System;

    public class OtherServicesJsonData
    {
        public OtherServicesJsonData()
        {
        }

        public OtherServicesJsonData(DateTime dateMadeChanges, string kilometers, string serviceMade)
        {
            DateMadeChanges = dateMadeChanges;
            Kilometers = kilometers;
            ServiceMade = serviceMade;
        }

        /// <summary>
        /// Дата на извършения ремонт
        /// </summary>
        public DateTime DateMadeChanges { get; set; }

        /// <summary>
        /// Изминати километри
        /// </summary>
        public string Kilometers { get; set; }

        /// <summary>
        /// Извършена сервизна дейност
        /// </summary>
        public string ServiceMade { get; set; }
    }
}
