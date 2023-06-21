using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public enum CameraOptions
    {
        Rear,
        Front,
        Unknown
    }

    public enum SupportedLanguage
    {
        Unknown,
        [Code("eng"), Description("English")] English,
        [Code("deu"), Description("Deutsch")] German
    }

    public enum IngrediantUnitType
    {
        [Code("Count"), Description("Count")] Count,
        [Code("Metric"), Description("Metric")] Metric,
        [Code("Imperial"), Description("Imperial (British)")] Imperial,
        [Code("US"), Description("Imperial (US)")] US,
    }
}
