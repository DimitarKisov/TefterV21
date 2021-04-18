namespace Tefter.DbEntities
{
    using System;
    using Tefter.DbEntities.Enums;

    public class CarData
    {
        public CarData()
        {
        }

        public CarData(string brand, string model, string color, string chassisNumber, string engineNumber, string workingVolumeCubicCm, DateTime firstRegisterDate, DateTime firstRegisterDateInBg, FuelType fuelType, string kilometers, string owner, string egn, string bulstat, string phoneNumber, string address)
        {
            Brand = brand;
            Model = model;
            Color = color;
            ChassisNumber = chassisNumber;
            EngineNumber = engineNumber;
            WorkingVolumeCubicCm = workingVolumeCubicCm;
            FirstRegisterDate = firstRegisterDate;
            FirstRegisterDateInBg = firstRegisterDateInBg;
            FuelType = fuelType;
            Kilometers = kilometers;
            Owner = owner;
            Egn = egn;
            Bulstat = bulstat;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public int Id { get; set; }

        /// <summary>
        /// Марка
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Модел
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Цвят
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Номер на шаси
        /// </summary>
        public string ChassisNumber { get; set; }

        /// <summary>
        /// Номер на двигател
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// Работен обем кубични сантиметри
        /// </summary>
        public string WorkingVolumeCubicCm { get; set; }

        /// <summary>
        /// Дата на първа регистрация
        /// </summary>
        public DateTime FirstRegisterDate { get; set; }

        /// <summary>
        /// Дата на първа регистрация в България
        /// </summary>
        public DateTime FirstRegisterDateInBg { get; set; }

        /// <summary>
        /// Тип гориво
        /// </summary>
        public FuelType FuelType { get; set; }

        /// <summary>
        /// Километри
        /// </summary>
        public string Kilometers { get; set; }

        /// <summary>
        /// Собственик
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Егн
        /// </summary>
        public string Egn { get; set; }

        /// <summary>
        /// Булстат
        /// </summary>
        public string Bulstat { get; set; }

        /// <summary>
        /// Телефонен номер
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        public string CarId { get; set; }

        public virtual Car Car { get; set; }

        public virtual CarExtras CarExtras { get; set; }
    }
}
