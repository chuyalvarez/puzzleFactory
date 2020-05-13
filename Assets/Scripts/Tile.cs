using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
    private Machine content;

    public void SetContent(Machine content)
    {
        this.content = content;
    }

    public Machine GetContent()
    {
        return this.content;
    }


}
