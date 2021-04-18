namespace Tefter.DbEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        public Car()
        {
        }

        public Car(string plateNumber)
        {
            Id = plateNumber;

            OilAndFilters = new List<OilAndFilter>();
            OtherServices = new List<OtherService>();
        }

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public virtual CarData CarData { get; set; }

        public virtual List<OilAndFilter> OilAndFilters { get; set; }

        public virtual List<OtherService> OtherServices { get; set; }
    }
}
