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
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public StarCollection Stars { get; set; }
    }

}