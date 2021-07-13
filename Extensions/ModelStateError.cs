namespace Test.Logger.Services.Extensions
{   
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public static class Extensions
    {
        public static IEnumerable<string> ToError(this ModelStateDictionary modelState)
        {
            var builder = new StringBuilder();
            var errors = new List<string>();

            if (!modelState.IsValid)
            {
                IEnumerable<ModelError> modelerrors = modelState.SelectMany(x => x.Value.Errors);
                foreach (var modelerror in modelerrors)
                {
                    errors.Add(modelerror.ErrorMessage);
                    builder.AppendLine("Description " + modelerror.ErrorMessage);
                }
            }          

            return errors;
        }
    }

}