﻿using Newtonsoft.Json.Linq;
using System;

public class HouseJsonConverter : CustomConverterBase<IHouse>
{
    protected override IHouse Create(Type objectType, JObject jObject)
    {
        if (FieldExists("Name", jObject))
        {
            string field = (string)jObject["Name"];

            if (field == Sty.NAME)
                return new Sty();
            else
                throw new NotImplementedException($"Implement other houses - Missing {field}");
        }

        return null;
    }

    private bool FieldExists(string fieldName, JObject jObject)
    {
        return jObject["Name"] != null;
    }
}
