[System.Serializable]
public class GeneratorData
{
    private bool isOn { get; set; }
    private float fuel { get; set; }

    public GeneratorData(bool isOn, float fuel)
    {
        this.isOn = isOn;
        this.fuel = fuel;
    }
}
