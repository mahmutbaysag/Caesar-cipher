using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace Sezar_Şifreleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bilgi = textBox1.Text;
            bilgi.ToLower();

            if (textBox1.Text != "" || textBox1.Text != null)
            {
                int i = 0;
                string yedek = "";
                char karakter;
                while (i < bilgi.Length)
                {
                    karakter = bilgi[i];                  
                    yedek += sifrele(bilgi,karakter,i);
                    i++;
                }
                textBox2.Text = yedek;
            }
            else
                MessageBox.Show("Lütfen sifrelenecek veri bilgi giriniz");
        }

        char sifrele(string bilgi,char karakter,int i)
        {
            string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";
            string rakamlar = "0123456789";
            if (!char.IsNumber(karakter) && (!char.IsSymbol(karakter) && !char.IsSurrogate(karakter)))
            {
                if (karakter == 'v' || karakter == 'y' || karakter == 'z')
                {
                    return alfabe[alfabe.IndexOf(bilgi[i]) - 26];
                }
                else if (karakter == ' ')
                {
                    return ' ';
                }
                else
                {
                    return alfabe[alfabe.IndexOf(bilgi[i]) + 3];
                }
            }
            else if(!char.IsSymbol(karakter) && !char.IsSurrogate(karakter))
            {
                if (karakter == '7' || karakter == '8' || karakter == '9')
                {
                    return rakamlar[rakamlar.IndexOf(bilgi[i]) - 7];
                }
                else if (karakter == ' ')
                {
                    return ' ';
                }
                else
                {
                    return rakamlar[rakamlar.IndexOf(bilgi[i]) + 3];
                }
            }
            else
            {
                MessageBox.Show("Lütfen Harfler ve Rakamlardan oluşan bilgiler giriniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //bu kısımda döngüden çıkmaya bak
            }
            return ' ';
        
        }

        char sifreCoz(string bilgi, char karakter, int i)
        {
            string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";
            string rakamlar = "0123456789";
            if (!char.IsNumber(karakter))
            {
                if (karakter == 'a' || karakter == 'b' || karakter == 'c')
                {
                    return alfabe[alfabe.IndexOf(bilgi[i]) + 26];
                }
                else if (karakter == ' ')
                {
                    return ' ';
                }
                else
                {
                    return alfabe[alfabe.IndexOf(bilgi[i]) - 3];
                }
            }
            else
            {
                if (karakter == '0' || karakter == '1' || karakter == '2')
                {
                    return rakamlar[rakamlar.IndexOf(bilgi[i]) + 7];
                }
                else if (karakter == ' ')
                {
                    return ' ';
                }
                else
                {
                    return rakamlar[rakamlar.IndexOf(bilgi[i]) - 3];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || textBox2.Text != null)
            {
                Registry.CurrentUser.SetValue("sezarsifreleme", textBox2.Text);
                MessageBox.Show("Şifreli bilgi başarıyla kaydedildi", "Başarılı");
            }
            else
                MessageBox.Show("Lütfen şifrelenecke bilgi giriniz");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bilgi = Registry.CurrentUser.GetValue("sezarsifreleme").ToString();
            int i = 0;
            string yedek = "";
            char karakter;
            while (i < bilgi.Length)
            {
                karakter = bilgi[i];
                yedek += sifreCoz(bilgi,karakter,i);
                i++;
            }
            MessageBox.Show(yedek,"Başarılı");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string bilgi = textBox3.Text;
            int i = 0;
            string yedek = "";
            char karakter;
            while (i < bilgi.Length)
            {
                karakter = bilgi[i];
                yedek += sifreCoz(bilgi,karakter,i);
                i++;
            }
            MessageBox.Show(yedek, "Başarılı");
        }
    }
}
