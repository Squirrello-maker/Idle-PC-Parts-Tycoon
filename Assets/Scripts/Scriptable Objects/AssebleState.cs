using UnityEngine;
/// <summary>
/// ScriptableObject storing data about each state of the part
/// </summary>
[CreateAssetMenu (fileName = "Part Assemble Status", menuName = "Part Data/Part Assemble Status")]
public class AssebleState : ScriptableObject
{
    public enum AssebmleState
    {
        none,
        motherboard,
        cpu,
        ram,
        gpu,
        psu,
        hdd,
        cover,
        cooling,
        RGBLeds,
        overclocking
    }
    public AssebmleState assebmleState = AssebmleState.none;
}
