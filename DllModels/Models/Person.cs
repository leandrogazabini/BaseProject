﻿using DllModels.Models.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace DllModels.Models
{


    public class Person : BaseClass
    {
        #region PROPERTIES
        public int PersonId{ get; set; }

        private string _oficialName;
        public string OficialName
        {
            get { return _oficialName; }
            set { SetField(ref _oficialName, value); }
        }

        private string _alternativeName;
        public string AlternativeName
        {
            get { return _alternativeName; }
            set { SetField(ref _alternativeName, value); }
        }

        private string _nickname;
        public string Nickname
        {
            get { return _nickname; }
            set { SetField(ref _nickname, value); }
        }

        private string _mainDocumentNumber;
        public string MainDocumentNumber
        {
            get { return _mainDocumentNumber; }
            set { SetField(ref _mainDocumentNumber, value); }
        }

        private string _alternativeDocumentNumber;
        public string AlternativeDocumentNumber
        {
            get { return _alternativeDocumentNumber; }
            set { SetField(ref _alternativeDocumentNumber, value); }
        }
        #endregion

        #region METHODS
        public Person CreatePerson(string OficialName = null,
                                   string AlternativeName = null,
                                   string Nickname = null,
                                   string MainDocumentNumber = null,
                                   string AlternativeDocumentNumber = null)
        {

            this.OficialName = OficialName;
            this.AlternativeName = AlternativeName;
            this.Nickname = Nickname;
            this.MainDocumentNumber = MainDocumentNumber;
            this.AlternativeDocumentNumber = AlternativeDocumentNumber;
            return this;
        }
        
        #endregion
    }

}

