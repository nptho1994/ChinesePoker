using pk_Application.Common;

namespace pk_Application.Model;

public class TreeCard
{
    public List<CardUnit> Stack1 { get; set; } = new List<CardUnit>();
    public List<CardUnit> Stack2 { get; set; } = new List<CardUnit>();
    public List<CardUnit> Stack3 { get; set; } = new List<CardUnit>();
}
