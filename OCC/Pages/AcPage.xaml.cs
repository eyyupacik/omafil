using OCC.Models;

namespace OCC.Pages;

public partial class AcPage : ContentPage
{
	public AcPage()
	{
		InitializeComponent();
        ACModel = new AcModel();
        Money = "$";
    }


    #region Model

    private double _iplikDenyesi;

    public double IplikDenyesi
    {
        get { return _iplikDenyesi; }
        set { _iplikDenyesi = value; OnPropertyChanged(); }
    }

    private double _likraDenyesi;

    public double LikraDenyesi
    {
        get { return _likraDenyesi; }
        set { _likraDenyesi = value; OnPropertyChanged(); }
    }

    private double _cekim;

    public double Cekim
    {
        get { return _cekim; }
        set { _cekim = value; OnPropertyChanged(); }
    }


    private double _makineHiz;

    public double MakineHiz
    {
        get { return _makineHiz; }
        set { _makineHiz = value; OnPropertyChanged(); }
    }


    private double _gozMiktar;

    public double GozMiktar
    {
        get { return _gozMiktar; }
        set { _gozMiktar = value; OnPropertyChanged(); }
    }


    private double _gunlukUretim;

    public double GunlukUretim
    {
        get { return _gunlukUretim; }
        set { _gunlukUretim = value; OnPropertyChanged(); }
    }

    private double _kullanilanIplik;

    public double KullanilanIplik
    {
        get { return _kullanilanIplik; }
        set { _kullanilanIplik = value; OnPropertyChanged(); }
    }

    private double _kullanilanLikra;

    public double KullanilanLikra
    {
        get { return _kullanilanLikra; }
        set { _kullanilanLikra = value; OnPropertyChanged(); }
    }

    private double _birimipFiyat;

    public double BirimIpFiyat
    {
        get { return _birimipFiyat; }
        set { _birimipFiyat = value; OnPropertyChanged(); }
    }

    private double _birimlikraFiyat;

    public double BirimLikraFiyat
    {
        get { return _birimlikraFiyat; }
        set { _birimlikraFiyat = value; OnPropertyChanged(); }
    }

    private double _gmakineMaliyet;

    public double GMakineMaliyet
    {
        get { return _gmakineMaliyet; }
        set { _gmakineMaliyet = value; OnPropertyChanged(); }
    }



    private double _toplam;

    public double Toplam
    {
        get { return _toplam; }
        set { _toplam = value; OnPropertyChanged(); }
    }

    private double _birim;

    public double Birim
    {
        get { return _birim; }
        set { _birim = value; OnPropertyChanged(); }
    }


    private AcModel _acmodel;

    public AcModel ACModel
    {
        get { return _acmodel; }
        set { _acmodel = value; OnPropertyChanged(); }
    }

    private string _money;
    public string Money
    {
        get { return _money; }
        set { _money = value; OnPropertyChanged(); }
    }
    #endregion
    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {

        IplikDenyesi = Convert.ToDouble(ACModel.iplik_denyesi);
        LikraDenyesi = Convert.ToDouble(ACModel.likra_denyesi);
        Cekim = Convert.ToDouble(ACModel.cekim);
        MakineHiz = Convert.ToDouble(ACModel.makina_hiz);
        GozMiktar = Convert.ToDouble(ACModel.kullanilan_goz_miktar);
        BirimIpFiyat = Convert.ToDouble(ACModel.birim_ip_fiyat);
        BirimLikraFiyat = Convert.ToDouble(ACModel.birim_likra_fiyat);
        GMakineMaliyet = Convert.ToDouble(ACModel.gunluk_makine_maliyet);



        if (IplikDenyesi == 0 && LikraDenyesi == 0 && Cekim == 0 && MakineHiz == 0 && GozMiktar == 0 && BirimIpFiyat == 0 && BirimLikraFiyat == 0 && GMakineMaliyet == 0)
        {
            return;
        }
        else
        {
            GunlukUretim = (IplikDenyesi + LikraDenyesi / Cekim) * MakineHiz * 1440 * GozMiktar / 9000 / 1000;
            KullanilanIplik = (IplikDenyesi / (IplikDenyesi + LikraDenyesi / Cekim)) * GunlukUretim;
            KullanilanLikra = GunlukUretim - KullanilanIplik;
            Toplam = (((((MakineHiz) * 60 * 24) / (9000 * 1000) * GozMiktar) * ((LikraDenyesi / Cekim) + IplikDenyesi)) * (100 - ((LikraDenyesi / Cekim) / (LikraDenyesi / Cekim + IplikDenyesi)) * 100) / 100) * BirimIpFiyat + ((GunlukUretim - KullanilanIplik) * BirimLikraFiyat) + GMakineMaliyet;
            Birim = Toplam / GunlukUretim;


        }
    }

    private void Back(object sender, EventArgs e)
    {
        App.Current.MainPage.Navigation.PopAsync();
    }

    private void Change_Money(object sender, EventArgs e)
    {

        if (Money == "$")
        {
            Money = "€";
            return;

        }
        if (Money == "€")
        {
            Money = "₺";
            return;
        }
        if (Money == "₺")
        {
            Money = "$";
            return;
        }

    }

}