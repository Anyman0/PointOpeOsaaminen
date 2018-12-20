using PointOpeOsaaminen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOpeOsaaminen.ViewModel
{
    public class OpettajaOsaaminenViewModel
    {
        //public OpettajaOsaaminen()
        //{
        //    this.Osaamiset = new HashSet<Osaamiset>();
        //}

        //public int? OpettajaID { get; set; }
        //public string Etunimi { get; set; }
        //public string Sukunimi { get; set; }
        //public string Sähköposti { get; set; }
        //public string Henkilönumero { get; set; }
        //public string Yksikkö { get; set; }
        //public string Toimenkuva { get; set; }

        //public string OpeNimi
        //{
        //    get
        //    {
        //        return Etunimi + " " + Sukunimi;
        //    }
        //}
        //public string Nimi { get; set; }
        //public int OsaamisID { get; set; }
        //public string Osaaminen { get; set; }

        //public string Kuvaus { get; set; }


        ////public virtual ICollection<Opettaja> Opettaja { get; set; }


        //public virtual ICollection<OpettajaOsaaminen> Osaamiset { get; set; }

        public int OpettajaID { get; set; }
        public IEnumerable<SelectListItem> OpettajaIDList { get; set; }
        public string Etunimi { get; set; }
        public IEnumerable<SelectListItem> EtunimiList { get; set; }
        public string Sukunimi { get; set; }
        public IEnumerable<SelectListItem> SukunimiList { get; set; }
        public string Sähköposti { get; set; }
        public IEnumerable<SelectListItem> SähköpostiList { get; set; }
        public string Henkilönumero { get; set; }
        public IEnumerable<SelectListItem> HenkilönumeroList { get; set; }
        public string Yksikkö { get; set; }
        public IEnumerable<SelectListItem> YksikköList { get; set; }
        public string Toimenkuva { get; set; }
        public IEnumerable<SelectListItem> ToimenkuvaList { get; set; }
       
        public string OpeNimi
        {
            get
            {
                return Etunimi + " " + Sukunimi;
            }
        }
        public string Nimi { get; set; }
        public int OsaamisID { get; set; }
        public IEnumerable<SelectListItem> OsaamisIDList { get; set; }
        public string OpenOsaaminen { get; set; }
        public IEnumerable<SelectListItem> OpenOsaaminenList { get; set; }

        public string Kuvaus { get; set; }
        public IEnumerable<SelectListItem> KuvausList { get; set; }

        public int OpettajaOsaamisID { get; set; }
        public IEnumerable<SelectListItem> OpettajaOsaamisIDList { get; set; }
        public List<string> OsaamisIDt { get; set; }

        public string OsaamisenKuvaus { get; set; }
        public IEnumerable<SelectListItem> OsaamisenKuvausList { get; set; }


        [Display(Name = "Osaamiset")]
        public MultiSelectList Osaamiset { get; set; }



        public Opettaja OpettajaModelliin { get; set; }
        public List<int> ValitutOsaamiset { get; set; }
        public virtual List<Osaaminen> TamanOpenOsaamiset { get; set; }


        public OpettajaOsaaminenViewModel()
        {

        }

        public OpettajaOsaaminenViewModel(Opettaja _opettaja, List<Osaaminen> _TamanOpenOsaamiset)
        {
            OpettajaModelliin = _opettaja;
            TamanOpenOsaamiset = _TamanOpenOsaamiset; 
            ValitutOsaamiset = new List<int>();
        }





        public OpettajaOsaaminenViewModel OpettajaOsaaminenModelliin { get; set; }
        public List<int> ValitutOsaamisetOpettajaOsaaminen { get; set; }
        public virtual List<Osaaminen> TamanOpenOsaamisetOpettajaOsaaminen { get; set; }

        public OpettajaOsaaminenViewModel(OpettajaOsaaminenViewModel _opettajaOsaaminen, List<Osaaminen> _TamanOpenOsaamisetOpettajaOsaaminen)
        {
            OpettajaOsaaminenModelliin = _opettajaOsaaminen;
            TamanOpenOsaamisetOpettajaOsaaminen = _TamanOpenOsaamisetOpettajaOsaaminen;
            ValitutOsaamisetOpettajaOsaaminen = new List<int>();
        }

        public virtual List<OpettajaOsaaminenViewModel> OpettajaIDjaOsaamisID { get; set; }



        public Osaaminen OsaaminenModelliin { get; set; }
        public List<int> ValitutOpettajat { get; set; }
        public virtual List<Opettaja> TamanOsaamisenOpettajat { get; set; }

        public OpettajaOsaaminenViewModel(Osaaminen _osaaminen, List<Opettaja> _TamanOsaamisenOpettajat)
        {
            OsaaminenModelliin = _osaaminen;
            TamanOsaamisenOpettajat = _TamanOsaamisenOpettajat;
            ValitutOpettajat = new List<int>();
        }





        //public SelectList OsaamisLista { get; set; }


        //public virtual ICollection<Opettaja> Opettaja { get; set; }


        public virtual Opettaja Opettaja { get; set; }

        public virtual Osaaminen Osaaminen { get; set; }
        public virtual OpettajaOsaaminenViewModel OpettajaOsaamiset { get; set; }
    }
}