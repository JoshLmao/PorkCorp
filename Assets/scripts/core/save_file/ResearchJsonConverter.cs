using Newtonsoft.Json.Linq;
using System;
using System.Linq;

public class ResearchJsonConverter : CustomConverterBase<IResearch>
{
    ResearchManager m_researchManager;

    public ResearchJsonConverter(ResearchManager researchManager)
    {
        m_researchManager = researchManager;
    }

    protected override IResearch Create(Type objectType, JObject jObject)
    {
        if (FieldExists("Name", jObject))
        {
            string field = (string)jObject["Name"];

            IResearch research = GetResearch(field);
            research.SetLoadedValues((int)jObject["AmountBought"]);

            if (research != null)
                return research;
            else
                throw new NotImplementedException($"Can't find research with name '{field}'");
        }

        return null;
    }

    IResearch GetResearch(string name)
    {
        return m_researchManager.AllResearch.FirstOrDefault(x => x.Name == name);
    }

    private bool FieldExists(string fieldName, JObject jObject)
    {
        return jObject["Name"] != null;
    }
}
