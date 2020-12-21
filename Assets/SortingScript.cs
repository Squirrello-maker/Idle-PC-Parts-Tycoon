using System.Linq;

public abstract class SortingScript 
{
    public static Cluster[] SortClusters(Cluster[] clusters)
    {
        return clusters.OrderBy(go => go.name).ToArray();
    }
}
