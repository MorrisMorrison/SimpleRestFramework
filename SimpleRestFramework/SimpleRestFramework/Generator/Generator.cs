namespace SimpleRestFramework.Generator
{
    public class Generator : IGenerator
    {
        public IDaoGenerator DaoGenerator { get; set; }
        public IServiceGenerator ServiceGenerator { get; set; }
        public IControllerGenerator ControllerGenerator { get; set; }




        public void GenerateControllers()
        {
            ControllerGenerator.GenerateControllers();
        }

        public void GenerateDaos()
        {
            DaoGenerator.GenerateDaos();
        }

        public void GenerateServices()
        {
            ServiceGenerator.GenerateServices();
        }
    }
}