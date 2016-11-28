using System;

namespace BookStore.Data.Entities
{
    public class Error : IEntityBases
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
