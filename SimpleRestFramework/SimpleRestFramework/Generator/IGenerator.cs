namespace SimpleRestFramework.Generator
{
    public interface IGenerator
    {

        IDaoGenerator DaoGenerator { get; set; }
        IServiceGenerator ServiceGenerator { get; set; }
        IControllerGenerator ControllerGenerator { get; set; }


        void GenerateDaos();
        void GenerateServices();
        void GenerateControllers();

    }
}