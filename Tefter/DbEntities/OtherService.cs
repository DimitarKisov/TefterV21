namespace Tefter.DbEntities
{
    using System;

    public class OtherService
    {
        public int Id { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Изминати километри
        /// </summary>
        public int Kilometers { get; set; }

        /// <summary>
        /// Извършена сервизна дейност
        /// </summary>
        public string ServiceCheck { get; set; }

        public string CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
