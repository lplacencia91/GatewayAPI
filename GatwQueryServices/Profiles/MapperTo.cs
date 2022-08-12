using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GatwQueryServices.Profiles
{
    public static class MapperTo
    {

        public static T MapTo<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
        }
    }
}
