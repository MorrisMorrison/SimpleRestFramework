namespace SimpleRestFramework.Generator
{
    public interface IDaoGenerator
    {
         IFileGenerator FileGenerator{get;set;}
         void GenerateDaos();
    }
}