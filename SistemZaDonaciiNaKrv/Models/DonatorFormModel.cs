using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemZaDonaciiNaKrv.Models
{
    public class DonatorFormModel
    {
        [Key]
        public int Id { get; set; }
        public string DonorId { get; set; }
        public bool daliOdobreno { get; set; }
        [Display(Name = "Име:")]
        public string Name { get; set; }
        [Display(Name = "Презиме:")]
        public string LastName { get; set; }
        [Display(Name = "Адреса:")]
        public string Address { get; set; }
        [Display(Name = "Телефон:")]
        public string Phone { get; set; }
        [Display(Name = "Е-адреса:")]
        public string Email { get; set; }
        [Display(Name = "Дали денес се чувствувате здрави?")]
        public bool daliDenesSeCuvstvuvateZdravi { get; set; }
        [Display(Name = "Дали денес имате настинка, грип, болно грло, температура, инфекција или алергија?")]
        public bool daliDenesNastinkaGrip { get; set; }
        [Display(Name = "Дали во последните 3 дена сте ги лекувале забите?")]
        public bool daliLekuvaleZabi { get; set; }
        [Display(Name = "Дали во последните 3 месеци сте примиле било каква вакцина или серум?")]
        public bool daliVakcina { get; set; }
        [Display(Name = "Дали во последните 6 месеци сте имале хируршки зафат?")]
        public bool daliOperacija { get; set; }
        [Display(Name = "– операција или некои сериозни медицински испитувања?")]
        public bool daliOperacijaSeriozniMedIspituvanja{ get; set; }
        [Display(Name = "– дупчење или тетоважа на кожата, акупунктура (од неовластено лице)?")]
        public bool daliTetovaza { get; set; }
        [Display(Name = "– случајна повреда (убод) со игла и/или контакт на слузницата со туѓа крв?")]
        public bool daliUbod { get; set; }
        [Display(Name = "– примале трансфузија?")]
        public bool daliTransfuzija { get; set; }
        [Display(Name = "– вакцинација против рабиес (беснило)?")]
        public bool daliBesnilo { get; set; }
        [Display(Name = "– дали сте биле изложени на жолтица (во фамилијата или на работа)?")]
        public bool daliZoltica { get; set; }
        [Display(Name = "Дали сте биле бремени во последната година?")]
        public bool daliBremeni { get; set; }
        [Display(Name = "Дали сте земале лекови кои содржат izotretinoin (Roaccutane), etretinat, (Tegison R), aciretin (Neotigason ), finastridom(Proscar R, Proprecia)?")]
        public bool daliLekovi { get; set; }
        [Display(Name = "Дали сте лекувани со екстракт на човечка хипофиза?")]
        public bool daliHipofiza { get; set; }
        [Display(Name = "Дали сте имале пресадување на тврдата мозочна обвивка?")]
        public bool daliMozocnaObvivka { get; set; }
        [Display(Name = "Дали сте имале пресадување на рожницата на окото?")]
        public bool daliRoznica { get; set; }
        [Display(Name = "жолтица, маларија, туберкулоза, ревматска грозница")]
        public bool daliZolticaMalarija { get; set; }
        [Display(Name = "срцеви болести, висок/ низок крвен притисок")]
        public bool daliSrceviPritisok { get; set; }

        [Display(Name = "алергија, астма")]
        public bool daliAlergjaAstma { get; set; }

        [Display(Name = "грчеви (конвулзии ) или нервни болести")]
        public bool daliGrcevi { get; set; }

        [Display(Name = "хронични болести како: шеќерна болест (инсулин зависна), хроничен бронхит, малигни заболувања или чир на желудникот")]
        public bool daliHronicni { get; set; }
        [Display(Name = "токсоплазмоза")]
        public bool daliToksoPlazmoza { get; set; }
        [Display(Name = "бруцелоза")]
        public bool daliBruceloza { get; set; }

        [Display(Name = "Дали сте доволно информирани во врска со ХИВ/ СИДА, жолтиците Б, Ц?")]
        public bool daliHiv { get; set; }
        [Display(Name = "Дали сте примале/примате дрога во вена?")]
        public bool daliDroga { get; set; }
        [Display(Name = "Дали сте примале/примате пари или дрога за сексуален однос?")]
        public bool daliPariIliDrogaZaSex { get; set; }
        [Display(Name = "Дали имате хемофилија или сте имале сексуален однос со лице кое има хемофилија?")]
        public bool daliHemofilijaSex { get; set; }
        [Display(Name = "Дали до сега сте имале однос со друг маж?")]
        public bool daliOdnosSoDrugMazi { get; set; }
        [Display(Name = "Според Вашето сознание, дали било кој маж со кој сте имале сексуален однос во изминатите 12 месеци имал однос со друг маж?")]
        public bool daliSexSoMazKojImalSexSoDrugMaz { get; set; }
        [Display(Name = "– е ХИВ позитивен или имал жолтица?")]
        public bool daliSexSoHivPozitivenIliZoltica { get; set; }
        [Display(Name = "– венски прима или примал дрога?")]
        public bool daliSexSoPrimatelNaDroga { get; set; }
        [Display(Name = "– примал или прима пари или дрога за сексуален однос ?")]
        public bool daliSexSoPrimatelNaPariIliDrogaZaSex { get; set; }
        [Display(Name = "Дали познавате некој кој имал Creutzfeldt-Jokob-ова болест (кравско лудило или спонгиоформна енцефалопатија ?")]
        public bool daliCreutzfeldtJokob { get; set; }
        [Display(Name = "Дали сте имале некоја полово пренослива болест ?")]
        public bool daliPolovoPrenoslivaBolest { get; set; }



    }
}