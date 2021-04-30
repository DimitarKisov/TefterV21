namespace Tefter.DbEntities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Note
    {
        public Note()
        {
        }

        public Note(string id, string description)
        {
            Id = id;
            Description = description;
        }

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
