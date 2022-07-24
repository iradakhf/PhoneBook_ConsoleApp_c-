using CoreLibrary.Abstractions;


namespace CoreLibrary
{
    public class Contact : IEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get ; set ; }
        
    }
}
