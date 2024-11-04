namespace Lab_2.Task4;

public class Barista
{
    /// <summary>
    ///     Accepts a list of coffee orders and prepares each coffee.
    /// </summary>
    public void TakeOrder(
        List<(string CoffeeType, Intensity Intensity, int? MlOfMilk, int? MgOfPumpkinSpice, SyrupType? Syrup)>
            orderList)
    {
        foreach (var order in orderList)
            switch (order.CoffeeType.ToLower())
            {
                case "cappuccino":
                    var cappuccino = Cappuccino.MakeCappuccino(order.Intensity, order.MlOfMilk ?? 0);
                    cappuccino.MakeCoffee();
                    Console.WriteLine();
                    break;

                case "pumpkinspicelatte":
                    var pumpkinLatte = PumpkinSpiceLatte.MakePumpkinSpiceLatte(order.Intensity, order.MlOfMilk ?? 0,
                        order.MgOfPumpkinSpice ?? 0);
                    pumpkinLatte.MakeCoffee();
                    Console.WriteLine();
                    break;

                case "americano":
                    var americano = Americano.MakeAmericano(order.Intensity, order.MlOfMilk ?? 0);
                    americano.MakeCoffee();
                    Console.WriteLine();
                    break;

                case "syrupcappuccino":
                    var syrupCappuccino = SyrupCappuccino.MakeSyrupCappuccino(order.Intensity, order.MlOfMilk ?? 0,
                        order.Syrup ?? SyrupType.CARAMEL);
                    syrupCappuccino.MakeCoffee();
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine($"Unknown coffee type: {order.CoffeeType}");
                    break;
            }
    }
}