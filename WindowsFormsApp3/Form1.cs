using System.Windows.Forms;
using WindowsFormsApp3.Entities;
using WindowsFormsApp3.Entities.WeaponType;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Player player;

        private void InitUI()
        {
            Weapon weapon = player.GetActiveWeapon();
            this.labelWeaponName.Text = weapon.GetName();
            this.labelCurrentAmmo.Text = weapon.getCurrentAmmo().ToString();
            this.labelMaxAmmoCount.Text = weapon.getMaxAmmo().ToString();

            InitMagazineList();
        }

        private void InitMagazineList()
        {
            this.listBoxMagazine.Items.Clear();
            int index = 1;
            foreach (var item in player.GetMagazines())
            {
                this.listBoxMagazine.Items.Add($"{item.GetName()} {index} - {item.GetCurrentAmmoCount()}/{item.GetAmmoCapacity()}");
                index++;
            }
        }

        private Magazine CreateFullAmmoMagazine(Entities.Caliber cal)
        {
            Magazine mag = new Magazine(cal, 30);
            mag.Reload(30);

            return mag;
        }
        public Form1()
        {
            AssaultRiffle ar15 = new AssaultRiffle("AR-15", Entities.Caliber.cal_556x45mm);
            ar15.Reload(CreateFullAmmoMagazine(ar15.GetCaliber()));

            player = new Player("Тактичний Рекс");
            player.AddWeapon(ar15);

            player.AddMagazine(CreateFullAmmoMagazine(ar15.GetCaliber()));
            player.AddMagazine(CreateFullAmmoMagazine(ar15.GetCaliber()));
            player.AddMagazine(CreateFullAmmoMagazine(ar15.GetCaliber()));

            InitializeComponent();
            InitUI();
        }

        private void buttonShoot_Click(object sender, System.EventArgs e)
        {
            player.GetActiveWeapon().Shoot();
            InitUI();
        }

        private void buttonReload_Click(object sender, System.EventArgs e)
        {
            player.ReloadActiveWeapon();
            InitUI();
        }
    }
}
