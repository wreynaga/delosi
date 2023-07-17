using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace DelosiWebApi.Helper
{
    public class CustomBody : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var modelName = bindingContext.ModelName;

            var values = bindingContext.ValueProvider.GetValue(modelName);
            if (values.Length == 0)
                return Task.CompletedTask;

            var a = (string)values;
            var b = "[" + a + "]";

            var result = JsonConvert.DeserializeObject<int[,]>(b);

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
