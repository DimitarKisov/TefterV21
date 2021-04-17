namespace Tefter.DbEntities
{
    using Newtonsoft.Json;
    using Tefter.DbEntities.Helper;

    public class OilAndFilter : JsonBase
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public string CarId { get; set; }

        public virtual Car Car { get; set; }

        public override T ParseData<T>()
        {
            return JsonConvert.DeserializeObject<T>(Data);
        }
    }
}
