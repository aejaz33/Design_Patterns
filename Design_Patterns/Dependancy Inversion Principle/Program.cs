namespace Dependancy_Inversion_Principle
{
    public enum Relation
    {
        Father,
        Child,
        Mother,
    }
    public class Person
    {
        public string name { get; set; }
    }

    public interface IRelation
    {
        IEnumerable<Person> GetAllChildrenOf(string name);
    }

    public class RelationShip : IRelation
    {
        public List<(Person, Relation, Person)> relations = new();//new List<(Person, Relation, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relation.Father, child));
            relations.Add((child, Relation.Child, parent));
        }
        public IEnumerable<Person> GetAllChildrenOf(string name)
        {
            return relations.Where(p => p.Item1.name == name && p.Item2 == Relation.Father).Select(i => i.Item3);
        }
    }
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var parent = new Person { name = "Parent" };
        //    var child1 = new Person { name = "Child1" };
        //    var child2 = new Person { name = "Child2" };

        //    var relationship = new RelationShip();
        //    relationship.AddParentAndChild(parent, child1);
        //    relationship.AddParentAndChild(parent, child2);

        //    var childrenNamas = relationship.GetAllChildrenOf("Parent");
        //    foreach (var child in childrenNamas)
        //    {
        //        Console.WriteLine($"Child Name: {child.name}");
        //    }
        //}
    }
}
