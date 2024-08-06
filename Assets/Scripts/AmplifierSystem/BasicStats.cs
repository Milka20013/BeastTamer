using System.Linq;

public class BasicStats : Stats<Attribute>
{
    private void Awake()
    {
        var attributes = GetComponent<IStatsInitializer<Attribute>>().GetAttributeSelectors();

        this.attributes.AddRange(attributes);

        amplifierSystem = new(attributes.Select(x => x.attribute), attributes.Select(x => x.value));
    }
}
