namespace Tefter.DbEntities.Helper
{
    public class OtherServicesJsonData
    {
        public OtherServicesJsonData()
        {
        }

        public OtherServicesJsonData(string dateMadeChanges, string kilometers, string serviceMade)
        {
            DateMadeChanges = dateMadeChanges;
            Kilometers = kilometers;
            ServiceMade = serviceMade;
        }

        /// <summary>
        /// Дата на извършения ремонт
        /// </summary>
        public string DateMadeChanges { get; set; }

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
