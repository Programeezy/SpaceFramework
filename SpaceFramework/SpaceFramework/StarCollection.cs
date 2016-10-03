using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class StarCollection : MainCollection<Star>
    {
    
        public bool Find(string Name)
        {
            foreach (Star _item in this)
            {
                if (_item.Name == Name)
                    return true;
            }

            return false;
        }

        public StarCollection Find(LumEnum SType)
        {
            StarCollection stars = new StarCollection();
            foreach (Star item in this)
            {
                if (item.Type.Equals(SType))
                    stars.Add(item);
            }

            return stars;
        }

       

    }
}