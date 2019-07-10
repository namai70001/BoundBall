using System.Collections.Generic;

namespace Framework.RectangularList
{
    public class RectangularList<T>
    {
        public List<ValueList<T>> valuseList = new List<ValueList<T>>();

        public RectangularList(List<ValueList<T>> rectangularList)
        {

        }
    }

    public class ValueList<T>
    {
        public List<T> List = new List<T>();

        public ValueList(List<T> list)
        {
            List = list;
        }
    }
}