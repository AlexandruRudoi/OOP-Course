namespace Lab_1.Domain;

public class Display
{
    /// <summary>
    ///     Gets or sets the width of the display in pixels.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    ///     Gets or sets the height of the display in pixels.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    ///     Gets or sets the pixel density (pixels per inch) of the display.
    /// </summary>
    public float Ppi { get; set; }

    /// <summary>
    ///     Gets or sets the model name of the display.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Display"/> class with specified dimensions, pixel density, and model.
    /// </summary>
    /// <param name="width">The width of the display in pixels.</param>
    /// <param name="height">The height of the display in pixels.</param>
    /// <param name="ppi">The pixel density (ppi) of the display.</param>
    /// <param name="model">The model name of the display.</param>
    public Display(int width, int height, float ppi, string model)
    {
        this.Width = width;
        this.Height = height;
        this.Ppi = ppi;
        this.Model = model;
    }

    /// <summary>
    ///     Calculates the area of the display in pixels.
    /// </summary>
    /// <returns>The area of the display (width * height).</returns>
    private int Area()
    {
        return Width * Height;
    }

    /// <summary>
    ///     Compares the size of this display with another display based on area.
    /// </summary>
    /// <param name="other">The other <see cref="Display" /> object to compare with.</param>
    public void CompareSize(Display other)
    {
        if (Area() > other.Area())
            Console.WriteLine($"{Model} is bigger in size than {other.Model}.");
        else if (Area() < other.Area())
            Console.WriteLine($"{Model} is smaller in size than {other.Model}.");
        else
            Console.WriteLine($"{Model} and {other.Model} are equal in size.");
    }

    /// <summary>
    ///     Compares the sharpness of this display with another display based on pixel density (ppi).
    /// </summary>
    /// <param name="other">The other <see cref="Display" /> object to compare with.</param>
    public void CompareSharpness(Display other)
    {
        if (Ppi > other.Ppi)
            Console.WriteLine($"{Model} is sharper than {other.Model}.");
        else if (Ppi < other.Ppi)
            Console.WriteLine($"{Model} is less sharp than {other.Model}.");
        else
            Console.WriteLine($"{Model} and {other.Model} have the same sharpness.");
    }

    /// <summary>
    ///     Compares both the size and sharpness of this display with another display, providing a detailed output.
    /// </summary>
    /// <param name="other">The other <see cref="Display" /> object to compare with.</param>
    public void CompareWithMonitor(Display other)
    {
        Console.WriteLine($"\nComparing {Model} with {other.Model}:");
        CompareSize(other);
        CompareSharpness(other);
    }
}