using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.utils
{
    class PathGiver
    {
        private static string PicturePath = Environment.CurrentDirectory.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\");
        public static string GetPicturePath()
        {
            return PicturePath;
        }
    }
}
