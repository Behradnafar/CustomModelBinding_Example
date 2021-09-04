using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBinding.Bugeto.Models
{
    public class UserCustomModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var values = bindingContext.ValueProvider.GetValue("user");
            if(values.Length == 0)
            {
                return Task.CompletedTask;
            }

            var splitData = values.FirstValue.Split(new char[] { '|' });
            if(splitData.Length >= 3)
            {
                User user = new User()
                {
                    Id = int.Parse(splitData[0]),
                    Name = splitData[1],
                    LastName = splitData[2]
                };
                bindingContext.Result = ModelBindingResult.Success(user);
            }

            return Task.CompletedTask;
        }
    }
}
