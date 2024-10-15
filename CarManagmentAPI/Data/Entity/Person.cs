using System.Collections.Generic;

namespace CarManagmentAPI.Data.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? SpecialModelId { get; set; }

        public ICollection<SpecialModel> SpecialModel { get; set; }

    }
}
