namespace Map;

public class GeneratorMapPerimeter
{
    public char[,] Create(char wallSymbol, char cleanSymbol, int width, int height)
    {
        char[,] newMap = new char[width, height];

        for (int i = 0; i < width; i++)
        {
            newMap[i, 0] = wallSymbol;
            newMap[i, height - 1] = wallSymbol;
        }

        for (int j = 1; j < height - 1; j++)
        {
            newMap[0, j] = wallSymbol;
            newMap[width - 1, j] = wallSymbol;
        }

        newMap[0, 1] = cleanSymbol;
        newMap[width - 1, height - 2] = cleanSymbol;
        return newMap;
    }
}