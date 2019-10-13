namespace SimpleRestFramework.Generator
{
    public interface IServiceGenerator
    {
         IFileGenerator FileGenerator{get;set;}
         void GenerateServices();
    }
}