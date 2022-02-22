// See https://aka.ms/new-console-template for more information
namespace DIO.CharCreate
{
  class Program
  {
    static CharRepository repository = new CharRepository();
    static void Main(string[] args)
    {
      string inputUser = GetInputUser();

      while (inputUser.ToUpper() != "X")
      {
        switch (inputUser)
        {
          case "1":
            ListHeros();
            Console.WriteLine("\n Pressione 'Enter' para voltar ao menu principal.");
            Console.Read();
            break;
          case "2":
            CharCreate();
            break;
          case "3":
            ModifyHero();
            break;
          case "4":
            GetStatusById();
            break;
          case "5":
            RemoveHero();
            break;
          default:
            inputUser = GetInputUser();
            break;
        }
        inputUser = GetInputUser();
      }
      Console.WriteLine("\n Obrigado por testar esse código!");
    }


    private static string GetInputUser()
    {
      Console.Clear();
      Console.WriteLine("Personagem de RPG! \n");

      Console.WriteLine("\t 1- Listar Heróis;");
      Console.WriteLine("\t 2- Criar Herói;");
      Console.WriteLine("\t 3- Modificar Herói;");
      Console.WriteLine("\t 4- Exibir status do Herói;");
      Console.WriteLine("\t 5- Remover Herói;");
      Console.WriteLine("\t X- Sair;");

      

      Console.Write("\n Digite sua escolhe: ");
      string input = Console.ReadLine();

      return input;
    }

    private static void ListHeros()
    {
      Console.Clear();
      Console.WriteLine("Lista de Heróis: \n");

      if (repository.MainList.Count == 0)
      {
        Console.WriteLine("Lista vazia");
      }

      foreach (Character character in repository.MainList)
      {
        if (!character.SocialStatus.NoExist)
          Console.WriteLine(character);
      }

    }

    private static void CharCreate()
    {
      Console.Clear();
      Console.WriteLine("Criando novo Herói: \n");
      foreach (int i in Enum.GetValues(typeof(CharClass)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(CharClass), i));
      }

      Console.Write("\n Escolha uma Classe: ");
      int inputClass = int.Parse(Console.ReadLine());

      Console.Write("\n Digite o nome do Herói: ");
      string inputName = Console.ReadLine();

      repository.Insert(new Character(repository.NextId(), inputName, (CharClass)inputClass));

      Console.WriteLine("\n Herói Criado com sucesso!");

      Console.WriteLine("\n Pressione 'Enter' para voltar ao menu principal.");
      Console.ReadLine();
    }

    private static void ModifyHero()
    {
      Console.Clear();
      Console.WriteLine("Modificando Herói: \n");

      foreach (int i in Enum.GetValues(typeof(CharClass)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(CharClass), i));
      }

      Console.Write("\n Digite o 'Id' do Herói: \n");
      int id = int.Parse(Console.ReadLine());

      Character oldHero = repository.MainList[id - 1];

      Console.Write($"\n Escolha nova Classe {("anterior", oldHero.SocialStatus.CharClass)}: ");
      int inputClass = int.Parse(Console.ReadLine());

      Console.Write($"\n Digite o nome do Herói {("anterior", oldHero.SocialStatus.Name)}: ");
      string inputName = Console.ReadLine();

      repository.Update(id - 1, new Character(id, inputName, (CharClass)inputClass));

      Console.WriteLine("\n Herói modificado com sucesso! \n");
      Console.ReadLine();
    }
    private static void GetStatusById()
    {
      Console.Clear();
      Console.WriteLine("Exibir status do Herói: \n");
      ListHeros();
      Console.Write("Digite o 'Id' do Héroi: ");

      int id = int.Parse(Console.ReadLine());

      Console.Clear();
      Console.WriteLine($"Status de: \n");

      Console.WriteLine(repository.GetById(id).Status());

      Console.WriteLine("\n Pressione 'Enter' para voltar.");
      Console.ReadLine();
    }
    private static void RemoveHero()
    {
      Console.Clear();
      Console.WriteLine("Remoção de Herói: \n");
      ListHeros();
      Console.Write("Digite o 'Id' do Héroi: ");

      int id = int.Parse(Console.ReadLine());

      repository.Remove(id);

      Console.WriteLine("\n Herói removido com sucesso!");

      Console.WriteLine("\n Pressione 'Enter' para voltar.");
      Console.ReadLine();
    }

    
  }
}