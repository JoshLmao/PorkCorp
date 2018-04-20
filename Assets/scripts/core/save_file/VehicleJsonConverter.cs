using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class VehicleConverter : CustomConverterBase<ISellVehicle>
{
    protected override ISellVehicle Create(Type objectType, JObject jObject)
    {
        if (FieldExists("Name", jObject) && FieldExists("VehicleIndex", jObject))
        {
            string field = (string)jObject["Name"] ;
            int vehicleIndex = (int)jObject["VehicleIndex"];

            if (field == Estate.NAME)
                return new Estate(vehicleIndex);
            else if (field == Truck.NAME)
                return new Truck(vehicleIndex);
            else
                throw new NotImplementedException($"Implement other vehicles - Missing {field}");
        }

        return null;
    }

    private bool FieldExists(string fieldName, JObject jObject)
    {
        return jObject["Name"] != null;
    }
}