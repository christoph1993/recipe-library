using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Pages
{
    partial class RecipePage
    {
        [Parameter]
        public Guid RecipeId { get; set; }

        private bool _loading = true;
        private Recipe _recipe { get; set; }
        private enum ActiveTab { Ingredients, Steps }
        private ActiveTab _activeTab { get; set; } = ActiveTab.Ingredients;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _recipe = Engine.GetRecipe(RecipeId);
            if (_recipe == null) _recipe = new();
            _loading = false;
        }
    }
}
