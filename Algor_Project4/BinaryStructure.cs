using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algor_Project4
{
    public struct BinStruct: IComparable
    {
        public int id;
        public BinaryFile file;
        public BinStruct(BinaryFile bFile)
        {
            id = -1;
            file = bFile;
        }

        public int CompareTo(Object Item)
        {
            BinStruct that = (BinStruct)Item;

            return this.id.CompareTo(that.id);

        }
    }

}
