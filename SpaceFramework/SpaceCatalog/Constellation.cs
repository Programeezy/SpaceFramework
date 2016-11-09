namespace SpaceCatalog
{
    public class Constellation
    {

        public Constellation()
        {
            Name = null;
            ImagePath = "";
            Stars = new StarCollection();
        }
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
            ImagePath = null;
            Stars = new StarCollection();
        }

        public string Name { get; set; }
        public string ImagePath { get; set; }
        public StarCollection Stars { get; set; }
    }

}