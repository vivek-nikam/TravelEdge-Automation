using System;

namespace ADX_Regression.ControlUnit
{
    class ExcelPath
    {
        public string ExcelFile()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string workbookPath = projectPath + "\\TestData\\TE_TestData.xlsx";
            return workbookPath;
        }
    }
}
