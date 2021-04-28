namespace Tefter.DbEntities
{
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
