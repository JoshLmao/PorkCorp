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
            else if (field == Van.NAME)
                return new Van(vehicleIndex);
            else if (field == Bus.NAME)
                return new Bus(vehicleIndex);
            else if (field == DoubleDecker.NAME)
                return new DoubleDecker(vehicleIndex);
            else if (field == Truck.NAME)
                return new Truck(vehicleIndex);
            else if (field == DoubleSemiTruck.NAME)
                return new DoubleSemiTruck(vehicleIndex);
            else if (field == LevitatingTruck.NAME)
                return new LevitatingTruck(vehicleIndex);
            else if (field == LevitatingDoubleSemi.NAME)
                return new LevitatingDoubleSemi(vehicleIndex);
            else if (field == StackedSemiTruck.NAME)
                return new StackedSemiTruck(vehicleIndex);
            else if (field == DoubleStackedSemi.NAME)
                return new DoubleStackedSemi(vehicleIndex);
            else
                throw new NotImplementedException($"Implement other vehicles - Missing '{field}'");
        }

        throw new NotImplementedException($"The field 'Name' doesn't exist on jObject {jObject} in {this.GetType().Name}");
    }

    private bool FieldExists(string fieldName, JObject jObject)
    {
        return jObject["Name"] != null;
    }
}