using Newtonsoft.Json.Linq;
using System;
using System.Linq;

public class ResearchJsonConverter : CustomConverterBase<IResearch>
{
    protected override IResearch Create(Type objectType, JObject jObject)
    {
        if (FieldExists("Name", jObject))
        {
            string field = (string)jObject["Name"];

            if (field == ValueResearch.NAME)
                return GetResearch(ValueResearch.NAME);
            else if (field == DoubleValue.NAME)
                return GetResearch(DoubleValue.NAME);
            else 
                throw new NotImplementedException($"Implement other researches - Missing '{field}'");
        }

        return null;
    }

    IResearch GetResearch(string name)
    {
        return ResearchManager.ALL_RESEARCH.FirstOrDefault(x => x.Name == name);
    }

    private bool FieldExists(string fieldName, JObject jObject)
    {
        return jObject["Name"] != null;
    }
}
