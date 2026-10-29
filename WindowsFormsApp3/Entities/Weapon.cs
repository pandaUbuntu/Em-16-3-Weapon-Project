using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp3.Entities
{
    public enum Caliber
    {
        cal_9x19mm = 1,
        cal_45_acp,
        cal_545x39mm,
        cal_556x45mm,
        cal_762x51mm,
        cal_12gau
    }

    public enum FireMode
    {
        Single = 1,
        Auto = 2
    }

    abstract class Weapon : BaseEntity
    {
        protected Magazine currentMagazine = null;
        Caliber caliber;

        readonly FireMode[] availableFireModes;
        FireMode currentFireMode;

        public Weapon(string name, Caliber caliber, FireMode[] availableFireModes) : base(name)
        {
            if (availableFireModes == null || availableFireModes.Length == 0)
                throw new ArgumentException("Weapon must have at least one fire mode");

            this.caliber = caliber;
            this.availableFireModes = availableFireModes;
            this.currentFireMode = availableFireModes[0];
        }

        public Caliber GetCaliber() => caliber;

        public FireMode[] GetAvailableFireModes() => availableFireModes.ToArray();
        public FireMode GetFireMode() => currentFireMode;
        public bool CanSwitchFireMode() => availableFireModes.Length > 1;

        public void SetFireMode(FireMode mode)
        {
            if (!availableFireModes.Contains(mode))
                throw new Exception($"{GetName()} does not support fire mode {mode}");

            currentFireMode = mode;
        }

        public virtual int GetRoundsPerSecond() => 3;

        public int getCurrentAmmo() => currentMagazine == null ? 0 : currentMagazine.GetCurrentAmmoCount();
        public int getMaxAmmo() => currentMagazine == null ? 0 : currentMagazine.GetAmmoCapacity();

        public abstract void Reload(List<Magazine> backpack);

        public bool Shoot()
        {
            if (currentMagazine == null)
                return false;

            return currentMagazine.DecreaseAmmo(1) == 1;
        }
    }
}
