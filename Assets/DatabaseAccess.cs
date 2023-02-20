using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://pedro:pedrocivis@cluster0.61v0sap.mongodb.net/?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        database = client.GetDatabase("civis");
        collection = database.GetCollection<BsonDocument>("proposicoes");

        var propositionAwaited = collection.Find(new BsonDocument());
        var propositionTest = propositionAwaited.ToList()[0].ToString();

        Debug.Log("testing: " + propositionTest);

        //Test
        var document = new BsonDocument { {"id_API", 999999 } };
        collection.InsertOne(document);
    }

    public async Task<List<string>> GetPropositionsFromDatabase() // Teste para obter proposições do MongoDB
    {
        var allPropositionsTask = collection.FindAsync(new BsonDocument());
        var propositionsAwaited = await allPropositionsTask;

        List<string> propositions = new List<string>();
        foreach (var proposition in propositionsAwaited.ToList())
        {
            propositions.Add(proposition.ToString());
        }

        return propositions;
    }
}
