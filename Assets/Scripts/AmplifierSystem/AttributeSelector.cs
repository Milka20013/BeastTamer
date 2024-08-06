using System;

[Serializable]
public class AttributeSelector<T> where T : Attribute
{

    public AttributeSelector(AttributeSelector<T> attributeSelector)
    {
        this.attribute = attributeSelector.attribute;
        this.value = attributeSelector.value;
    }
    public T attribute;
    public float value;
}
