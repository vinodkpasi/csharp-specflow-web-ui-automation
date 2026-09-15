using System;
using TechTalk.SpecFlow;
using SpecFlowExpertLevelCertification.Utils;

namespace SpecFlowExpertLevelCertification.Hooks
{
    [Binding]
    public class ReportsHooks
    {
        [AfterTestRun]
        public static void GenerateReport()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C livingdoc test-assembly SpecFlowExpertLevelCertification.dll -t TestExecution.json --output ../../../Reports/Report.html";
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception ex)
            {
                Util.Log.Error(ex.StackTrace);
            }
        }
    }
}
