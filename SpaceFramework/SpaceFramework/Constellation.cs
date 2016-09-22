using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFramework
{
    public class Constellation
    {
        public Constellation(string name, string imagepath, StarCollection constellas)
        {
            Name = name;
            ImagePath = imagepath;
            Constellations = constellas;
        }
        public string Name;
        public string ImagePath;
        public StarCollection Constellations;
    }

}