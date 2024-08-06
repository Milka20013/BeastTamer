using System.Collections.Generic;
using System.Linq;

public class AmplifierValues<T> where T : Attribute
{
    public float baseValue;
    public float additiveValue;
    public float additiveMultiplier;
    public float trueMuliplier;

    public AmplifierValues(float baseValue)
    {
        this.baseValue = baseValue;
        Reset();
    }

    public void Reset()
    {
        additiveValue = 0;
        additiveMultiplier = 1;
        trueMuliplier = 1;
    }
    public void RegisterAmplifier(Amplifier<T> amplifier)
    {
        switch (amplifier.amplifierType)
        {
            case AmplifierType.Plus:
                additiveValue += amplifier.value;
                break;
            case AmplifierType.AdditivePercentage:
                additiveMultiplier += amplifier.value / 100;
                break;
            case AmplifierType.TruePercentage:
                trueMuliplier *= 1 + amplifier.value / 100;
                break;
            default:
                break;
        }
    }
    public float GetBuffedValue()
    {
        return (baseValue + additiveValue) * additiveMultiplier * trueMuliplier;
    }
}
public class AmplifierSystem<T> where T : Attribute
{
    private readonly Dictionary<T, AmplifierValues<T>> attributeDatas = new();
    private readonly Dictionary<string, Amplifier<T>> amplifiers = new();

    public AmplifierSystem(IEnumerable<T> attributes, IEnumerable<float> values)
    {
        for (int i = 0; i < attributes.Count(); i++)
        {
            attributeDatas.Add(attributes.ElementAt(i), new(values.ElementAt(i)));
        }
    }

    public void RegisterAmplifiers(Amplifier<T> towerAmplifier)
    {
        amplifiers.TryAdd(towerAmplifier.uniqueTag, towerAmplifier);
        CalculateAmplifierValues(towerAmplifier.attribute);
    }
    public void RegisterAmplifiers(ICollection<Amplifier<T>> towerAmplifiers)
    {
        foreach (var item in towerAmplifiers)
        {
            RegisterAmplifiers(item);
        }
    }

    public void UnRegisterAmplifiers(Amplifier<T> towerAmplifier)
    {
        var result = amplifiers.TryGetValue(towerAmplifier.uniqueTag, out Amplifier<T> _);
        if (result)
        {
            amplifiers.Remove(towerAmplifier.uniqueTag);
            CalculateAmplifierValues(towerAmplifier.attribute);
        }
    }
    public void UnRegisterAmplifiers(ICollection<Amplifier<T>> towerAmplifiers)
    {
        foreach (var item in towerAmplifiers)
        {
            UnRegisterAmplifiers(item);
        }
    }

    private void CalculateAmplifierValues(T attribute)
    {
        attributeDatas[attribute].Reset();
        var amplifiersInContext = amplifiers.Where(x => x.Value.attribute == attribute).Select(x => x.Value);
        foreach (var item in amplifiersInContext)
        {
            attributeDatas[attribute].RegisterAmplifier(item);
        }
    }

    public bool TryGetBuffedAttributeValue(T attribute, out float value)
    {
        if (attributeDatas.TryGetValue(attribute, out AmplifierValues<T> values))
        {
            value = values.GetBuffedValue();
            return true;
        }
        value = -1;
        return false;
    }

}
