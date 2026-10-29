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

        public List<Weapon> GetWeapons() => weaponSlots;

        public int GetActiveWeaponIndex() => activeWeaponIndex;

        public void ChooseWeapon(int index)
        {
            if (index < 0 || index >= weaponSlots.Count)
                throw new ArgumentOutOfRangeException("index");

            activeWeaponIndex = index;
        }

        public void ReloadActiveWeapon()
        {
            GetActiveWeapon().Reload(magazines);
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
