using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCatalog
{
   
    public class ConstellationCollection : MainCollection<Constellation>
    {
       
        public Constellation FindByName(string name)
        {
            foreach (Constellation item in this)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }

            return null;
            
        }


    }
}
