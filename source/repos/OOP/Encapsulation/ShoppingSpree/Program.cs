using ShoppingSpree;

string[] inputPerson = Console.ReadLine().Split((new string[]{"="," ",";"}),StringSplitOptions.RemoveEmptyEntries).ToArray();

string[] productsInput= Console.ReadLine().Split((new string[] { "=", " ", ";" }), StringSplitOptions.RemoveEmptyEntries).ToArray();

List <Person> people = new List <Person>();
List <Product> products = new List <Product>();

try
{
    for (int i = 0; i < inputPerson.Length; i += 2)
    {

        string name = inputPerson[i];
        double money = double.Parse(inputPerson[i + 1]);

        Person person = new Person(name, money);

        people.Add(person);
    }


    for (int i = 0; i < productsInput.Length; i += 2)
    {
        string name = productsInput[i];
        double cost = double.Parse(productsInput[i + 1]);
        Product product = new Product(name, cost);

        products.Add(product);
    }

    string command;

    while ((command = Console.ReadLine()) != "END")
    {
        string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string name = tokens[0];
        string productToFind = tokens[1];

        Person person = people.FirstOrDefault(p => p.Name == name);
        Product product = products.FirstOrDefault(p => p.Name == productToFind);
        if (person != null)
        {
            Console.WriteLine(person.AddProduct(product));
        }


    }

    foreach (var personToPrint in people)
    {
        if (personToPrint.HasProducts())
        {

        Console.WriteLine(personToPrint.ToString());
        }
        else
        {
            Console.WriteLine($"{personToPrint.Name} - Nothing bought ");
        }
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}

