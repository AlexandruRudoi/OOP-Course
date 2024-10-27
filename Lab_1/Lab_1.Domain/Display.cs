namespace Lab_1.Domain;

public class Display
{
    private int Width { get; set; }
    private int Height { get; set; }
    private float Ppi { get; set; }
    private string Model { get; set; }

    public Display(int width, int height, float ppi, string model)
    {
        this.Width = width;
        this.Height = height;
        this.Ppi = ppi;
        this.Model = model;
    }

    private int Area()
    {
        return Width * Height;
    }

    public void CompareSize(Display other)
    {
        if (this.Area() > other.Area())
        {
            Console.WriteLine($"{this.Model} is bigger in size than {other.Model}.");
        }
        else if (this.Area() < other.Area())
        {
            Console.WriteLine($"{this.Model} is smaller in size than {other.Model}.");
        }
        else
        {
            Console.WriteLine($"{this.Model} and {other.Model} are equal in size.");
        }
    }

    public void CompareSharpness(Display other)
    {
        if (this.Ppi > other.Ppi)
        {
            Console.WriteLine($"{this.Model} is sharper than {other.Model}.");
        }
        else if (this.Ppi < other.Ppi)
        {
            Console.WriteLine($"{this.Model} is less sharp than {other.Model}.");
        }
        else
        {
            Console.WriteLine($"{this.Model} and {other.Model} have the same sharpness.");
        }
    }

    public void CompareWithMonitor(Display other)
    {
        Console.WriteLine($"Comparing {this.Model} with {other.Model}:");
        CompareSize(other);
        CompareSharpness(other);
    }
}