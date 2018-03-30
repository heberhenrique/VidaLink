using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models.Base;
using VidaLink.Domain.Util;

namespace VidaLink.Domain.Util
{
    public static class ObjectExtensions
    {
        public static T GenerateIDs<T>(this T model)
        {
            var types = new[] { typeof(Guid), typeof(Nullable<Guid>) };

            var guidProperties = model.GetType()
                                          .GetProperties()
                                          .Where(p => types.Contains(p.PropertyType))
                                          .ToArray();

            foreach (var guidProperty in guidProperties)
            {
                var currentValue = default(Guid);

                if (guidProperty.Name.Equals("ID"))
                {
                    if (guidProperty.GetValue(model, null) != null)
                    {
                        currentValue = (Guid)guidProperty.GetValue(model, null);
                        if (currentValue.Equals(Guid.Empty))
                        {
                            guidProperty.SetValue(model, Guid.NewGuid(), null);
                        }
                    }
                }
            }

            var baseModelTypes = new[] { typeof(BaseModel) };

            var baseModelProperties = model.GetType()
                                          .GetProperties()
                                          .ToArray();

            foreach (var baseModelProperty in baseModelProperties)
            {
                var currentValue = default(BaseModel);

                try
                {
                    currentValue = (BaseModel)baseModelProperty.GetValue(model, null);
                }
                catch { }

                if (currentValue != null)
                {
                    baseModelProperty.SetValue(model, currentValue.GenerateIDs(), null);
                }

            }

            return model;
        }
    }
}
