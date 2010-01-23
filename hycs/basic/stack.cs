using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Sport
{
    public string Name;
    public uint PlayersPerTeam;
}

public static class Program
{
    public static int  Main(string[] args)
    {
        Stack sports = OpenSports();

        foreach (Sport spt in sports)
        {
            Console.WriteLine("=-+-+-+-+-= Sport =-+-+-+-+-=");
            Console.WriteLine("Sport Name:   {0}", spt.Name);
            Console.WriteLine("Players/Team: {0}", spt.PlayersPerTeam);
        }

        Console.WriteLine();
        return 0;
    }

    public static void SaveSports(Stack stc)
    {
        FileStream fsSport = new FileStream("Sports.spt",
                                            FileMode.Create,
                                            FileAccess.Write);
        BinaryFormatter bfSport = new BinaryFormatter();

        bfSport.Serialize(fsSport, stc);
        fsSport.Close();
    }

    public static Stack OpenSports()
    {
        FileStream fsSport = new FileStream("Sports.spt",
                                            FileMode.Open,
                                            FileAccess.Read);
        BinaryFormatter bfSport = new BinaryFormatter();

        Stack games = (Stack)bfSport.Deserialize(fsSport);
        fsSport.Close();

        return games;
    }
}