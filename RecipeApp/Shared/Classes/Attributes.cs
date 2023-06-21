using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CodeAttribute : Attribute
    {
        public string Code { get; set; }
        public CodeAttribute(string code) => Code = code;
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; set; }
        public DescriptionAttribute(string description) => Description = description;
    }
}
