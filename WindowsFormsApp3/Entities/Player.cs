using System;
using System.Collections.Generic;

namespace WindowsFormsApp3.Entities
{
    class Player : BaseEntity
    {
        int activeWeaponIndex = -1;

        const int MAX_WEAPON_COUNT = 4;
        const int MAX_MAGAZINE_COUNT = 6;
      
        List<Weapon> weaponSlots = new List<Weapon>();
        List<Magazine> magazines = new List<Magazine>();

        public Player(string name) : base(name)
        {

        }

        public List<Magazine> GetMagazines() => magazines;

        public void ReloadActiveWeapon()
        {
            Weapon activeWeapon = GetActiveWeapon();

            List<Magazine> tmpArray = magazines.FindAll(mag => mag.GetCaliber() == activeWeapon.GetCaliber());
            
            if(tmpArray.Count == 0)
                throw new Exception("Not a magazine by caliber");

            if (tmpArray.Count > 1)
                tmpArray.Sort((m1, m2) => m2.GetCurrentAmmoCount().CompareTo(m1.GetCurrentAmmoCount()));


            var oldMagazine = activeWeapon.Reload(tmpArray[0]);
            this.magazines.RemoveAll(mag => mag.GetId() == tmpArray[0].GetId());

            if (oldMagazine != null)
                this.magazines.Add(oldMagazine);
        }

        public Weapon GetActiveWeapon()
        {
            return weaponSlots[activeWeaponIndex];
        }

        public void ChooseNextWeapon()
        {
            activeWeaponIndex++;

            if (activeWeaponIndex == weaponSlots.Count)
                activeWeaponIndex = 0;
        }

        public void AddWeapon(Weapon weapon)
        {
            if (MAX_WEAPON_COUNT == weaponSlots.Count)
                throw new Exception("Not empty slots");

            weaponSlots.Add(weapon);

            if (weaponSlots.Count == 1)
                activeWeaponIndex = 0;
        }

        public void AddMagazine(Magazine magazine)
        {
            if (MAX_MAGAZINE_COUNT == magazines.Count)
                throw new Exception("Not empty slots");

            magazines.Add(magazine);
        }
    }
}
