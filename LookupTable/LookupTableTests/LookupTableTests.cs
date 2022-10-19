using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Security.Principal;
using LookupNamespace;
namespace LookupTableTests;

public class Tests
{
    public int x, y;
    public Random ran;
    [SetUp]
    public void Setup()
    {
        x = 1080;
        y = 720;
        ran = new Random();

    }

    [Test]
    public void ArrayIntitialize()
    { 
        LookupTable Table  = new LookupTable(x, y);
        Vector3?[,] Array = Table.GetArray();
        Assert.AreEqual(Array.GetLength(0),x);
        Assert.AreEqual(Array.GetLength(1),y);
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Assert.Null(Table.LookUp(i,j));
            }
        }
    }

    [Test]
    [Repeat(500)]
    public void ValueAdded()
    {
        LookupTable Table  = new LookupTable(x, y);
        int testx = ran.Next(x);
        int testy = ran.Next(y);
        Assert.Null(Table.LookUp(testx,testy));
        Table.PutInTable(testx,testy,new Vector3(ran.Next(),ran.Next(),ran.Next()));
        Assert.NotNull(Table.LookUp(testx,testy));
    }

    [Test]
    [Repeat(500)]
    public void CorrectValueAdded()
    { 
        LookupTable Table  = new LookupTable(x, y);
        int testx = ran.Next(x);
        int testy = ran.Next(y);
        Vector3 testvec = new Vector3(ran.Next(), ran.Next(), ran.Next());
        Assert.Null(Table.LookUp(testx,testy));
        Table.PutInTable(testx,testy,testvec);
        Assert.AreEqual(testvec,Table.LookUp(testx,testy));
    }
    
    
}