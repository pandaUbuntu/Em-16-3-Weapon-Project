using System;
using System.Collections.Generic;

namespace WindowsFormsApp3.Entities.WeaponType
{
    class Shotgun : Weapon
    {
        public Shotgun(string name, Caliber caliber, int shellCapacity = 8)
            : base(name, caliber, new[] { FireMode.Single })
        {
            currentMagazine = new Magazine(caliber, shellCapacity, "Труба");
        }

        public override void Reload(List<Magazine> backpack)
        {
            if (currentMagazine.GetCurrentAmmoCount() >= currentMagazine.GetAmmoCapacity())
                return; 

            Magazine shellBox = backpack.Find(mag =>
                mag.GetCaliber() == GetCaliber() && mag.GetCurrentAmmoCount() > 0);

            if (shellBox == null)
                throw new Exception("No shells in backpack");

            shellBox.DecreaseAmmo(1);
            currentMagazine.Reload(currentMagazine.GetCurrentAmmoCount() + 1);
        }
    }
}
