using System.ComponentModel.DataAnnotations;

namespace  ContactsManager.Core.Domain.Entities
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
       
        public string? Name { get; set; }
    }
}