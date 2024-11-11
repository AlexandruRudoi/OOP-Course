namespace Lab_2.Task4;

public class Barista
{
    /// <summary>
    ///     Accepts a list of coffee orders and prepares each coffee.
    /// </summary>
    public void TakeOrder(
        List<(string CoffeeType, Intensity Intensity, int? MlOfLiquid, int? MgOfPumpkinSpice, SyrupType? Syrup)>
            orderList)
    {
        foreach (var order in orderList)
            switch (order.CoffeeType.ToLower())
            {
                case "cappuccino":
                    var cappucino = new Cappuccino(order.Intensity, order.MlOfLiquid ?? 0);
                    cappucino.MakeCappuccino();
                    Console.WriteLine();
                    break;

                case "pumpkinspicelatte":
                    var pumpkinLatte = new PumpkinSpiceLatte(order.Intensity, order.MlOfLiquid ?? 0,
                        order.MgOfPumpkinSpice ?? 0);
                    pumpkinLatte.MakePumpkinSpiceLatte();
                    Console.WriteLine();
                    break;

                case "americano":
                    var americano = new Americano(order.Intensity, order.MlOfLiquid ?? 0);
                    americano.MakeAmericano();
                    Console.WriteLine();
                    break;

                case "syrupcappuccino":
                    var syrupCappuccino = new SyrupCappuccino(order.Intensity, order.MlOfLiquid ?? 0,
                        order.Syrup ?? SyrupType.CARAMEL);
                    syrupCappuccino.MakeSyrupCappuccino();
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine($"Unknown coffee type: {order.CoffeeType}");
                    break;
            }
    }
}