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
        public string Name;
        public string ImagePath;
        public StarCollection Stars;
    }

}