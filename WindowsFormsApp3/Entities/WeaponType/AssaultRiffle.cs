using System;
using System.Collections.Generic;

namespace WindowsFormsApp3.Entities.WeaponType
{
    class AssaultRiffle : Weapon
    {
        public AssaultRiffle(string name, Caliber caliber)
            : base(name, caliber, new[] { FireMode.Single, FireMode.Auto })
        {
        }

        public Magazine InsertMagazine(Magazine newMagazine)
        {
            var oldMagazine = currentMagazine;
            currentMagazine = newMagazine;
            return oldMagazine;
        }

        public override void Reload(List<Magazine> backpack)
        {
            var suitable = backpack.FindAll(mag => mag.GetCaliber() == GetCaliber());

            if (suitable.Count == 0)
                throw new Exception("Not a magazine by caliber");

            suitable.Sort((m1, m2) => m2.GetCurrentAmmoCount().CompareTo(m1.GetCurrentAmmoCount()));

            Magazine best = suitable[0];
            Magazine oldMagazine = InsertMagazine(best);

            backpack.RemoveAll(mag => mag.GetId() == best.GetId());

            if (oldMagazine != null)
                backpack.Add(oldMagazine);
        }
    }
}
