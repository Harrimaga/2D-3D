using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Core.Model
{
    internal class LookupTable
    {
        public int Width => LookupArray.GetLength(0);
        public int Height => LookupArray.GetLength(1);
        public Vector3[,] LookupArray { get; }

        public Vector3 this[int x, int y]
        {
            get => LookupArray[x, y];
            set => LookupArray[x, y] = value;
        }

        public LookupTable(int width, int height) =>
            LookupArray = new Vector3[width, height];
        /*
            private Vector3?[,] _lookupArray;

            public LookupTable(int x, int y)
            {
        	    _lookupArray = new Vector3?[x, y];
            }

            public Vector3? LookUp(int x, int y)
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
        */
    }
}