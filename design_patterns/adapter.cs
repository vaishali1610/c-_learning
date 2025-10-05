using System;

public class LegacyLight
{
    public void SwitchOnOld() => Console.WriteLine("Legacy Light turned ON (old system).");
    public void SwitchOffOld() => Console.WriteLine("Legacy Light turned OFF (old system).");
}
public interface ISmartDevice
{
    void TurnOn();
    void TurnOff();
}
public class LightAdapter : ISmartDevice
{
    private LegacyLight legacyLight;
    public LightAdapter(LegacyLight legacyLight)
    {
        this.legacyLight = legacyLight;
    }
    public void TurnOn() => legacyLight.SwitchOnOld();
    public void TurnOff() => legacyLight.SwitchOffOld();
}
public class Fan : ISmartDevice
{
    public void TurnOn() => Console.WriteLine("Fan turned ON.");
    public void TurnOff() => Console.WriteLine("Fan turned OFF.");
}

public class AirConditioner : ISmartDevice
{
    public void TurnOn() => Console.WriteLine("AC turned ON.");
    public void TurnOff() => Console.WriteLine("AC turned OFF.");
}

public class SmartHomeFacade
{
    private ISmartDevice light;
    private ISmartDevice fan;
    private ISmartDevice ac;
    public SmartHomeFacade(ISmartDevice light, ISmartDevice fan, ISmartDevice ac)
    {
        this.light = light;
        this.fan = fan;
        this.ac = ac;
    }
    public void ActivateEveningMode()
    {
        Console.WriteLine("Activating Evening Mode");
        light.TurnOn();
        fan.TurnOn();
        ac.TurnOn();
    }

    public void DeactivateAll()
    {
        light.TurnOff();
        fan.TurnOff();
        ac.TurnOff();
        Console.WriteLine("All devices off");
    }
}

class Program
{
    static void Main()
    {
        LegacyLight legacyLight = new LegacyLight();
        ISmartDevice adaptedLight = new LightAdapter(legacyLight);
        ISmartDevice fan = new Fan();
        ISmartDevice ac = new AirConditioner();
        SmartHomeFacade home = new SmartHomeFacade(adaptedLight, fan, ac);
        home.ActivateEveningMode();
        Console.WriteLine();
        home.DeactivateAll();
    }
}
