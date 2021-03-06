using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowDreanLotteryHome.utils
{
    public class LoggerContainer
    {
        protected static NLog.Logger Log = LogManager.GetCurrentClassLogger();
    }
}
