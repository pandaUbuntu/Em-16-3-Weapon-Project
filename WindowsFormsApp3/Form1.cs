using System;
using System.Windows.Forms;
using WindowsFormsApp3.Entities;
using WindowsFormsApp3.Entities.WeaponType;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Player player;

        bool isUpdatingUI = false;

        private void InitUI()
        {
            isUpdatingUI = true;

            Weapon weapon = player.GetActiveWeapon();
            this.labelWeaponName.Text = weapon.GetName();
            this.labelCurrentAmmo.Text = weapon.getCurrentAmmo().ToString();
            this.labelMaxAmmoCount.Text = weapon.getMaxAmmo().ToString();

            InitWeaponList();
            InitFireModes(weapon);
            InitMagazineList();

            isUpdatingUI = false;
        }

        private void InitWeaponList()
        {
            this.listBoxWeapons.Items.Clear();
            foreach (var weapon in player.GetWeapons())
            {
                this.listBoxWeapons.Items.Add($"{weapon.GetName()}  {weapon.getCurrentAmmo()}/{weapon.getMaxAmmo()}");
            }
            this.listBoxWeapons.SelectedIndex = player.GetActiveWeaponIndex();
        }

        private void InitFireModes(Weapon weapon)
        {
            RadioButton[] radios = { radioButton1, radioButton2, radioButton3 };
            FireMode[] modes = weapon.GetAvailableFireModes();

            for (int i = 0; i < radios.Length; i++)
            {
                if (i < modes.Length)
                {
                    radios[i].Visible = true;
                    radios[i].Tag = modes[i];
                    radios[i].Text = GetFireModeTitle(modes[i]);
                    radios[i].Checked = (modes[i] == weapon.GetFireMode());
                }
                else
                {
                    radios[i].Visible = false;
                    radios[i].Checked = false;
                }
            }

            this.groupBox1.Enabled = weapon.CanSwitchFireMode();
        }

        private string GetFireModeTitle(FireMode mode)
        {
            switch (mode)
            {
                case FireMode.Single: return "Одиночний";
                case FireMode.Auto: return "Автоматичний";
                default: return mode.ToString();
            }
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

        private Magazine CreateFullAmmoMagazine(Caliber cal, int capacity = 30, string name = "Магазин")
        {
            Magazine mag = new Magazine(cal, capacity, name);
            mag.Reload(capacity);

            return mag;
        }

        public Form1()
        {
            AssaultRiffle ar15 = new AssaultRiffle("AR-15", Caliber.cal_556x45mm);
            ar15.InsertMagazine(CreateFullAmmoMagazine(ar15.GetCaliber(), 30, "Магазин 5.56"));

            Shotgun remington = new Shotgun("Remington 870", Caliber.cal_12gau, 8);

            player = new Player("Тактичний Рекс");
            player.AddWeapon(ar15);
            player.AddWeapon(remington);

            player.AddMagazine(CreateFullAmmoMagazine(ar15.GetCaliber(), 30, "Магазин 5.56"));
            player.AddMagazine(CreateFullAmmoMagazine(ar15.GetCaliber(), 30, "Магазин 5.56"));
            player.AddMagazine(CreateFullAmmoMagazine(ar15.GetCaliber(), 30, "Магазин 5.56"));
            player.AddMagazine(CreateFullAmmoMagazine(remington.GetCaliber(), 24, "Набої 12к"));

            InitializeComponent();
            InitUI();
        }

        // ---------- Стрільба ----------

        private void FireOnce()
        {
            bool shotDone = player.GetActiveWeapon().Shoot();

            if (!shotDone)
                timerAutoFire.Stop(); 

            InitUI();
        }

        private void buttonShoot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Weapon weapon = player.GetActiveWeapon();

            FireOnce();

            if (weapon.GetFireMode() == FireMode.Auto)
            {
                timerAutoFire.Interval = 1000 / weapon.GetRoundsPerSecond();
                timerAutoFire.Start();
            }
        }

        private void buttonShoot_MouseUp(object sender, MouseEventArgs e)
        {
            timerAutoFire.Stop();
        }

        private void timerAutoFire_Tick(object sender, EventArgs e)
        {
            FireOnce();
        }
        private void buttonReload_Click(object sender, EventArgs e)
        {
            try
            {
                player.ReloadActiveWeapon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Перезарядка");
            }

            InitUI();
        }

        private void listBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI || listBoxWeapons.SelectedIndex < 0)
                return;

            timerAutoFire.Stop();
            player.ChooseWeapon(listBoxWeapons.SelectedIndex);
            InitUI();
        }

        private void radioButtonFireMode_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI)
                return;

            RadioButton radio = (RadioButton)sender;
            if (!radio.Checked)
                return;

            player.GetActiveWeapon().SetFireMode((FireMode)radio.Tag);
        }
    }
}
