using System;
using System.Linq;
using System.Text;
using SimpleRestFramework.Utils;

namespace SimpleRestFramework.Generator
{
    public class DaoGenerator:IDaoGenerator
    {
        private DaoConfig _daoConfig {get;set;}
        public IFileGenerator FileGenerator { get; set; }

        public DaoGenerator (DaoConfig p_config){
            _daoConfig = p_config;
        }

        public void GenerateDaos()
        {
            string path = PathUtils.GetDaoPath();

            foreach (var daoToCreate in _daoConfig.DaosToCreate)
            {
                string fileName = daoToCreate.Key;
                Type type = daoToCreate.Value;

                
                path = path + "/" + fileName;

                string content = BuildContent(fileName, type);

                FileGenerator.GenerateFile(path, fileName + ".cs", content);
            };

        }

        private string BuildContent(string p_fileName, Type p_type){
            StringBuilder sb = new StringBuilder();

            string fileName = p_fileName[0].ToString().ToUpper() + p_fileName.Substring(1);

            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using MongoDB.Bson;");
            sb.AppendLine("using MongoDB.Drive;");

            sb.AppendLine("namespace SimpleRestFramework.Dao");
            sb.AppendLine("{");

            sb.AppendLine("public class " + fileName + ":IDao");
            sb.AppendLine("{");

            sb.Append(BuildGetFunction());

            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string BuildGetFunction(){
        
            return "";
            
        }
    }
}