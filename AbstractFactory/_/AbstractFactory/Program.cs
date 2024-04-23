using System.Runtime.CompilerServices;

public interface AbstractProducer
{
    AbstractBrics bricsOrder();
    AbstractConcrete concreteOrder();
    AbstractSlabs slabsOrder();
}

public interface AbstractBrics
{
    public int PalletsOfBricksAvailable();
    public int CostOnePallet();
}
public interface AbstractConcrete
{
    int TonsOfConcreteAvailable();
    int CostOneTonn();
}
public interface AbstractSlabs
{
    public int AvailableSlabs();
    public int CostOneSlabs();
}

class TomskProducerBrics : AbstractBrics
{
    private int palletsOfBricksAvailable;
    private Random rnd = new Random();
    private int costOnePallet;
    public TomskProducerBrics()
    {
        palletsOfBricksAvailable = (int) rnd.NextInt64(50, 80);
        costOnePallet = (int) rnd.NextInt64(6000, 10000); 
    }    
    public int PalletsOfBricksAvailable()
    {
        return palletsOfBricksAvailable;
    }
    public int CostOnePallet()
    {
        return costOnePallet;
    }
}
class NovosibirskProducerBrics : AbstractBrics
{
    private int palletsOfBricksAvailable;
    Random rnd = new Random();
    private int costOnePallet;
    public NovosibirskProducerBrics()
    {
        palletsOfBricksAvailable = (int)rnd.NextInt64(50, 80);
        costOnePallet = (int)rnd.NextInt64(6000, 10000);
    }
    public int PalletsOfBricksAvailable()
    {
        return palletsOfBricksAvailable;
    }
    public int CostOnePallet()
    {
        return costOnePallet;
    }
}
class AtriumProducerBrics : AbstractBrics
{
    private int palletsOfBricksAvailable;
    Random rnd = new Random();
    private int costOnePallet;
    public AtriumProducerBrics()
    {
        palletsOfBricksAvailable = 0;
        costOnePallet = 0;
    }
    public int PalletsOfBricksAvailable()
    {
        return palletsOfBricksAvailable;
    }
    public int CostOnePallet()
    {
        return costOnePallet;
    }
}
class TomskProducerConcrete : AbstractConcrete
{
    private int tonsOfConcreteAvailable;
    Random rnd = new Random();
    private int costOneTonn;
    public TomskProducerConcrete()
    {
        tonsOfConcreteAvailable = 0;
        costOneTonn = 0;
    }
    public int TonsOfConcreteAvailable()
    {
        return tonsOfConcreteAvailable;
    }
    public int CostOneTonn()
    {
        return costOneTonn;
    }
}
class NovosibirskProducerConcrete : AbstractConcrete
{
    private int tonsOfConcreteAvailable;
    Random rnd = new Random();
    private int costOneTonn;
    public NovosibirskProducerConcrete()
    {
        tonsOfConcreteAvailable = (int)rnd.NextInt64(25, 40);
        costOneTonn = (int)rnd.NextInt64(4000, 6000);
    }
    public int TonsOfConcreteAvailable()
    {
        return tonsOfConcreteAvailable;
    }
    public int CostOneTonn()
    {
        return costOneTonn;
    }
}
class AtriumProducerConcrete : AbstractConcrete
{
    private int tonsOfConcreteAvailable;
    Random rnd = new Random();
    private int costOneTonn;
    public AtriumProducerConcrete()
    {
        tonsOfConcreteAvailable = (int)rnd.NextInt64(25, 40);
        costOneTonn = (int)rnd.NextInt64(4000, 6000);
    }
    public int TonsOfConcreteAvailable()
    {
        return tonsOfConcreteAvailable;
    }
    public int CostOneTonn()
    {
        return costOneTonn;
    }
}
class TomskProducerSlabs : AbstractSlabs
{
    private int availableSlabs;
    Random rnd = new Random();
    private int costOneSlabs;
    public TomskProducerSlabs()
    {
        availableSlabs = 0;
        costOneSlabs = 0;
    }
    public int AvailableSlabs()
    {
        return availableSlabs;
    }
    public int CostOneSlabs()
    {
        return costOneSlabs;
    }
}
class NovosibirskProducerSlabs : AbstractSlabs
{
    private int availableSlabs;
    Random rnd = new Random();
    private int costOneSlabs;
    public NovosibirskProducerSlabs()
    {
        availableSlabs = (int)rnd.NextInt64(15, 20);
        costOneSlabs = (int)rnd.NextInt64(9000, 15000);
    }
    public int AvailableSlabs()
    {
        return availableSlabs;
    }
    public int CostOneSlabs()
    {
        return costOneSlabs;
    }
}
class AtriumProducerSlabs : AbstractSlabs
{
    private int availableSlabs;
    Random rnd = new Random();
    private int costOneSlabs;
    public AtriumProducerSlabs()
    {
        availableSlabs = (int)rnd.NextInt64(15, 20);
        costOneSlabs = (int)rnd.NextInt64(9000, 15000);
    }
    public int AvailableSlabs()
    {
        return availableSlabs;
    }
    public int CostOneSlabs()
    {
        return costOneSlabs;
    }
}
 
class TomskProducer : AbstractProducer
{
    public TomskProducer() { }
    public AbstractBrics bricsOrder() {
        return new TomskProducerBrics();
    }
    public AbstractConcrete concreteOrder() {
        return new TomskProducerConcrete();
    }
    public AbstractSlabs slabsOrder() {
        return new TomskProducerSlabs();
    }
}

class NovosibirskProducer : AbstractProducer
{
    public NovosibirskProducer() { }
    public AbstractBrics bricsOrder()
    {
        return new NovosibirskProducerBrics();
    }
    public AbstractConcrete concreteOrder()
    {
        return new NovosibirskProducerConcrete();
    }
    public AbstractSlabs slabsOrder()
    {
        return new NovosibirskProducerSlabs();
    }

}

class AtriumProducer : AbstractProducer
{
    public AtriumProducer() { }
    public AbstractBrics bricsOrder()
    {
        return new AtriumProducerBrics();
    }
    public AbstractConcrete concreteOrder()
    {
        return new AtriumProducerConcrete();
    }
    public AbstractSlabs slabsOrder()
    {
        return new AtriumProducerSlabs();
    }

}

public class InputManager
{
    public static int[] GetPrimalData()
    {
        int[] primalData = new int[3];

        primalData[0] = GetIntegerInput("Кирпичи (макс = 100): ", 0, 100);
        primalData[1] = GetIntegerInput("Бетон (макс = 50): ", 0, 50);
        primalData[2] = GetIntegerInput("ЖБ плиты (макс = 30): ", 0, 30);

        return primalData;
    }

    private static int GetIntegerInput(string message, int min, int max)
    {
        int input;
        do
        {
            Console.Write(message);
            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out input) && input >= min && input <= max)
            {
                return input;
            }

            if (input < min)
            {
                Console.Write($"Введёное число меньше минимально допустимого. К вводу принято число {min}" + "\n");
                return min;
            }
            if (input > max) {
                Console.Write($"Введёное число больше максимально допустимого. К вводу принято число {max}" + "\n");
                return max;
            }
            } while (true);
    }
}

class Start
{
    static void Main()
    {
        int[] arrPrimalDate = InputManager.GetPrimalData();
        calculationOfTheOptimalPlan(arrPrimalDate[0], arrPrimalDate[1], arrPrimalDate[2]);
    }
    
    static void calculationOfTheOptimalPlan(int demandBrics, int demandConcrete, int demandSlabs)
    {
        int sum = 0;

        AbstractProducer producerTom = new TomskProducer();
        AbstractBrics bricsTom = producerTom.bricsOrder();
        AbstractConcrete concreteTom = producerTom.concreteOrder();
        AbstractSlabs slabsTom = producerTom.slabsOrder();

        AbstractProducer producerNov = new NovosibirskProducer();
        AbstractBrics bricsNov = producerNov.bricsOrder();
        AbstractConcrete concreteNov = producerNov.concreteOrder();
        AbstractSlabs slabsNov = producerNov.slabsOrder();

        AbstractProducer producerAtr = new AtriumProducer();
        AbstractBrics bricsAtr = producerAtr.bricsOrder();
        AbstractConcrete concreteAtr = producerAtr.concreteOrder();
        AbstractSlabs slabsAtr = producerAtr.slabsOrder();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Оптимальный план закупок кирпичей: ");
        Console.WriteLine("Цена за ед. для TomskProducer: " + bricsTom.CostOnePallet() + "; Доступное кол-во: " + bricsTom.PalletsOfBricksAvailable());
        Console.WriteLine("Цена за ед. для NovosibirskProducer: " + bricsNov.CostOnePallet() + "; Доступное кол-во: " + bricsNov.PalletsOfBricksAvailable());
        Console.WriteLine("Цена за ед. для AtriumProducer: " + bricsAtr.CostOnePallet() + "; Доступное кол-во: " + bricsAtr.PalletsOfBricksAvailable() + "\n");
        sum += transportProblem(bricsTom.CostOnePallet(), bricsNov.CostOnePallet(), bricsAtr.CostOnePallet(), bricsTom.PalletsOfBricksAvailable(), bricsNov.PalletsOfBricksAvailable(), bricsAtr.PalletsOfBricksAvailable(), demandBrics);
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Оптимальный план закупок бетона: ");
        Console.WriteLine("Цена за ед. для TomskProducer: " + concreteTom.CostOneTonn() + "; Доступное кол-во: " + concreteTom.TonsOfConcreteAvailable());
        Console.WriteLine("Цена за ед. для NovosibirskProducer: " + concreteNov.CostOneTonn() + "; Доступное кол-во: " + concreteNov.TonsOfConcreteAvailable());
        Console.WriteLine("Цена за ед. для AtriumProducer: " + concreteAtr.CostOneTonn() + "; Доступное кол-во: " + concreteAtr.TonsOfConcreteAvailable() + "\n");
        sum += transportProblem(concreteTom.CostOneTonn(), concreteNov.CostOneTonn(), concreteAtr.CostOneTonn(), concreteTom.TonsOfConcreteAvailable(), concreteNov.TonsOfConcreteAvailable(), concreteAtr.TonsOfConcreteAvailable(), demandConcrete);
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Оптимальный план закупок ЖБ плит: ");
        Console.WriteLine("Цена за ед. для TomskProducer: " + slabsTom.CostOneSlabs() + "; Доступное кол-во: " + slabsTom.AvailableSlabs());
        Console.WriteLine("Цена за ед. для NovosibirskProducer: " + slabsNov.CostOneSlabs() + "; Доступное кол-во: " + slabsNov.AvailableSlabs());
        Console.WriteLine("Цена за ед. для AtriumProducer: " + slabsAtr.CostOneSlabs() + "; Доступное кол-во: " + slabsAtr.AvailableSlabs() + "\n");
        sum += transportProblem(slabsTom.CostOneSlabs(), slabsNov.CostOneSlabs(), slabsAtr.CostOneSlabs(), slabsTom.AvailableSlabs(), slabsNov.AvailableSlabs(), slabsAtr.AvailableSlabs(), demandSlabs);
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Суммарные затраты: " + sum);
    }

    static int transportProblem(int tomskCost, int novosibirskCost, int atriumCost, int tomskAvailable, int novosibirskAvailable, int atriumAvailable, int demand)
    {
        //Console.WriteLine(tomskCost + " " + novosibirskCost + " "+atriumCost + " " + tomskAvailable + " "+novosibirskAvailable +" "+ atriumAvailable +" "+ demand);
        int cost = 0, sum = 0;
        if (tomskCost < novosibirskCost && tomskCost < atriumCost && (novosibirskCost < atriumCost))
        {
            if (tomskAvailable >= demand)
            {
                cost = demand * tomskCost;
                sum += cost;
                Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + demand+ " по суммарной цене "+ cost);
            }
            else
            {
                cost = tomskAvailable * tomskCost;
                sum += cost;
                if (tomskAvailable > 0) Console.WriteLine("Закупки у поставщика TomskProducer в количестве "+ tomskAvailable+ " по суммарной цене " +cost);
                demand -= tomskAvailable;
                if (novosibirskAvailable >= demand)
                {
                    cost = demand * novosibirskAvailable;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве "+ demand+ " по суммарной цене "+ cost);
                }
                else
                {
                    cost = novosibirskAvailable * novosibirskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + novosibirskAvailable + " по суммарной цене " + cost);
                    demand -= novosibirskAvailable;
                    cost = demand * atriumCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + demand + " по суммарной цене " + cost);
                }
            }
        } 
        else if (tomskCost < novosibirskCost && tomskCost < atriumCost && (atriumCost < novosibirskCost))
        {
            if (tomskAvailable >= demand)
            {
                cost = demand * tomskCost;
                sum += cost;
                Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + demand + " по суммарной цене " + cost);
            }
            else
            {
                cost = tomskAvailable * tomskCost;
                sum += cost;
                if (tomskAvailable > 0) Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + tomskAvailable + " по суммарной цене " + cost);
                demand -= tomskAvailable;
                if (atriumAvailable >= demand)
                {
                    cost = demand * atriumCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + demand + " по суммарной цене " + cost);
                }
                else
                {
                    cost = atriumAvailable * atriumCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + atriumAvailable + " по суммарной цене " + cost);
                    demand -= atriumAvailable;
                    cost = demand * novosibirskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + demand + " по суммарной цене " + cost);
                }
            }
        }
        else if (novosibirskCost < tomskCost && novosibirskCost < atriumCost && (atriumCost < tomskCost))
        {
            // Новосибирск предлагает наименьшую стоимость, при условии что Атриум дороже Томска
            if (novosibirskAvailable >= demand)
            {
                cost = demand * novosibirskCost;
                sum += cost;
                Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + demand + " по суммарной цене " + cost);
            }
            else
            {
                cost = novosibirskAvailable * novosibirskCost;
                sum += cost;
                if (novosibirskAvailable > 0)  Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + novosibirskAvailable + " по суммарной цене " + cost);
                demand -= novosibirskAvailable;
                if (atriumAvailable >= demand)
                {
                    cost = demand * atriumCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + demand + " по суммарной цене " + cost);
                }
                else
                {
                    cost = atriumAvailable * atriumCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + atriumAvailable + " по суммарной цене " + cost);
                    demand -= atriumAvailable;
                    cost = demand * tomskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + demand + " по суммарной цене " + cost);
                }
            }
        }
        else if (novosibirskCost < tomskCost && novosibirskCost < atriumCost && (tomskCost < atriumCost))
        {
            // Новосибирск предлагает наименьшую стоимость, при условии что Томск дороже Атриума
            if (novosibirskAvailable >= demand)
            {
                cost = demand * novosibirskCost;
                sum += cost;
                Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве "+ demand+ " по суммарной цене "+ cost);
            }
            else
            {
                cost = novosibirskAvailable * novosibirskCost;
                sum += cost;
                if (novosibirskAvailable > 0) Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве "+ novosibirskAvailable+ " по суммарной цене "+ cost);
                demand -= novosibirskAvailable;
                if (tomskAvailable >= demand)
                {
                    cost = demand * tomskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика TomskProducer в количестве "+ demand+" по суммарной цене :"+ cost);
                }
                else
                {
                    cost = tomskAvailable * tomskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + tomskAvailable + " по суммарной цене " + cost);
                    demand -= tomskAvailable;
                    cost = demand * atriumCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + demand + " по суммарной цене " + cost);
                }
            }
        }
        else if (atriumCost < tomskCost && atriumCost < novosibirskCost && (tomskCost < novosibirskCost))
        {
            // Атриум предлагает наименьшую стоимость, при условии что Томск дороже Новосибирска
            if (atriumAvailable >= demand)
            {
                cost = demand * atriumCost;
                sum += cost;
                Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + demand + " по суммарной цене " + cost);
            }
            else
            {
                cost = atriumAvailable * atriumCost;
                sum += cost;
                if (atriumAvailable > 0) Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + atriumAvailable + " по суммарной цене " + cost);
                demand -= atriumAvailable;
                if (tomskAvailable >= demand)
                {
                    cost = demand * tomskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + demand + " по суммарной цене " + cost);
                }
                else
                {
                    cost = tomskAvailable * tomskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + tomskAvailable + " по суммарной цене " + cost);
                    demand -= tomskAvailable;
                    cost = demand * novosibirskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + demand + " по суммарной цене " + cost);
                }
            }
        }
        else if (atriumCost < tomskCost && atriumCost < novosibirskCost && (novosibirskCost < tomskCost))
        {
            // Атриум предлагает наименьшую стоимость, при условии что Новосибирск дороже Томска
            if (atriumAvailable >= demand)
            {
                cost = demand * atriumCost;
                sum += cost;
                Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + demand + " по суммарной цене " + cost);
            }
            else
            {
                cost = atriumAvailable * atriumCost;
                sum += cost;
                if (atriumAvailable > 0) Console.WriteLine("Закупки у поставщика AtriumProducer в количестве " + atriumAvailable + " по суммарной цене " + cost);
                demand -= atriumAvailable;
                if (novosibirskAvailable >= demand)
                {
                    cost = demand * novosibirskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + demand + " по суммарной цене " + cost);
                }
                else
                {
                    cost = novosibirskAvailable * novosibirskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика NovosibirskProducer в количестве " + novosibirskAvailable + " по суммарной цене " + cost);
                    demand -= novosibirskAvailable;
                    cost = demand * tomskCost;
                    sum += cost;
                    Console.WriteLine("Закупки у поставщика TomskProducer в количестве " + demand + " по суммарной цене " +  cost);
                }
            }
        }
        Console.WriteLine("ИТОГО: "+ sum);
        return sum;
    }

}

/*
 * https://github.com/qcha/JBook/blob/master/patterns/creational/abstract_factory.md
 * https://habr.com/ru/articles/465835/
 */