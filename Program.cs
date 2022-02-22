// See https://aka.ms/new-console-template for more information
namespace DIO.CharCreate
{
  class Program
  {
    static void Main(string[] args)
    {
      Character Hero = new Character(1, "Tiago", CharClass.WIZARD);
      Console.WriteLine(Hero.Status());
    }
  }
}