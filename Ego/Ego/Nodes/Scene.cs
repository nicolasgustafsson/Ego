using System.Reflection;
using Newtonsoft.Json;

namespace Ego;

public class Scene : Node, IAsset
{
    string Json = "";
    private System.Type Type = null!;
    public void LoadFrom(string aPath)
    {
    }
    
    public void SaveTree(Node aSceneRoot)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.TypeNameHandling = TypeNameHandling.All;
        Json = JsonConvert.SerializeObject(aSceneRoot, aSceneRoot.GetType(), settings);
        
        //Json = Newtonsoft.Json.JsonSerializer.Serialize(aSceneRoot, options);
        Type = aSceneRoot.GetType();
    }
    
    public Node Spawn(Assembly aGameAssembly)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.TypeNameHandling = TypeNameHandling.All;
        JsonConverter converter;
        return (JsonConvert.DeserializeObject(Json, aGameAssembly.GetType(Type.Name), settings) as Node)!; //(JsonSerializer.Deserialize(Json, Type) as Node)!;
    }
}