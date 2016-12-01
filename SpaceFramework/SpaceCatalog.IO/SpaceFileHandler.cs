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
        private static int PlanetID = RefreshPlanetID();
        private static int StarID = RefreshStarID();
        public static readonly string PlanetsFile = @"Planets";
        public static readonly string StarsFile = @"Stars";
        public static readonly string ConstellationsFile = @"Constellations";

        private static int RefreshPlanetID()
        {
            PlanetID = 1;

            using (Stream fileSource = new FileStream(PlanetsFile + ".bin", FileMode.OpenOrCreate))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Decompress))
                {
                    BinaryReader br = new BinaryReader(ds);
                    while (br.PeekChar() > -1)
                    {
                        PlanetID = br.ReadInt32();
                        br.ReadString();
                        br.ReadDouble();
                        br.ReadDouble();
                        br.ReadDouble();
                        br.ReadDouble();
                        br.ReadDouble();
                    }
                    br.Close();
                    return PlanetID;
                }
            }

        }

        private static int RefreshStarID()
        {
            StarID = 1;

            using (Stream fileSource = new FileStream(StarsFile + ".bin", FileMode.OpenOrCreate))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Decompress))
                {
                    BinaryReader br = new BinaryReader(ds);
                    while (br.PeekChar() > -1)
                    {
                        StarID = br.ReadInt32();
                        br.ReadString();
                        br.ReadDouble();
                        br.ReadDouble();
                        br.ReadDouble();
                        br.ReadChar();
                        br.ReadString();
                    }
                    br.Close();
                }
            }
           
            return StarID;
        }



        private static string[] GetFieldsFromConstellation(Constellation constellation)
        {
            string[] fields = new string[3];

            fields[0] = constellation.Name;
            fields[1] = constellation.ImagePath;

            foreach (var star in constellation.Stars)
                fields[2] += WriteBinaryStar(StarsFile, star) + " ";

            fields[2] = fields[2].Remove(fields[2].Length - 1);

            return fields;

        }

        private static string[] GetFieldsFromStar(Star star)
        {
            string[] fields = new string[7];

            fields[0] = StarID.ToString();
            StarID++;
            fields[1] = star.Name;
            fields[2] = star.Radius.ToString();
            fields[3] = star.Mass.ToString();
            fields[4] = star.Luminosity.ToString();
            fields[5] = star.Type.ToString();
            foreach (var planet in star.SatellitePlanets)
            {
                fields[6] += WriteBinaryPlanet(PlanetsFile, planet).ToString() + " ";
            }

            fields[6] = fields[6].Remove(fields[6].Length - 1 );
            return fields;

        }
        private static string[] GetFieldsFromPlanet(Planet planet)
        {
            string[] fields = new string[7];
            fields[0] = PlanetID.ToString();
            PlanetID++;
            fields[1] = planet.Name;
            fields[2] += planet.Radius.ToString();
            fields[3] += planet.Mass.ToString();
            fields[4] += planet.PeriodOfSpinning.ToString();
            fields[5] += planet.PeriodOfRotation.ToString();
            fields[6] += planet.RadiusOfOrbit.ToString();
            return fields;
        }

        public static void WriteBinaryConstellation(string filename, Constellation constellation)
        {

            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.Append))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Compress))
                {
                    BinaryWriter bw = new BinaryWriter(ds);
                    string[] constellationFields = GetFieldsFromConstellation(constellation);

                    foreach (var str in constellationFields)
                    {
                        bw.Write(str);
                    }

                    bw.Close();
                }
            }
        }

        public static int WriteBinaryStar(string filename, Star star)
        {
            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.OpenOrCreate))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Compress))
                {
                    BinaryWriter bw = new BinaryWriter(ds);
                    string[] starFields = GetFieldsFromStar(star);

                    foreach (var str in starFields)
                    {
                        bw.Write(str);
                    }

                    bw.Close();
                    return Convert.ToInt32(starFields[0]);
                }
            }
        }

        public static int WriteBinaryPlanet(string filename, Planet planet)
        {
            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.Append))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Compress))
                {
                    BinaryWriter bw = new BinaryWriter(ds);
                    string[] planetFields = GetFieldsFromPlanet(planet);
                    foreach (var str in planetFields)
                    {
                        bw.Write(str);
                    }

                    bw.Close();
                    return PlanetID;
                }
            }
        }

        

        public static Planet ReadBinaryPlanet(string filename, int id = 0)
        {
            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.OpenOrCreate))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Decompress))
                {
                    BinaryReader br = new BinaryReader(ds);
                    if (id == 0)
                    {
                        br.ReadInt32();
                        return new Planet(br.ReadString(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble());
                    }

                    else
                    {
                        while (Convert.ToInt32(br.ReadString()) != id)
                        {
                            if (br.PeekChar() <= -1)
                                return null;

                            br.ReadString();
                            br.ReadString();
                            br.ReadString();
                            br.ReadString();
                            br.ReadString();
                            br.ReadString();
                        }

                        return new Planet(br.ReadString(), Convert.ToDouble(br.ReadString()), Convert.ToDouble(br.ReadString()), Convert.ToDouble(br.ReadString()), Convert.ToDouble(br.ReadString()), Convert.ToDouble(br.ReadString()));
                    }
                }
            }
        }

        public static Star ReadBinaryStar(string filename, int id = 0)
        {
            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.OpenOrCreate))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Decompress))
                {
                    BinaryReader br = new BinaryReader(ds);
                    if (id == 0)
                    {
                        br.ReadInt32();
                        Star _star = new Star(br.ReadString(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), (LumEnum)br.ReadChar(), new PlanetCollection());
                        string _planets = br.ReadString();
                        string[] _idList = _planets.Split(' ');

                        foreach (var idItem in _idList)
                        {
                            _star.SatellitePlanets.Add(ReadBinaryPlanet(PlanetsFile, Convert.ToInt32(idItem)));
                        }

                        return _star;
                    }

                    while (Convert.ToInt32(br.ReadString()) != id)
                    {
                        

                       string a = br.ReadString();
                        br.ReadString();
                        br.ReadString();
                        br.ReadString();
                        br.ReadString();
                        br.ReadString();
                    }
                    
                    Star star = new Star(br.ReadString(), Convert.ToDouble(br.ReadString()), Convert.ToDouble(br.ReadString()), Convert.ToDouble(br.ReadString()), (LumEnum)Convert.ToChar(br.ReadString()), new PlanetCollection());
                    string planets = br.ReadString();
                    string[] idList = planets.Split(' ');

                    foreach (var idItem in idList)
                    {
                        star.SatellitePlanets.Add(ReadBinaryPlanet(PlanetsFile, Convert.ToInt32(id)));
                    }

                    br.Close();
                    return star;

                }
            }
        }

        public static Constellation ReadBinaryConstellation(string filename)
        {
            using (Stream fileSource = new FileStream(filename + ".bin", FileMode.Open))
            {
                using (DeflateStream ds = new DeflateStream(fileSource, CompressionMode.Decompress))
                {
                    BinaryReader br = new BinaryReader(ds);
                    Constellation constellation = new Constellation(br.ReadString(), br.ReadString(), new StarCollection());
                    string stars = br.ReadString();
                    string[] idList = stars.Split(' ');

                    foreach (var idItem in idList)
                    {
                        constellation.Stars.Add(ReadBinaryStar(StarsFile, Convert.ToInt32(idItem)));
                    }

                    return constellation;
                }
            }
        }

    }
}