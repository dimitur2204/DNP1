namespace Intro_SDJ.DomainModel;

public class Person
{
   public String name { get; set; }

   public Person(String name)
   {
       this.name = name;
   }
   public void printName()
   {
       Console.WriteLine(name);
   }
}