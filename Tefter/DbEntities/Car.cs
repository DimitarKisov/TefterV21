namespace Tefter.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Tefter.DbEntities.Enums;

    public class Car
    {
        public Car()
        {
        }

        public Car(string plateNumber, string brand, string model, string color, string chassisNumber, string engineNumber, string workingVolumeCubicCm, DateTime firstRegisterDate, DateTime firstRegisterDateInBg, FuelType fuelType, string kilometers, string owner, string egn, string bulstat, string phoneNumber, string address)
        {
            Id = plateNumber;
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

            OilAndFilters = new List<OilAndFilter>();
            OtherServices = new List<OtherService>();
        }

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

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

        public virtual CarExtras CarExtras { get; set; }

        public virtual List<OilAndFilter> OilAndFilters { get; set; }

        public virtual List<OtherService> OtherServices { get; set; }
    }
}
