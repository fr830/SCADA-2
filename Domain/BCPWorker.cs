using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BCPWorker
    {
        public void GetDataFromServer(string TableName, string FileName)
        {
            string Comm = string.Format(@"BCP Data.dbo.{0} OUT {1}\{2}.csv -w -T -S", TableName, FileName, DateTime.Now.ToString("yyyy_MM_dd_HH_mm"));
            string ServerName = "DESKTOP-M4V9RKV";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            string str = Comm + ServerName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
        }
    }
}
