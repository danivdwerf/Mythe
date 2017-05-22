using UnityEditor;
using UnityEngine;

public class ReadOnlyModelPostProcessor : AssetPostprocessor 
{
    public void OnPreprocessModel()
    {
        ModelImporter importer = assetImporter as ModelImporter;
        if (!importer.isReadable)
            return;
        importer.isReadable = false;
        importer.SaveAndReimport();
    }
}
