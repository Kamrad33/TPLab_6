using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;

namespace TP_Lab5.Models
{
    public class Log
    {
        static Log()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static ILog For(object LoggedObject)
        {
            if (LoggedObject != null)
                return For(LoggedObject.GetType());
            else
                return For(null);
        }

        public static ILog For(Type ObjectType)
        {
            if (ObjectType != null)
                return LogManager.GetLogger(ObjectType.Name);
            else
                return LogManager.GetLogger(string.Empty);
        }
    }
}
