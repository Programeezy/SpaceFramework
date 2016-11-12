using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceCatalog;
using System.IO;
using System.IO.Compression;

namespace SpaceCatalog.IO
{
    public static class SpaceFileHandler
    {
        static void WriteBinaryConstellation(string filename, Constellation constellation)
        {

        }

        static void WriteBinaryStar(string filename, Star constellations)
        {

        }

        static void WriteBinaryPlanet(string filename, Constellation constellations )
        {
            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.Append))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Compress))
                {
                    BinaryWriter bw = new BinaryWriter(ds);
                    
                }
            }
        }

    }
}
