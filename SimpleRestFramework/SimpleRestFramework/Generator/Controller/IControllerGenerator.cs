namespace SimpleRestFramework.Generator
{
    public interface IControllerGenerator
    {
         IFileGenerator FileGenerator{get;set;}
         void GenerateControllers();
    }
}