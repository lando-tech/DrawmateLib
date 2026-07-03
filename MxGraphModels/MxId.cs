using System.Text;

namespace DrawmateLib.MxGraphModels;

public class MxId
{
    public string Value { get; }
    private List<char> AlphanumericList = [.. Enumerable.Range('0', 10)
            .Concat(Enumerable.Range('A', 26))
            .Concat(Enumerable.Range('a', 26))
            .Select(i => (char)i)];
    private int DefaultIdSize { get; set; } = 20;

    public MxId()
    {
        Value = GenerateIdWithoutPostfix();
    }

    public MxId(int cellCount)
    {
        Value = GenerateId(cellCount);
    }

    /// <summary>
    ///  Generates a random Id using the count of the node prefixed with '-'.
    ///  This matches draw.io's internal Id generation.
    /// </summary>
    /// <param name="cellCount">The number assigned to the node</param>
    /// <returns></returns>
    private string GenerateId(int cellCount)
    {
        var rand = new Random();
        var sb = new StringBuilder();
        for (int i = 0; i < DefaultIdSize; ++i)
        {
            int randIdx = rand.Next(AlphanumericList.Count - 1);
            sb.Append(AlphanumericList[randIdx]);
        }
        sb.Append($"-{cellCount}");
        return sb.ToString();
    }

    private string GenerateIdWithoutPostfix()
    {
        var rand = new Random();
        var sb = new StringBuilder();
        for (int i = 0; i < DefaultIdSize; ++i)
        {
            int randIdx = rand.Next(AlphanumericList.Count - 1);
            sb.Append(AlphanumericList[randIdx]);
        }
        return sb.ToString();
    }
}
