using System;

[Serializable]
public class Grid2DString
{
    public int rows = 3;
    public int cols = 3;
    public string[] data = new string[9];

    public string[,] Get2DArray()
    {
        string[,] result = new string[rows, cols];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                result[r, c] = data[r * cols + c];
        return result;
    }

    public void Resize(int newRows, int newCols)
    {
        newRows = Math.Max(1, newRows);
        newCols = Math.Max(1, newCols);

        string[] newData = new string[newRows * newCols];
        int copyRows = Math.Min(rows, newRows);
        int copyCols = Math.Min(cols, newCols);
        for (int r = 0; r < copyRows; r++)
            for (int c = 0; c < copyCols; c++)
                newData[r * newCols + c] = data[r * cols + c];

        rows = newRows;
        cols = newCols;
        data = newData;
    }
}
