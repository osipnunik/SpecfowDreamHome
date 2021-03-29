using SpecFlowDreanLotteryHome.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecFlowDreanLotteryHome.services
{
    class EmailGeverService
    {
        public string[] GetEmails()
        {
            string path = PathGiver.GetEmailFilePath() + "users_1.csv";
            string[] arr = new string[2567];
            string s = String.Empty;
            
                    using (StreamReader sr = new StreamReader(path))
                    {
                        int i = 0;
                        while ((s = sr.ReadLine()) != null)
                        {
                            arr[i] = s;
                            Console.WriteLine(arr[i]);
                            i++;
                        }
                    }                         
            return arr;
        }

    }
}
