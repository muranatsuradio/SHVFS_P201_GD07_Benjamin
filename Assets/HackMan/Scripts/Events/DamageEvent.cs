using HackMan.Scripts.Components;

namespace HackMan.Scripts.Events
{
    public class DamageEvent
    {
        public DamagableComponent Damagable { get; }

        public DamageEvent(DamagableComponent damagable)
        {
            this.Damagable = damagable;
        }
    }
}