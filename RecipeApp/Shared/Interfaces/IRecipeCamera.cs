using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IRecipeCamera
    {
        public virtual Task TaskPhoto() => Task.FromException(new NotSupportedException());
    }
}
