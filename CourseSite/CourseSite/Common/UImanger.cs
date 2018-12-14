using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CourseSite.Common
{
    public static class UImanger
    {
        public static string CurrentLang
        {
            get { return Thread.CurrentThread.CurrentCulture.Name; }
        }
    }
}