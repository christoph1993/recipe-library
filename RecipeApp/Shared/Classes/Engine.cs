using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace RecipeApp
{
    public static class Engine
    {
        #region Private Properties
        private static HashSet<Recipe> _recipes { get; set; }
        #endregion

        #region Public Properties
        #endregion

        #region Ocr Properties
        private static object _lock;
        private static bool _disposed = false;
        private static SupportedLanguage _language { get; set; } = SupportedLanguage.English;
        private static TesseractEngine _ocrEngine { get; set; }        
        public static TesseractEngine OcrEngine
        {
            get
            {
                if (_ocrEngine == null)
                    InitializeOcrEngine();
                return _ocrEngine;
            }
            set
            {
                if (_ocrEngine == value)
                    return;
                lock (_lock)
                {
                    if (_ocrEngine != null || !_ocrEngine.IsDisposed)
                        Dispose();
                    _ocrEngine = value;
                }
            }
        }
        #endregion

        #region Intializers
        public static void Initialize() => InitializeOcrEngine();
        public static void InitializeOcrEngine() => OcrEngine = new TesseractEngine(Constants.DataPath, _language.GetCode(), EngineMode.Default);
        #endregion

        #region Disposal Methods
        public static void Dispose()
        {
            if(!_disposed)
            {
                _ocrEngine.Dispose();
                _disposed = true;
            }
        }
        #endregion

        #region Ocr Methods
        public static void ChangeLanguage(SupportedLanguage lan)
        {
            _language = lan;
            InitializeOcrEngine();
        }
        public static string ParseTextFromImageBytes(byte[] bytes)
        {
            string result;
            using (var image = Pix.LoadFromMemory(bytes))
            {
                using (var page = OcrEngine.Process(image))
                {
                    var text = page.GetText();
                    if (string.IsNullOrWhiteSpace(text))
                        throw new NullReferenceException("No text was found in this image.");
                    result = text;
                }
            }
            return result;
        }
        #endregion

        #region Recipes
        public static Task<List<Recipe>> GetRecipes()
        {
            _recipes = new HashSet<Recipe>();
            return Task.FromResult(_recipes.ToList());
        }
        public static Recipe GetRecipe(Guid id) => _recipes.FirstOrDefault(r => r.RecipeKey == id);
        public static void AddRecipe(Recipe recipe) => _recipes.Add(recipe);
        public static void AddRecipe(string name, List<string> ingredients = default, List<string> steps = default, string description = null) => _recipes.Add(new Recipe() { Description = description, Name = name, Ingredients = ingredients, Steps = steps, RecipeKey = Guid.NewGuid() });
        #endregion
    }
}
