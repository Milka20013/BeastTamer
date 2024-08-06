
using System.Collections.Generic;
public interface IStatsInitializer<T> where T : Attribute
{
    public ICollection<AttributeSelector<T>> GetAttributeSelectors();
}
