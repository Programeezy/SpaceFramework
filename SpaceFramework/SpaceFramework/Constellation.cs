namespace SpaceFramework
{
    public class Constellation
    {
        public Constellation(string name, string imagepath, StarCollection constellas)
        {
            Name = name;
            ImagePath = imagepath;
            Stars = constellas;
        }

        public Constellation(string name, string imagepath)
        {
            Name = name;
            ImagePath = imagepath;
        }

        public Constellation(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public StarCollection Stars { get; set; }
    }

}