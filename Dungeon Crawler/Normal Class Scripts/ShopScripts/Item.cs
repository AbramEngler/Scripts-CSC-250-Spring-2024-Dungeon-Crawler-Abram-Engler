using UnityEngine;

[System.Serializable]
public class Item
{
    public int page;
    public int position;
    public string name;
    public string stat_impacted;
    public int modifier;

    public Item(int page, int position, string name, string stat_impacted, int modifier)
    {
        this.page = page;
        this.position = position;
        this.name = name;
        this.stat_impacted = stat_impacted;
        this.modifier = modifier;
    }

    public void display()
    { 
        Debug.Log($"Name: {this.name}, Stat Impacted: {this.stat_impacted}, Modifier: {this.modifier}");
    }
}

[System.Serializable]
public class RootObject
{
    public Item[] items; //collection of items
}
