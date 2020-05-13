using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine
{
    private string storage;
    private int outputDir=3;

    public bool HasItemsToTransport()
    {
        return !storage.Equals("");
    }

    public void setStorage(string item)
    {
        this.storage = item;
    }

    public string getStorage()
    {
        return storage;
    }

    public void setOutputDir(int side)
    {
        this.outputDir = side;
    }

    public int getOutputDir()
    {
        return outputDir;
    }
}
