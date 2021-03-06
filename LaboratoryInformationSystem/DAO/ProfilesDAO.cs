﻿using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class ProfilesDAO : IProfilesDAO
    {
        public ProfileModel ReadProfileById(long? id, string lang)
        {
            string query = $@"
                select p.IdProfile, p.Code, p.Permament, t.Name as Name
                from Profiles p
                join ProfileTranslations t on p.IdProfile = t.IdProfile
                join Languages l on t.IdLanguage = l.IdLanguage
                where p.IdProfile = {id} and l.code = '{lang}'
            ";

            return BaseDAO.SelectFirst(query, ReadProfileModel);
        }

        public List<ProfileModel> ReadProfilesList(string lang)
        {
            string query = $@"
                select p.IdProfile, p.Code, p.Permament, t.Name as Name
                from Profiles p
                join ProfileTranslations t on p.IdProfile = t.IdProfile
                join Languages l on t.IdLanguage = l.IdLanguage
                where l.code = '{lang}'
            ";

            return BaseDAO.Select(query, ReadProfileModel);
        }
        private ProfileModel ReadProfileModel(CustomReader reader)
        {
            return new ProfileModel()
            {
                IdProfile = reader.GetLong("IdProfile"),
                Code = reader.GetString("Code"),
                Permament = reader.GetBool("Permament"),
                Name = reader.GetString("Name")
            };
        }
    }
}