using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using CultureBase.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CultureBase
{
   
    public enum Culture
    {
        [Description("ru")]
        ru = 1,

        [Description("en")]
        en = 2,

        [Description("pt")]
        pt = 3,

        [Description("pt-br")]
        ptbr = 4
    }
}