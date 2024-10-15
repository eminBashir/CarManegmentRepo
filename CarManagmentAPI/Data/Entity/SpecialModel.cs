namespace CarManagmentAPI.Data.Entity
{
    public class SpecialModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public Person Person { get; set; }
    }
}
