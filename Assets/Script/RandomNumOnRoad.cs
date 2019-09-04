
public class RandomNumOnRoad
{
    private static int RandomNum;
    public static int PositionOnRoad(int lowValue,int toleranceValueToMid, int highValue)
    {

        RandomNum = UnityEngine.Random.Range(lowValue, highValue);
        if (RandomNum < -toleranceValueToMid)
        {
            RandomNum = lowValue;
        }
        else if (RandomNum >= toleranceValueToMid)
        {
            RandomNum = highValue;
        }
        else
        {
            RandomNum = 0;
        }

        return RandomNum;
    }
}