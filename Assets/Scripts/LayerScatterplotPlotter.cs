using System.Collections;
using System.Collections.Generic;
using IATK;
using UnityEngine;

public class LayerScatterplotPlotter : MonoBehaviour
{
    // Start is called before the first frame update
    public string path_name = "Data/proposicoes_scatter_original";
    void Start()
    {
        LoadPoints(path_name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPoints(string datasetPath)
    {
        TextAsset myDataSource = Resources.Load(datasetPath) as TextAsset;
        CSVDataSource myCSVDataSource;
        myCSVDataSource = createCSVDataSource(myDataSource.text);

        // Create a view builder with the point topology
        ViewBuilder vb = new ViewBuilder(MeshTopology.Points, "IATK Scatterplot").
                             initialiseDataView(myCSVDataSource.DataCount).
                             setDataDimension(myCSVDataSource["x"].Data, ViewBuilder.VIEW_DIMENSION.X).
                             setDataDimension(myCSVDataSource["y"].Data, ViewBuilder.VIEW_DIMENSION.Y).
                             setDataDimension(myCSVDataSource["z"].Data, ViewBuilder.VIEW_DIMENSION.Z).     
                             setColors(getListOfColorsFromListOfHexStrings(myCSVDataSource, "alternativeColorMap"));                    
               

        // Use the "IATKUtil" class to get the corresponding Material mt 
        Material mt = IATKUtil.GetMaterialFromTopology(AbstractVisualisation.GeometryType.Lines);
        mt.SetFloat("_MinSize", 0.25f);
        mt.SetFloat("_MaxSize", 0.25f);

        // Create a view builder with the point topology
        View view = vb.updateView().apply(gameObject, mt);

        //view.transform.localScale += new Vector3(0.1f, 2.0f, 0.1f); // Coloca o scatterplot de frente ao outro

        view.transform.position -= new Vector3(0.5f, 0.5f, 0.5f); // compensating for the fact that natively the center of the view object is the lower left corner of the visualization and not its centroid.
        view.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self); // Coloca o scatterplot de frente ao outro
    }



    // A reusable method to create an IATK CSVDataSource object.
    CSVDataSource createCSVDataSource(string data)
    {
        CSVDataSource dataSource;
        dataSource = gameObject.AddComponent<CSVDataSource>();
        dataSource.load(data, null);
        return dataSource;
    }


    // Improvised function to retrieve data from a column comprising color strings in hex format 
    Color[] getListOfColorsFromListOfHexStrings(CSVDataSource csvds, string colorColumnIdentifier)
    {
        float[] iatk_float_data = csvds[colorColumnIdentifier].Data;
        //float[] iatk_float_data = csvds["z"].Data;
        Color[] newColorList = new Color[iatk_float_data.Length];
        int i = 0;

        foreach (float f in iatk_float_data)
        {            
            Color newCol;
            if (ColorUtility.TryParseHtmlString(csvds.getOriginalValue(f, colorColumnIdentifier).ToString(), out newCol))
            {
                newColorList[i++] = newCol;
            }

           /*if(f == 0){
                
                if (ColorUtility.TryParseHtmlString("#0000FF", out newCol))
                {
                    newColorList[i++] = newCol;
                }
            }
            else{
                if (ColorUtility.TryParseHtmlString("#FF0000", out newCol))
                {
                    newColorList[i++] = newCol;
                }
            }*/
        }

        return newColorList;
    }


}
