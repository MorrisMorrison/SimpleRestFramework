using SimpleRestFramework.Persistence;

namespace SimpleRestFramework.Utils
{
    public static class ConfigUtils
    {
        public static DbConfig GetDefaultDbConfig(){
            return new DbConfig("mysql", "developmentPW123!", "localhost", 3306, "tests", "public");
//            return new DbConfig("", "", "localhost", 27017, "simplerestframework", "");
        }
    }
}