using System;

namespace designPatterns
{
    //A classe Creator declara o método de fábrica que deve retornar
    //um objeto de uma classe Product. As subclasses do Creator geralmente fornecem
    //a implementação deste método.
    abstract class Creator
    {
        //Observe que o Creator também porde fornecer alguma implementação padrão.  
        //o método fábrica
        public abstract IProduct FactoryMethod();

        //Observe também que, apesar do nome, a principal
        //responsabilidade não é criar produtos. Normalmente contém algumá lógica de negócios
        //principal que depende de objetos de produto, retornados pelo método de fábrica.
        //As subclasses podem alterar diretamente essa lógica de negócios substituindo
        //o método de fábrica e retornando um tipo diferente de produto a partir dele

        public string SomeOperation()
        {
            //Chama o método de fábrica para criar um objeto produto.
            var product = FactoryMethod();
            //Agora, usa o produto.
            var result = "Creator: O mesmo código do Creator acabou de trabalhar com "
                + product.Operation();

            return result;
        }
    }

    //Os Creators concretos substituem o método fábrica para alterar o tipo de produto resultante.    
    class ConcreteCreator1 : Creator
    {
        //Observe que a assinatura do método ainda usa o produto do tipo abstrato, mesmo que 
        //o produto concreto seja realmente devolvido do método. Desta forma, o Creator pode fornececer 
        //independente do produto concreto da classe.
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    //Os criadores de concreto substituem o método fábrica para alterar o tipo de produto resultante.    
    class ConcreteCreator2 : Creator
    {
        //Observe que a assinatura do método ainda usa o produto do tipo abstrato, mesmo que 
        //o produto concreto seja realmente devolvido do método. Desta forma, o Creator pode fornececer 
        //independente do produto concreto da classe.
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    //A interface do produto declara as operações que todos os produtos concretos deve implementar.    
    public interface IProduct
    {
        string Operation();
    }

    //Produtos concretos fornecem várias implementações da Interface Produto.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Resultado do produto concreto 1}";
        }
    }

    //Produtos concretos fornecem várias implementações da Interface Produto.
    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Resultado do produto concreto 2}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Carregado com o criador Concreto 1.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: Carregado com o criador Concreto 2.");
            ClientCode(new ConcreteCreator2());
        }

        // O código do cliente funciona com uma instância de um Creator concreto, embora
        // por meio de sua interface base.
        // Contanto que o cliente continue trabalhando com o Creator através da interface base,
        //você pode passá-lo para qualquer Creator subclasse.
        public void ClientCode(Creator creator)
        {       
            Console.WriteLine("Client: Não conheço a classe Creator," +
                "mas,  ainda funciona\n" + creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
