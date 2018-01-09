namespace Ellegia.Application.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        
        public string Name { get; set; }

        public ContactTypeDto ContactType { get; set; }
    }
}
