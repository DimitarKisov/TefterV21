namespace Tefter.DbEntities
{
    public class CarExtras
    {
        public int Id { get; set; }

        public bool Abs { get; set; }

        public bool Asd { get; set; }

        public bool Ebs { get; set; }

        public bool Arb { get; set; }

        public bool Esp { get; set; }

        /// <summary>
        /// 4х4
        /// </summary>
        public bool FourByFour { get; set; }

        /// <summary>
        /// Климатик
        /// </summary>
        public bool AirConditioning { get; set; }

        /// <summary>
        /// Климатроник
        /// </summary>
        public bool Climatronic { get; set; }

        /// <summary>
        /// Люк
        /// </summary>
        public bool Hatch { get; set; }

        /// <summary>
        /// Аларма
        /// </summary>
        public bool Alarm { get; set; }

        /// <summary>
        /// Имобилайзер
        /// </summary>
        public bool Immobilizer { get; set; }

        /// <summary>
        /// Централно заключване
        /// </summary>
        public bool CentralLocking { get; set; }

        /// <summary>
        /// Ел. стъкла
        /// </summary>
        public bool ElectronicGlass { get; set; }

        /// <summary>
        /// Електронни огледала
        /// </summary>
        public bool ElectronicMirrors { get; set; }

        /// <summary>
        /// Автоматик
        /// </summary>
        public bool Automatic { get; set; }

        /// <summary>
        /// Ел. пак.
        /// </summary>
        public bool ElectronicPacket { get; set; }

        /// <summary>
        /// Хидравклика на волана
        /// </summary>
        public bool SteeringWheelHydraulics { get; set; }

        /// <summary>
        /// Стерео
        /// </summary>
        public bool Stereo { get; set; }

        /// <summary>
        /// CD чейнджър
        /// </summary>
        public bool CdChanger { get; set; }

        /// <summary>
        /// Усилвател
        /// </summary>
        public bool Amplifier { get; set; }

        /// <summary>
        /// Други
        /// </summary>
        public string Other { get; set; }

        public int CarDataId { get; set; }

        public virtual CarData CarData { get; set; }
    }
}
