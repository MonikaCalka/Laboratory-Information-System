﻿using LaboratoryInformationSystem.Enums;
using LaboratoryInformationSystem.IDAO;
using LaboratoryInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratoryInformationSystem.DAO
{
    public class DictionaryDAO : IDictionaryDAO
    { 
        public DictionaryModel ReadDictionaryById(DictionaryTypesEnum type, long? id, string lang)
        {
            if (id != null)
            {
                string query = "";
                switch (type)
                {
                    case DictionaryTypesEnum.Positions:
                        query = $@"
                            select p.IdPosition as Id, t.Name as Name
                            from Positions p
                            join PositionTranslations t on p.IdPosition = t.IdPosition 
                            join Languages l on t.IdLanguage = l.IdLanguage
                            where p.IdPosition = {id} and l.code = '{lang}'
                        ";
                        break;
                    case DictionaryTypesEnum.Ward:
                        query = $@"
                            select p.IdWard as Id, t.Name as Name
                            from Wards p
                            join WardTranslations t on p.IdWard = t.IdWard 
                            join Languages l on t.IdLanguage = l.IdLanguage
                            where p.IdWard = {id} and l.code = '{lang}'
                        ";
                        break;
                    case DictionaryTypesEnum.Priorities:
                        query = $@"
                            select p.IdPriority as Id, t.Name as Name
                            from Priorities p
                            join PriorityTranslations t on p.IdPriority = t.IdPriority
                            join Languages l on t.IdLanguage = l.IdLanguage
                            where p.IdPriority = {id} and l.code = '{lang}'
                        ";
                        break;
                    case DictionaryTypesEnum.Status:
                        query = $@"
                            select p.IdStatus as Id, t.Name as Name
                            from Status p
                            join StatusTranslations t on p.IdStatus = t.IdStatus
                            join Languages l on t.IdLanguage = l.IdLanguage
                            where p.IdStatus = {id} and l.code = '{lang}'
                        ";
                        break;
                }
                DictionaryModel model = BaseDAO.SelectFirst(query, ReadDictionaryModel);
                model.Type = type;
                return model;
            }
            else {
                return null;
            }
        }

        public List<DictionaryModel> ReadDictionaryListByType(DictionaryTypesEnum type, string lang)
        {
            string query = "";
            switch (type)
            {
                case DictionaryTypesEnum.Positions:
                    query = $@"
                        select p.IdPosition as Id, t.Name as Name
                        from Positions p
                        join PositionTranslations t on p.IdPosition = t.IdPosition 
                        join Languages l on t.IdLanguage = l.IdLanguage
                        where l.code = '{lang}'
                    ";
                    break;
                case DictionaryTypesEnum.Ward:
                    query = $@"
                        select p.IdWard as Id, t.Name as Name
                        from Wards p
                        join WardTranslations t on p.IdWard = t.IdWard 
                        join Languages l on t.IdLanguage = l.IdLanguage
                        where l.code = '{lang}'
                    ";
                    break;
                case DictionaryTypesEnum.Priorities:
                    query = $@"
                            select p.IdPriority as Id, t.Name as Name
                            from Priorities p
                            join PriorityTranslations t on p.IdPriority = t.IdPriority
                            join Languages l on t.IdLanguage = l.IdLanguage
                            where l.code = '{lang}'
                        ";
                    break;
                case DictionaryTypesEnum.Status:
                    query = $@"
                            select p.IdStatus as Id, t.Name as Name
                            from Status p
                            join StatusTranslations t on p.IdStatus = t.IdStatus
                            join Languages l on t.IdLanguage = l.IdLanguage
                            where l.code = '{lang}'
                        ";
                    break;
            }
            List <DictionaryModel> list = BaseDAO.Select(query, ReadDictionaryModel);
            foreach (DictionaryModel model in list) {
                model.Type = type;
            }
            return list;
        }

        private DictionaryModel ReadDictionaryModel(CustomReader reader)
        {
            return new DictionaryModel()
            {
                Id = reader.GetLong("Id"),
                Name = reader.GetString("Name")
            };
        }
    }
}