using System;

namespace WindowsFormsApp3.Entities
{
    public enum Caliber
    {
       cal_9x19mm = 1,
       cal_45_acp = 2,
       cal_545x39mm = 3,
       cal_556x45mm = 4,
       cal_762x51mm = 5,
       cal_12gau = 6
    }

    abstract class Weapon : BaseEntity
    {
        Magazine currentMagazine = null;
        Caliber caliber;

        public Weapon(string name, Caliber caliber) : base(name)
        {
            this.caliber = caliber;
        }

        public Caliber GetCaliber() => caliber;

        public int getCurrentAmmo() => currentMagazine.GetCurrentAmmoCount();
        public int getMaxAmmo() => currentMagazine.GetAmmoCapacity();

        public Magazine Reload(Magazine newMagazine)
        {
            if(currentMagazine == null)
            {
                currentMagazine = newMagazine;
                return null;
            }

            var oldMagazine = currentMagazine;
            currentMagazine = newMagazine;

            return oldMagazine;
        }

        public void Shoot()
        {
            currentMagazine.DecreaseAmmo(1);
        }

        public void RapidFire()
        {

        }
    }
}
