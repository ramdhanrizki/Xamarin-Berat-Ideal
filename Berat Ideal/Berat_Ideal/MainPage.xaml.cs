using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Berat_Ideal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnHitungLaki_Clicked(object sender, EventArgs e)
        {
            double berat = System.Convert.ToDouble(txtBeratBadan.Text);
            double tinggi = System.Convert.ToDouble(txtTinggiBadan.Text);
            double nilaiBMI = hitungBMI(tinggi, berat);
            String status = cekStatus("lelaki", nilaiBMI);
            txtBeratBrocha.Text = hitungBrocha("lelaki", tinggi).ToString()+" Kg";
            txtBeratBMI.Text = System.Convert.ToInt32(nilaiBMI).ToString();
            txtKesimpulan.Text = status;
        }

        private void btnHitungPerempuan_Clicked(object sender, EventArgs e)
        {
            double berat = System.Convert.ToDouble(txtBeratBadan.Text);
            double tinggi = System.Convert.ToDouble(txtTinggiBadan.Text);
            Debug.WriteLine("Tinggi Awal : {0}", tinggi);
            double nilaiBMI = hitungBMI(tinggi, berat);
            String status = cekStatus("perempuan", nilaiBMI);
            txtBeratBrocha.Text = hitungBrocha("perempuan", tinggi).ToString()+" Kg";
            txtBeratBMI.Text = System.Convert.ToInt32(nilaiBMI).ToString();
            txtKesimpulan.Text = status;
        }

        private double hitungBrocha(String jenis,double tinggi)
        {
            if (jenis == "lelaki")
            {
                return (tinggi - 100) - (0.1 * (tinggi - 100));
            }
            else
            {
                return (tinggi - 100) - (0.15 * (tinggi - 100));
            }
        }

        private double hitungBMI(double tinggi,double berat)
        {
            Debug.WriteLine("Tinggi Semula : {0}", tinggi);
            Debug.WriteLine("Berat Semula : {0}", berat);

            double tinggi2 = tinggi / 100;
            Debug.WriteLine("Tinggi setelahnya adalah : {0}", tinggi2);
            double bmi = berat / (tinggi2 * tinggi2);
            Debug.WriteLine("Berat BMI {0}", bmi);
            return bmi;
        }

        private String cekStatus(String jenis,double berat)
        {
            switch (jenis)
            {
                case "lelaki":
                    if (berat < 17)
                    {
                        return "Under Weight (BMI <17)";
                    }else if(berat>17 && berat < 24)
                    {
                        return "Normal Weight (BMI 17-23)";
                    }else if(berat>24 && berat < 28)
                    {
                        return "Over Weight (BMI 23-27)";
                    }
                    else
                    {
                        return "Obesitas (BMI >27)";
                    }
                    break;
                case "perempuan":
                    if (berat < 18)
                    {
                        return "Under Weight (BMI <18)";
                    }
                    else if (berat > 18 && berat < 26)
                    {
                        return "Normal Weight (BMI 18-25)";
                    }
                    else if (berat > 25 && berat < 28)
                    {
                        return "Over Weight (BMI 25-27)";
                    }
                    else
                    {
                        return "Obesitas (BMI >27)";
                    }
                    break;
                default:
                    return "";
            }
        }
    }
}
