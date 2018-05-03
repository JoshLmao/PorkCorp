using Newtonsoft.Json.Linq;
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
            else if (field == LargeShed.NAME)
                return new LargeShed();
            else if (field == Bungalow.NAME)
                return new Bungalow();
            else if (field == Detatched.NAME)
                return new Detatched();
            else if (field == PorkHouse.NAME)
                return new PorkHouse();
            else if (field == Library.NAME)
                return new Library();
            else if (field == SmallTower.NAME)
                return new SmallTower();
            else if (field == Hangar.NAME)
                return new Hangar();
            else if (field == OinkTower.NAME)
                return new OinkTower();
            else if (field == Pigosseum.NAME)
                return new Pigosseum();
            else if (field == ThePorkopolis.NAME)
                return new ThePorkopolis();
            else if (field == Virtualization.NAME)
                return new Virtualization();
            else
                throw new NotImplementedException($"Implement other houses - Missing '{field}'");
        }

        throw new NullReferenceException($"The field 'Name' is missing from jObject {jObject} in {this.GetType().Name}");
    }

    private bool FieldExists(string fieldName, JObject jObject)
    {
        return jObject["Name"] != null;
    }
}
