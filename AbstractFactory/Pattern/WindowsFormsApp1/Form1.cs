using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


namespace WindowsFormsApp1
{
public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                numericUpDown19.Value = 0; numericUpDown9.Value = 0; numericUpDown22.Value = 0; numericUpDown10.Value = 0;
                numericUpDown6.Value = 0; numericUpDown25.Value = 0; numericUpDown38.Value = 0; numericUpDown28.Value = 0;
                numericUpDown41.Value = 0; numericUpDown16.Value = 0; numericUpDown13.Value = 0; numericUpDown31.Value = 0;
                numericUpDown36.Value = 0; numericUpDown20.Value = 0; numericUpDown8.Value = 0; numericUpDown23.Value = 0;
                numericUpDown11.Value = 0; numericUpDown5.Value = 0; numericUpDown26.Value = 0; numericUpDown39.Value = 0;
                numericUpDown29.Value = 0; numericUpDown43.Value = 0; numericUpDown17.Value = 0; numericUpDown14.Value = 0;
                numericUpDown32.Value = 0; numericUpDown35.Value = 0; numericUpDown21.Value = 0; numericUpDown7.Value = 0;
                numericUpDown24.Value = 0; numericUpDown12.Value = 0; numericUpDown4.Value = 0; numericUpDown27.Value = 0;
                numericUpDown40.Value = 0; numericUpDown37.Value = 0; numericUpDown42.Value = 0; numericUpDown18.Value = 0;
                numericUpDown15.Value = 0; numericUpDown33.Value = 0; numericUpDown34.Value = 0;
            }
            calculationOfTheOptimalPlan((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
        }


        private static int[] factory(AbstractProducer producer)
        {
            AbstractBrics brics = producer.bricsOrder();
            AbstractConcrete concrete = producer.concreteOrder();
            AbstractSlabs slabs = producer.slabsOrder();

            return new int[] { brics.CostOnePallet(), concrete.CostOneTonn(), slabs.CostOneSlabs(), brics.PalletsOfBricksAvailable(), concrete.TonsOfConcreteAvailable(), slabs.AvailableSlabs() };


        }
        public void calculationOfTheOptimalPlan(int demandBrics, int demandConcrete, int demandSlabs)
        {
            int sum = 0;
            AbstractProducer producerTom = new TomskProducer();
            int[] arr1 = factory(producerTom);
            {
                numericUpDown21.Value = arr1[0];
                numericUpDown20.Value = arr1[1];
                numericUpDown19.Value = arr1[2];
                numericUpDown12.Value = arr1[3];
                numericUpDown11.Value = arr1[4];
                numericUpDown10.Value = arr1[5];
            }

            AbstractProducer producerNov = new NovosibirskProducer();
            arr1 = factory(producerNov);
            {
                numericUpDown7.Value = arr1[0];
                numericUpDown8.Value = arr1[1];
                numericUpDown9.Value = arr1[2];
                numericUpDown4.Value = arr1[3];
                numericUpDown5.Value = arr1[4];
                numericUpDown6.Value = arr1[5];
            }

            AbstractProducer producerKem = new AtriumProducer();
            arr1 = factory(producerKem);
            {
                numericUpDown24.Value = arr1[0];
                numericUpDown23.Value = arr1[1];
                numericUpDown22.Value = arr1[2];
                numericUpDown27.Value = arr1[3];
                numericUpDown26.Value = arr1[4];
                numericUpDown25.Value = arr1[5];
            }

            sum += transportProblem((int)numericUpDown21.Value, (int)numericUpDown7.Value, (int)numericUpDown24.Value, (int)numericUpDown12.Value, (int)numericUpDown4.Value, (int)numericUpDown27.Value, demandBrics, numericUpDown40, numericUpDown37, numericUpDown42, numericUpDown18, numericUpDown15, numericUpDown33, numericUpDown34);
            sum += transportProblem((int)numericUpDown20.Value, (int)numericUpDown8.Value, (int)numericUpDown23.Value, (int)numericUpDown11.Value, (int)numericUpDown5.Value, (int)numericUpDown26.Value, demandConcrete, numericUpDown39, numericUpDown29, numericUpDown43, numericUpDown17, numericUpDown14, numericUpDown32, numericUpDown35);
            sum += transportProblem((int)numericUpDown19.Value, (int)numericUpDown9.Value, (int)numericUpDown22.Value, (int)numericUpDown10.Value, (int)numericUpDown6.Value, (int)numericUpDown25.Value, demandSlabs, numericUpDown38, numericUpDown28, numericUpDown41, numericUpDown16, numericUpDown13, numericUpDown31, numericUpDown36);
            numericUpDown30.Value = sum;
        }

        private int transportProblem(int tomskCost, int novosibirskCost, int atriumCost, int tomskAvailable, int novosibirskAvailable, int atriumAvailable, int demand,
                                NumericUpDown numericUpSumTomsk, NumericUpDown numericUpSumNovosibirsk, NumericUpDown numericUpSumAtrium, NumericUpDown numericUpPurchasedTomsk, NumericUpDown numericUpPurchasedNovosibirsk, NumericUpDown numericUpPurchasedAtrium, NumericUpDown numericUpSum)
        {
            int cost = 0, sum = 0;
            if (tomskCost <= novosibirskCost && tomskCost <= atriumCost && atriumCost <= novosibirskCost)
            {
                if (tomskAvailable >= demand)
                {
                    cost = demand * tomskCost;
                    sum += cost;
                    numericUpPurchasedTomsk.Value = demand;
                    numericUpSumTomsk.Value = cost;
                }
                else
                {
                    cost = tomskAvailable * tomskCost;
                    sum += cost;
                    numericUpPurchasedTomsk.Value = tomskAvailable;
                    numericUpSumTomsk.Value = cost;
                    demand -= tomskAvailable;
                    if (atriumAvailable >= demand)
                    {
                        cost = demand * atriumCost;
                        sum += cost;
                        numericUpPurchasedAtrium.Value = demand;
                        numericUpSumAtrium.Value = cost;
                    }
                    else
                    {
                        cost = atriumAvailable * atriumCost;
                        sum += cost;
                        numericUpPurchasedAtrium.Value = atriumAvailable;
                        numericUpSumAtrium.Value = cost;
                        demand -= atriumAvailable;
                        cost = demand * novosibirskCost;
                        sum += cost;
                        numericUpPurchasedNovosibirsk.Value = demand;
                        numericUpSumNovosibirsk.Value = cost;
                    }
                }
            }
            else if (novosibirskCost <= tomskCost && novosibirskCost <= atriumCost && atriumCost <= tomskCost)
            {
                if (novosibirskAvailable >= demand)
                {
                    cost = demand * novosibirskCost;
                    sum += cost;
                    numericUpPurchasedNovosibirsk.Value = demand;
                    numericUpSumNovosibirsk.Value = cost;
                }
                else
                {
                    cost = novosibirskAvailable * novosibirskCost;
                    sum += cost;
                    numericUpPurchasedNovosibirsk.Value = novosibirskAvailable;
                    numericUpSumNovosibirsk.Value = cost;
                    demand -= novosibirskAvailable;
                    if (atriumAvailable >= demand)
                    {
                        cost = demand * atriumCost;
                        sum += cost;
                        numericUpPurchasedAtrium.Value = demand;
                        numericUpSumAtrium.Value = cost;
                    }
                    else
                    {
                        cost = atriumAvailable * atriumCost;
                        sum += cost;
                        numericUpPurchasedAtrium.Value = atriumAvailable;
                        numericUpSumAtrium.Value = cost;
                        demand -= atriumAvailable;
                        cost = demand * tomskCost;
                        sum += cost;
                        numericUpPurchasedTomsk.Value = demand;
                        numericUpSumTomsk.Value = cost;
                    }
                }
            }
            else if (novosibirskCost <= tomskCost && novosibirskCost <= atriumCost && tomskCost <= atriumCost)
            {
                if (novosibirskAvailable >= demand)
                {
                    cost = demand * novosibirskCost;
                    sum += cost;
                    numericUpPurchasedNovosibirsk.Value = demand;
                    numericUpSumNovosibirsk.Value = cost;
                }
                else
                {
                    cost = novosibirskAvailable * novosibirskCost;
                    sum += cost;
                    numericUpPurchasedNovosibirsk.Value = novosibirskAvailable;
                    numericUpSumNovosibirsk.Value = cost;
                    demand -= novosibirskAvailable;
                    if (tomskAvailable >= demand)
                    {
                        cost = demand * tomskCost;
                        sum += cost;
                        numericUpPurchasedTomsk.Value = demand;
                        numericUpSumTomsk.Value = cost;
                    }
                    else
                    {
                        cost = tomskAvailable * tomskCost;
                        sum += cost;
                        numericUpPurchasedTomsk.Value = tomskAvailable;
                        numericUpSumTomsk.Value = cost;
                        demand -= tomskAvailable;
                        cost = demand * atriumCost;
                        sum += cost;
                        numericUpPurchasedAtrium.Value = demand;
                        numericUpSumAtrium.Value = cost;
                    }
                }
            }
            else if (atriumCost <= tomskCost && atriumCost <= novosibirskCost && tomskCost <= novosibirskCost)
            {
                if (atriumAvailable >= demand)
                {
                    cost = demand * atriumCost;
                    sum += cost;
                    numericUpPurchasedAtrium.Value = demand;
                    numericUpSumAtrium.Value = cost;
                }
                else
                {
                    cost = atriumAvailable * atriumCost;
                    sum += cost;
                    numericUpPurchasedAtrium.Value = atriumAvailable;
                    numericUpSumAtrium.Value = cost;
                    demand -= atriumAvailable;
                    if (tomskAvailable >= demand)
                    {
                        cost = demand * tomskCost;
                        sum += cost;
                        numericUpPurchasedTomsk.Value = demand;
                        numericUpSumTomsk.Value = cost;
                    }
                    else
                    {
                        cost = tomskAvailable * tomskCost;
                        sum += cost;
                        numericUpPurchasedTomsk.Value = tomskAvailable;
                        numericUpSumTomsk.Value = cost;
                        demand -= tomskAvailable;
                        cost = demand * novosibirskCost;
                        sum += cost;
                        numericUpPurchasedNovosibirsk.Value = demand;
                        numericUpSumNovosibirsk.Value = cost;
                    }
                }
            }
            else if (atriumCost <= tomskCost && atriumCost <= novosibirskCost && novosibirskCost <= tomskCost)
            {
                if (atriumAvailable >= demand)
                {
                    cost = demand * atriumCost;
                    sum += cost;
                    numericUpPurchasedAtrium.Value = demand;
                    numericUpSumAtrium.Value = cost;
                }
                else
                {
                    cost = atriumAvailable * atriumCost;
                    sum += cost;
                    numericUpPurchasedAtrium.Value = atriumAvailable;
                    numericUpSumAtrium.Value = cost;
                    demand -= atriumAvailable;
                    if (novosibirskAvailable >= demand)
                    {
                        cost = demand * novosibirskCost;
                        sum += cost;
                        numericUpPurchasedNovosibirsk.Value = demand;
                        numericUpSumNovosibirsk.Value = cost;
                    }
                    else
                    {
                        cost = novosibirskAvailable * novosibirskCost;
                        sum += cost;
                        numericUpPurchasedNovosibirsk.Value = novosibirskAvailable;
                        numericUpSumNovosibirsk.Value = cost;
                        demand -= novosibirskAvailable;
                        cost = demand * tomskCost;
                        sum += cost;
                        numericUpPurchasedTomsk.Value = demand;
                        numericUpSumTomsk.Value = cost;
                    }
                }
            }
            else if (tomskCost <= novosibirskCost && tomskCost <= atriumCost && novosibirskCost <= atriumCost)
            {
                if (tomskAvailable >= demand)
                {
                    cost = demand * tomskCost;
                    sum += cost;
                    numericUpPurchasedTomsk.Value = demand;
                    numericUpSumTomsk.Value = cost;
                }
                else
                {
                    cost = tomskAvailable * tomskCost;
                    sum += cost;
                    numericUpPurchasedTomsk.Value = tomskAvailable;
                    numericUpSumTomsk.Value = cost;
                    demand -= tomskAvailable;
                    if (atriumAvailable >= demand)
                    {
                        cost = demand * atriumCost;
                        sum += cost;
                        numericUpPurchasedNovosibirsk.Value = demand;
                        numericUpSumNovosibirsk.Value = cost;
                    }
                    else
                    {
                        cost = atriumAvailable * atriumCost;
                        sum += cost;
                        numericUpPurchasedNovosibirsk.Value = novosibirskAvailable;
                        numericUpSumNovosibirsk.Value = cost;
                        demand -= novosibirskAvailable;
                        cost = demand * atriumCost;
                        sum += cost;
                        numericUpPurchasedAtrium.Value = demand;
                        numericUpSumAtrium.Value = cost;
                    }
                }
            
        }
        Console.WriteLine(tomskCost + " " + novosibirskCost + " " + atriumCost + " " + tomskAvailable + " " + novosibirskAvailable + " " + atriumAvailable + " " + demand + " sum =" + sum);
        numericUpSum.Value = sum;
        return sum;
        }
    }
    
    public interface AbstractProducer
    {
        AbstractBrics bricsOrder();
        AbstractConcrete concreteOrder();
        AbstractSlabs slabsOrder();
    }

    public interface AbstractBrics
    {
        int PalletsOfBricksAvailable();
        int CostOnePallet();
    }
    public interface AbstractConcrete
    {
        int TonsOfConcreteAvailable();
        int CostOneTonn();
    }
    public interface AbstractSlabs
    {
        int AvailableSlabs();
        int CostOneSlabs();
    }

    class TomskProducerBrics : AbstractBrics
    {
        private int palletsOfBricksAvailable;
        private Random rnd = new Random(DateTime.Now.Millisecond + 1000);
        private int costOnePallet;
        public TomskProducerBrics()
        {
            palletsOfBricksAvailable = rnd.Next(50, 80);
            Console.WriteLine(palletsOfBricksAvailable);
            costOnePallet = rnd.Next(6000, 10000);
            Console.WriteLine(costOnePallet);

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
        Random rnd = new Random(DateTime.Now.Millisecond - 100);
        private int costOnePallet;
        public NovosibirskProducerBrics()
        {
            palletsOfBricksAvailable = rnd.Next(50, 80);
            Console.WriteLine(palletsOfBricksAvailable);
            costOnePallet = rnd.Next(6000, 10000);
            Console.WriteLine(costOnePallet);
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
        Random rnd = new Random(DateTime.Now.Millisecond);
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
        Random rnd = new Random(DateTime.Now.Millisecond);
        private int costOneTonn;
        public TomskProducerConcrete()
        {
            tonsOfConcreteAvailable = rnd.Next(25, 40);
            Console.WriteLine(tonsOfConcreteAvailable);
            costOneTonn = rnd.Next(4000, 6000);
            Console.WriteLine(costOneTonn);
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
        Random rnd = new Random(DateTime.Now.Millisecond + 256);
        private int costOneTonn;
        public NovosibirskProducerConcrete()
        {
            tonsOfConcreteAvailable = rnd.Next(25, 40);
            Console.WriteLine(tonsOfConcreteAvailable);
            costOneTonn = rnd.Next(4000, 6000);
            Console.WriteLine(costOneTonn);
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
        Random rnd = new Random(DateTime.Now.Millisecond + 784);
        private int costOneTonn;
        public AtriumProducerConcrete()
        {
            tonsOfConcreteAvailable = rnd.Next(25, 40);
            Console.WriteLine(tonsOfConcreteAvailable);
            costOneTonn = rnd.Next(4000, 6000);
            Console.WriteLine(costOneTonn);

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
        Random rnd = new Random(DateTime.Now.Millisecond + 11);
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
        Random rnd = new Random(DateTime.Now.Millisecond);
        private int costOneSlabs;
        public NovosibirskProducerSlabs()
        {
            availableSlabs = rnd.Next(15, 20);
            Console.WriteLine(availableSlabs);
            costOneSlabs = rnd.Next(9000, 15000);
            Console.WriteLine(costOneSlabs);

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
        Random rnd = new Random(DateTime.Now.Millisecond);
        private int costOneSlabs;
        public AtriumProducerSlabs()
        {
            availableSlabs = rnd.Next(15, 20);
            Console.WriteLine(availableSlabs);

            costOneSlabs = rnd.Next(9000, 15000);
            Console.WriteLine(costOneSlabs);

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
        public AbstractBrics bricsOrder()
        {
            return new TomskProducerBrics();
        }
        public AbstractConcrete concreteOrder()
        {
            return new TomskProducerConcrete();
        }
        public AbstractSlabs slabsOrder()
        {
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
}
