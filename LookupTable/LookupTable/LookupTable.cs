using System;
using System.Numerics;
namespace LookupNamespace;

public class LookupTable
{
    
    private Vector3?[,] _lookupArray;

    public LookupTable(int x, int y)
    {
        _lookupArray = new Vector3?[x, y];
    }
    
    public  Vector3? LookUp(int x, int y)
    {
        return _lookupArray[x, y];
    }

    public void PutInTable(int x, int y, Vector3 location)
    { 
        _lookupArray[x, y] = location;
    }

    public Vector3?[,] GetArray()
    {
        return _lookupArray;
    }

}