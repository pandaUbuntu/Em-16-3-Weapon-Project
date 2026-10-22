using System;


namespace WindowsFormsApp3.Entities
{
    class Magazine : BaseEntity
    {
        Caliber caliber;

        int currentAmmoCount = 0;
        int ammoCapacity = 0;

        public Magazine(Caliber caliber, int ammoCapacity, string name = "Unnamed") : base(name)
        {
            this.caliber = caliber;
            this.ammoCapacity = ammoCapacity;
        }

        public Caliber GetCaliber() => caliber;
        public int GetCurrentAmmoCount() => currentAmmoCount;
        public int GetAmmoCapacity() => ammoCapacity;

        public void Reload(int ammoCount)
        {
            //TO DO
            if (ammoCount > ammoCapacity)
                currentAmmoCount = ammoCapacity;
            else
                currentAmmoCount = ammoCount;
        }

        public int DecreaseAmmo(int amount)
        {
            if (currentAmmoCount >= amount)
            {
                currentAmmoCount -= amount;
                return amount;
            }
            else
            {
                int tmp = currentAmmoCount;
                currentAmmoCount = 0;
                return tmp;
            }
        }
    }
}
