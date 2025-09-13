using System.Collections.Generic;
public struct Peaces
{
    public List<List<int>> peace1;
    public List<List<int>> peace2;
    public int axis;
}
class Programm {
    public List<List<int>> map = new List<List<int>>();
    void GeneratorMap()
    {
        for (int i = 0; i < 100; i++)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < 100; j++)
            {
                list.Add(0);
            }
            map.Add(list);
        }
    }
    void PrintMap(List<List<int>> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                Console.Write(list[i][j]);
            }
            Console.Write("\n");
        }
    }
    Peaces Cut(List<List<int>> list, int axis, int cut)
    {
        List<List<int>> peace1 = new List<List<int>>();
        List<List<int>> peace2 = new List<List<int>>();

        if (axis == 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i < cut) peace1.Add(list[i]);
                else peace2.Add(list[i]);
            }
        }
        else if (axis == 1) 
        {
            for (int i = 0;i < list.Count; i++)
            {
                List<int> str = new List<int>();
                List<int> str2 = new List<int>();
                for (int j = 0;j < list[i].Count; j++)
                {
                    if (j < cut) str.Add(list[i][j]);
                    else str2.Add(list[i][j]);
                }
                peace1.Add(str);
                peace2.Add(str2);
            }
        }
        Peaces p = new Peaces();
        PrintMap(peace1);
        PrintMap(peace2);
        p.peace1 = peace1;
        p.peace2 = peace2;
        p.axis = axis;
        return p;
    }
    List<List<int>> Connect(Peaces p)
    {
        List < List<int> > ret = new List<List<int>>();
        if (p.axis == 0)
        {
            ret.AddRange(p.peace1);
            ret.AddRange(p.peace2);
        }
        else
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < p.peace1.Count + p.peace2.Count; i++)
            {
                ret.Add(ints);
                ret[i].AddRange(p.peace1[i]);
                ret[i].AddRange(p.peace2[i]);
            }
        }
        return ret;
    }
    List<List<int>> Dig(List<List<int>> list) {
    
    }
    Peaces BTSmap(List<List<int>> list, int n)
    {
        n--;
        Random rnd = new Random();
        int cut = rnd.Next(Convert.ToInt32(list.Count * 0.3), Convert.ToInt32(list.Count * 0.7));
        int axis = rnd.Next(0, 1);
        Peaces peases = new Peaces();
        peases = Cut(list, axis, cut);
        Peaces ret1 = new Peaces();
        Peaces ret2 = new Peaces();
        if (n  == 0)
        {

            return peases;
        }
        else
        {
            ret1 = BTSmap(peases.peace1, n);
            ret2 = BTSmap(peases.peace2, n);
            List<List<int>> peace1 = new List<List<int>>();
            List<List<int>> peace2 = new List<List<int>>();
            peace1 = Connect(ret1);
            peace2 = Connect(ret2);
            Peaces ret = new Peaces();
            ret.peace1 = peace1;
            ret.peace2 = peace2;
            ret.axis = axis;
            return ret;
        }
    }
    public static int Main(string[] args)
    {
        Programm start = new Programm();
        start.GeneratorMap();
        Peaces p = new Peaces();
        p = start.BTSmap(start.map, 3);
        start.map.Clear();
        start.map = start.Connect(p);
        start.PrintMap(start.map);

        return 0;
    }
}