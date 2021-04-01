using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.utils
{
    class PathGiver
    {
        private static string CurDir = Environment.CurrentDirectory;
        private static string PicturePath = CurDir.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\pictures\\");
        private static string ProjectPath = CurDir.Replace("TestResults", "\\SpecFlowDreanLotteryHome\\");
        public static string GetPicturePath()
        {
            return PicturePath;
        }
        public static string GetProjectPath()
        {
            return ProjectPath;
        }
        public static string GetEmailFilePath()
        {
            return PicturePath;
        }
    }
}
