namespace ApiAssignment.ServiceInterface
{
    public class CollectionNameAttribute : System.Attribute
    {
        public string Name;

        public CollectionNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}