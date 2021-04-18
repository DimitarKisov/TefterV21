namespace Tefter.DbEntities
{
    using System;

    public class OtherService
    {
        public OtherService()
        {
        }

        public OtherService(string data)
        {
            Data = data;
        }

        public int Id { get; set; }

        public string Data { get; set; }

        public string CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
